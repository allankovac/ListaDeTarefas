function AjaxLogin() {
    let email = $('#UserName').val();
    let senha = $('#Password').val();

    let valido = false;

    if (email) {
        if (validacaoEmail(email)) {
            valido = true;
        } else {
            $('#feedBack').html(`
                <div class="alert alert-danger alert-dismissible fade show" role="alert">
                    Email fora do padrão aceitavel.
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>`);
        }
    } else {
        $('#feedBack').html(`
                <div class="alert alert-danger alert-dismissible fade show" role="alert">
                    Email precisa ser preenchido.
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>`);
    }


    if (!senha) {
        $('#feedBack').append(`
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        Senha precisa ser preenchido.
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);
        valido = false;
    }

    if (valido) {
        let request = $.ajax({
            url: "/login/Login",
            data: {
                "UserName": email,
                "Password": senha
            },
            type: "post",
        });

        request.done(function (response, textStatus, jqXHR) {
            let retorno = response.retorno;

            if (retorno.statusRetorno === "erro") {
                $('#feedBack').html(`
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        ${retorno.mensagemRetorno}
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);
            }
            else if (retorno.statusRetorno === "sucesso") {
                $('#feedBack').html(`
                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                        ${retorno.mensagemRetorno}
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);

                window.location.replace(`/Tarefa/ListarTarefas`);
            }
        });
        //<div class="alert alert-success" role="alert">
        //    A simple success alert—check it out!
        //</div>
    }
}


function AjaxRegistro() {
    let data = RetornaObjetoDoFormulario();
    console.log(data);
    let request = $.ajax({
        url: "/login/RegistrarUsuario",
        data: data,
        type: "post",
    });

    request.done(function (response, textStatus, jqXHR) {
        window.location.replace(`/tarefa/ListarTarefas/`);
    });
}


