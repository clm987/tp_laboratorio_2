using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace System.Collections.Generic
{
    /// <summary>
    /// Metodo que extiende la funcionalidad de la tipo Queue permitiendo calcular el monto de ventas procesadas. (Tema metodos de extension)
    /// </summary>
    public static class QueueExtension
    {
        public static float CalcularTotalVentasProcesadas(this Queue<Venta> colaDeventasProcesadas)
        {
            float total = 0;

            foreach (Venta item in colaDeventasProcesadas)
            {
                total += item.Monto;
            }
            return total;
        }
    }
}
