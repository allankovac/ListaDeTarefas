$(document).ready(function () {
    let data = sessionStorage.getItem('sessao');

    if (data != null) {
        let request = $.ajax({
            url: "/sessao/ValidarSessao",
            data: {
                id: data
            },
            type: "post",
        });

        request.done(function (response, textStatus, jqXHR) {
            if (!response.valido) {
                window.location.replace(`/login`);
            }
        });
    }
    else {
        window.location.replace(`/login`);
    }

});

function RetornaObjetoDoFormulario() {
    let objeto = {};

    $('#formularioTarefa div input').each((i, z) => {
        objeto[z.name] = z.value;
    });

    return objeto;
}

function AjaxRegistrarTarefas() {
    let data = RetornaObjetoDoFormulario();

    let request = $.ajax({
        url: "/tarefa/CriarTarefa",
        data: data,
        type: "post",
    });

    request.done(function (response, textStatus, jqXHR) {
        if (response.status === "sucesso") {
            alert(response.mensagem);

            window.location.replace(`/tarefa/CriarTarefa/${$("#UsuarioId").value}`);
        }
    });
}
