using CarritoCompras.Entidad;
using CarritoCompras.EntityService.MCS;
using CarritoCompras.EntityService.MTS;
using CarritoCompras.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.EntityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductoService.svc or ProductoService.svc.cs at the Solution Explorer and start debugging.
    public class ProductoService : IProductoService
    {

        public List<ProductoEntidad> BuscarProducto(ProductoEntidad entidad)
        {
            MacroConsultaServiceClient proxy = new MacroConsultaServiceClient();
            return proxy.ObtenerProductos(entidad);
        }


        public ResponseWeb ReservarProducto(ProductoEntidad entidad)
        {
            MacroTransaccionServiceClient proxy = new MacroTransaccionServiceClient();
            return proxy.ReservarProducto(entidad);
        }
    }
}
