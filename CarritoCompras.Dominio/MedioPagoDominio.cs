using CarritoCompras.Entidad;
using CarritoCompras.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Dominio
{
    public class MedioPagoDominio
    {
        MedioPagoRepositorio oMedioPagoRepositorio = new MedioPagoRepositorio();
        #region "Metodos No Transaccionales"
        public List<MedioPagoEntidad> listarActivos()
        {
            return oMedioPagoRepositorio.listarActivos();
        }

        #endregion
    }
}
