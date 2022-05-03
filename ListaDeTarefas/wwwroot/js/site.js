// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function Sair() {
    let request = $.ajax({
        url: "/Login/LogOut",
        type: "post",
    });

    request.done(function (response, textStatus, jqXHR) {
        window.location.replace(`/Login`);
    });
}