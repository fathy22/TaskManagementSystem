(function ($) {
    var _taskSheetService = abp.services.app.taskSheets,
        l = abp.localization.getSource('TaskManagementSystem'),
        _$modal = $('#TaskSheetCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#TaskSheetsTable');

    var _$taskSheetsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _taskSheetService.getAll,
            inputFilter: function () {
                return $('#TaskSheetsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$taskSheetsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'title',
                sortable: false
            },
            {
                targets: 2,
                data: 'description',
                sortable: false
            },
            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-taskSheet" data-taskSheet-id="${row.id}" data-toggle="modal" data-target="#TaskSheetEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-taskSheet" data-taskSheet-id="${row.id}" data-taskSheet-title="${row.title}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
       debugger;
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var taskSheet = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _taskSheetService
            .create(taskSheet)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$taskSheetsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-taskSheet', function () {
      
        var taskSheetId = $(this).attr("data-taskSheet-id");
        var taskSheetTitle = $(this).attr('data-taskSheet-title');

        deleteTaskSheet(taskSheetId, taskSheetTitle);
    });

    $(document).on('click', '.edit-taskSheet', function (e) {
        var taskSheetId = $(this).attr("data-taskSheet-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'TaskSheets/EditModal?taskId=' + taskSheetId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#TaskSheetEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        })
    });

    abp.event.on('taskSheet.edited', (data) => {
        _$taskSheetsTable.ajax.reload();
    });

    function deleteTaskSheet(taskSheetId, taskSheetTitle) {
      
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                taskSheetTitle),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _taskSheetService.delete({
                        id: taskSheetId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$taskSheetsTable.ajax.reload();
                    });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$taskSheetsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$taskSheetsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);

