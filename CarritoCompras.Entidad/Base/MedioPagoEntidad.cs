using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Entidad
{
    public class MedioPagoEntidad
    {
        public int Cod_MedioPago { get; set; }
        public string Nom_MedioPago { get; set; }
        public string Foto { get; set; }
        public bool Estado { get; set; }
    }
}
