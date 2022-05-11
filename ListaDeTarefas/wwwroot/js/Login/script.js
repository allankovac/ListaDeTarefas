function AjaxLogin() {

    let email = $('#UserName').val();
    let senha = $('#Password').val();

    let validacao = validacaoCamposLogin(email, senha);

    if (validacao) {
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
                window.location.replace(`/Tarefa/ListarTarefasFinalizadas`);
            } 
        });
    }
}


function AjaxRegistro() {
    let obj = {
        "Usuario.Nome": $('#Nome').val(),
        "Usuario.SobreNome": $('#SobreNome').val(),
        "Usuario.Email": $('#Email').val(),
        "Password": $('#Password').val(),
        "valido": false
    };

   // limparFeedBack();

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
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-info-circle-fill" viewBox="0 0 16 16">
                              <path d="M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16zm.93-9.412-1 4.705c-.07.34.029.533.304.533.194 0 .487-.07.686-.246l-.088.416c-.287.346-.92.598-1.465.598-.703 0-1.002-.422-.808-1.319l.738-3.468c.064-.293.006-.399-.287-.47l-.451-.081.082-.381 2.29-.287zM8 5.5a1 1 0 1 1 0-2 1 1 0 0 1 0 2z"/>
                            </svg>
                        </span>
                        <span class="col-md-10">
                            ${retorno.mensagemRetorno}
                        </span>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);

                window.location.replace(`/Login/Login`);
            }
        });
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