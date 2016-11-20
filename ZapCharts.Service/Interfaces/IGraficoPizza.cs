using ZapCharts.Data.Model.Entities;

namespace ZapCharts.Service.Interfaces
{
    public interface IGraficoPizzaService
    {
        GraficoPizza GetDemo(string titulo, object[] dados);

    }
}
