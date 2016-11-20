using DotNet.Highcharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ZapCharts.Views.ViewModel.Formulario
{
    public class FormularioInsercaoArquivoViewModel
    {
        public string Titulo
        {
            get { return "ZapCharts - Inserção de Arquivo"; }
        }
        [DisplayName("Password Autocomplete")]
        public bool PasswordAutocomplete { get; set; }
        [DisplayName("X-Frame-Options Header Not Set")]
        public bool XFrameOptionsHeaderNotSet { get; set; }

        [DisplayName("X-Content-Type-Options Header Missing")]
        public bool XContentTypeOptionsHeaderMissing { get; set; }

        [DisplayName("XSS - Cross-site scripting")]
        public bool Xss { get; set; }

        [DisplayName("Web Browser XSS Protection Not Enabled")]
        public bool WebBrowserXssProtetionNotEnabled { get; set; }

        [DisplayName("SQL Injection")]
        public bool SqlInjection { get; set; }

        [DisplayName("URL Open")]
        public bool UrlOpen { get; set; }

        [DisplayName("Application Error Disclosure")]
        public bool ApplicationErrorDisclosure { get; set; }

        [DisplayName("Arquivo: ")]
        public HttpPostedFileBase Arquivo { get; set; }
        public bool ApresetarResultados{ get; set; }
        public Highcharts GraficoPizza { get; set; }

    }
}