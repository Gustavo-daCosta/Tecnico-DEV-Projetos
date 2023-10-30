async function cadastrar(event) {
    event.preventDefault();
    
    let cep = document.getElementById('cep').value;
    let logradouro = document.getElementById('rua').value;
    let complemento = document.getElementById('complemento').value;
    let bairro = document.getElementById('bairro').value;
    let localidade = document.getElementById('cidade').value;
    let uf = document.getElementById('UF').value;

    const urlLocal = "http://127.0.0.1:5500/index.html"
    const objDados = { cep, logradouro, complemento, bairro, localidade, uf };

    try {
        const promise = await fetch(urlLocal, {
            body: JSON.stringify(objDados),
            headers: {"Content-Type": "application/json"},
            method: "post",
        });
    } catch (error) {
        alert("Deu ruim, erro: " + error);
    }
}

async function chamarApi() {
    const cep = document.getElementById("cep").value;
    const url = `https://viacep.com.br/ws/${cep}/json/`;

    try {
        // resolvida ou fullfilled
        const promise = await fetch(url);
        const resposta = await promise.json();

        console.log(resposta);

        if ('erro' in resposta) {
            throw new Error();
        }

        preencherEndereco(resposta);
    } catch (error) {
        // rejected
        console.log("Deu ruim na API");
    }
}

function preencherEndereco(resposta) {
    document.getElementById('rua').value = resposta.logradouro;
    document.getElementById('complemento').value = resposta.complemento;
    document.getElementById('bairro').value = resposta.bairro;
    document.getElementById('cidade').value = resposta.localidade;
    document.getElementById('UF').value = resposta.uf;
}

function limparDados() {
    document.getElementById('nome').value = "";
    document.getElementById('sobrenome').value = "";
    document.getElementById('email').value = "";
    document.getElementById('pais').value = "";
    document.getElementById('ddd').value = "";
    document.getElementById('telefone').value = "";
    document.getElementById('cep').value = "";
    document.getElementById('rua').value = "";
    document.getElementById('numero').value = "";
    document.getElementById('complemento').value = "";
    document.getElementById('bairro').value = "";
    document.getElementById('cidade').value = "";
    document.getElementById('UF').value = "";
}
