using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using WebApiShared.Entities.NOTIFICACIONES;
using WebApiShared.Helpers;

namespace WebApiShared.Entities.LOGIN
{
    public class Permisos : DALBase
    {
        public int cod_proceso { get; set; }

        public string descripcion { get; set; }

        public Permisos()
        {
            cod_proceso = 0;
            descripcion = string.Empty;
           
        }


        private static List<Permisos> mapeo(SqlDataReader dr)
        {
            List<Permisos> lst = new List<Permisos>();
            Permisos obj;
            if (dr.HasRows)
            {
                int cod_proceso = dr.GetOrdinal("cod_proceso");
                int descripcion = dr.GetOrdinal("descripcion");
                while (dr.Read())
                {
                    obj = new Permisos();
                    if (!dr.IsDBNull(cod_proceso)) { obj.cod_proceso = dr.GetInt32(cod_proceso); }
                    if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }  
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Permisos> GetPermisosCidi(int cod_usuario)
        {
            try
            {
                List<Permisos> lst = new List<Permisos>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @" select p.COD_PROCESO,p2.PROCESO as descripcion
                                         from PROCESOS_X_USUARIO_V2 p left join PROCESOS_V2 p2 on p2.COD_PROCESO=p.COD_PROCESO
                                         where p.COD_USUARIO=110 and p.COD_PROCESO
                                         in (select t.cod_permiso from TIPO_NOTIF_DIGITAL t) ";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
