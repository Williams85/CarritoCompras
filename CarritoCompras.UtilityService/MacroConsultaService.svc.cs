using CarritoCompras.Dominio;
using CarritoCompras.Entidad;
using CarritoCompras.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.UtilityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MacroConsultaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MacroConsultaService.svc or MacroConsultaService.svc.cs at the Solution Explorer and start debugging.
    public class MacroConsultaService : IMacroConsultaService
    {
        CategoriaDominio oCategoriaDominio = new CategoriaDominio();
        ProductoDominio oProductoDominio = new ProductoDominio();
        PedidoDominio oPedidoDominio = new PedidoDominio();
        ClienteDominio oClienteDominio = new ClienteDominio();
        MedioPagoDominio oMedioPagoDominio = new MedioPagoDominio();

        public List<CategoriaEntidad> ObtenerCategorias()
        {
            return oCategoriaDominio.listarActivos();
        }

        public List<MedioPagoEntidad> ObtenerMediosPago()
        {
            return oMedioPagoDominio.listarActivos();
        }

        public List<ProductoEntidad> ObtenerProductos(ProductoEntidad entidad)
        {
            string rutaCola = @".\private$\compraproductos";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            cola.Purge();
            return oProductoDominio.filtrar(entidad);
        }

        public ClienteEntidad ObtenerCliente(ClienteEntidad entidad)
        {
            return oClienteDominio.BuscarCliente(entidad);
        }

        public List<PedidoEntidad> ObtenerPedido(PedidoEntidad entidad)
        {
            return oPedidoDominio.FiltrarPedido(entidad);
        }


        public List<DetallePedidoEntidad> ObtenerDetallePedido()
        {
            string rutaCola = @".\private$\compraproductos";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);

            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(ProductoEntidad) });
            var mensajes = cola.GetAllMessages();
            //cola.Purge();
            List<ProductoEntidad> ListaProductos = new List<ProductoEntidad>();
            if (mensajes != null && mensajes.Length > 0)
            {
                foreach (var mensaje in mensajes)
                {
                    ProductoEntidad oProductoEntidad = new ProductoEntidad();
                    oProductoEntidad = (ProductoEntidad)mensaje.Body;
                    ListaProductos.Add(oProductoEntidad);
                }
            }

            List<DetallePedidoEntidad> ListaDetallePedido = new List<DetallePedidoEntidad>();
            foreach(var item in ListaProductos){
                var producto = oProductoDominio.ObtenerxCodigo(item.Cod_Producto.ToString());
                DetallePedidoEntidad oDetallePedidoEntidad = new DetallePedidoEntidad();
                producto.Cantidad = item.Cantidad;
                oDetallePedidoEntidad.Producto = producto;
                oDetallePedidoEntidad.SubTotal = (producto.Cantidad*producto.Precio);
                ListaDetallePedido.Add(oDetallePedidoEntidad);
            }

            return ListaDetallePedido;
        }
    }
}
