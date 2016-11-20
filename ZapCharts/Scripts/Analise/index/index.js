function enviarFormulario() {
    debugger;
    if ($("#ValidarZap").is(':checked') || $("#ValidarIronwasp").is(':checked') || $("#ValidarGrabber").is(':checked')) {
        $('form').submit()
    } else {
        MostrarMensagem("erro", "É necessário selecionar pelo menos uma ferramenta para analise.");
    }
}

function limparFormulario() {
    $('form').trigger("reset");
}
