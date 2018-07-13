using CarritoCompras.Entidad;
using CarritoCompras.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Dominio
{
    public class PedidoDominio
    {
        PedidoRepositorio oPedidoRepositorio = new PedidoRepositorio();
        #region "Metodos No Transaccionales"
        public List<PedidoEntidad> FiltrarPedido(PedidoEntidad entidad)
        {
            return oPedidoRepositorio.FiltrarPedido(entidad);
        }
        public PedidoEntidad ObtenerxId(PedidoEntidad entidad)
        {
            return oPedidoRepositorio.ObtenerxId(entidad);
        }

        #endregion

        #region "Metodos Transaccionales"

        public bool RegistrarPedido(PedidoEntidad entidad)
        {
            return oPedidoRepositorio.RegistrarPedido(entidad);
        }


        public bool ModificarPedido(PedidoEntidad entidad)
        {
            return oPedidoRepositorio.ModificarPedido(entidad);
        }


        #endregion
    }
}
