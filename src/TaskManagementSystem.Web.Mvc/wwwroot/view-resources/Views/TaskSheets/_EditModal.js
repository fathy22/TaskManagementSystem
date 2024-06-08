(function ($) {
    var _taskSheetService = abp.services.app.taskSheet,
        l = abp.localization.getSource('TaskManagementSystem'),
        _$modal = $('#TaskSheetEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var taskSheet = _$form.serializeFormToObject();

        abp.ui.setBusy(_$form);
        _taskSheetService.update(taskSheet).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('TaskSheet.edited', taskSheet);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
