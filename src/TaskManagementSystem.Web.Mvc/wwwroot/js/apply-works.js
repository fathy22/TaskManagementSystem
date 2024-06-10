function toggleDependentTaskDiv() {
    debugger;
    var checkbox = document.getElementById('toggleCheckbox');
    var dependentTaskDiv = document.getElementById('dependentTaskDiv');
    if (checkbox.checked) {
        dependentTaskDiv.style.display = 'block';
    } else {
        dependentTaskDiv.style.display = 'none';
    }
}
function toggleDependentTaskDivForEdit() {
    debugger;
    var checkbox = document.getElementById('editToggleCheckbox');
    var dependentTaskDiv = document.getElementById('editDependentTaskDiv');
    if (checkbox.checked) {
        dependentTaskDiv.style.display = 'block';
    } else {
        dependentTaskDiv.style.display = 'none';
    }
}

//function uploadAttachment(files) {
//    debugger;
//    if (files.length === 0) {
//        abp.notify.warn('Please select a file to upload.');
//        return;
//    }

//    var file = files[0];
//    var formData = new FormData();
//    formData.append('file', file);

//    $.ajax({
//        url: 'api/attachment/uploadAttachment',
//        type: 'POST',
//        data: formData,
//        contentType: false,
//        processData: false,
//        success: function (response) {
//            abp.notify.success('File uploaded successfully.');
//        },
//        error: function (error) {
//            abp.notify.error('An error occurred while uploading the file.');
//        }
//    });
//}