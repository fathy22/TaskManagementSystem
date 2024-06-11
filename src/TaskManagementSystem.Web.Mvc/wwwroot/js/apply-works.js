(function ($) {
    debugger;
    const uploadButton = document.getElementById('uploadButton');
    if (uploadButton) {
        uploadButton.addEventListener('click', () => {
            const fileInput = document.getElementById('fileInput');
            if (fileInput) {
                fileInput.click();
            }
        });
    }

    const fileInput = document.getElementById('fileInput');
    if (fileInput) {
        fileInput.addEventListener('change', () => {
            const file = fileInput.files[0];
            if (file) {
                uploadAttachment(file);
            }
        });
    }
    function uploadAttachment(file) {

        const formData = new FormData();
        formData.append('file', file);
        var url = abp.appPath + 'api/services/app/attachment/UploadAttachment';

        abp.ajax({
            url: url,
            type: 'POST',
            processData: false,
            contentType: false,
            data: formData,
            success: function (result) {
                document.getElementById('attachmentId').value = result;
                document.getElementById('uploadedFileName').textContent = file.name;
                abp.notify.info('File uploaded successfully.');
            },
            error: function (error) {
                abp.notify.error('File upload failed.');
            }
        });
    }
})(jQuery);
function toggleDependentTaskDiv() {
  
    var checkbox = document.getElementById('toggleCheckbox');
    var dependentTaskDiv = document.getElementById('dependentTaskDiv');
    if (checkbox.checked) {
        dependentTaskDiv.style.display = 'block';
    } else {
        dependentTaskDiv.style.display = 'none';
    }
}
function toggleDependentTaskDivForEdit() {
  
    var checkbox = document.getElementById('editToggleCheckbox');
    var dependentTaskDiv = document.getElementById('editDependentTaskDiv');
    if (checkbox.checked) {
        dependentTaskDiv.style.display = 'block';
    } else {
        dependentTaskDiv.style.display = 'none';
    }
}
