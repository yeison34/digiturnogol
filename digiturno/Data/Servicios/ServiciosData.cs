using Dapper;
using digiturno.Data.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Description;

namespace digiturno.Data.Servicios
{
    public class ServiciosData
    {
        public static Servicios ObtenerPorId(int id) {
            Servicios servicio = null;
            try { 
                StringBuilder sql=new StringBuilder();
                sql.Append("select id,nombre,esconsultas,esasesoria,esotros,icono,codigo,escaja from servicios_servicios");
                sql.Append(" where id=@id");
                DynamicParameters parametros=new DynamicParameters();
                parametros.Add("id", id);
                var connection = ConnectionData.ConnectionSystem();
                servicio = connection.QueryFirstOrDefault<Servicios>(sql.ToString(),parametros);
            }
            catch(Exception ex) {
                throw ex;
            }
            return servicio;
        }

        public static List<Servicios> ObtenerRegistros() {
            List<Servicios> servicios = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select id,nombre,esconsultas,esasesoria,esotros,icono,codigo,escaja from servicios_servicios");
                var connection = ConnectionData.ConnectionSystem();
                servicios = connection.Query<Servicios>(sql.ToString()).ToList();
            }
            catch (Exception ex) {
                throw ex;          
            }

            return servicios;
        }
    }
}