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

    limparFeedBack();

    if (ValidarFormularioDeCriacaoDeTarefa(obj)) {
        let request = $.ajax({
            url: "/tarefa/CriarTarefa",
            data: obj,
            type: "post",
        });

        request.done(function (response, textStatus, jqXHR) {
            if (response.status === "sucesso") {
                $('#feedBack').html(`
                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                        ${response.mensagem}
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);
                window.location.replace(`/tarefa/AdicionarTarefas/`);
            } else {
                $('#feedBack').append(`
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        ${response.mensagem}
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);
            }

        });
    }
    
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

            window.location.replace(`/tarefa/AdicionarTarefas/`);
        }
    });
}

function AjaxFinalizarTarefaEmMassa() {
    var listaIdTarefa = [];
    $("input[type='hidden']").each((i, z) => {
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

            window.location.replace(`/tarefa/AdicionarTarefas/`);
        }
    });
}


function ValidarFormularioDeCriacaoDeTarefa(obj) {
    if (!obj['Tarefa.Titulo']) {
        $('#feedBack').append(`
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        Campo obrigatório não preenchido.
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);
        return false;
    }
    else if (!obj.Data) {
        $('#feedBack').append(`
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        Campo obrigatório não preenchido.
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`);

        return false;
    }

    return true; 
}