// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function updateStatus(id) {
    var url = '/Jobs/UpdateStatus';

    $.ajax({
        method: 'POST',
        url: url,
        data: { id: id },
        success: function () { },
        error: function (error) {

        }
    });
}