// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('[data-toggle="popover"]').popover();

    $('#customFile').on('change', function () {
        //get the file name
        var fileName = $(this).get(0).files.item(0).name;
        //replace the "Choose a file" label
        $(this).next('.custom-file-label').html(fileName);
    })
});

