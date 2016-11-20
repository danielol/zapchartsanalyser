$("#btn_gerar_analise").click(function () {
    $('form').submit();
    exibeBtnNovaAnalise('formulario_insercao_arquivo', 'btn_nova_analise');
})

$("#btn_nova_analise").click(function () {
    removeResultadoAnalise('resultado_analise');
    toggleFormularioAnexo('formulario_insercao_arquivo');
    exibeBtnNovaAnalise('formulario_insercao_arquivo', 'btn_nova_analise');
})

$("#Arquivo").change(function () {
    var arquivo = $("#Arquivo").val();
    var possuiAnexo = (arquivo == '' || Arquivo == 'undefined') ? false : true;
    if (possuiAnexo) {
        $("#btn_gerar_analise").prop("disabled", false);
    } else {
        $("#btn_gerar_analise").prop("disabled", true);
    }
});

function toggleFormularioAnexo(idFormulario) {
    $('#' + idFormulario).slideToggle("slow", function () {});
}

function removeResultadoAnalise(idDivResultado) {
    $('#'+ idDivResultado).remove();
}

function exibeBtnNovaAnalise(idFormulario, idBtnNovaAnalise) {
    var formularioVisivel = $('#' + idFormulario).attr("display") == 'none' ? false : true;
    if (formularioVisivel) {
        $('#' + idBtnNovaAnalise).hide();
    } else {
        $('#' + idBtnNovaAnalise).show();
    }
}

