
$(document).ready(function () {

    $("#btnDetalhesIronwasp").click(function () {
        var conteudoModalHtml = $("#ConteudoDetalhesAnaliseIronwasp").html();
        $("#TituloModal").text("Detalhes da Analise Ferramenta Ironwasp");
        $("#ConteudoModal").html(conteudoModalHtml);
    });

    $("#btnDetalhesZap").click(function () {
        var conteudoModalHtml = $("#ConteudoDetalhesAnaliseZap").html();
        $("#TituloModal").text("Detalhes da Analise Ferramenta Zap");
        $("#ConteudoModal").html(conteudoModalHtml);
    });

    $("#btnDetalhesGrabber").click(function () {
        var conteudoModalHtml = $("#ConteudoDetalhesAnaliseGrabber").html();
        $("#TituloModal").text("Detalhes da Analise Ferramenta Grabber");
        $("#ConteudoModal").html(conteudoModalHtml);
    });

    $("#btnExportarPdf").click(function () {
        var conteudoZap = $("#ConteudoDetalhesAnaliseZap").html();
        $("#formularioExportarPdf #conteudoPdf").val(conteudoZap);
        $("#formularioExportarPdf").submit();
    });
});
