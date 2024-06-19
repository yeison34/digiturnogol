using digiturno.Data.ModulosData;
using digiturno.Data.Servicios;
using digiturno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace digiturno.Controllers.Servicios
{
    public class ServiciosController : Controller
    {
        public ActionResult Index()
        {
            List<ServiciosModel> lista = new List<ServiciosModel>();
            try {
                lista = ServiciosData.ObtenerRegistros().Select(x=>new ServiciosModel(x.Id,x.Nombre,x.Esconsultas,x.Esasesoria,x.Esotros,x.Icono,x.Codigo,x.Escaja)).ToList();
            }
            catch (Exception ex) {
                throw ex;
            }
            return View(lista);
        }
    }
}