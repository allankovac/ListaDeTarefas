function AjaxLogin() {

    let email = $('#UserName').val();
    let senha = $('#Password').val();
    let validacao = validacaoCamposLogin(email, senha);

    if (validacao) {

        loading(true);

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
                <div class="alert alert-danger alert-dismissible fade show d-flex" role="alert">
                    <span class="col-md-1 text-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-exclamation-triangle-fill" viewBox="0 0 20 20">
                            <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                        </svg>
                    </span>
                    <span class="col-md-10">
                        ${retorno.mensagemRetorno}
                    </span>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>`);
            }
            else if (retorno.statusRetorno === "sucesso") {
                window.location.replace(`/Tarefa/ListarTarefasFinalizadas`);
            }
            loading(false);
        });
    }
}

function AjaxRegistro() {

    loading(true);

    let obj = {
        "Usuario.Nome": $('#Nome').val(),
        "Usuario.SobreNome": $('#SobreNome').val(),
        "Usuario.Email": $('#Email').val(),
        "Password": $('#Password').val(),
        "valido": false
    };

    obj = validarFormularioCadastro(obj);

    if (obj.valido) {
        let request = $.ajax({
            url: "/login/RegistrarUsuario",
            data: obj,
            type: "post",
        });

        request.done(function (response, textStatus, jqXHR) {
            let retorno = response.retorno;

            if (retorno.statusRetorno === "erro") {
                $('#feedBack').html(`
                    <div class="alert alert-danger alert-dismissible fade show d-flex" role="alert">
                        <span class="col-md-1 text-center">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-exclamation-triangle-fill" viewBox="0 0 20 20">
                                <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                            </svg>
                        </span>
                        <span class="col-md-10">
                            ${retorno.mensagemRetorno}
                        </span>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);
            }
            else if (retorno.statusRetorno === "sucesso") {
                $('#feedBack').html(`
                    <div class="alert alert-success alert-dismissible fade show d-flex" role="alert">
                        <span class="col-md-1 text-center">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-check-circle-fill" viewBox="0 0 20 20">
                              <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z"/>
                            </svg>
                        </span>
                        <span class="col-md-10">
                            Cadastrado com sucesso! Retornando ao login...
                        </span>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);

                setTimeout(() => window.location.replace(`/Login/Login`), 6000);
            }
            loading(false);
        });
    } else {
        loading(false);
    }
}

function validarFormularioCadastro(obj) {

    let form = $('.formularioCadastro')[0];

    form.classList.add('was-validated');

    if (obj["Usuario.Email"]) {
        if (validacaoEmail(obj["Usuario.Email"])) {
            obj.valido = true;
        } else {
            $('#email.invalid-feedback').html(`Email fora do padrão aceitável.`);
        }
    } else {
        $('#email.invalid-feedback').html(`Email não informado.`);
    }

    if (!obj.Password) {
        obj.valido = false;
        $('#senha.invalid-feedback').html(`Senha não informada.`);
    }
    if (!obj["Usuario.Nome"]) {
        obj.valido = false;
        $('#nome.invalid-feedback').html(`Nome não informado.`);
    }
    if (!obj["Usuario.SobreNome"]) {
        obj.valido = false;
        $('#sobrenome.invalid-feedback').html(`Sobrenome não informado.`);
    }

    return obj;
}

function validacaoCamposLogin(email, senha) {

    let validacao = true;
    let form = $('.formularioLogin')[0];

    form.classList.add('was-validated');

    if (email) {
        if (!validacaoEmail(email)) {
            $('#email.invalid-feedback').html(`Email fora do padrão aceitável.`);
            validacao = false;
        }
    } else {
        $('#email.invalid-feedback').html(`Email não informado.`);
        validacao = false;
    }

    if (!senha) {
        $('#senha.invalid-feedback').html(`Senha não informada.`);
        validacao = false;
    }

    if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
    }

    return validacao;
}