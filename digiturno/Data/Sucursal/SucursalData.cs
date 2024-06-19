using Dapper;
using digiturno.Data.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digiturno.Data.Sucursal
{
    public class SucursalData
    {
        public static Sucursal ObtenerPorId(int id) {
            Sucursal sucursal = null;
            try
            {
                StringBuilder sql= new StringBuilder();
                sql.Append("select id,nombre,esactiva,codigo from usuarios_sucursal");
                sql.Append(" where id=@idsucursal");
                DynamicParameters parametros=new DynamicParameters();
                parametros.Add("idsucursal",id);
                var connecion = ConnectionData.ConnectionSystem();
                sucursal = connecion.QueryFirstOrDefault<Sucursal>(sql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                throw;
            }
            return sucursal;
        }
    }
}