using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.comparer
{
    public class PasajeComparer : IComparer<Pasaje>
    {
        public int Compare(Pasaje x, Pasaje y)
        {
            return y.PrecioPasaje.CompareTo(x.PrecioPasaje);
        }
    }
}
