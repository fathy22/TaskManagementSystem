(function () {
document.addEventListener('DOMContentLoaded', function () {
    const fileInput = document.getElementById('fileInput');
    const uploadButton = document.getElementById('uploadButton');

    uploadButton.addEventListener('click', function () {
        fileInput.click();
    });

    fileInput.addEventListener('change', function () {
        debugger;
        const files = fileInput.files;
        if (files.length > 0) {
            const file = files[0];
            uploadAttachment(file);
        }
    });
});
})();
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

function uploadAttachment(file) {
    debugger;

    fetch('api/attachment/uploadAttachment', {
        method: 'POST',
        body: file
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Server responded with error: ' + response.status + ' ' + response.statusText);
            }
            const contentType = response.headers.get('content-type');
            if (contentType && contentType.includes('application/json')) {
                return response.json();
            } else {
                throw new Error('Response was not JSON');
            }
        })
        .then(data => {
            console.log('Upload response:', data);
            // Handle upload response
        })
        .catch(error => {
            debugger;
            console.error('Error uploading file:', error);
            // Handle upload error
        });
}