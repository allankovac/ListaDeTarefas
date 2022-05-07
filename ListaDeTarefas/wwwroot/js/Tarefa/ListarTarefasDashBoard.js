$(document).ready(() => {
    showTarefas('Nao-Finalizadas')
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