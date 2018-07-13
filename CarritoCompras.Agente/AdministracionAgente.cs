using CarritoCompras.Agente.VS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CarritoCompras.Agente
{
    public class AdministracionAgente
    {
        public List<PedidoEntidad> BuscarPedidos(PedidoEntidad entidad)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(entidad);
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
            var respuesta = js.Deserialize<List<PedidoEntidad>>(tramaJson);
            return respuesta;
        }

        public ResponseWeb ModificarEstadoPedido(PedidoEntidad entidad)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(entidad);
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
            return respuesta;
        }
    }
}
