using System.Web.Mvc;
using CarritoCompras.Agente;
using CarritoCompras.Agente.VS;


namespace CarritoCompras.Presentacion.Controllers
{
    public class HomeController : Controller
    {

 VentaAgente oVentaAgente = new VentaAgente();
        public ActionResult Index()
        {

            SessionManager.ListaCategorias = oVentaAgente.ListarCategoria();
            return View();
        }

        public ActionResult Categoria(int id)
        {
            var ListaProducto = oVentaAgente.BuscarProducto(id);
            return View(ListaProducto);
        }

        [HttpPost]
        public ActionResult ReservarProducto(ProductoEntidad entidad)
        {
            var Response = oVentaAgente.ReservarProducto(entidad);
            return Json(Response);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}