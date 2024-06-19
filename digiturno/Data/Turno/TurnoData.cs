using Dapper;
using digiturno.Data.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace digiturno.Data.Turno
{
    public class TurnoData
    {

        public static Turno ObtenerPorId(int id)
        {
            Turno turno = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select id,idsucursal,idservicio,idmodulo,consecutivo,cedular,esllamado,nosepresento,atendido from turnos_turnos");
                sql.Append(" where id=@id");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("id", id);
                var connection = ConnectionData.ConnectionSystem();
                turno = connection.QueryFirstOrDefault<Turno>(sql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return turno;
        }

        public static List<Turno> ObtenerRegistros()
        {
            List<Turno> turnos = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select id,idsucursal,idservicio,idmodulo,consecutivo,cedular,esllamado,nosepresento,atendido from turnos_turnos");
                var connection = ConnectionData.ConnectionSystem();
                turnos = connection.Query<Turno>(sql.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return turnos;
        }

        public static Turno Insertar(Turno turno) {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("insert into turnos_turnos(id,idsucursal,idservicio,idmodulo,consecutivo,cedular,esllamado,nosepresento,atendido) values(@id,@idsucursal,@idservicio,@idmodulo,@consecutivo,@cedular,@esllamado,@nosepresento,@atendido)");
                var connection = ConnectionData.ConnectionSystem();
                int id = connection.ExecuteScalar<int>("select nextval('turnos_turnos_id_seq'::regclass)");
                turno.Id= id;
                connection.Execute(sql.ToString(),turno);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return turno;
        }

        public static void Actualizar(Turno turno) {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("update turnos_turnos set ");
                sql.Append("idsucursal=@idsucursal,");
                sql.Append("idservicio=@idservicio,");
                sql.Append("idmodulo=@idmodulo,");
                sql.Append("consecutivo=@consecutivo,");
                sql.Append("cedular=@cedular,");
                sql.Append("esllamado=@esllamado,");
                sql.Append("nosepresento=@nosepresento,");
                sql.Append("atendido=@atendido ");
                sql.Append("where id=@id");
                var connection = ConnectionData.ConnectionSystem();
                connection.Execute(sql.ToString(), turno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ObtenerConsecutivo(int idsucursal,int idservicio) {
            int consecutivo = 0;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select coalesce(max(consecutivo),0) from turnos_turnos where esllamado=false and atendido=false and idsucursal=@idsucursal and idservicio=@idservicio");
                DynamicParameters parametros=new DynamicParameters();
                parametros.Add("idsucursal",idsucursal);
                parametros.Add("idservicio", idservicio);
                var connection = ConnectionData.ConnectionSystem();
                consecutivo = connection.ExecuteScalar<int>(sql.ToString(),parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return consecutivo;
        }

        public static Turno ObtenerTurnoPorSucursalServicio(int idsucursal, int idservicio) {
            Turno turno = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select id,idsucursal,idservicio,idmodulo,consecutivo,cedular,esllamado,nosepresento,atendido from turnos_turnos where esllamado=false and atendido=false and idsucursal=@idsucursal and idservicio=@idservicio order by consecutivo asc");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("idsucursal", idsucursal);
                parametros.Add("idservicio", idservicio);
                var connection = ConnectionData.ConnectionSystem();
                turno = connection.QueryFirstOrDefault<Turno>(sql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return turno;
        }

        public static Turno ObtenerPorClienteCedula(string cedula)
        {
            Turno turno = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select id,idsucursal,idservicio,idmodulo,consecutivo,cedular,esllamado,nosepresento,atendido from turnos_turnos");
                sql.Append(" where cedular=@cedular");
                sql.Append(" and esllamado=false and atendido=false");
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("cedular", cedula);
                var connection = ConnectionData.ConnectionSystem();
                turno = connection.QueryFirstOrDefault<Turno>(sql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return turno;
        }
    }
}