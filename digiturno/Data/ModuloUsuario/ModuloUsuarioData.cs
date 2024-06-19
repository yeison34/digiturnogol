using Dapper;
using digiturno.Data.Connection;
using digiturno.Data.ModulosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digiturno.Data.ModuloUsuario
{
    public class ModuloUsuarioData
    {
        public static Modulos ObtenerModuloPorIdUsuario(string idusuario)
        {
            Modulos modulo = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select tm.id,tm.nombre,tm.idsucursal,tm.esactivo from turnos_modulousuario mu");
                sql.Append(" inner join turnos_modulos tm");
                sql.Append(" on mu.idmodulo=tm.id");
                sql.Append(" where mu.idusuario=@idusuario and mu.esactivo=true and tm.esactivo=true");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("idusuario", idusuario);
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