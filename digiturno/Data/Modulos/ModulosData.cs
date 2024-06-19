using Dapper;
using digiturno.Data.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digiturno.Data.ModulosData
{
    public class ModulosData
    {
        public static Modulos ObtenerPorId(int id)
        {
            Modulos modulo = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select id,nombre,idsucursal,esactivo from turnos_modulos");
                sql.Append(" where id=@id");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("id", id);
                var connecion = ConnectionData.ConnectionSystem();
                modulo = connecion.QueryFirstOrDefault<Modulos>(sql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                throw;
            }
            return modulo;
        }
    }
}