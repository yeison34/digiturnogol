using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digiturno.Data.Usuarios
{
    public class UsuariosData
    {

        public static Usuarios GetUsuarioPorUsuarioYContrasena(string usuario,string contrasena)
        {
            Usuarios usuariomodel = null;
            try { 
                StringBuilder sql=new StringBuilder();
                sql.Append("select id,usuario,contrasena from usuarios_usuario");
                sql.Append(" where usuario=@usuario and contrasena=@contrasena");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("usuario",usuario);
                parametros.Add("contrasena",contrasena);
                var connection = Connection.ConnectionData.ConnectionSystem();
                usuariomodel = connection.QueryFirstOrDefault<Usuarios>(sql.ToString(), parametros);
            }catch(Exception ex) {
                throw ex;
            }
            return usuariomodel;
        }

        public static Usuarios GetUsuarioPorId(string idusuario)
        {
            Usuarios usuariomodel = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select id,usuario,contrasena from usuarios_usuario");
                sql.Append(" where id=@id");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("id", idusuario);
                var connection = Connection.ConnectionData.ConnectionSystem();
                usuariomodel = connection.QueryFirstOrDefault<Usuarios>(sql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuariomodel;
        }
    }
}