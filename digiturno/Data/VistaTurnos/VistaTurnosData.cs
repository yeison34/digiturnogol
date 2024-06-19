using Dapper;
using digiturno.Data.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digiturno.Data.VistaTurnos
{
    public class VistaTurnosData
    {

        public static List<VistaTurnos> ObtenerRegistros()
        {
            List<VistaTurnos> vistaturnos = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select idturno,idsucursal,idservicio,turno,cedular,servicio,sucursal,esllamado,nosepresento,atendido,idmodulo,modulo from turnos_vistaturnospendientes");
                var connection = ConnectionData.ConnectionSystem();
                vistaturnos = connection.Query<VistaTurnos>(sql.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vistaturnos;
        }
    }
}