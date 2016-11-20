using DotNet.Highcharts;
using System;
using System.Collections.Generic;
using System.Web;

namespace ZapCharts.Views.ViewModel.Formulario
{
    public class FormularioCadastroAnaliseViewModel
    {
        public int Registro{ get; set; }
        public string NomeCodigoApp{ get; set; }
        public string EnderecoEletronico{ get; set; }
        public DateTime DtVerificacao { get; set; }

        public bool ValidarZap { get; set; }
        public bool ValidarIronwasp { get; set; }
        public bool ValidarGrabber { get; set; }

        public HttpPostedFileBase ArquivoFerramentaZap { get; set; }
        public HttpPostedFileBase ArquivoFerramentaIronwasp { get; set; }
        public HttpPostedFileBase ArquivoFerramentaGrabber { get; set; }
        
    }
}