using CarritoCompras.Agente;
using CarritoCompras.Agente.US;
using CarritoCompras.Agente.VS;
using System.Web.Mvc;
namespace CarritoCompras.Presentacion.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            SessionManager.ListaCategorias = null;
            SessionManager.Usuario = null;
            return View();
        }
        [HttpPost]
        public ActionResult ValidarUsuario(UsuarioEntidad entidad)
        {
            SeguridadAgente oSeguridadAgente = new SeguridadAgente();
            var response = oSeguridadAgente.ValidarUsuario(entidad);
            ResponseWeb oResponseWeb = new ResponseWeb();
            if (response != null)
            {
                SessionManager.Usuario = response;
                oResponseWeb.Estado = true;
            }
            else
            {
                oResponseWeb.Estado = false;
                oResponseWeb.Message = "Usuario o contraseña incorrecta";
            }
            return Json(oResponseWeb);
        }

        public ActionResult ConsultarPedido()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarPedidos(PedidoEntidad entidad)
        {
            AdministracionAgente oAdministracionAgente = new AdministracionAgente();
            var ListaPedido = oAdministracionAgente.BuscarPedidos(entidad);
            return PartialView("_ResultadoPedidos", ListaPedido);
        }

        [HttpPost]
        public ActionResult ModificarEstadoPedido(PedidoEntidad entidad)
        {
            AdministracionAgente oAdministracionAgente = new AdministracionAgente();
            var response = oAdministracionAgente.ModificarEstadoPedido(entidad);
            return Json(response);
        }

    }
}