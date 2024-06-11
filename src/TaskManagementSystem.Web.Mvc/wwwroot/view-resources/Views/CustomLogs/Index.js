(function ($) {
  
    var _logService = abp.services.app.customLog,
        l = abp.localization.getSource('TaskManagementSystem'),
        _$table = $('#LogsTable');

    var _$logsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _logService.getAllCustomLogs,
            inputFilter: function () {
                return $('#LogsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$logsTable.draw(false)
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
                data: 'description',
                sortable: false
            },
            {
                targets: 2,
                data: 'creationTime',
                sortable: false
            }
        ]
    });

    $('.btn-search').on('click', (e) => {
        _$logsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$logsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
