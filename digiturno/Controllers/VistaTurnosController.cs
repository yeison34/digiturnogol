using digiturno.Data.VistaTurnos;
using digiturno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace digiturno.Controllers
{
    public class VistaTurnosController : Controller
    {
        // GET: VistaTurnos
        public ActionResult Index()
        {
            List<VistaTurnosModel> lista= new List<VistaTurnosModel>();
            try {
                lista = VistaTurnosData.ObtenerRegistros().Where(x=>x.Idsucursal==1 && x.Atendido==false && x.Esllamado==false && x.Nosepresento==false).Select(x=>new VistaTurnosModel(x.Idturno,x.Idsucursal,x.Idservicio,x.Turno,x.Cedular,x.Servicio,x.Sucursal,x.Esllamado,x.Nosepresento,x.Atendido,x.Idmodulo,x.Modulo)).ToList();
            }
            catch(Exception ex) {
            }
            return View(lista);
        }
    }
}