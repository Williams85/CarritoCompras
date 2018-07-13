using CarritoCompras.Entidad;
using CarritoCompras.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Dominio
{
    public class ProductoDominio
    {
        ProductoRepositorio oProductoRepositorio = new ProductoRepositorio();
        #region "Metodos No Transaccionales"
        public List<ProductoEntidad> filtrar(ProductoEntidad entidad)
        {
            return oProductoRepositorio.filtrar(entidad);
        }

        public ProductoEntidad ObtenerxCodigo(string Codigo)
        {
            return oProductoRepositorio.ObtenerxCodigo(Codigo);
        }

        #endregion
    }
}
