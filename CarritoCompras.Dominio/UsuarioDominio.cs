using CarritoCompras.Entidad;
using CarritoCompras.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Dominio
{
    public class UsuarioDominio
    {

        UsuarioRepositorio oUsuarioRepositorio = new UsuarioRepositorio();
        #region "Metodos No Transaccionales"
        public UsuarioEntidad validarUsuario(UsuarioEntidad entidad)
        {
            return oUsuarioRepositorio.validarUsuario(entidad);
        }
        #endregion
    }
}
