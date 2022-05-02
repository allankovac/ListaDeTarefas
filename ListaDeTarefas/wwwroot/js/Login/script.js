function RetornaObjetoDoFormulario() {
    let objeto = {};

    $('#formularioLogin div input').each((i, z) => {
        objeto[z.name] = z.value;
    });

    return objeto;
}

function AjaxLogin() {
    let data = RetornaObjetoDoFormulario();

    let request = $.ajax({
        url: "/login/Login",
        data: data,
        type: "post",
    });

    request.done(function (response, textStatus, jqXHR) {
        if (response.usuario > 0) {
            let data = sessionStorage.getItem('sessao');
            if (data == null) {
                sessionStorage.setItem('sessao', response.sessao);

                window.location.replace(`/tarefa/ListarTarefas/${response.usuario}`);
            }
        }
    });
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