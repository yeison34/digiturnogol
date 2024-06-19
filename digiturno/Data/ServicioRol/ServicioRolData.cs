using Dapper;
using digiturno.Data.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digiturno.Data.ServicioRol
{
    public class ServicioRolData
    {
        public static List<Servicios.Servicios> ObtenerServiciosPorIdRol(int id)
        {
            List<Servicios.Servicios> servicios = new List<Servicios.Servicios>();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select s.id,s.nombre,s.esconsultas,s.esasesoria,s.esotros,s.icono,s.codigo,s.escaja from usuarios_serviciosrol sr");
                sql.Append(" inner join servicios_servicios s on sr.idservicio=s.id");
                sql.Append(" where sr.idrol=@idrol");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("idrol", id);
                var connecion = ConnectionData.ConnectionSystem();
                servicios = connecion.Query<Servicios.Servicios>(sql.ToString(), parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return servicios;
        }
    }
}