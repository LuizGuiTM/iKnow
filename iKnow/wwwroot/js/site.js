function pegaqrcode() {
    console.log("Entrei na função pegarqrcode")
    var api = "http://3.129.210.114:1026/v2/entities/";
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
            document.getElementById("qrcode").value = dados[0].qrcode.value;
            apagaqrcode();
        }
    })
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

function enviaqrcode(qrcode) {
    if (qrcode != "") {
        var operacao = (string)ViewBag.Erro;
        url: "/Home/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
        success: function(dados) {
            console.log("Dados enviados para o método")
        }
    }
}