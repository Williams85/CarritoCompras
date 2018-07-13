using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace CarritoCompras.Testing
{
    [TestClass]
    public class AdministracionTest
    {
        #region "Pruebas Integrales"
        
        [TestMethod]
        public void TestValidarUsuarioOK()
        {

            //Definiendo Datos ingreso
            UsuarioEntity oUsuarioEntity = new UsuarioEntity();
            oUsuarioEntity.Nom_Usuario = "U0001";
            oUsuarioEntity.Pass_Usuario = "123456";


            //Comunicarse con el Servicio
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(oUsuarioEntity);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51149/AdministracionService.svc/ValidarUsuario");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            var respuesta = js.Deserialize<UsuarioEntity>(tramaJson);


            //Validar Respuesta
            Assert.AreEqual(true, string.IsNullOrWhiteSpace(respuesta.Perfil_Usuario) == false);
        }

        [TestMethod]
        public void TestValidarUsuarioError()
        {

            //Definiendo Datos ingreso
            UsuarioEntity oUsuarioEntity = new UsuarioEntity();
            oUsuarioEntity.Nom_Usuario = "U0001";
            oUsuarioEntity.Pass_Usuario = "1234567";


            //Comunicarse con el Servicio
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(oUsuarioEntity);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51149/AdministracionService.svc/ValidarUsuario");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            var respuesta = js.Deserialize<UsuarioEntity>(tramaJson);


            //Validar Respuesta
            Assert.AreEqual(true, string.IsNullOrWhiteSpace(respuesta.Perfil_Usuario) == false);
        }

        [TestMethod]
        public void TestBuscarPedidosOK()
        {

            //Definiendo Datos ingreso
            PedidoEntity oPedidoEntity = new PedidoEntity();
            oPedidoEntity.Fecha_Inicio = DateTime.Parse("13/07/2018");
            oPedidoEntity.Fecha_Fin = DateTime.Parse("13/07/2018");


            //Comunicarse con el Servicio
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(oPedidoEntity);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51149/AdministracionService.svc/ConsultarPedido");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            var respuesta = js.Deserialize<List<PedidoEntity>>(tramaJson);


            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Count > 0);
        }

        [TestMethod]
        public void TestBuscarPedidosError()
        {

            //Definiendo Datos ingreso
            PedidoEntity oPedidoEntity = new PedidoEntity();
            oPedidoEntity.Fecha_Inicio = DateTime.Parse("10/07/2018");
            oPedidoEntity.Fecha_Fin = DateTime.Parse("10/07/2018");


            //Comunicarse con el Servicio
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(oPedidoEntity);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51149/AdministracionService.svc/ConsultarPedido");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            var respuesta = js.Deserialize<List<PedidoEntity>>(tramaJson);


            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Count > 0);
        }


        [TestMethod]
        public void TestModificarEstadoPedidoOK()
        {

            //Definiendo Datos ingreso
            PedidoEntity oPedidoEntity = new PedidoEntity();
            oPedidoEntity.Cod_Pedido = 23;
            //oPedidoEntity.Fecha_Fin = DateTime.Parse("10/07/2018");


            //Comunicarse con el Servicio
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(oPedidoEntity);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51149/AdministracionService.svc/ModificarEstadoPedido");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            var respuesta = js.Deserialize<ResponseWeb>(tramaJson);
            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Estado);
        }


        [TestMethod]
        public void TestModificarEstadoPedidoError()
        {

            //Definiendo Datos ingreso
            PedidoEntity oPedidoEntity = new PedidoEntity();
            oPedidoEntity.Cod_Pedido = 24;
            //oPedidoEntity.Fecha_Fin = DateTime.Parse("10/07/2018");


            //Comunicarse con el Servicio
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(oPedidoEntity);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51149/AdministracionService.svc/ModificarEstadoPedido");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            var respuesta = js.Deserialize<ResponseWeb>(tramaJson);
            //Validar Respuesta
            Assert.AreEqual(true, respuesta.Estado);
        }

        #endregion


    }
}
