using ZapCharts.Data.Model.Entities;
using ZapCharts.Service.Interfaces;

namespace ZapCharts.Service.Services
{
    public class GraficoPizzaService : IGraficoPizzaService
    {
        public GraficoPizza GetDemo(string titulo, object[] dados){
            return new GraficoPizza(titulo, dados);//representa mock
        }
    }
}
