$(document).ready(() => {
    //showTarefas('Nao-Finalizadas')
});

function showTarefas(tarefa) {
    $(`#${tarefa}`).addClass('active');

    if (tarefa === 'Nao-Finalizadas') {
        $(`#Finalizadas`).removeClass('active');
        $(`#Tarefas-Finalizadas`).hide();
    }
    else {
        $(`#Nao-Finalizadas`).removeClass('active');
        $(`#Tarefas-Nao-Finalizadas`).hide();
    }

    $(`#Tarefas-${tarefa}`).show();
}

function AjaxRestaurarTarefa(id) {
    let request = $.ajax({
        url: "/tarefa/RestaurarTarefa",
        data: {
            id: id
        },
        type: "post",
    });

    request.done(function (response, textStatus, jqXHR) {
        if (response.status === "sucesso") {
            alert(response.mensagem);

            window.location.replace(`/tarefa/ListarTarefasDashBoard/`);
        }
    });
}
