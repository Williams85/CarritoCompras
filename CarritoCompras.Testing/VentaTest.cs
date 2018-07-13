using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CarritoCompras.Testing
{
    [TestClass]
    public class VentaTest
    {

        #region "Pruebas Integrales"
        [TestMethod]
        public void TestListarCategoriaOK()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            var respuesta = proxy.ListarCategoria();

            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Count > 0);
        }

        [TestMethod]
        public void TestBuscarProductoOK()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            var respuesta = proxy.BuscarProducto(new VS.ProductoEntidad
            {
                Categoria = new VS.CategoriaEntidad
                {
                    Cod_Categoria = 1
                }
            });

            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Count > 0);

        }

        [TestMethod]
        public void TestBuscarProductoError()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            var respuesta = proxy.BuscarProducto(new VS.ProductoEntidad
            {
                Categoria = new VS.CategoriaEntidad
                {
                    Cod_Categoria = 100
                }
            });

            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Count > 0);

        }

        [TestMethod]
        public void TestReservarProductoOK()
        {


            //Definiendo Datos ingreso
            VS.ProductoEntidad oProductoEntidad = new VS.ProductoEntidad();
            oProductoEntidad.Cod_Producto = 1;
            oProductoEntidad.Cantidad = 2;

            //Comunicarse con el Servicio
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            var respuesta = proxy.ReservarProducto(oProductoEntidad);

            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Estado);
        }


        [TestMethod]
        public void TestReservarProductoError()
        {
            //Definiendo Datos ingreso
            VS.ProductoEntidad oProductoEntidad = new VS.ProductoEntidad();
            oProductoEntidad.Cod_Producto = 1;
            oProductoEntidad.Cantidad = 2000;

            //Comunicarse con el Servicio
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            var respuesta = proxy.ReservarProducto(oProductoEntidad);

            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Estado);
        }


        [TestMethod]
        public void TestBuscarDetallePedidoOK()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            var respuesta = proxy.BuscarDetallePedido();

            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Count > 0);
        }

        [TestMethod]
        public void TestListarMediosPagoOK()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            var respuesta = proxy.ListarMediosPago();

            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Count > 0);
        }

        [TestMethod]
        public void TestGrabarVentaOK()
        {


            //Definiendo Datos ingreso
            VS.PedidoEntidad oPedidoEntidad = new VS.PedidoEntidad();
            oPedidoEntidad.Dir_Entrega = "Av. El Sol 456";
            oPedidoEntidad.Fecha_Entrega = DateTime.Parse("13/07/2018");
            oPedidoEntidad.Cliente = new VS.ClienteEntidad
            {
                Nom_Cliente = "Williams Morales",
                Ema_Cliente = "williams.morales.caballero@gmail.com"
            };
            oPedidoEntidad.MedioPago = new VS.MedioPagoEntidad
            {
                Cod_MedioPago = 1
            };
            //Comunicarse con el Servicio
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            oPedidoEntidad.DetallePedido = proxy.BuscarDetallePedido();
            oPedidoEntidad.Total_Neto = oPedidoEntidad.DetallePedido.Sum(x => x.SubTotal);
            var respuesta = proxy.GrabarVenta(oPedidoEntidad);


            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Estado);
        }


        [TestMethod]
        public void TestGrabarVentaError()
        {


            //Definiendo Datos ingreso
            VS.PedidoEntidad oPedidoEntidad = new VS.PedidoEntidad();
            oPedidoEntidad.Dir_Entrega = "Av. El Sol 456";
            oPedidoEntidad.Fecha_Entrega = DateTime.Parse("13/07/2018");
            oPedidoEntidad.Cliente = new VS.ClienteEntidad
            {
                Nom_Cliente = "Williams Morales",
                Ema_Cliente = "williams.morales.caballero@gmail.com"
            };
            oPedidoEntidad.MedioPago = new VS.MedioPagoEntidad
            {
                Cod_MedioPago = 1
            };
            //Comunicarse con el Servicio
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            oPedidoEntidad.DetallePedido = proxy.BuscarDetallePedido();
            oPedidoEntidad.Total_Neto = oPedidoEntidad.DetallePedido.Sum(x => x.SubTotal);
            var respuesta = proxy.GrabarVenta(oPedidoEntidad);


            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Estado);
        }

        #endregion

        #region "Flujos Distribuidos"

        //Buscar Productos por Categoria
        [TestMethod]
        public void TestBuscarProductosxCategoria()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();

            //Consultar Categorias de Productos
            var ListaCategorias = proxy.ListarCategoria();

            //Consultar Productos por Categoria

            var respuesta = proxy.BuscarProducto(new VS.ProductoEntidad
            {
                Categoria = new VS.CategoriaEntidad
                {
                    Cod_Categoria = ListaCategorias[0].Cod_Categoria,
                }
            });


            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Count > 0);
        }

        //Reservar Producto y Visualizarlo
        [TestMethod]
        public void TestReservarProducto()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();

            //Consultar Categorias de Productos
            var ListaCategorias = proxy.ListarCategoria();

            //Consultar Productos por Categoria

            var ListaProductos = proxy.BuscarProducto(new VS.ProductoEntidad
            {
                Categoria = new VS.CategoriaEntidad
                {
                    Cod_Categoria = ListaCategorias[0].Cod_Categoria,
                }
            });

            //Definiendo Datos ingreso
            var oProductoEntidad = ListaProductos[1];
            oProductoEntidad.Cantidad = 2;

            //Comunicarse con el Servicio
            proxy.ReservarProducto(oProductoEntidad);

            var respuesta = proxy.BuscarDetallePedido();

            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Count > 0);
        }


        //Grabar Venta
        [TestMethod]
        public void TestGrabarVenta()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();

            //Consultar Categorias de Productos
            var ListaCategorias = proxy.ListarCategoria();

            //Consultar Productos por Categoria

            var ListaProductos = proxy.BuscarProducto(new VS.ProductoEntidad
            {
                Categoria = new VS.CategoriaEntidad
                {
                    Cod_Categoria = ListaCategorias[0].Cod_Categoria,
                }
            });

            //Definiendo Datos ingreso
            var oProductoEntidad = ListaProductos[1];
            oProductoEntidad.Cantidad = 2;

            //Comunicarse con el Servicio
            proxy.ReservarProducto(oProductoEntidad);

            //Definiendo Datos ingreso Compra
            VS.PedidoEntidad oPedidoEntidad = new VS.PedidoEntidad();
            oPedidoEntidad.Dir_Entrega = "Av. El Sol 456";
            oPedidoEntidad.Fecha_Entrega = DateTime.Parse("13/07/2018");
            oPedidoEntidad.Cliente = new VS.ClienteEntidad
            {
                Nom_Cliente = "Williams Morales",
                Ema_Cliente = "williams.morales.caballero@gmail.com"
            };
            oPedidoEntidad.MedioPago = new VS.MedioPagoEntidad
            {
                Cod_MedioPago = 1
            };
            //Comunicarse con el Servicio

            oPedidoEntidad.DetallePedido = proxy.BuscarDetallePedido();
            oPedidoEntidad.Total_Neto = oPedidoEntidad.DetallePedido.Sum(x => x.SubTotal);
            var respuesta = proxy.GrabarVenta(oPedidoEntidad);


            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Estado);
        }
        #endregion


    }
}
