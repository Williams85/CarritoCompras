using CarritoCompras.Agente.US;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace CarritoCompras.Agente
{
    public class SeguridadAgente
    {
        public UsuarioEntidad ValidarUsuario(UsuarioEntidad entidad)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(entidad);
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
            var respuesta = js.Deserialize<UsuarioEntidad>(tramaJson);
            return respuesta;
        }
    }
}
