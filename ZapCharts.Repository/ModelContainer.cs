using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZapCharts.Repository
{
    public static class ModelContainer
    {
        private static readonly object _Key = new object();
        private static UnityContainer _Instance;

        public static UnityContainer Instance
        {
            get
            {
                if(_Instance == null)
                {
                    lock (_Key)
                    {
                        if(_Instance == null)
                        {
                            _Instance = new UnityContainer();
                            _Instance.RegisterType<Igr, algumaCoisa>();
                        }
                    }
                }
            }
        }
    }
}
