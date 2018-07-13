using CarritoCompras.Entidad;
using CarritoCompras.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Dominio
{
    public class ClienteDominio
    {
        ClienteRepositorio oClienteRepositorio = new ClienteRepositorio();
        #region "Metodos No Transaccionales"
        public ClienteEntidad BuscarCliente(ClienteEntidad entidad)
        {
            return oClienteRepositorio.BuscarCliente(entidad);
        }
        #endregion

        #region "Metodos Transaccionales"

        public bool RegistrarCliente(ClienteEntidad entidad)
        {
            return oClienteRepositorio.RegistrarCliente(entidad);
        }


        public bool ModificarCliente(ClienteEntidad entidad)
        {
            return oClienteRepositorio.ModificarCliente(entidad);
        }


        #endregion
    }
}
