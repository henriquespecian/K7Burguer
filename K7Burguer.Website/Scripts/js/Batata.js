function carregarJs() {

    $('#formCadastro').submit(function (ev) {

        var model = $('#formCadastro').serialize();

        $('#Valor').val().replace(".", '').replace(",", ".");

        $.ajax({
            url: "/Batata/Salvar",
            type: 'POST',
            data: model,
            dataType: 'JSON',
            success: function (data) {

                if (data.Sucesso === true) {

                    window.alert(data.Mensagem);
                    window.location.href = '/Batata/Index';
                }
                else {
                    window.alert("Ocorreu um erro no cadastro");
                    window.location.href = '/Batata/Index';

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
            url: "/Batata/Salvar",
            type: 'POST',
            data: model,
            dataType: 'JSON',
            success: function (data) {

                if (data.Sucesso === true) {

                    window.alert("Editado com Sucesso");
                    window.location.href = '/Batata/Index';
                }
                else {
                    window.alert("Ocorreu um erro no cadastro");
                    window.location.href = '/Batata/Index';
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

function excluirBatata(idBatata) {

    if (confirm("Deseja excluir este item?")) {
        $.ajax({
            url: "/Batata/Excluir",
            type: 'POST',
            data: { idBatata },
            dataType: 'JSON',
            success: function (data) {
                if (data.Sucesso == true) {
                    window.alert(data.Mensagem);
                    window.location.href = '/Batata/Index';
                } else {
                    window.alert("Ocorreu um erro ao excluir");
                    window.location.href = '/Batata/Index';
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {

            }
        });
    }


}


function editarBatata(idBatata) {

    $.ajax({
        url: "/Batata/Editar",
        type: 'POST',
        data: { idBatata },
        dataType: 'JSON',
        success: function (data) {

            window.location.href = '/Batata/Editar';
        },
        error: function (jqXhr, textStatus, errorThrown) {

        }
    });
}

