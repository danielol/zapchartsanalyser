using System;
using ZapCharts.Data.Model.Entities;
using ZapCharts.Service.Interfaces;


namespace ZapCharts.Service.Services.LineChart
{
    public class GraficoLinhasService : IGraficoLinhasService
    {
        public GraficoLinhas GetDemo(string titulo)
        {
            return new GraficoLinhas(titulo);//representa mock
        }
    }
}
