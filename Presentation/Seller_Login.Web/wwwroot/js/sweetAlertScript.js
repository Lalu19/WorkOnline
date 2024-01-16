// sweetAlertScript.js
document.addEventListener('DOMContentLoaded', function () {
    // Attach a submit event listener to the form
    var form = document.querySelector('form');
    if (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault(); // Prevent the default form submission

            var updateSuccessMessage = 'Succesfully Updated';
            var errorMessage = 'Unexpected Error';

            if (updateSuccessMessage) {
                Swal.fire({
                    icon: 'success',
                    title: 'Update Successful',
                    text: updateSuccessMessage,
                }).then(function () {
                    form.submit(); // Continue with the form submission after the SweetAlert
                });
            } else if (errorMessage) {
                Swal.fire({
                    icon: 'error',
                    title: 'Unexpected Error',
                    text: errorMessage,
                });
            }
        });
    }
});
