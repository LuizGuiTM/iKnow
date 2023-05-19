/*
function pegaqrcode() {
    console.log("Entrei na função pegarqrcode")
    var api = "http://3.129.210.114:1026/v2/entities/";
    var result
    $.ajax({
        type: 'GET',
        url: api,
        headers:
            {
        "Accept": "application/json",
        "fiware-service": "helixiot",
        "fiware-servicepath": "/",
        },
        success: function (dados) {
            console.log(JSON.stringify(dados))
            console.log(dados[0].qrcode.value)
            result = dados;
        }
    })
    return result;
}

function enviaqrcode() {
    var qrcode = pegaqrcode()[0].qrcode.value;
    if (qrcode != "") { }
    var operacao = $("#operacao").val();
    var api = "/Home/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
    $.ajax({
        url: api,
        success: function () {
            console.log("Dados enviados para o método")
            apagaqrcode();
        }
    })
}

*/
function deleteProduto(id) {
    if (confirm('Deseja confirma a exclusão?'))
        location.href = '/produto/delete?id=' + id;
}
function pegaqrcode() {
    console.log("Entrei na função pegarqrcode");
    var api = "http://3.129.210.114:1026/v2/entities/";

    return new Promise(function (resolve, reject) {
        $.ajax({
            type: 'GET',
            url: api,
            headers: {
                "Accept": "application/json",
                "fiware-service": "helixiot",
                "fiware-servicepath": "/",
            },
            success: function (dados) {
                console.log(JSON.stringify(dados));
                console.log(dados[0].qrcode.value);
                resolve(dados);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

async function enviaqrcode() {
    try {
        var result = await pegaqrcode();
        var qrcode = result[0].qrcode.value;
        if (qrcode !== "") {
            var operacao = $("#operacao").val();
            var api = "/Home/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
            $.ajax({
                url: api,
                success: function () {
                    console.log("Dados enviados para o método");
                    apagaqrcode();
                }
            });
        }
    } catch (error) {
        console.error(error);
    }
}


function apagaqrcode() {
    console.log("Entrei na função apagarqrcode")
    var api = "http://3.129.210.114:1026/v2/entities/urn:ngsi-ld:entity:esp_iknow/attrs";
    var data = "{\"qrcode\": {\"type\": \"text\",\"value\": \"\"}}";
    $.ajax({
        type: 'POST',
        url: api,
        dataType: 'json',
        data: data,
        headers:
        {
            "Content-Type": "application/json",
            "fiware-service": "helixiot",
            "fiware-servicepath": "/",
        },
        success: function (dados) {
            console.log("QR Code apagado");
        }
    })
}

function post(entidade) {
    console.log("Entrei na função apagarqrcode")
    var api = "http://3.129.210.114:1026/v2/entities/" + entidade + "/attrs";
    var data = "{\"qrcode\": {\"type\": \"text\",\"value\": \"on\"}}";
    $.ajax({
        type: 'POST',
        url: api,
        dataType: 'json',
        data: data,
        headers:
        {
            "Content-Type": "application/json",
            "fiware-service": "helixiot",
            "fiware-servicepath": "/",
        },
        success: function (dados) {
            console.log("Postado");
        }
    })
}

function alteraestado(estado) {
    console.log("Entrei na função alteraestado")
    var api = "http://3.129.210.114:1026/v2/entities/urn:ngsi-ld:entity:esp_iknow/attrs";
    var data = "{\"estado\": {\"type\": \"text\",\"value\": \"" + estado + "\"}}";
    $.ajax({
        type: 'POST',
        url: api,
        dataType: 'json',
        data: data,
        headers:
        {
            "Content-Type": "application/json",
            "fiware-service": "helixiot",
            "fiware-servicepath": "/",
        },
        success: function (dados) {
            console.log("Estado:" , estado , "\n Enviado para o Helix.");
        }
    })
}


function rendercarrinho() {
    var api = "/Home/CarrinhoView";
    $.ajax({
        url: api,
            success: function(dados) {
                console.log("Renderizando o Carrinho")
                document.getElementById('listacarrinho').innerHTML = dados;
            }
    })
}

function cancelacompra() {
    var api = "/Home/RemoveCarrinho";
    $.ajax({
        url: api,
        success: function (dados) {
            console.log("Carrinho apagado.");
        }
    })
}
