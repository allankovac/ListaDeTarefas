$(document).ready(() => {
    $("#DtTarefaFim").datepicker({
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
    });
});

function AjaxRegistrarTarefas() {
    var obj = {
        'Tarefa.Titulo': $("#Titulo").val(),
        'Tarefa.Descricao': $("#Descricao").val(),
        'Data': $("#DtTarefaFim").val()
    };

    let request = $.ajax({
        url: "/tarefa/CriarTarefa",
        data: obj,
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
