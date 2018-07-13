using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarritoCompras.Testing
{
    [TestClass]
    public class ProductoTest
    {
        [TestMethod]
        public void FiltrarProductoOK()
        {
            //Declaramos el Proxy
            ProductoServiceReference.ProductoServiceClient proxy = new ProductoServiceReference.ProductoServiceClient();
            
            //Declaramos la entidad con los datos a registrar
            ProductoServiceReference.ProductoEntidad obj = new ProductoServiceReference.ProductoEntidad();
            obj.Categoria = new ProductoServiceReference.CategoriaEntidad
            {
                Cod_Categoria = 1,
            };
            obj.Nom_Producto = "";

            //Recibir resultado
            var resultado = proxy.BuscarProducto(obj);

            //Comparar valor de resultado con valor esperado
            Assert.AreEqual(true, resultado.Count > 0);
        }

        [TestMethod]
        public void FiltrarProductoError()
        {
            //Declaramos el Proxy
            ProductoServiceReference.ProductoServiceClient proxy = new ProductoServiceReference.ProductoServiceClient();

            //Declaramos la entidad con los datos a registrar
            ProductoServiceReference.ProductoEntidad obj = new ProductoServiceReference.ProductoEntidad();
            obj.Categoria = new ProductoServiceReference.CategoriaEntidad
            {
                Cod_Categoria = -1,
            };
            obj.Nom_Producto = "";

            //Recibir resultado
            var resultado = proxy.BuscarProducto(obj);

            //Comparar valor de resultado con valor esperado
            Assert.AreEqual(true, resultado.Count > 0);
        }

    }
}
