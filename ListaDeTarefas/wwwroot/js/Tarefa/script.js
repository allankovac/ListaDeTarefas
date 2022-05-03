
function RetornaObjetoDoFormulario() {
    let objeto = {};

    $('#formularioTarefa div input').each((i, z) => {
        objeto[z.name] = z.value;
    });

    return objeto;
}

function AjaxRegistrarTarefas() {
    let data = RetornaObjetoDoFormulario();

    console.log(data);
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

function AjaxFinalizarTarefa(id) {
    let request = $.ajax({
        url: "/tarefa/FinalizarTarefa",
        data: {
            id: id
        },
        type: "post",
    });

    request.done(function (response, textStatus, jqXHR) {
        if (response.status === "sucesso") {
            alert(response.mensagem);

            window.location.replace(`/tarefa/ListarTarefas/`);
        }
    });
}

function AjaxFinalizarTarefaEmMassa() {
    var listaIdTarefa = [];
    $("#table-tarefa input[type='hidden']").each((i, z) => {
        if ($(`#finalizar-${z.value}`).is(":checked")) {
            listaIdTarefa.push(z.value)
        }
    });

    let request = $.ajax({
        url: "/tarefa/FinalizarTarefaEmMassa",
        data: {
            listaId: listaIdTarefa
        },
        type: "post",
    });

    request.done(function (response, textStatus, jqXHR) {
        if (response.status === "sucesso") {
            alert(response.mensagem);

            window.location.replace(`/tarefa/ListarTarefas/`);
        }
    });
}
