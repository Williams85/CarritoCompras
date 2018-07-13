using CarritoCompras.Agente;
using CarritoCompras.Agente.VS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarritoCompras.Presentacion.Controllers
{
    public class CompraController : Controller
    {
        //
        // GET: /Compra/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarMediosPago()
        {
            VentaAgente oVentaAgente = new VentaAgente();
            var Lista = oVentaAgente.ListarMediosPago();
            return PartialView("_ResultadoMediosPago", Lista);
        }

        public ActionResult BuscarDetallePedido()
        {
            VentaAgente oVentaAgente = new VentaAgente();
            var Lista = oVentaAgente.BuscarDetallePedido();
            return PartialView("_ResultadoDetallePedido", Lista);
        }

        [HttpPost]
        public ActionResult GrabarVenta(PedidoEntidad entidad)
        {
            VentaAgente oVentaAgente = new VentaAgente();
            var response = oVentaAgente.GrabarVenta(entidad);
            return Json(response);
        }


	}
}