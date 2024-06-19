using digiturno.Data.Servicios;
using digiturno.Data.Turno;
using digiturno.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace digiturno.Controllers.Turno
{
    public class TurnoController : Controller
    {
        public ActionResult Index()
        {
            TurnoGenerarModel turnogenerar = new TurnoGenerarModel();
            try {
                turnogenerar.Idturno = 0;
                turnogenerar.Cedula = "";
                turnogenerar.Idservicio = 0;
            }catch(Exception ex)
            {
                throw;
            }
            return View(turnogenerar);
        }

        [HttpPost]
        public ActionResult Turno(string cedula,int servicio,int idturno)
        {
            TurnoGenerarModel turnogenerar=new TurnoGenerarModel();
            try {
                if (cedula.Length<8) {
                    throw new Exception("El numero de identificación debe ser mayor a 8 caracteres");
                }
                var turnoRegistradoCliente = TurnoData.ObtenerPorClienteCedula(cedula);
                if (turnoRegistradoCliente != null && turnoRegistradoCliente.Idservicio!=null) {
                    throw new Exception("Ya ha solicitado un turno");
                }
                digiturno.Data.Turno.Turno model = new digiturno.Data.Turno.Turno(idturno, turnoRegistradoCliente?.Idsucursal??1, turnoRegistradoCliente?.Idservicio, null, turnoRegistradoCliente?.Consecutivo??0, cedula,false,false,false);
                if (servicio != 0)
                {
                    model.Idservicio = servicio;
                }

                if (turnoRegistradoCliente != null && servicio!=0) {
                    if (turnoRegistradoCliente.Consecutivo==0) {
                        var consecutivo = TurnoData.ObtenerConsecutivo(1, servicio);
                        model.Consecutivo = consecutivo+1;
                    }
                }
                if (idturno == 0)
                {
                    TurnoData.Insertar(model);
                }
                else {
                    TurnoData.Actualizar(model);
                }
                turnogenerar.Idturno= model.Id;
                turnogenerar.Cedula = model.Cedular;
                turnogenerar.Idservicio = model.Idservicio??0;
                turnogenerar.Servicios=ServiciosData.ObtenerRegistros().Select(x => new ServiciosModel(x.Id, x.Nombre, x.Esconsultas, x.Esasesoria, x.Esotros, x.Icono, x.Codigo,x.Escaja)).ToList();
                if (turnogenerar.Idservicio!=0) {
                    return RedirectToAction("Imprimir",new { idturno=turnogenerar.Idturno});
                }
            }
            catch (Exception ex) {
                ViewBag.mensaje = ex.Message;
                turnogenerar.Idturno = idturno;
                turnogenerar.Cedula = cedula;
                turnogenerar.Idservicio = servicio;
                turnogenerar.Servicios = ServiciosData.ObtenerRegistros().Select(x => new ServiciosModel(x.Id, x.Nombre, x.Esconsultas, x.Esasesoria, x.Esotros, x.Icono, x.Codigo,x.Escaja)).ToList();

            }
            return View("Index",turnogenerar);
        }

        public ActionResult Imprimir(int idturno) {
            TurnoImpresoModel turnoimpreso=new TurnoImpresoModel();
            try {
                var turno = TurnoData.ObtenerPorId(idturno);
                if (turno!=null) {
                    turnoimpreso = new TurnoImpresoModel(turno.Id,$"{turno.servicio?.Codigo??""}-{turno.Consecutivo}",$"{turno.sucursal?.Codigo??""}-{turno.sucursal?.Nombre??""}",turno.Cedular,"TURNOS GOL",DateTime.Now);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return View(turnoimpreso);
        }
    }
}