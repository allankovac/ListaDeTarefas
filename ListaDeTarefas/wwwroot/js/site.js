// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function Sair() {
    let request = $.ajax({
        url: "/Login/LogOut",
        type: "post",
    });

    request.done(function (response, textStatus, jqXHR) {
        window.location.replace(`/Login`);
    });
}

function validacaoEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

function loading(load) {
    if (load) {
        $('.loading').addClass('ativo');
        $('.loading.ativo').html(`
        <div class="spin-load">
            <div class="d-flex justify-content-center">
                <div class="spinner-border text-info" role="status"></div>
            </div>
         </div>
        `);
    } else {
        $('.loading').removeClass('ativo');
    }
}