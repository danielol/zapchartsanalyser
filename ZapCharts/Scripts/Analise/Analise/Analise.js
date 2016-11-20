function enviarFormulario() {
    debugger;
    if (($('#ArquivoFerramentaZap')[0] !== undefined && $('#ArquivoFerramentaZap')[0].files[0] !== undefined) || ($('#ArquivoFerramentaIronwasp')[0] !== undefined && $('#ArquivoFerramentaIronwasp')[0].files[0] !== undefined) || ($('#ArquivoFerramentaGrabber')[0] !== undefined && $('#ArquivoFerramentaGrabber')[0].files[0] !== undefined)) {
        $('form').submit()
    } else {
        MostrarMensagem("erro", "É necessário Anexar Pelo menos um arquivo para analise.");
    }
}
function limparFormulario() {
    $('form').trigger("reset");
}
