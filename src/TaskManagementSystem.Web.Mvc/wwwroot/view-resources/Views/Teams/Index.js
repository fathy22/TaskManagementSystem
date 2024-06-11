(function ($) {
  
    var _teamService = abp.services.app.team,
        l = abp.localization.getSource('TaskManagementSystem'),
        _$modal = $('#TeamCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#TeamsTable');

    var _$teamsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _teamService.getAll,
            inputFilter: function () {
                return $('#TeamsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$teamsTable.draw(false)
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
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-team" data-team-id="${row.id}" data-toggle="modal" data-target="#TeamEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-team" data-team-id="${row.id}" data-team-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
      
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var team = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _teamService
            .create(team)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$teamsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-team', function () {
        var teamId = $(this).attr("data-team-id");
        var teamName = $(this).attr('data-team-name');

        deleteTeam(teamId, teamName);
    });

    $(document).on('click', '.edit-team', function (e) {
      
        var teamId = $(this).attr("data-team-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Teams/EditModal?teamId=' + teamId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#TeamEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        })
    });

    abp.event.on('team.edited', (data) => {
        _$teamsTable.ajax.reload();
    });

    function deleteTeam(teamId, teamName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                teamName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _teamService.delete({
                        id: teamId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$teamsTable.ajax.reload();
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
        _$teamsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$teamsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
