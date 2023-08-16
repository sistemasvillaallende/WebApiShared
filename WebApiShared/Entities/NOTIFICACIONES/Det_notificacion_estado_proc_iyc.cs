using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Det_notificacion_estado_proc_iyc : DALBase
    {
        public int Nro_Emision { get; set; }
        public int Nro_Notificacion { get; set; }
        public int Nro_Procuracion { get; set; }
        public int Legajo { get; set; }
        public int Nro_Badec { get; set; }
        public string Nombre { get; set; }
        public string Estado_Actual { get; set; }
        public DateTime Fecha_Inicio_Estado { get; set; }
        public DateTime Fecha_Fin_Estado { get; set; }
        public DateTime vencimiento { get; set; }
        public int Nro_cedulon { get; set; }
        public decimal Debe { get; set; }
        public string Barcode39 { get; set; }
        public string Barcodeint25 { get; set; }
        public decimal Monto_original { get; set; }
        public decimal Interes { get; set; }
        public decimal Descuento { get; set; }
        public decimal Importe_pagar { get; set; }

        public string estado_Actualizado { get; set; }
        public string cuit { get; set; }
        public int notificado_cidi { get; set; }

        public Det_notificacion_estado_proc_iyc()
        {
            Nro_Emision = 0;
            Nro_Notificacion = 0;
            Nro_Procuracion = 0;
            Legajo = 0;
            Nro_Badec = 0;
            Nombre = string.Empty;
            Estado_Actual = string.Empty;
            Fecha_Inicio_Estado = DateTime.Now;
            Fecha_Fin_Estado = DateTime.Now;
            vencimiento = DateTime.Now;
            Nro_cedulon = 0;
            Debe = 0;
            Barcode39 = string.Empty;
            Barcodeint25 = string.Empty;
            Monto_original = 0;
            Interes = 0;
            Descuento = 0;
            Importe_pagar = 0;
            estado_Actualizado = string.Empty;
            cuit = string.Empty;
            notificado_cidi = 0;
        }

        private static List<Det_notificacion_estado_proc_iyc> mapeo(SqlDataReader dr)
        {
            List<Det_notificacion_estado_proc_iyc> lst = new List<Det_notificacion_estado_proc_iyc>();
            Det_notificacion_estado_proc_iyc obj;
            if (dr.HasRows)
            {
                int Nro_Emision = dr.GetOrdinal("Nro_Emision");
                int Nro_Notificacion = dr.GetOrdinal("Nro_Notificacion");
                int Nro_Procuracion = dr.GetOrdinal("Nro_Procuracion");
                int Legajo = dr.GetOrdinal("Legajo");
                int Nro_Badec = dr.GetOrdinal("Nro_Badec");
                int Nombre = dr.GetOrdinal("Nombre");
                int Estado_Actual = dr.GetOrdinal("Estado_Actual");
                int Fecha_Inicio_Estado = dr.GetOrdinal("Fecha_Inicio_Estado");
                int Fecha_Fin_Estado = dr.GetOrdinal("Fecha_Fin_Estado");
                int vencimiento = dr.GetOrdinal("vencimiento");
                int Nro_cedulon = dr.GetOrdinal("Nro_cedulon");
                int Debe = dr.GetOrdinal("Debe");
                int Barcode39 = dr.GetOrdinal("Barcode39");
                int Barcodeint25 = dr.GetOrdinal("Barcodeint25");
                int Monto_original = dr.GetOrdinal("Monto_original");
                int Interes = dr.GetOrdinal("Interes");
                int Descuento = dr.GetOrdinal("Descuento");
                int Importe_pagar = dr.GetOrdinal("Importe_pagar");
                int estado_Actualizado = dr.GetOrdinal("estado_Actualizado");
                int cuit = dr.GetOrdinal("cuit");
                int notificado_cidi = dr.GetOrdinal("notificado_cidi");
                while (dr.Read())
                {
                    obj = new Det_notificacion_estado_proc_iyc();
                    if (!dr.IsDBNull(Nro_Emision)) { obj.Nro_Emision = dr.GetInt32(Nro_Emision); }
                    if (!dr.IsDBNull(Nro_Notificacion)) { obj.Nro_Notificacion = dr.GetInt32(Nro_Notificacion); }
                    if (!dr.IsDBNull(Nro_Procuracion)) { obj.Nro_Procuracion = dr.GetInt32(Nro_Procuracion); }
                    if (!dr.IsDBNull(Legajo)) { obj.Legajo = dr.GetInt32(Legajo); }
                    if (!dr.IsDBNull(Nro_Badec)) { obj.Nro_Badec = dr.GetInt32(Nro_Badec); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(Estado_Actual)) { obj.Estado_Actual = dr.GetString(Estado_Actual); }
                    if (!dr.IsDBNull(Fecha_Inicio_Estado)) { obj.Fecha_Inicio_Estado = dr.GetDateTime(Fecha_Inicio_Estado); }
                    if (!dr.IsDBNull(Fecha_Fin_Estado)) { obj.Fecha_Fin_Estado = dr.GetDateTime(Fecha_Fin_Estado); }
                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                    if (!dr.IsDBNull(Nro_cedulon)) { obj.Nro_cedulon = dr.GetInt32(Nro_cedulon); }
                    if (!dr.IsDBNull(Debe)) { obj.Debe = dr.GetDecimal(Debe); }
                    if (!dr.IsDBNull(Barcode39)) { obj.Barcode39 = dr.GetString(Barcode39); }
                    if (!dr.IsDBNull(Barcodeint25)) { obj.Barcodeint25 = dr.GetString(Barcodeint25); }
                    if (!dr.IsDBNull(Monto_original)) { obj.Monto_original = dr.GetDecimal(Monto_original); }
                    if (!dr.IsDBNull(Interes)) { obj.Interes = dr.GetDecimal(Interes); }
                    if (!dr.IsDBNull(Descuento)) { obj.Descuento = dr.GetDecimal(Descuento); }
                    if (!dr.IsDBNull(Importe_pagar)) { obj.Importe_pagar = dr.GetDecimal(Importe_pagar); }
                    if (!dr.IsDBNull(estado_Actualizado)) { obj.estado_Actualizado = dr.GetString(estado_Actualizado).Trim(); }
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(notificado_cidi)) { obj.notificado_cidi = dr.GetInt16(notificado_cidi); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Det_notificacion_estado_proc_iyc> ListarDetalle(int nro_emision)
        {
            try
            {
                List<Det_notificacion_estado_proc_iyc> lst = new List<Det_notificacion_estado_proc_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @" SELECT
                      a.Nro_Emision,a.Nro_Notificacion,a.nro_procuracion,a.legajo,a.nro_badec,
                      a.nombre,a.Estado_Actual,a.Fecha_Inicio_Estado,a.Fecha_Fin_Estado, a.vencimiento,a.Nro_cedulon,
                      Debe=((SELECT SUM(DEBE)
		   	                    FROM CTASCTES_INDYCOM C
			                    JOIN DEUDAS_PROC_IYC D ON
				                    D.nro_procuracion=a.nro_procuracion AND
                                    D.nro_transaccion=C.nro_transaccion
                                     )) -
				                       (SELECT SUM(haber)
				                        FROM CTASCTES_INDYCOM C
				                        JOIN DEUDAS_PROC_IYC D ON
						                    D.nro_procuracion=a.nro_procuracion AND

						                    D.nro_transaccion=C.nro_transaccion) ,
                       a.Barcode39,a.Barcodeint25,a.Monto_original,a.interes, a.Descuento,a.Importe_pagar,
                       estado_Actualizado= (  SELECT ep.descripcion_estado
                                        FROM PROCURA_IYC pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo),b.cuit
                                       ,notificado_cidi=isnull( a.Notificado_cidi,0)
                    FROM DET_NOTIFICACION_ESTADO_PROC_IYC A (nolock)left join INDYCOM i ON i.legajo=A.Legajo
                    left join badec b  on b.NRO_BAD=a.Nro_Badec
                    WHERE
                    nro_emision=" + nro_emision.ToString();
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

        public static List<Det_notificacion_estado_proc_iyc> ListarDetallexEstado(int nro_emision, int cod_estado)
        {
            try
            {
                List<Det_notificacion_estado_proc_iyc> lst = new List<Det_notificacion_estado_proc_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @" SELECT
                      a.Nro_Emision,a.Nro_Notificacion,a.nro_procuracion,a.legajo,a.nro_badec,
                      a.nombre,a.Estado_Actual,a.Fecha_Inicio_Estado,a.Fecha_Fin_Estado, a.vencimiento,a.Nro_cedulon,
                      Debe=((SELECT SUM(DEBE)
		   	                    FROM CTASCTES_INDYCOM C
			                    JOIN DEUDAS_PROC_IYC D ON
				                    D.nro_procuracion=a.nro_procuracion AND
                                    D.nro_transaccion=C.nro_transaccion
                                     )) -
				                       (SELECT SUM(haber)
				                        FROM CTASCTES_INDYCOM C
				                        JOIN DEUDAS_PROC_IYC D ON
						                    D.nro_procuracion=a.nro_procuracion AND

						                    D.nro_transaccion=C.nro_transaccion) ,
                       a.Barcode39,a.Barcodeint25,a.Monto_original,a.interes, a.Descuento,a.Importe_pagar,
                       estado_Actualizado= (  SELECT ep.descripcion_estado
                                        FROM PROCURA_IYC pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo),b.cuit
                                       ,notificado_cidi=isnull( a.Notificado_cidi,0)
                    FROM DET_NOTIFICACION_ESTADO_PROC_IYC A (nolock)left join INDYCOM i ON i.legajo=A.Legajo
                    left join badec b  on b.NRO_BAD=a.Nro_Badec
                    WHERE
                    nro_emision=" + nro_emision.ToString() + @" AND (SELECT ep.codigo_estado
                    FROM PROCURA_IYC pa
                     JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                    AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo)=" + cod_estado.ToString();
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

        public static List<Det_notificacion_estado_proc_iyc> read()
        {
            try
            {
                List<Det_notificacion_estado_proc_iyc> lst = new List<Det_notificacion_estado_proc_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Det_notificacion_estado_proc_iyc";
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

        public static Det_notificacion_estado_proc_iyc getByPk(
        int Nro_Emision, int Nro_Notificacion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Det_notificacion_estado_proc_iyc WHERE");
                sql.AppendLine("Nro_Emision = @Nro_Emision");
                sql.AppendLine("AND Nro_Notificacion = @Nro_Notificacion");
                Det_notificacion_estado_proc_iyc obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_Emision", Nro_Emision);
                    cmd.Parameters.AddWithValue("@Nro_Notificacion", Nro_Notificacion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Det_notificacion_estado_proc_iyc> lst = mapeo(dr);
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

        public static int insert(Det_notificacion_estado_proc_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Det_notificacion_estado_proc_iyc(");
                sql.AppendLine("Nro_Emision");
                sql.AppendLine(", Nro_Notificacion");
                sql.AppendLine(", Nro_Procuracion");
                sql.AppendLine(", Legajo");
                sql.AppendLine(", Nro_Badec");
                sql.AppendLine(", Nombre");
                sql.AppendLine(", Estado_Actual");
                sql.AppendLine(", Fecha_Inicio_Estado");
                sql.AppendLine(", Fecha_Fin_Estado");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", Nro_cedulon");
                sql.AppendLine(", Debe");
                sql.AppendLine(", Barcode39");
                sql.AppendLine(", Barcodeint25");
                sql.AppendLine(", Monto_original");
                sql.AppendLine(", Interes");
                sql.AppendLine(", Descuento");
                sql.AppendLine(", Importe_pagar");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nro_Emision");
                sql.AppendLine(", @Nro_Notificacion");
                sql.AppendLine(", @Nro_Procuracion");
                sql.AppendLine(", @Legajo");
                sql.AppendLine(", @Nro_Badec");
                sql.AppendLine(", @Nombre");
                sql.AppendLine(", @Estado_Actual");
                sql.AppendLine(", @Fecha_Inicio_Estado");
                sql.AppendLine(", @Fecha_Fin_Estado");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @Nro_cedulon");
                sql.AppendLine(", @Debe");
                sql.AppendLine(", @Barcode39");
                sql.AppendLine(", @Barcodeint25");
                sql.AppendLine(", @Monto_original");
                sql.AppendLine(", @Interes");
                sql.AppendLine(", @Descuento");
                sql.AppendLine(", @Importe_pagar");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_Emision", obj.Nro_Emision);
                    cmd.Parameters.AddWithValue("@Nro_Notificacion", obj.Nro_Notificacion);
                    cmd.Parameters.AddWithValue("@Nro_Procuracion", obj.Nro_Procuracion);
                    cmd.Parameters.AddWithValue("@Legajo", obj.Legajo);
                    cmd.Parameters.AddWithValue("@Nro_Badec", obj.Nro_Badec);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Estado_Actual", obj.Estado_Actual);
                    cmd.Parameters.AddWithValue("@Fecha_Inicio_Estado", obj.Fecha_Inicio_Estado);
                    cmd.Parameters.AddWithValue("@Fecha_Fin_Estado", obj.Fecha_Fin_Estado);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@Nro_cedulon", obj.Nro_cedulon);
                    cmd.Parameters.AddWithValue("@Debe", obj.Debe);
                    cmd.Parameters.AddWithValue("@Barcode39", obj.Barcode39);
                    cmd.Parameters.AddWithValue("@Barcodeint25", obj.Barcodeint25);
                    cmd.Parameters.AddWithValue("@Monto_original", obj.Monto_original);
                    cmd.Parameters.AddWithValue("@Interes", obj.Interes);
                    cmd.Parameters.AddWithValue("@Descuento", obj.Descuento);
                    cmd.Parameters.AddWithValue("@Importe_pagar", obj.Importe_pagar);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Det_notificacion_estado_proc_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Det_notificacion_estado_proc_iyc SET");
                sql.AppendLine("Nro_Procuracion=@Nro_Procuracion");
                sql.AppendLine(", Legajo=@Legajo");
                sql.AppendLine(", Nro_Badec=@Nro_Badec");
                sql.AppendLine(", Nombre=@Nombre");
                sql.AppendLine(", Estado_Actual=@Estado_Actual");
                sql.AppendLine(", Fecha_Inicio_Estado=@Fecha_Inicio_Estado");
                sql.AppendLine(", Fecha_Fin_Estado=@Fecha_Fin_Estado");
                sql.AppendLine(", vencimiento=@vencimiento");
                sql.AppendLine(", Nro_cedulon=@Nro_cedulon");
                sql.AppendLine(", Debe=@Debe");
                sql.AppendLine(", Barcode39=@Barcode39");
                sql.AppendLine(", Barcodeint25=@Barcodeint25");
                sql.AppendLine(", Monto_original=@Monto_original");
                sql.AppendLine(", Interes=@Interes");
                sql.AppendLine(", Descuento=@Descuento");
                sql.AppendLine(", Importe_pagar=@Importe_pagar");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_Emision=@Nro_Emision");
                sql.AppendLine("AND Nro_Notificacion=@Nro_Notificacion");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_Emision", obj.Nro_Emision);
                    cmd.Parameters.AddWithValue("@Nro_Notificacion", obj.Nro_Notificacion);
                    cmd.Parameters.AddWithValue("@Nro_Procuracion", obj.Nro_Procuracion);
                    cmd.Parameters.AddWithValue("@Legajo", obj.Legajo);
                    cmd.Parameters.AddWithValue("@Nro_Badec", obj.Nro_Badec);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Estado_Actual", obj.Estado_Actual);
                    cmd.Parameters.AddWithValue("@Fecha_Inicio_Estado", obj.Fecha_Inicio_Estado);
                    cmd.Parameters.AddWithValue("@Fecha_Fin_Estado", obj.Fecha_Fin_Estado);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@Nro_cedulon", obj.Nro_cedulon);
                    cmd.Parameters.AddWithValue("@Debe", obj.Debe);
                    cmd.Parameters.AddWithValue("@Barcode39", obj.Barcode39);
                    cmd.Parameters.AddWithValue("@Barcodeint25", obj.Barcodeint25);
                    cmd.Parameters.AddWithValue("@Monto_original", obj.Monto_original);
                    cmd.Parameters.AddWithValue("@Interes", obj.Interes);
                    cmd.Parameters.AddWithValue("@Descuento", obj.Descuento);
                    cmd.Parameters.AddWithValue("@Importe_pagar", obj.Importe_pagar);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Det_notificacion_estado_proc_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Det_notificacion_estado_proc_iyc ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_Emision=@Nro_Emision");
                sql.AppendLine("AND Nro_Notificacion=@Nro_Notificacion");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_Emision", obj.Nro_Emision);
                    cmd.Parameters.AddWithValue("@Nro_Notificacion", obj.Nro_Notificacion);
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

