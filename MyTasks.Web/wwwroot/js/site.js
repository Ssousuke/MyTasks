function atualizarDataHora() {
    var dataHoraAtual = new Date();
    var dataFormatada = dataHoraAtual.toLocaleDateString();
    var horaFormatada = dataHoraAtual.toLocaleTimeString();
    document.getElementById("data-hora-atual").innerHTML = "Olá, hoje é: " + dataFormatada + " " + horaFormatada;
}

setInterval(atualizarDataHora, 1000);