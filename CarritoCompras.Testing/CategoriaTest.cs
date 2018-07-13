using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarritoCompras.Testing
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void ListarCategoriaProductoOK()
        {
            //Declaramos el Proxy
            CategoriaServiceReference.CategoriaProductoServiceClient proxy = new CategoriaServiceReference.CategoriaProductoServiceClient();

            //Recibir resultado
            var resultado = proxy.ListarCategoria();

            //Comparar valor de resultado con valor esperado
            Assert.AreEqual(true, resultado.Count > 0);
        }

        [TestMethod]
        public void ListarCategoriaProductoError()
        {
            //Declaramos el Proxy
            CategoriaServiceReference.CategoriaProductoServiceClient proxy = new CategoriaServiceReference.CategoriaProductoServiceClient();

            //Recibir resultado
            var resultado = proxy.ListarCategoria();

            //Comparar valor de resultado con valor esperado
            Assert.AreEqual(true, resultado.Count <=0);
        }

    }
}
