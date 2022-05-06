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

function limparFeedBack() {
    $('#feedBack').html('');
}

function validacaoEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}