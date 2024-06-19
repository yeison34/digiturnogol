using Dapper;
using digiturno.Data.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digiturno.Data.Roles
{
    public class RolesData
    {
        public static Roles ObtenerPorId(int id)
        {
            Roles rol = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select id,nombre,esactivo from usuarios_roles");
                sql.Append(" where id=@idrol");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("idrol", id);
                var connecion = ConnectionData.ConnectionSystem();
                rol = connecion.QueryFirstOrDefault<Roles>(sql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                throw;
            }
            return rol;
        }
    }
}