﻿/*
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

async function enviaqrcodecompra() {
    try {
        var result = await pegaqrcode();
        var qrcode = result[0].qrcode.value;
        var operacao = $("#operacao").val();
        var api = "/Loja/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
        $.ajax({
            url: api,
            success: function (response) {
                console.log("Dados enviados para o método");
                apagaqrcode();
                $("#listacarrinho").html(response);
            }
        }
        );
    } catch (error) {
        console.error(error);
    }
}

function processarRespostaUsuario(response) {
    var url = response.url;
    console.log("Dados enviados para o método");
    if (response.compraViewModel) {
        var compraViewModelJson = encodeURIComponent(JSON.stringify(response.compraViewModel));
        window.location.href = url + "?compraViewModel=" + compraViewModelJson;
    } else if (response.mensagem) {
        var mensagem = response.mensagem;
        window.location.href = url + "?mensagem=" + encodeURIComponent(mensagem);
    } else {
        window.location.href = url;
    }
}

function processarRespostaCompra(response) {
    console.log("Dados enviados para o método");
    $("#listacarrinho").html(response);
    enviaqrcode("compra", "");
}

async function enviaqrcode(operacao, lastQrcode) {
    try {
        var opera = operacao;

        // Função para processar a resposta e redirecionar


        // Função para verificar se o QR Code mudou
        async function verificarQrcode() {
            var result = await pegaqrcode();
            var qrcode = result[0].qrcode.value;
            if (lastQrcode === null) {
                lastQrcode = qrcode; // Atualizar o valor do lastQrcode com o valor inicial do qrcode
                return false; // Indica que a variável não mudou
            }
            if (qrcode !== lastQrcode) {
                lastQrcode = qrcode; // Atualizar o valor do lastQrcode
                return true; // Indica que a variável mudou
            }
            return false; // Indica que a variável não mudou
        }

        // Loop principal (Long Polling)
        while (true) {
            var hasChanged = await verificarQrcode();
            if (hasChanged) {
                var operacao = $("#operacao").val();
                var api = "/Loja/ValidaQRCode?qrcode=" + lastQrcode + "&Operacao=" + operacao;

                $.ajax({
                    url: api,
                    success: function (resposta) {
                        if (opera == "usuario")
                            processarRespostaUsuario(resposta);
                        else
                            processarRespostaCompra(resposta);
                    },
                    async: false // Desativar o modo assíncrono para garantir o comportamento de Long Polling
                });

                break;
            }

            await new Promise(resolve => setTimeout(resolve, 1000)); // Aguardar 1 segundo antes de fazer a próxima verificação
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
                apagaqrcode();
                resolve(dados);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

var enviaqrcodeExecutando = false; // Variável de controle

function enviaqrcodecheck(tipo) {
    if (!enviaqrcodeExecutando) {
        enviaqrcodeExecutando = true;
        enviaqrcode(tipo, "");
    }
}

function processarRespostaCompra(response) {
    console.log("Dados enviados para o método");
    $("#listacarrinho").html(response);
    enviaqrcodecheck("compra");
}

function processarRespostaUsuario(response) {
    var url = response.url;
    console.log("Dados enviados para o método usuario");
    if (response.compraViewModel) {
        var compraViewModelJson = encodeURIComponent(JSON.stringify(response.compraViewModel));
        window.location.href = url + "?compraViewModel=" + compraViewModelJson;
    } else if (response.mensagem) {
        var mensagem = response.mensagem;
        window.location.href = url + "?mensagem=" + encodeURIComponent(mensagem);
    } else {
        window.location.href = url;
    }
}

function enviaqrcode(opera, lastQrcode) {
    return new Promise(async (resolve, reject) => {
        try {
            async function verificarQrcode() {
                var result = await pegaqrcode();
                var qrcode = result[0].qrcode.value;
                if (lastQrcode === null) {
                    lastQrcode = qrcode;
                    return false;
                }
                if (qrcode !== lastQrcode) {
                    lastQrcode = qrcode;
                    return true;
                }
                return false;
            }

            while (true) {
                var hasChanged = await verificarQrcode();
                if (hasChanged) {
                    var operacao = $("#operacao").val();
                    var api = "/Loja/ValidaQRCode?qrcode=" + lastQrcode + "&Operacao=" + operacao;

                    await new Promise(resolveAjax => {
                        $.ajax({
                            url: api,
                            success: function (resposta) {
                                if (opera == "usuario")
                                    processarRespostaUsuario(resposta);
                                else
                                    processarRespostaCompra(resposta);

                                apagaqrcode(); // Chama a função apagaqrcode() após o sucesso da chamada AJAX
                                resolveAjax(); // Resolve a promessa após o sucesso da chamada AJAX
                            },
                            async: false
                        });
                    });

                    console.log("enviaqrcodeExecutando = false;")
                    enviaqrcodeExecutando = false;
                    resolve();
                    break;
                }

                await new Promise(resolveTimeout => setTimeout(resolveTimeout, 1000));
            }
        } catch (error) {
            enviaqrcodeExecutando = false;
            console.error(error);
            reject(error);
        }
    });
}

async function apagaqrcode() {
    console.log("Entrei na função apagarqrcode");
    var api = "http://3.129.210.114:1026/v2/entities/urn:ngsi-ld:entity:esp_iknow/attrs";
    var data = "{\"qrcode\": {\"type\": \"text\",\"value\": \"\"}}";

    $.ajax({
        type: 'POST',
        url: api,
        dataType: 'json',
        data: data,
        headers: {
            "Content-Type": "application/json",
            "fiware-service": "helixiot",
            "fiware-servicepath": "/",
        },
        success: function (dados) {
            console.log("QR Code apagado");
        },
        error: function (error) {
            console.error(error);
        }
    });
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

async function enviaqrcode(opera) {
    if (executando) {
        return;
    }

    try {
        executando = true;
        var result;
        var qrcode = "";
        //console.log(opera);
        while (qrcode === "") {
            result = await pegaqrcode();
            qrcode = result[0].qrcode.value;
            if (qrcode === "") {
                await new Promise(resolve => setTimeout(resolve, 2000)); // Espera 2 segundos antes de fazer a próxima requisição
            }
        }
        apagaqrcode();
        await new Promise(resolve => setTimeout(resolve, 3000));
        var operacao = $("#operacao").val();
        var api = "/Loja/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
        $.ajax({
            url: api,
            success: async function (response) {
                if (opera === "usuario") {
                    var url = response.url;
                    //console.log("Dados enviados para o método usuario");
                    if (response.compraViewModel) {
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
                apagaqrcode();
                //console.log("false");
                executando = false; // Set executando to false here
                if (opera !== "usuario") {
                    //console.log("enviaqrcode")
                    //enviaqrcode(opera); // Call enviaqrcode() after setting executando to false
                }
            }
        });
    } catch (error) {
        executando = false;
        console.error(error);
    }
}

function pegaqrcodeasync() {
    //console.log("Entrei na função pegarqrcode");
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
                //console.log(JSON.stringify(dados));
                var result = dados[0].qrcode.value;
                if(result != null)
                console.log(result);
                resolve(dados);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

*/

var executando = false;


/*
function pegaqrcode() {
    var helix = "http://3.129.210.114";
    var api = helix + ":1026/v2/entities/";
    var xhr = new XMLHttpRequest();
    xhr.open('GET', api, false); // false indica que a chamada é síncrona
    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("fiware-service", "helixiot");
    xhr.setRequestHeader("fiware-servicepath", "/");

    xhr.send();

    if (xhr.status === 200) {
        var dados = JSON.parse(xhr.responseText);
        var result = dados[0].qrcode.value;
        if (result != null) {
            console.log(result);
        }
        return dados;
    } else {
        throw new Error('Erro na requisição: ' + xhr.status);
    }
}

*/

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

/*
async function enviaqrcode() {
try {
var result = await pegaqrcode();
var qrcode = result[0].qrcode.value;
if (qrcode !== "") {
var operacao = $("#operacao").val();
var api = "/Loja/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
$.ajax({
url: api,
success: function (response) {
    var url = response.url;
    console.log("Dados enviados para o método");
    apagaqrcode();
    if (response.compraViewModel) {
        // Se o objeto CompraViewModel estiver presente, codificar como um parâmetro em formato JSON
        var compraViewModelJson = encodeURIComponent(JSON.stringify(response.compraViewModel));

        // Redirecionar para a view com o parâmetro CompraViewModel
        window.location.href = url + "?compraViewModel=" + compraViewModelJson;
    }
    else if (response.mensagem) {
        var url = response.url;
        var mensagem = response.mensagem;
        window.location.href = url + "?mensagem=" + encodeURIComponent(mensagem);
    }
    else {
        // Redirecionar para a view sem o parâmetro CompraViewModel
        window.location.href = url;
    }
}
});
}
} catch (error) {
console.error(error);
}
}

async function enviaqrcodecompra() {
try {
var result = await pegaqrcode();
var qrcode = result[0].qrcode.value;
if (qrcode !== "") {
var operacao = $("#operacao").val();
var api = "/Loja/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
$.ajax({
url: api,
success: function (response) {
    console.log("Dados enviados para o método");
    apagaqrcode();
    $("#listacarrinho").html(response);
    }
}
);
}
} catch (error) {
console.error(error);
}
}

async function enviaqrcode() {
try {
var result = await pegaqrcode();
var qrcode = result[0].qrcode.value;
var operacao = $("#operacao").val();
var api = "/Loja/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
$.ajax({
url: api,
success: function (response) {
var url = response.url;
console.log("Dados enviados para o método");
apagaqrcode();
if (response.compraViewModel) {
    // Se o objeto CompraViewModel estiver presente, codificar como um parâmetro em formato JSON
    var compraViewModelJson = encodeURIComponent(JSON.stringify(response.compraViewModel));

    // Redirecionar para a view com o parâmetro CompraViewModel
    window.location.href = url + "?compraViewModel=" + compraViewModelJson;
}
else if (response.mensagem) {
    var url = response.url;
    var mensagem = response.mensagem;
    window.location.href = url + "?mensagem=" + encodeURIComponent(mensagem);
}
else {
    // Redirecionar para a view sem o parâmetro CompraViewModel
    window.location.href = url;
}
}
});
} catch (error) {
console.error(error);
}
}

async function enviaqrcode(operacao) {
try {
var opera = operacao;
var lastQrcode = null; // Armazena o valor anterior do qrcode

// Função para processar a resposta e redirecionar
function processarRespostaUsuario(response) {
var url = response.url;
console.log("Dados enviados para o método");
apagaqrcode();
if (response.compraViewModel) {
var compraViewModelJson = encodeURIComponent(JSON.stringify(response.compraViewModel));
window.location.href = url + "?compraViewModel=" + compraViewModelJson;
} else if (response.mensagem) {
var mensagem = response.mensagem;
window.location.href = url + "?mensagem=" + encodeURIComponent(mensagem);
} else {
window.location.href = url;
}
}

function processarRespostaCompra(response) {
console.log("Dados enviados para o método");
apagaqrcode();
$("#listacarrinho").html(response);
}

// Função para verificar se o QR Code mudou
async function verificarQrcode() {
var result = await pegaqrcode();
var qrcode = result[0].qrcode.value;
if (lastQrcode === null) {
lastQrcode = qrcode; // Atualizar o valor do lastQrcode com o valor inicial do qrcode
return false; // Indica que a variável não mudou
}
if (qrcode !== lastQrcode) {
lastQrcode = qrcode; // Atualizar o valor do lastQrcode
return true; // Indica que a variável mudou
}
return false; // Indica que a variável não mudou
}

// Loop principal (Long Polling)
while (true) {
var hasChanged = await verificarQrcode();
if (hasChanged) {
var operacao = $("#operacao").val();
var api = "/Loja/ValidaQRCode?qrcode=" + lastQrcode + "&Operacao=" + operacao;

$.ajax({
    url: api,
    success: processarResposta,
    async: false // Desativar o modo assíncrono para garantir o comportamento de Long Polling
});

break;
}

await new Promise(resolve => setTimeout(resolve, 1000)); // Aguardar 1 segundo antes de fazer a próxima verificação
}
} catch (error) {
console.error(error);
}
}

async function enviaqrcodecompra() {
try {
var result = await pegaqrcode();
var qrcode = result[0].qrcode.value;
var operacao = $("#operacao").val();
var api = "/Loja/ValidaQRCode?qrcode=" + qrcode + "&Operacao=" + operacao;
$.ajax({
url: api,
success: function (response) {
console.log("Dados enviados para o método");
apagaqrcode();
$("#listacarrinho").html(response);
}
}
);
} catch (error) {
console.error(error);
}
}

async function enviaqrcode(operacao) {
try {
var opera = operacao;
var lastQrcode = null; // Armazena o valor anterior do qrcode

// Função para processar a resposta e redirecionar
function processarRespostaUsuario(response) {
var url = response.url;
console.log("Dados enviados para o método");
apagaqrcode();
if (response.compraViewModel) {
var compraViewModelJson = encodeURIComponent(JSON.stringify(response.compraViewModel));
window.location.href = url + "?compraViewModel=" + compraViewModelJson;
} else if (response.mensagem) {
var mensagem = response.mensagem;
window.location.href = url + "?mensagem=" + encodeURIComponent(mensagem);
} else {
window.location.href = url;
}
}

function processarRespostaCompra(response) {
console.log("Dados enviados para o método");
apagaqrcode();
$("#listacarrinho").html(response);
enviaqrcode("compra");
}

// Função para verificar se o QR Code mudou
async function verificarQrcode() {
var result = await pegaqrcode();
var qrcode = result[0].qrcode.value;
if (lastQrcode === null) {
lastQrcode = qrcode; // Atualizar o valor do lastQrcode com o valor inicial do qrcode
return false; // Indica que a variável não mudou
}
if (qrcode !== lastQrcode) {
lastQrcode = qrcode; // Atualizar o valor do lastQrcode
return true; // Indica que a variável mudou
}
return false; // Indica que a variável não mudou
}

// Loop principal (Long Polling)
while (true) {
var hasChanged = await verificarQrcode();
if (hasChanged) {
var operacao = $("#operacao").val();
var api = "/Loja/ValidaQRCode?qrcode=" + lastQrcode + "&Operacao=" + operacao;

$.ajax({
    url: api,
    success: function (resposta) {
        if (opera == "usuario")
            processarRespostaUsuario(resposta);
        else
            processarRespostaCompra(resposta);
    },
    async: false // Desativar o modo assíncrono para garantir o comportamento de Long Polling
});

break;
}

await new Promise(resolve => setTimeout(resolve, 1000)); // Aguardar 1 segundo antes de fazer a próxima verificação
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

async function enviaqrcode(operacao) {
    try {
        var opera = operacao;
        var lastQrcode = null; // Armazena o valor anterior do qrcode

        // Função para processar a resposta e redirecionar
        function processarRespostaUsuario(response) {
            var url = response.url;
            console.log("Dados enviados para o método");
            apagaqrcode();
            if (response.compraViewModel) {
                var compraViewModelJson = encodeURIComponent(JSON.stringify(response.compraViewModel));
                window.location.href = url + "?compraViewModel=" + compraViewModelJson;
            } else if (response.mensagem) {
                var mensagem = response.mensagem;
                window.location.href = url + "?mensagem=" + encodeURIComponent(mensagem);
            } else {
                window.location.href = url;
            }
        }

        function processarRespostaCompra(response) {
            console.log("Dados enviados para o método");
            apagaqrcode();
            $("#listacarrinho").html(response);
            verificaEResponde();
        }

        // Função para verificar se o QR Code mudou
        async function verificarQrcode() {
            var result = await pegaqrcode();
            var qrcode = result[0].qrcode.value;
            if (lastQrcode === null) {
                lastQrcode = qrcode; // Atualizar o valor do lastQrcode com o valor inicial do qrcode
                return false; // Indica que a variável não mudou
            }
            if (qrcode !== lastQrcode) {
                lastQrcode = qrcode; // Atualizar o valor do lastQrcode
                return true; // Indica que a variável mudou
            }
            return false; // Indica que a variável não mudou
        }

        // Função para verificar o QR Code e processar a resposta
        async function verificaEResponde() {
            var hasChanged = await verificarQrcode();
            if (hasChanged) {
                var operacao = $("#operacao").val();
                var api = "/Loja/ValidaQRCode?qrcode=" + lastQrcode + "&Operacao=" + operacao;

                $.ajax({
                    url: api,
                    success: function (resposta) {
                        if (opera == "usuario")
                            processarRespostaUsuario(resposta);
                        else
                            processarRespostaCompra(resposta);
                    },
                    async: false // Desativar o modo assíncrono para garantir o comportamento de Long Polling
                });
            }
        }

        // Loop principal (Long Polling)
        while (true) {
            await verificaEResponde();
            await new Promise(resolve => setTimeout(resolve, 1000)); // Aguardar 1 segundo antes de fazer a próxima verificação
        }
    } catch (error) {
        console.error(error);
    }
}


async function apagaqrcode() {
    console.log("Entrei na função apagarqrcode");
    var api = "http://3.129.210.114:1026/v2/entities/urn:ngsi-ld:entity:esp_iknow/attrs";
    var data = "{\"qrcode\": {\"type\": \"text\",\"value\": \"\"}}";
    try {
        await $.ajax({
            type: 'POST',
            url: api,
            dataType: 'json',
            data: data,
            headers: {
                "Content-Type": "application/json",
                "fiware-service": "helixiot",
                "fiware-servicepath": "/",
            },
        });
        console.log("QR Code apagado");
    } catch (error) {
        console.error("Erro ao apagar o QR Code:", error);
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
