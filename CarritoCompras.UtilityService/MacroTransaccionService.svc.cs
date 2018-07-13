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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MacroTransaccionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MacroTransaccionService.svc or MacroTransaccionService.svc.cs at the Solution Explorer and start debugging.
    public class MacroTransaccionService : IMacroTransaccionService
    {
        public ResponseWeb ReservarProducto(ProductoEntidad entidad)
        {
            ResponseWeb response = new ResponseWeb();
            try
            {

                ProductoDominio oProductoDominio = new ProductoDominio();
                var producto = oProductoDominio.ObtenerxCodigo(entidad.Cod_Producto.ToString());


                string rutaCola = @".\private$\compraproductos";
                if (!MessageQueue.Exists(rutaCola))
                    MessageQueue.Create(rutaCola);
                MessageQueue cola = new MessageQueue(rutaCola);

                #region "Consultar Reserva Productos"
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
                var ListaReservaProducto = ListaProductos.Where(x => x.Cod_Producto == entidad.Cod_Producto).ToList();
                var CantidadReservas = ListaReservaProducto.Count;
                #endregion

                #region "Reserva del Producto"
                if (producto.Cantidad > (CantidadReservas + entidad.Cantidad))
                {
                    System.Messaging.Message mensaje = new System.Messaging.Message();
                    mensaje.Label = "Reserva Producto";
                    mensaje.Body = entidad;
                    cola.Send(mensaje);
                    response.Estado = true;
                    response.Message = "Se reservo el producto";
                }
                else
                {
                    response.Estado = false;
                    response.Message = "Ya no hay stock del producto";
                }
                #endregion

            }
            catch (Exception)
            {
                response.Estado = false;
                response.Message = "No se pudo reservar el producto";
                throw;
            }

            return response;
        }

        public ResponseWeb RegistrarPedido(PedidoEntidad entidad)
        {

            PedidoDominio oPedidoDominio = new PedidoDominio();
            ResponseWeb response = new ResponseWeb();
            response.Estado = oPedidoDominio.RegistrarPedido(entidad);
            if (response.Estado)
            {
                string rutaCola = @".\private$\compraproductos";
                if (!MessageQueue.Exists(rutaCola))
                    MessageQueue.Create(rutaCola);
                MessageQueue cola = new MessageQueue(rutaCola);
                cola.Purge();
            }
            return response;
        }

        public ResponseWeb ActualizarPedido(PedidoEntidad entidad)
        {

            PedidoDominio oPedidoDominio = new PedidoDominio();
            ResponseWeb response = new ResponseWeb();
            var pedido = oPedidoDominio.ObtenerxId(entidad);
            if (pedido.Fecha_Entrega < DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")))
            {
                response.Estado = false;
                response.Message = "La fecha de pedido ya vencio";
            }
            else
            {
                if (pedido.Fecha_Entrega.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    response.Estado = false;
                    response.Message = "Solo se puede modificar el estado en la misma fecha de entrega";
                }
                else
                {
                    response.Estado = oPedidoDominio.ModificarPedido(entidad);
                }
            }


            return response;
        }

        public ResponseWeb RegistrarCliente(ClienteEntidad entidad)
        {
            ResponseWeb response = new ResponseWeb();
            try
            {
                ClienteDominio oClienteDominio = new ClienteDominio();
                response.Estado = oClienteDominio.RegistrarCliente(entidad);
                if (response.Estado)
                    response.Message = "Se grabó el cliente";
                else
                    response.Message = "No se grabó el cliente";
            }
            catch (Exception)
            {
                response.Estado = false;
                response.Message = "Error en el registro";
                throw;
            }
            return response;
        }

        public ResponseWeb ActualizarCliente(ClienteEntidad entidad)
        {
            ResponseWeb response = new ResponseWeb();
            try
            {
                ClienteDominio oClienteDominio = new ClienteDominio();
                response.Estado = oClienteDominio.ModificarCliente(entidad);
                if (response.Estado)
                    response.Message = "Se modificó el cliente";
                else
                    response.Message = "No se modificó el cliente";
            }
            catch (Exception)
            {
                response.Estado = false;
                response.Message = "Error en la modifición";
                throw;
            }
            return response;
        }
    }
}
