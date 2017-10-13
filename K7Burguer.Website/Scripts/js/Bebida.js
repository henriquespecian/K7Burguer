function carregarJs() {

    $('#formCadastro').submit(function (ev) {

        var model = $('#formCadastro').serialize();

        $('#Valor').val().replace(".", '').replace(",", ".");

        $.ajax({
            url: "/Bebida/Salvar",
            type: 'POST',
            data: model,
            dataType: 'JSON',
            success: function (data) {

                if (data.Sucesso === true) {

                    window.alert(data.Mensagem);
                    window.location.href = '/Bebida/Index';
                }
                else {
                    window.alert("Ocorreu um erro no cadastro");
                    window.location.href = '/Bebida/Index';

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
            url: "/Bebida/Salvar",
            type: 'POST',
            data: model,
            dataType: 'JSON',
            success: function (data) {

                if (data.Sucesso === true) {

                    window.alert("Editado com Sucesso");
                    window.location.href = '/Bebida/Index';
                }
                else {
                    window.alert("Ocorreu um erro no cadastro");
                    window.location.href = '/Bebida/Index';
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

function excluirBebida(idBebida) {

    if (confirm("Deseja excluir este item?")) {
        $.ajax({
            url: "/Bebida/Excluir",
            type: 'POST',
            data: { idBebida },
            dataType: 'JSON',
            success: function (data) {
                if (data.Sucesso == true) {
                    window.alert(data.Mensagem);
                    window.location.href = '/Bebida/Index';
                } else {
                    window.alert("Ocorreu um erro ao excluir");
                    window.location.href = '/Bebida/Index';
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {

            }
        });
    }


}


function editarBebida(idBebida) {

    $.ajax({
        url: "/Bebida/Editar",
        type: 'POST',
        data: { idBebida },
        dataType: 'JSON',
        success: function (data) {

            window.location.href = '/Bebida/Editar';
        },
        error: function (jqXhr, textStatus, errorThrown) {

        }
    });
}

