function carregarJs() {


    $('#formCadastro').submit(function (ev) {

        var model = $('#formCadastro').serialize();

        $('#Valor').val().replace(".", '').replace(",", ".");

        $.ajax({
            url: "/Hamburguer/Salvar",
            type: 'POST',
            data: model,
            dataType: 'JSON',
            success: function (data) {

                if (data.Sucesso === true) {

                    window.alert(data.Mensagem);
                    window.location.href = '/Hamburguer/Index';
                }
                else {
                    window.alert("Ocorreu um erro no cadastro");
                    window.location.href = '/Hamburguer/Index';

                }
            },
            error: function (jqXhr, textStatus, errorThrown) {

            }
        });

        limparCampos();

        ev.preventDefault();
    });


  

    $('#formEditar').submit(function (ev) {

        var model = $('#formEditar').serialize();

        $('#Valor').val().replace(".", '').replace(",", ".");

        $.ajax({
            url: "/Hamburguer/Salvar",
            type: 'POST',
            data: model,
            dataType: 'JSON',
            success: function (data) {

                if (data.Sucesso === true) {

                    window.alert("Editado com Sucesso");
                    window.location.href = '/Hamburguer/Index';
                }
                else {
                    window.alert("Ocorreu um erro no cadastro");
                    window.location.href = '/Hamburguer/Index';
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {

            }
        });

        limparCampos();

        ev.preventDefault();
    });


}


function limparCampos() {
    $("#Nome").val("");
    $("#Ingredientes").val("");
    $("#Valor").val("");
}


function excluirHamburguer(idhamburguer) {    

    if (confirm("Deseja excluir este item?")) {
        $.ajax({
            url: "/Hamburguer/Excluir",
            type: 'POST',
            data: { idhamburguer },
            dataType: 'JSON',
            success: function (data) {
                if (data.Sucesso === true) {
                    window.alert(data.Mensagem);
                    window.location.href = '/Hamburguer/Index';
                } else {
                    window.alert("Ocorreu um erro ao excluir");
                    window.location.href = '/Hamburguer/Index';
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {

            }
        });
    }

    
}


function editarHamburguer(idhamburguer) {    

    $.ajax({
        url: "/Hamburguer/Editar",
        type: 'POST',
        data: { idhamburguer },
        dataType: 'JSON',
        success: function (data) {

            window.location.href = '/Hamburguer/Editar';
        },
        error: function (jqXhr, textStatus, errorThrown) {

        }
    });
}

