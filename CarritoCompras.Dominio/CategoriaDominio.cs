using CarritoCompras.Entidad;
using CarritoCompras.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Dominio
{
    public class CategoriaDominio
    {
        CategoriaRepositorio oCategoriaRepositorio = new CategoriaRepositorio();
        #region "Metodos No Transaccionales"
        public List<CategoriaEntidad> listarActivos()
        {
            return oCategoriaRepositorio.listarActivos();
        }

        #endregion
    }
}
