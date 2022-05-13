// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function Sair() {
    let request = $.ajax({
        url: "/Login/LogOut",
        type: "post",
    });

    request.done(function (response, textStatus, jqXHR) {
        window.location.replace(`/Login`);
    });
}

function validacaoEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

function loading(load) {
    if (load) {
        $('.loading').addClass('ativo');
        $('.loading.ativo').html(`
        <div class="spin-load">
            <div class="d-flex justify-content-center">
                <div class="spinner-border text-info" role="status"></div>
            </div>
         </div>
        `);
    } else {
        $('.loading').removeClass('ativo');
    }
}

function modalConfirmacao(func, nome, id = '') {
    
    var obj = mensagemModal(nome);
    console.log(id);
    if (obj.ativo) {
        $('.modal-confirmacao').addClass('ativo');
        $('.modal-confirmacao.ativo').html(`
            <div class="modal" tabindex = "-1" role = "dialog" >
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">${obj.titulo}</h5>
                        </div>
                        <div class="modal-body">
                            <p>${obj.texto}</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" id="confirma">Confirmar</button>
                            <button type="button" class="btn btn-secondary" data-dismiss="modal" id="cancela">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
        `);
    } else {
        alert("Um erro inesperado ocorreu. Tente novamente depois.");
    }
    $("button#confirma")[0].addEventListener("click", function () { func(id) });
    $("button#cancela")[0].addEventListener("click", function () { $('.modal-confirmacao').removeClass('ativo').html(''); });
}

function mensagemModal(nome) {
    let obj = {};
  
    if (nome == "AjaxFinalizarTarefaEmMassa") {
        obj.titulo = "Finalizar Tarefa"; obj.texto = "Deseja mesmo finalizar a(s) tarefa(s)?"; obj.ativo = true;
    } else if (nome == "AjaxFinalizarTarefa") {
        obj.titulo = "Finalizar Tarefa"; obj.texto = "Deseja mesmo finalizar a tarefa?"; obj.ativo = true;
    } else if (nome = "AjaxRegistrarTarefas") {
        obj.titulo = "Adicionar Tarefa"; obj.texto = "Confirma adicionar nova tarefa?"; obj.ativo = true;
    } else if (nome = "AjaxRestaurarTarefa") {
        obj.titulo = "Restaurar Tarefa"; obj.texto = "Confirma restauração da tarefa?"; obj.ativo = true;
    }
    return obj;
}