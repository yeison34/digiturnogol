using digiturno.Data.ModuloUsuario;
using digiturno.Data.ServicioRol;
using digiturno.Data.Servicios;
using digiturno.Data.Turno;
using digiturno.Data.UsuarioRol;
using digiturno.Data.Usuarios;
using digiturno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace digiturno.Controllers
{
    public class HomeController : Controller
    {
        private const string _idusuario = "2";
        private const int _idsucursal = 1;
        public ActionResult Index()
        {
            AtencionClienteModel model = new AtencionClienteModel();
            try {
                var idusuario = User.Identity.Name;
                var modulousuario = ModuloUsuarioData.ObtenerModuloPorIdUsuario(idusuario);
                var usuarioingreo = UsuariosData.GetUsuarioPorId(idusuario);
                if (modulousuario!=null) {
                    model = new AtencionClienteModel(modulousuario.Nombre, false, "", "", "",0,false,usuarioingreo.Usuario);
                }
                

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View(model);
        }

        public ActionResult Atender(int idturno)
        {
            AtencionClienteModel model = new AtencionClienteModel();
            try {
                var idusuario = User.Identity.Name;
                var modulousuario = ModuloUsuarioData.ObtenerModuloPorIdUsuario(_idusuario);
                if (idturno!=0) {
                    var turnollamando = TurnoData.ObtenerPorId(idturno);
                    if (turnollamando.Esllamado) {
                        model = new AtencionClienteModel(modulousuario.Nombre,true,$"{turnollamando.servicio?.Codigo??""}-{turnollamando.Consecutivo}", $"{turnollamando.servicio?.Codigo??""}-{turnollamando.servicio?.Nombre??""}", turnollamando.Cedular, turnollamando.Id,false,idusuario);
                        return View("Index",model);
                    }
                }
                List<Data.Servicios.Servicios> servicios = new List<Data.Servicios.Servicios>();
                var rolesusuario = UsuarioRolData.GetRolesPorIdusuario(_idusuario);
                foreach (var item in rolesusuario)
                {
                    var serviciorol = ServicioRolData.ObtenerServiciosPorIdRol(item.Idrol);
                    if (serviciorol.Count!=0) {
                        servicios.AddRange(serviciorol);
                    }
                    
                }
                
                model = new AtencionClienteModel(modulousuario.Nombre, false, "", "", "",0,false,idusuario);
                var hayturnos = true;
                Data.Turno.Turno turnoatendido = null;
                List<Data.Turno.Turno> turnosporatender = new List<Data.Turno.Turno>();
                foreach (var itemservicio in servicios)
                {
                    var turnoatender = TurnoData.ObtenerTurnoPorSucursalServicio(_idsucursal, itemservicio.Id);
                    if (turnoatender != null)
                    {
                        turnosporatender.Add(turnoatender);
                        break;
                    }
                }

                if (turnosporatender.Count != 0)
                {
                    var turnoescogido = turnosporatender.OrderBy(x => x.Id).First();
                    turnoatendido = turnoescogido;
                    model.Servicio = $"{turnoescogido.servicio?.Codigo ?? ""}-{turnoescogido.servicio?.Nombre ?? ""}";
                    model.Turno = $"{turnoescogido.servicio?.Codigo ?? ""}-{turnoescogido.Consecutivo}";
                    model.Cedula = turnoescogido.Cedular;
                    model.Idturno = turnoescogido.Id;
                    model.Enatencion = true;
                    hayturnos = true;
                }
                else {
                    hayturnos = false;
                }
                if (!hayturnos)
                {
                    throw new Exception("No hay turnos para atender");
                }
                else {
                    if (turnoatendido!=null) {
                        turnoatendido.Esllamado = true;
                        TurnoData.Actualizar(turnoatendido);
                    }
                }
                
            }
            catch(Exception ex)
            {

                throw ex;
            }
            return View("Index",model);
        }

        public ActionResult TerminarAtencion(int idturno) {
            AtencionClienteModel model = new AtencionClienteModel();
            try
            {
                var modulousuario = ModuloUsuarioData.ObtenerModuloPorIdUsuario(_idusuario);
                var turnollamando = TurnoData.ObtenerPorId(idturno);
                if (turnollamando != null)
                {
                    turnollamando.Nosepresento = false;
                    turnollamando.Esllamado = true;
                    turnollamando.Atendido = true;
                    TurnoData.Actualizar(turnollamando);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public ActionResult TurnoNoSePresento(int idturno)
        {
            try {
                var turno = TurnoData.ObtenerPorId(idturno);
                if (turno!=null) {
                    turno.Nosepresento = true;
                    turno.Esllamado=true;
                    turno.Atendido= true;
                    TurnoData.Actualizar(turno);
                }
            }catch(Exception ex) {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public ActionResult IniciarAtencion(int idturno) {
            AtencionClienteModel model = new AtencionClienteModel();
            try
            {
                var idusuario = User.Identity.Name;
                var modulousuario = ModuloUsuarioData.ObtenerModuloPorIdUsuario(_idusuario);
                var turnollamando = TurnoData.ObtenerPorId(idturno);
                if (turnollamando != null)
                {
                    turnollamando.Nosepresento = false;
                    turnollamando.Esllamado = true;
                    turnollamando.Atendido= false;
                    turnollamando.Idmodulo = modulousuario.Id;
                    TurnoData.Actualizar(turnollamando);
                    model = new AtencionClienteModel(modulousuario.Nombre, true, turnollamando.Consecutivo.ToString(), turnollamando.servicio?.Nombre ?? "", turnollamando.Cedular, turnollamando.Id,true,idusuario);
                    return View("Index", model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
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