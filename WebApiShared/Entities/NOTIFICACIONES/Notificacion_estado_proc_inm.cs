using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Notificacion_estado_proc_inm : DALBase
    {
        public int Nro_emision { get; set; }
        public DateTime Fecha_emision { get; set; }
        public int Cod_estado_procuracion { get; set; }
        public string Nvo_estado_procuracion { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public int Cantidad_reg { get; set; }
        public decimal Total { get; set; }
        public decimal Porcentaje { get; set; }

        public Notificacion_estado_proc_inm()
        {
            Nro_emision = 0;
            Fecha_emision = DateTime.Now;
            Cod_estado_procuracion = 0;
            Nvo_estado_procuracion = string.Empty;
            Fecha_vencimiento = DateTime.Now;
            Cantidad_reg = 0;
            Total = 0;
            Porcentaje = 0;
        }

        private static List<Notificacion_estado_proc_inm> mapeo(SqlDataReader dr)
        {
            List<Notificacion_estado_proc_inm> lst = new List<Notificacion_estado_proc_inm>();
            Notificacion_estado_proc_inm obj;
            if (dr.HasRows)
            {
                int Nro_emision = dr.GetOrdinal("Nro_emision");
                int Fecha_emision = dr.GetOrdinal("Fecha_emision");
                int Cod_estado_procuracion = dr.GetOrdinal("Cod_estado_procuracion");
                int Nvo_estado_procuracion = dr.GetOrdinal("Nvo_estado_procuracion");
                int Fecha_vencimiento = dr.GetOrdinal("Fecha_vencimiento");
                int Cantidad_reg = dr.GetOrdinal("Cantidad_reg");
                int Total = dr.GetOrdinal("Total");
                int Porcentaje = dr.GetOrdinal("Porcentaje");
                while (dr.Read())
                {
                    obj = new Notificacion_estado_proc_inm();
                    if (!dr.IsDBNull(Nro_emision)) { obj.Nro_emision = dr.GetInt32(Nro_emision); }
                    if (!dr.IsDBNull(Fecha_emision)) { obj.Fecha_emision = dr.GetDateTime(Fecha_emision); }
                    if (!dr.IsDBNull(Cod_estado_procuracion)) { obj.Cod_estado_procuracion = dr.GetInt32(Cod_estado_procuracion); }
                    if (!dr.IsDBNull(Nvo_estado_procuracion)) { obj.Nvo_estado_procuracion = dr.GetString(Nvo_estado_procuracion); }
                    if (!dr.IsDBNull(Fecha_vencimiento)) { obj.Fecha_vencimiento = dr.GetDateTime(Fecha_vencimiento); }
                    if (!dr.IsDBNull(Cantidad_reg)) { obj.Cantidad_reg = dr.GetInt32(Cantidad_reg); }
                    if (!dr.IsDBNull(Total)) { obj.Total = dr.GetDecimal(Total); }
                    if (!dr.IsDBNull(Porcentaje)) { obj.Porcentaje = dr.GetDecimal(Porcentaje); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Notificacion_estado_proc_inm> ListarNotifProcInm()
        {
            try
            {
                List<Notificacion_estado_proc_inm> lst = new List<Notificacion_estado_proc_inm>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Notificacion_estado_proc_inm order by nro_emision desc";
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

    

        //public static Notificacion_estado_proc_inm getByPk(
        //int Nro_emision, Datetime Fecha_emision)
        //{
        //    try
        //    {
        //        StringBuilder sql = new StringBuilder();
        //        sql.AppendLine("SELECT *FROM Notificacion_estado_proc_inm WHERE");
        //        sql.AppendLine("Nro_emision = @Nro_emision");
        //        sql.AppendLine("AND Fecha_emision = @Fecha_emision");
        //        Notificacion_estado_proc_inm obj = null;
        //        using (SqlConnection con = GetConnection())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = sql.ToString();
        //            cmd.Parameters.AddWithValue("@Nro_emision", Nro_emision);
        //            cmd.Parameters.AddWithValue("@Fecha_emision", Fecha_emision);
        //            cmd.Connection.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            List<Notificacion_estado_proc_inm> lst = mapeo(dr);
        //            if (lst.Count != 0)
        //                obj = lst[0];
        //        }
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static int insert(Notificacion_estado_proc_inm obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Notificacion_estado_proc_inm(");
                sql.AppendLine("Nro_emision");
                sql.AppendLine(", Fecha_emision");
                sql.AppendLine(", Cod_estado_procuracion");
                sql.AppendLine(", Nvo_estado_procuracion");
                sql.AppendLine(", Fecha_vencimiento");
                sql.AppendLine(", Cantidad_reg");
                sql.AppendLine(", Total");
                sql.AppendLine(", Porcentaje");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nro_emision");
                sql.AppendLine(", @Fecha_emision");
                sql.AppendLine(", @Cod_estado_procuracion");
                sql.AppendLine(", @Nvo_estado_procuracion");
                sql.AppendLine(", @Fecha_vencimiento");
                sql.AppendLine(", @Cantidad_reg");
                sql.AppendLine(", @Total");
                sql.AppendLine(", @Porcentaje");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Fecha_emision", obj.Fecha_emision);
                    cmd.Parameters.AddWithValue("@Cod_estado_procuracion", obj.Cod_estado_procuracion);
                    cmd.Parameters.AddWithValue("@Nvo_estado_procuracion", obj.Nvo_estado_procuracion);
                    cmd.Parameters.AddWithValue("@Fecha_vencimiento", obj.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@Cantidad_reg", obj.Cantidad_reg);
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

        public static void update(Notificacion_estado_proc_inm obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Notificacion_estado_proc_inm SET");
                sql.AppendLine("Cod_estado_procuracion=@Cod_estado_procuracion");
                sql.AppendLine(", Nvo_estado_procuracion=@Nvo_estado_procuracion");
                sql.AppendLine(", Fecha_vencimiento=@Fecha_vencimiento");
                sql.AppendLine(", Cantidad_reg=@Cantidad_reg");
                sql.AppendLine(", Total=@Total");
                sql.AppendLine(", Porcentaje=@Porcentaje");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_emision=@Nro_emision");
                sql.AppendLine("AND Fecha_emision=@Fecha_emision");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Fecha_emision", obj.Fecha_emision);
                    cmd.Parameters.AddWithValue("@Cod_estado_procuracion", obj.Cod_estado_procuracion);
                    cmd.Parameters.AddWithValue("@Nvo_estado_procuracion", obj.Nvo_estado_procuracion);
                    cmd.Parameters.AddWithValue("@Fecha_vencimiento", obj.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@Cantidad_reg", obj.Cantidad_reg);
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

        public static void delete(Notificacion_estado_proc_inm obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Notificacion_estado_proc_inm ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_emision=@Nro_emision");
                sql.AppendLine("AND Fecha_emision=@Fecha_emision");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Fecha_emision", obj.Fecha_emision);
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

    public class Datetime
    {
    }
}

