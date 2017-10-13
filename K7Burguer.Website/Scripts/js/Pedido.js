function carregarJs() {

    document.getElementById("QtdHamburguer").disabled = true
    document.getElementById("QtdBatata").disabled = true
    document.getElementById("QtdBebida").disabled = true

    $('#CodHamburguer').on('change', function () {
        if (this.value !== "") {
            document.getElementById("QtdHamburguer").disabled = false
            document.getElementById("QtdHamburguer").value = 1
        } else {
            document.getElementById("QtdHamburguer").value = ""
            document.getElementById("QtdHamburguer").disabled = true
        }
    })

    $('#CodBatata').on('change', function () {
        if (this.value !== "") {
            document.getElementById("QtdBatata").disabled = false
            document.getElementById("QtdBatata").value = 1
        } else {
            document.getElementById("QtdBatata").value = ""
            document.getElementById("QtdBatata").disabled = true
        }
    })

    $('#CodBebida').on('change', function () {
        if (this.value !== "") {
            document.getElementById("QtdBebida").disabled = false
            document.getElementById("QtdBebida").value = 1
        } else {
            document.getElementById("QtdBebida").value = ""
            document.getElementById("QtdBebida").disabled = true
        }
    })





    $('#formPedido').submit(function (ev) {

        var model = $('#formPedido').serialize();

        $.ajax({
            url: "/Pedido/Salvar",
            type: 'POST',
            data: model,
            dataType: 'JSON',
            success: function (data) {

                if (data.Sucesso === true) {

                    window.alert(data.Mensagem);
                    window.location.href = '/Home/Index';
                }
                else {
                    window.alert(data.Mensagem);
                    window.location.href = '/Pedido/Index';

                }
            },
            error: function (jqXhr, textStatus, errorThrown) {

            }
        });

        ev.preventDefault();
    });
}

function somenteNumeros(num) {
    var er = /[^0-9.]/;
    er.lastIndex = 0;
    var campo = num;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}