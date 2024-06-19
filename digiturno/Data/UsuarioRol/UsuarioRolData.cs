using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digiturno.Data.UsuarioRol
{
    public class UsuarioRolData
    {
        public static List<UsuarioRol> GetRolesPorIdusuario(string idusuario)
        {
            List<UsuarioRol> usuariorol = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select idusuario,idrol from usuarios_usuariorol");
                sql.Append(" where idusuario=@usuario");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("usuario", idusuario);
                var connection = Connection.ConnectionData.ConnectionSystem();
                usuariorol = connection.Query<UsuarioRol>(sql.ToString(), parametros).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuariorol;
        }
    }
}