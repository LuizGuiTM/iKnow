
var executando = false;

function makeSyncGetRequest(url, headers) {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", url, false); // Configurando a solicitação para ser síncrona
    //xhr.setRequestHeader("Content-Type", "application/json");

    // Definindo os cabeçalhos personalizados
    if (headers) {
        for (var header in headers) {
            xhr.setRequestHeader(header, headers[header]);
        }
    }

    xhr.send();
    if (xhr.status === 200) {
        //console.log("Resposta:", xhr.responseText);
        return JSON.parse(xhr.responseText); // Convertendo a resposta em JSON
    } else {
        throw new Error("Erro na solicitação: " + xhr.status);
    }
}

// Uso do método makeSyncGetRequest
var helix = "http://3.129.210.114";
var link = helix + ":1026/v2/entities/";

var headershelix = {
    Accept: "application/json",
    "fiware-service": "helixiot",
    "fiware-servicepath": "/"
};


function pegaqrcode() {
    try {
        var response = makeSyncGetRequest(link, headershelix)[0].qrcode.value;
        return response;
        //console.log(response);
    } catch (error) {
        console.error(error);
    }
}

function enviaqrcode(opera) {
    if (executando) {
        return;
    }
    try {
        executando = true;
        var result;
        var qrcode = "";
        //console.log(opera);
        function loop() {
            qrcode = pegaqrcode();
            if (qrcode === "")
                console.log("vazio");
            else
                console.log(qrcode);
            //qrcode = result[0].qrcode.value;
            if (qrcode === "") {
                setTimeout(loop, 2000); // Espera 2 segundos antes de chamar o loop novamente
            } else {
                apagaqrcode();
                var operacao = $("#operacao").val();
                var api = "/Loja/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
                $.ajax({
                    url: api,
                    success: function (response) {
                        if (opera === "usuario") {
                            var url = response.url;
                            //console.log("Dados enviados para o método usuario");
                            if (response.compraViewModel) {
                                console.log("Entrou NO COMPRA");
                                var compraViewModelJson = encodeURIComponent(JSON.stringify(response.compraViewModel));
                                window.location.href = url + "?compraViewModel=" + compraViewModelJson;
                            } else if (response.mensagem) {
                                var mensagem = response.mensagem;
                                window.location.href = url + "?mensagem=" + encodeURIComponent(mensagem);
                            } else {
                                window.location.href = url;
                            }
                        } else {
                            console.log("Entrou aqui");
                            $("#listacarrinho").html(response);
                        }
                        //console.log("Dados enviados para o método");
                        //console.log("false");
                        executando = false; // Define executando como false aqui
                        if (opera !== "usuario") {
                            //console.log("enviaqrcode")
                            enviaqrcode(opera); // Chama enviaqrcode() novamente após definir executando como false
                        }
                    }
                });
            }
        }
        loop(); // Chama o loop pela primeira vez
    } catch (error) {
        executando = false;
        console.error(error);
    }
}

/*
function enviaqrcode(opera) {
    if (executando) {
        return;
    }
    try {
        executando = true;
        var result;
        var qrcode = "";
        //console.log(opera);
        function loop() {
            qrcode = pegaqrcode();
            if (qrcode === "")
                console.log("vazio");
            else
                console.log(qrcode);
            //qrcode = result[0].qrcode.value;
            if (qrcode === "") {
                setTimeout(loop, 2000); // Espera 2 segundos antes de chamar o loop novamente
            } else {
                return;
            }
        }
        loop(); // Chama o loop pela primeira vez
    } catch (error) {
        executando = false;
        console.error(error);
    }
}
*/
function apagaqrcode() {
    //console.log("Entrei na função apagarqrcode")
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
            //console.log("QR Code apagado");
        }
    })
}

function deleteProduto(id) {
    if (confirm('Deseja confirma a exclusão?'))
        location.href = '/produto/delete?id=' + id;
}

function deleteCliente(id) {
    if (confirm('Deseja confirma a exclusão?'))
        location.href = '/cliente/delete?id=' + id;
}

function deleteFuncionario(id) {
    if (confirm('Deseja confirma a exclusão?'))
        location.href = '/funcionario/delete?id=' + id;
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
    var api = "/Loja/CarrinhoView";
    $.ajax({
        url: api,
            success: function(dados) {
                console.log("Renderizando o Carrinho")
                document.getElementById('listacarrinho').innerHTML = dados;
            }
    })
}

function cancelacompra() {
    deleteCarrinho()
    var mensagem = "Faça login novamente.";
    location.href = '/Loja/IndexComMensagem?mensagem=' + mensagem;
}

function deleteCarrinho() {
    if (confirm('Deseja confirma a exclusão?')) {
        var api = "/Loja/RemoveCarrinho";
        $.ajax({
            url: api,
            success: function (dados) {
                console.log("Carrinho apagado.");
            }
        })
    }
}


function aplicaFiltroConsultaAvancada() {
    var vNome = document.getElementById('nome').value;
    var vCategoria = document.getElementById('categoria').value;
    var vPrecoInicial = document.getElementById('precoInicial').value;
    var vPrecoFinal = document.getElementById('precoFinal').value;

    $.ajax({
        url: "/produto/ObtemDadosConsultaAvancada",
        data: { nome: vNome, categoria: vCategoria, precoInicial: vPrecoInicial, precoFinal: vPrecoFinal },
        success: function (dados) {
            if (dados.erro != undefined) {
                alert(dados.msg);
            }
            else {
                document.getElementById('resultadoConsulta').innerHTML = dados;
            }
        },
    });

}
