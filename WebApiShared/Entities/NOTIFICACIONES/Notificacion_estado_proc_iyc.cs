using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Notificacion_estado_proc_iyc : DALBase
    {
        public int Nro_Emision { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public int Cod_Estado_Procuracion { get; set; }
        public string Nvo_Estado_Procuracion { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public int Cantidad_Reg { get; set; }
        public decimal Total { get; set; }
        public decimal Porcentaje { get; set; }

        public Notificacion_estado_proc_iyc()
        {
            Nro_Emision = 0;
            Fecha_Emision = DateTime.Now;
            Cod_Estado_Procuracion = 0;
            Nvo_Estado_Procuracion = string.Empty;
            Fecha_Vencimiento = DateTime.Now;
            Cantidad_Reg = 0;
            Total = 0;
            Porcentaje = 0;
        }

        private static List<Notificacion_estado_proc_iyc> mapeo(SqlDataReader dr)
        {
            List<Notificacion_estado_proc_iyc> lst = new List<Notificacion_estado_proc_iyc>();
            Notificacion_estado_proc_iyc obj;
            if (dr.HasRows)
            {
                int Nro_Emision = dr.GetOrdinal("Nro_Emision");
                int Fecha_Emision = dr.GetOrdinal("Fecha_Emision");
                int Cod_Estado_Procuracion = dr.GetOrdinal("Cod_Estado_Procuracion");
                int Nvo_Estado_Procuracion = dr.GetOrdinal("Nvo_Estado_Procuracion");
                int Fecha_Vencimiento = dr.GetOrdinal("Fecha_Vencimiento");
                int Cantidad_Reg = dr.GetOrdinal("Cantidad_Reg");
                int Total = dr.GetOrdinal("Total");
                int Porcentaje = dr.GetOrdinal("Porcentaje");
                while (dr.Read())
                {
                    obj = new Notificacion_estado_proc_iyc();
                    if (!dr.IsDBNull(Nro_Emision)) { obj.Nro_Emision = dr.GetInt32(Nro_Emision); }
                    if (!dr.IsDBNull(Fecha_Emision)) { obj.Fecha_Emision = dr.GetDateTime(Fecha_Emision); }
                    if (!dr.IsDBNull(Cod_Estado_Procuracion)) { obj.Cod_Estado_Procuracion = dr.GetInt32(Cod_Estado_Procuracion); }
                    if (!dr.IsDBNull(Nvo_Estado_Procuracion)) { obj.Nvo_Estado_Procuracion = dr.GetString(Nvo_Estado_Procuracion); }
                    if (!dr.IsDBNull(Fecha_Vencimiento)) { obj.Fecha_Vencimiento = dr.GetDateTime(Fecha_Vencimiento); }
                    if (!dr.IsDBNull(Cantidad_Reg)) { obj.Cantidad_Reg = dr.GetInt32(Cantidad_Reg); }
                    if (!dr.IsDBNull(Total)) { obj.Total = dr.GetDecimal(Total); }
                    if (!dr.IsDBNull(Porcentaje)) { obj.Porcentaje = dr.GetDecimal(Porcentaje); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Notificacion_estado_proc_iyc> ListarNotifProcIyc()
        {
            try
            {
                List<Notificacion_estado_proc_iyc> lst = new List<Notificacion_estado_proc_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Notificacion_estado_proc_iyc order by nro_emision desc";
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

        public static Notificacion_estado_proc_iyc getByPk(
        int Nro_Emision)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Notificacion_estado_proc_iyc WHERE");
                sql.AppendLine("Nro_Emision = @Nro_Emision");
                Notificacion_estado_proc_iyc obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_Emision", Nro_Emision);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Notificacion_estado_proc_iyc> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(Notificacion_estado_proc_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Notificacion_estado_proc_iyc(");
                sql.AppendLine("Nro_Emision");
                sql.AppendLine(", Fecha_Emision");
                sql.AppendLine(", Cod_Estado_Procuracion");
                sql.AppendLine(", Nvo_Estado_Procuracion");
                sql.AppendLine(", Fecha_Vencimiento");
                sql.AppendLine(", Cantidad_Reg");
                sql.AppendLine(", Total");
                sql.AppendLine(", Porcentaje");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nro_Emision");
                sql.AppendLine(", @Fecha_Emision");
                sql.AppendLine(", @Cod_Estado_Procuracion");
                sql.AppendLine(", @Nvo_Estado_Procuracion");
                sql.AppendLine(", @Fecha_Vencimiento");
                sql.AppendLine(", @Cantidad_Reg");
                sql.AppendLine(", @Total");
                sql.AppendLine(", @Porcentaje");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_Emision", obj.Nro_Emision);
                    cmd.Parameters.AddWithValue("@Fecha_Emision", obj.Fecha_Emision);
                    cmd.Parameters.AddWithValue("@Cod_Estado_Procuracion", obj.Cod_Estado_Procuracion);
                    cmd.Parameters.AddWithValue("@Nvo_Estado_Procuracion", obj.Nvo_Estado_Procuracion);
                    cmd.Parameters.AddWithValue("@Fecha_Vencimiento", obj.Fecha_Vencimiento);
                    cmd.Parameters.AddWithValue("@Cantidad_Reg", obj.Cantidad_Reg);
                    cmd.Parameters.AddWithValue("@Total", obj.Total);
                    cmd.Parameters.AddWithValue("@Porcentaje", obj.Porcentaje);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Notificacion_estado_proc_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Notificacion_estado_proc_iyc SET");
                sql.AppendLine("Fecha_Emision=@Fecha_Emision");
                sql.AppendLine(", Cod_Estado_Procuracion=@Cod_Estado_Procuracion");
                sql.AppendLine(", Nvo_Estado_Procuracion=@Nvo_Estado_Procuracion");
                sql.AppendLine(", Fecha_Vencimiento=@Fecha_Vencimiento");
                sql.AppendLine(", Cantidad_Reg=@Cantidad_Reg");
                sql.AppendLine(", Total=@Total");
                sql.AppendLine(", Porcentaje=@Porcentaje");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_Emision=@Nro_Emision");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_Emision", obj.Nro_Emision);
                    cmd.Parameters.AddWithValue("@Fecha_Emision", obj.Fecha_Emision);
                    cmd.Parameters.AddWithValue("@Cod_Estado_Procuracion", obj.Cod_Estado_Procuracion);
                    cmd.Parameters.AddWithValue("@Nvo_Estado_Procuracion", obj.Nvo_Estado_Procuracion);
                    cmd.Parameters.AddWithValue("@Fecha_Vencimiento", obj.Fecha_Vencimiento);
                    cmd.Parameters.AddWithValue("@Cantidad_Reg", obj.Cantidad_Reg);
                    cmd.Parameters.AddWithValue("@Total", obj.Total);
                    cmd.Parameters.AddWithValue("@Porcentaje", obj.Porcentaje);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Notificacion_estado_proc_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Notificacion_estado_proc_iyc ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_Emision=@Nro_Emision");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_Emision", obj.Nro_Emision);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

