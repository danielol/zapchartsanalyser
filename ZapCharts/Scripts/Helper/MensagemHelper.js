function MostrarMensagem(tipo, mensagem) {
    var css= ""; 
    switch(tipo.toLowerCase()) {
        case 'sucesso':
            css = "alert alert-success";
            break;
        case 'atencao':
            css = "alert alert-warning";
            break;
        case 'informacao':
            css = "alert alert-info";
            break;
        case 'erro':
            css = "alert alert-danger";
            break;
        default:
            css = "alert alert-info";
    }
    var tempoDeExibicaoMs= 10000;
    $("#caixaMensagem").removeClass();
    $("#caixaMensagem").addClass(css);
    $("#caixaMensagem").fadeIn(1000, function () {});
    $("#mensagem").html(mensagem);
    $("#caixaMensagem").fadeOut(tempoDeExibicaoMs, function () { });
}
