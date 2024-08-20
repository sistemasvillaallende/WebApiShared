using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiShared.Entities;

namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Notificacion_iyc : DALBase
    {
        public int Nro_emision { get; set; }
        public string Descripcion_noti { get; set; }
        public DateTime Fecha_emision { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public int Cantidad_reg { get; set; }
        public int Cod_estado_noti { get; set; }
        public int Categoria_deuda { get; set; }
        public bool ConPlan { get; set; }
        public int CantCuotas { get; set; }
        public bool ConDeuda { get; set; }
        public decimal Total_adeudado { get; set; }
        public Int16 Cod_tipo_procuracion { get; set; }
        public bool Bloqueado { get; set; }
        public Int16 Codigo_procurador { get; set; }
        public bool TieneHonorarios { get; set; }
        public Int16 Tipo_descuento { get; set; }
        public Int16 Cod_formulario { get; set; }
        public Int16 Deuda_sin_interes { get; set; }
        public DateTime Fecha_desde { get; set; }
        public DateTime Fecha_hasta { get; set; }
        public decimal Porcentaje { get; set; }

        public Notificacion_iyc()
        {
            Nro_emision = 0;
            Descripcion_noti = string.Empty;
            Fecha_emision = DateTime.Now;
            Fecha_vencimiento = DateTime.Now;
            Cantidad_reg = 0;
            Cod_estado_noti = 0;
            Categoria_deuda = 0;
            ConPlan = false;
            CantCuotas = 0;
            ConDeuda = false;
            Total_adeudado = 0;
            Cod_tipo_procuracion = 0;
            Bloqueado = false;
            Codigo_procurador = 0;
            TieneHonorarios = false;
            Tipo_descuento = 0;
            Cod_formulario = 0;
            Deuda_sin_interes = 0;
            Fecha_desde = DateTime.Now;
            Fecha_hasta = DateTime.Now;
            Porcentaje = 0;
        }

        private static List<Notificacion_iyc> mapeo(SqlDataReader dr)
        {
            List<Notificacion_iyc> lst = new List<Notificacion_iyc>();
            Notificacion_iyc obj;
            if (dr.HasRows)
            {
                int Nro_emision = dr.GetOrdinal("Nro_emision");
                //int Descripcion_noti = dr.GetOrdinal("Descripcion_noti");
                int Fecha_emision = dr.GetOrdinal("Fecha_emision");
                int Fecha_vencimiento = dr.GetOrdinal("Fecha_vencimiento");
                int Cantidad_reg = dr.GetOrdinal("Cantidad_reg");
                //int Cod_estado_noti = dr.GetOrdinal("Cod_estado_noti");
                //int Categoria_deuda = dr.GetOrdinal("Categoria_deuda");
                //int ConPlan = dr.GetOrdinal("ConPlan");
                //int CantCuotas = dr.GetOrdinal("CantCuotas");
                //int ConDeuda = dr.GetOrdinal("ConDeuda");
                int Total_adeudado = dr.GetOrdinal("Total_adeudado");
                //int Cod_tipo_procuracion = dr.GetOrdinal("Cod_tipo_procuracion");
                //int Bloqueado = dr.GetOrdinal("Bloqueado");
                //int Codigo_procurador = dr.GetOrdinal("Codigo_procurador");
                //int TieneHonorarios = dr.GetOrdinal("TieneHonorarios");
                //int Tipo_descuento = dr.GetOrdinal("Tipo_descuento");
                //int Cod_formulario = dr.GetOrdinal("Cod_formulario");
                //int Deuda_sin_interes = dr.GetOrdinal("Deuda_sin_interes");
                //int Fecha_desde = dr.GetOrdinal("Fecha_desde");
                //int Fecha_hasta = dr.GetOrdinal("Fecha_hasta");
                //int Porcentaje = dr.GetOrdinal("Porcentaje");
                while (dr.Read())
                {
                    obj = new Notificacion_iyc();
                    if (!dr.IsDBNull(Nro_emision)) { obj.Nro_emision = dr.GetInt32(Nro_emision); }
                    //if (!dr.IsDBNull(Descripcion_noti)) { obj.Descripcion_noti = dr.GetString(Descripcion_noti); }
                    if (!dr.IsDBNull(Fecha_emision)) { obj.Fecha_emision = dr.GetDateTime(Fecha_emision); }
                    if (!dr.IsDBNull(Fecha_vencimiento)) { obj.Fecha_vencimiento = dr.GetDateTime(Fecha_vencimiento); }
                    if (!dr.IsDBNull(Cantidad_reg)) { obj.Cantidad_reg = dr.GetInt32(Cantidad_reg); }
                    //if (!dr.IsDBNull(Cod_estado_noti)) { obj.Cod_estado_noti = dr.GetInt32(Cod_estado_noti); }
                    //if (!dr.IsDBNull(Categoria_deuda)) { obj.Categoria_deuda = dr.GetInt32(Categoria_deuda); }
                    //if (!dr.IsDBNull(ConPlan)) { obj.ConPlan = dr.GetBoolean(ConPlan); }
                    //if (!dr.IsDBNull(CantCuotas)) { obj.CantCuotas = dr.GetInt32(CantCuotas); }
                    //if (!dr.IsDBNull(ConDeuda)) { obj.ConDeuda = dr.GetBoolean(ConDeuda); }
                    if (!dr.IsDBNull(Total_adeudado)) { obj.Total_adeudado = dr.GetDecimal(Total_adeudado); }
                    //if (!dr.IsDBNull(Cod_tipo_procuracion)) { obj.Cod_tipo_procuracion = dr.GetInt16(Cod_tipo_procuracion); }
                    //if (!dr.IsDBNull(Bloqueado)) { obj.Bloqueado = dr.GetBoolean(Bloqueado); }
                    //if (!dr.IsDBNull(Codigo_procurador)) { obj.Codigo_procurador = dr.GetInt16(Codigo_procurador); }
                    //if (!dr.IsDBNull(TieneHonorarios)) { obj.TieneHonorarios = dr.GetBoolean(TieneHonorarios); }
                    //if (!dr.IsDBNull(Tipo_descuento)) { obj.Tipo_descuento = dr.GetInt16(Tipo_descuento); }
                    //if (!dr.IsDBNull(Cod_formulario)) { obj.Cod_formulario = dr.GetInt16(Cod_formulario); }
                    //if (!dr.IsDBNull(Deuda_sin_interes)) { obj.Deuda_sin_interes = dr.GetInt16(Deuda_sin_interes); }
                    //if (!dr.IsDBNull(Fecha_desde)) { obj.Fecha_desde = dr.GetDateTime(Fecha_desde); }
                    //if (!dr.IsDBNull(Fecha_hasta)) { obj.Fecha_hasta = dr.GetDateTime(Fecha_hasta); }
                    //if (!dr.IsDBNull(Porcentaje)) { obj.Porcentaje = dr.GetDecimal(Porcentaje); }
                    lst.Add(obj);
                }
            }
                return lst;
        }

        public static List<Notificacion_iyc> read()
        {
            try
            {
                List<Notificacion_iyc> lst = new List<Notificacion_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT 
                                            Nro_emision, 
                                            Fecha_emision, 
                                            0 AS Cod_Estado_procuracion, 
                                            'NOTIFICACION EMITIDA' AS Nvo_Estado_Procuracion, 
                                            Fecha_vencimiento, 
                                            Cantidad_reg, 
                                            Total_adeudado, 
                                            Porcentaje 
                                        FROM Notificacion_iyc 
                                        ORDER BY Fecha_emision desc";
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

        public static Notificacion_iyc getByPk(int nro_emision)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Notificacion_iyc WHERE");
                sql.AppendLine("Nro_emision = @Nro_emision");
                Notificacion_iyc obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", nro_emision);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Notificacion_iyc> lst = mapeo(dr);
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

        public static int insert(Notificacion_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Notificacion_iyc(");
                sql.AppendLine("Nro_emision");
                sql.AppendLine(", Descripcion_noti");
                sql.AppendLine(", Fecha_emision");
                sql.AppendLine(", Fecha_vencimiento");
                sql.AppendLine(", Cantidad_reg");
                sql.AppendLine(", Cod_estado_noti");
                sql.AppendLine(", Categoria_deuda");
                sql.AppendLine(", ConPlan");
                sql.AppendLine(", CantCuotas");
                sql.AppendLine(", ConDeuda");
                sql.AppendLine(", Total_adeudado");
                sql.AppendLine(", Cod_tipo_procuracion");
                sql.AppendLine(", Bloqueado");
                sql.AppendLine(", Codigo_procurador");
                sql.AppendLine(", TieneHonorarios");
                sql.AppendLine(", Tipo_descuento");
                sql.AppendLine(", Cod_formulario");
                sql.AppendLine(", Deuda_sin_interes");
                sql.AppendLine(", Fecha_desde");
                sql.AppendLine(", Fecha_hasta");
                sql.AppendLine(", Porcentaje");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nro_emision");
                sql.AppendLine(", @Descripcion_noti");
                sql.AppendLine(", @Fecha_emision");
                sql.AppendLine(", @Fecha_vencimiento");
                sql.AppendLine(", @Cantidad_reg");
                sql.AppendLine(", @Cod_estado_noti");
                sql.AppendLine(", @Categoria_deuda");
                sql.AppendLine(", @ConPlan");
                sql.AppendLine(", @CantCuotas");
                sql.AppendLine(", @ConDeuda");
                sql.AppendLine(", @Total_adeudado");
                sql.AppendLine(", @Cod_tipo_procuracion");
                sql.AppendLine(", @Bloqueado");
                sql.AppendLine(", @Codigo_procurador");
                sql.AppendLine(", @TieneHonorarios");
                sql.AppendLine(", @Tipo_descuento");
                sql.AppendLine(", @Cod_formulario");
                sql.AppendLine(", @Deuda_sin_interes");
                sql.AppendLine(", @Fecha_desde");
                sql.AppendLine(", @Fecha_hasta");
                sql.AppendLine(", @Porcentaje");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Descripcion_noti", obj.Descripcion_noti);
                    cmd.Parameters.AddWithValue("@Fecha_emision", obj.Fecha_emision);
                    cmd.Parameters.AddWithValue("@Fecha_vencimiento", obj.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@Cantidad_reg", obj.Cantidad_reg);
                    cmd.Parameters.AddWithValue("@Cod_estado_noti", obj.Cod_estado_noti);
                    cmd.Parameters.AddWithValue("@Categoria_deuda", obj.Categoria_deuda);
                    cmd.Parameters.AddWithValue("@ConPlan", obj.ConPlan);
                    cmd.Parameters.AddWithValue("@CantCuotas", obj.CantCuotas);
                    cmd.Parameters.AddWithValue("@ConDeuda", obj.ConDeuda);
                    cmd.Parameters.AddWithValue("@Total_adeudado", obj.Total_adeudado);
                    cmd.Parameters.AddWithValue("@Cod_tipo_procuracion", obj.Cod_tipo_procuracion);
                    cmd.Parameters.AddWithValue("@Bloqueado", obj.Bloqueado);
                    cmd.Parameters.AddWithValue("@Codigo_procurador", obj.Codigo_procurador);
                    cmd.Parameters.AddWithValue("@TieneHonorarios", obj.TieneHonorarios);
                    cmd.Parameters.AddWithValue("@Tipo_descuento", obj.Tipo_descuento);
                    cmd.Parameters.AddWithValue("@Cod_formulario", obj.Cod_formulario);
                    cmd.Parameters.AddWithValue("@Deuda_sin_interes", obj.Deuda_sin_interes);
                    cmd.Parameters.AddWithValue("@Fecha_desde", obj.Fecha_desde);
                    cmd.Parameters.AddWithValue("@Fecha_hasta", obj.Fecha_hasta);
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

        public static void update(Notificacion_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Notificacion_iyc SET");
                sql.AppendLine("Descripcion_noti=@Descripcion_noti");
                sql.AppendLine(", Fecha_emision=@Fecha_emision");
                sql.AppendLine(", Fecha_vencimiento=@Fecha_vencimiento");
                sql.AppendLine(", Cantidad_reg=@Cantidad_reg");
                sql.AppendLine(", Cod_estado_noti=@Cod_estado_noti");
                sql.AppendLine(", Categoria_deuda=@Categoria_deuda");
                sql.AppendLine(", ConPlan=@ConPlan");
                sql.AppendLine(", CantCuotas=@CantCuotas");
                sql.AppendLine(", ConDeuda=@ConDeuda");
                sql.AppendLine(", Total_adeudado=@Total_adeudado");
                sql.AppendLine(", Cod_tipo_procuracion=@Cod_tipo_procuracion");
                sql.AppendLine(", Bloqueado=@Bloqueado");
                sql.AppendLine(", Codigo_procurador=@Codigo_procurador");
                sql.AppendLine(", TieneHonorarios=@TieneHonorarios");
                sql.AppendLine(", Tipo_descuento=@Tipo_descuento");
                sql.AppendLine(", Cod_formulario=@Cod_formulario");
                sql.AppendLine(", Deuda_sin_interes=@Deuda_sin_interes");
                sql.AppendLine(", Fecha_desde=@Fecha_desde");
                sql.AppendLine(", Fecha_hasta=@Fecha_hasta");
                sql.AppendLine(", Porcentaje=@Porcentaje");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_emision=@Nro_emision");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Descripcion_noti", obj.Descripcion_noti);
                    cmd.Parameters.AddWithValue("@Fecha_emision", obj.Fecha_emision);
                    cmd.Parameters.AddWithValue("@Fecha_vencimiento", obj.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@Cantidad_reg", obj.Cantidad_reg);
                    cmd.Parameters.AddWithValue("@Cod_estado_noti", obj.Cod_estado_noti);
                    cmd.Parameters.AddWithValue("@Categoria_deuda", obj.Categoria_deuda);
                    cmd.Parameters.AddWithValue("@ConPlan", obj.ConPlan);
                    cmd.Parameters.AddWithValue("@CantCuotas", obj.CantCuotas);
                    cmd.Parameters.AddWithValue("@ConDeuda", obj.ConDeuda);
                    cmd.Parameters.AddWithValue("@Total_adeudado", obj.Total_adeudado);
                    cmd.Parameters.AddWithValue("@Cod_tipo_procuracion", obj.Cod_tipo_procuracion);
                    cmd.Parameters.AddWithValue("@Bloqueado", obj.Bloqueado);
                    cmd.Parameters.AddWithValue("@Codigo_procurador", obj.Codigo_procurador);
                    cmd.Parameters.AddWithValue("@TieneHonorarios", obj.TieneHonorarios);
                    cmd.Parameters.AddWithValue("@Tipo_descuento", obj.Tipo_descuento);
                    cmd.Parameters.AddWithValue("@Cod_formulario", obj.Cod_formulario);
                    cmd.Parameters.AddWithValue("@Deuda_sin_interes", obj.Deuda_sin_interes);
                    cmd.Parameters.AddWithValue("@Fecha_desde", obj.Fecha_desde);
                    cmd.Parameters.AddWithValue("@Fecha_hasta", obj.Fecha_hasta);
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

        public static void delete(Notificacion_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Notificacion_iyc ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_emision=@Nro_emision");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
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

