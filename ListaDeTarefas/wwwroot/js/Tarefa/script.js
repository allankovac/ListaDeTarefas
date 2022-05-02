
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

            window.location.replace(`/tarefa/ListarTarefas/`);
        }
    });
}
