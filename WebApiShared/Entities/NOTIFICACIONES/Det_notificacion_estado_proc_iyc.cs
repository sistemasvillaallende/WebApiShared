using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
        public string cuit_valido { get; set; }
        public string des_com { get; set; }
        public string nom_fantasia { get; set; }


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
            cuit_valido = string.Empty;
            des_com = string.Empty;
            nom_fantasia = string.Empty;
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
                int cuit_valido = dr.GetOrdinal("cuit_valido");
                int des_com = dr.GetOrdinal("des_com");
                int nom_fantasia = dr.GetOrdinal("nom_fantasia");
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
                    if (!dr.IsDBNull(cuit_valido)) { obj.cuit_valido = dr.GetString(cuit_valido); }
                    if (!dr.IsDBNull(des_com)) { obj.des_com = dr.GetString(des_com); }
                    if (!dr.IsDBNull(nom_fantasia)) { obj.nom_fantasia = dr.GetString(nom_fantasia); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Det_notificacion_estado_proc_iyc> ListarDetalle(int nro_emision)
        {
            try
            {
                string strSQL = @"SELECT 
                                a.nro_emision, a.nro_notificacion, a.nro_procuracion, a.legajo, a.nro_badec,
                                a.nombre, a.estado_actual, a.fecha_inicio_estado, 
                                a.fecha_fin_estado, a.vencimiento, a.nro_cedulon,
                                debe=((SELECT SUM(DEBE)
		   	                                FROM CTASCTES_INDYCOM C
			                                JOIN DEUDAS_PROC_IYC D ON
				                                D.nro_procuracion=a.nro_procuracion AND
					                            D.nro_transaccion=C.nro_transaccion))-
				                       (SELECT SUM(haber)
				                        FROM CTASCTES_INDYCOM C
				                        JOIN DEUDAS_PROC_IYC D ON
						                    D.nro_procuracion=a.nro_procuracion AND
						                    D.nro_transaccion=C.nro_transaccion),
                                a.barcode39, a.barcodeint25,
                                a.monto_original, a.interes, 
                                a.descuento, a.importe_pagar,
                                estado_Actualizado= (SELECT ep.descripcion_estado
												     FROM PROCURA_IYC pa
                                                     JOIN ESTADOS_PROCURACION ep ON 
												        ep.codigo_estado=pa.codigo_estado_actual AND
                                                        pa.nro_procuracion=a.nro_procuracion AND 
													    a.legajo=pa.legajo),
	                            i.nro_cuit as cuit,
                                notificado_cidi=isnull( a.Notificado_cidi,0),
	                            CASE
		                            WHEN i.nro_cuit ='' then 'CUIT_NO_VALIDADO'
		                            WHEN (SELECT count(*) from VECINO_DIGITAL vd WHERE LTRIM(RTRIM(i.nro_cuit))=LTRIM(RTRIM(vd.cuit )))>0 THEN 'CUIT_VALIDADO'
		                            WHEN (SELECT count(*) from VECINO_DIGITAL vd WHERE LTRIM(RTRIM(i.nro_cuit))=LTRIM(RTRIM(vd.cuit )))=0 THEN 'CUIT_NO_VALIDADO'
	                            END AS cuit_valido,
                                i.des_com, 
                                i.nom_fantasia 
                                FROM DET_NOTIFICACION_ESTADO_PROC_IYC a (nolock) 
                                LEFT JOIN INDYCOM i ON i.legajo=a.legajo
                                LEFT JOIN BADEC b ON b.nro_bad=a.nro_badec
                                WHERE nro_emision=@nro_emision";
                List<Det_notificacion_estado_proc_iyc> lst = new List<Det_notificacion_estado_proc_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nro_emision", nro_emision);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //********************************************************************************************************//
        public static List<Det_notificacion_estado_proc_iyc> DetalleProcuracionByPk(int nro_emision, int nro_procuracion)
        {
            try
            {
                string strSQL = @"SELECT 
                                a.nro_emision, a.nro_notificacion, a.nro_procuracion, a.legajo, a.nro_badec,
                                a.nombre, a.estado_actual, a.fecha_inicio_estado, 
                                a.fecha_fin_estado, a.vencimiento, a.nro_cedulon,
                                Debe=((SELECT SUM(DEBE)
		   	                                FROM CTASCTES_INDYCOM C
			                                JOIN DEUDAS_PROC_IYC D ON
				                                D.nro_procuracion=a.nro_procuracion AND
					                            D.nro_transaccion=C.nro_transaccion)) -
				                            (SELECT SUM(haber)
				                            FROM CTASCTES_INDYCOM C
				                            JOIN DEUDAS_PROC_IYC D ON
					                           D.nro_procuracion=a.nro_procuracion AND
					                           D.nro_transaccion=C.nro_transaccion),
                                a.barcode39, a.barcodeint25,
                                a.monto_original, a.interes, 
                                a.descuento, a.importe_pagar,
                                estado_Actualizado= (SELECT ep.descripcion_estado
												     FROM PROCURA_IYC pa
                                                     JOIN ESTADOS_PROCURACION ep ON 
												        ep.codigo_estado=pa.codigo_estado_actual AND
                                                        pa.nro_procuracion=a.nro_procuracion AND 
													    a.legajo=pa.legajo),
	                            i.nro_cuit as cuit,
                                notificado_cidi=isnull( a.Notificado_cidi,0),
	                            CASE
		                            WHEN i.nro_cuit='' then 'CUIT_NO_VALIDADO'
		                            WHEN (SELECT count(*) from VECINO_DIGITAL vd WHERE LTRIM(RTRIM(i.nro_cuit))=LTRIM(RTRIM(vd.cuit )))>0 THEN 'CUIT_VALIDADO'
		                            WHEN (SELECT count(*) from VECINO_DIGITAL vd WHERE LTRIM(RTRIM(i.nro_cuit))=LTRIM(RTRIM(vd.cuit )))=0 THEN 'CUIT_NO_VALIDADO'
	                            END AS cuit_valido,
                                i.des_com, i.nom_fantasia 
                                FROM DET_NOTIFICACION_ESTADO_PROC_IYC a (nolock) 
                                LEFT JOIN INDYCOM i ON i.legajo=a.legajo
                                LEFT JOIN BADEC b  on b.nro_bad=a.nro_badec
                                WHERE nro_emision=@nro_emision AND nro_procuracion=@nro_procuracion";
                List<Det_notificacion_estado_proc_iyc> lst = new List<Det_notificacion_estado_proc_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nro_emision", nro_emision);
                    cmd.Parameters.AddWithValue("@nro_procuracion", nro_procuracion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //**********************************************************************************************************************//
        public static List<Det_notificacion_estado_proc_iyc> ListarDetallexEstado(int nro_emision, int cod_estado)
        {
            try
            {
                string strSQL = @"SELECT
                                    a.nro_emision,
                                    a.nro_notificacion,a.nro_procuracion,
                                    a.legajo,a.nro_badec,
                                    a.nombre,a.estado_actual,
                                    a.fecha_inicio_estado,
                                    a.fecha_fin_estado, 
                                    a.vencimiento,a.nro_cedulon,
                                    debe=((SELECT SUM(DEBE)
		   	                                    FROM CTASCTES_INDYCOM C
			                                    JOIN DEUDAS_PROC_IYC D ON
				                                   D.nro_procuracion=a.nro_procuracion AND
                                                   D.nro_transaccion=C.nro_transaccion)) -
				                                (SELECT SUM(haber)
				                                 FROM CTASCTES_INDYCOM C
				                                 JOIN DEUDAS_PROC_IYC D ON
						                           D.nro_procuracion=a.nro_procuracion AND
						                           D.nro_transaccion=C.nro_transaccion),
                                    a.barcode39, 
                                    a.barcodeint25,
	                                a.monto_original, 
                                    a.interes, 
	                                a.descuento, 
                                    a.importe_pagar,
                                    estado_actualizado=(SELECT ep.descripcion_estado
                                                        FROM PROCURA_IYC pa
                                                        JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                        AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo),
	                                i.nro_cuit as cuit,
	                                notificado_cidi=isnull( a.Notificado_cidi,0),
                                    CASE
                                      WHEN i.nro_cuit ='' then 'CUIT_NO_VALIDADO'
                                      WHEN (select  count(*) from VECINO_DIGITAL vd  where LTRIM(RTRIM(i.nro_cuit))=LTRIM(RTRIM(vd.cuit)))>0 then 'CUIT_VALIDADO'
                                      WHEN (select  count(*) from VECINO_DIGITAL vd  where LTRIM(RTRIM(i.nro_cuit))=LTRIM(RTRIM(vd.cuit)))=0 then 'CUIT_NO_VALIDADO'
                                    END AS cuit_valido,
                                    i.des_com, 
                                    i.nom_fantasia 
                                    FROM DET_NOTIFICACION_ESTADO_PROC_IYC A (nolock)
	                                LEFT JOIN INDYCOM i ON i.legajo=A.Legajo
                                    LEFT JOIN BADEC b ON b.nro_bad=a.nro_badec
                                    WHERE A.nro_emision=@nro_emision AND 
			                              (SELECT pa.codigo_estado_actual
			                               FROM PROCURA_IYC pa
                                           WHERE pa.nro_procuracion=a.nro_procuracion AND a.legajo=pa.legajo)=@cod_estado";
                List<Det_notificacion_estado_proc_iyc> lst = new List<Det_notificacion_estado_proc_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nro_emision", nro_emision);
                    cmd.Parameters.AddWithValue("@cod_estado", cod_estado);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Det_notificacion_estado_proc_iyc> read()
        {
            try
            {
                string sql = @"SELECT a.*, b.des_comercio, b.nombre_fantasia 
                               FROM Det_notificacion_estado_proc_iyc a
                               LEFT JOIN INDYCOM b on
                                a.legajo=b.legajo";
                List<Det_notificacion_estado_proc_iyc> lst = new List<Det_notificacion_estado_proc_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Det_notificacion_estado_proc_iyc getByPk(int nro_emision, int nro_notificacion)
        {
            try
            {
                string sql = @"
                    SELECT d.*, b.des_com, b.nom_fantasia,
	                    estado_Actualizado= 
	                    (SELECT ep.descripcion_estado 
	                     FROM PROCURA_IYC pa                                  
	                     JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual 
                         AND pa.nro_procuracion=d.Nro_Procuracion AND d.Legajo=pa.legajo),cuit ='',cuit_valido=''    
                    FROM Det_notificacion_estado_proc_iyc  d
                    LEFT JOIN INDYCOM b on
                      d.legajo=b.legajo
                    WHERE d.Nro_Emision = @nro_emision
                    AND d.Nro_Notificacion = @nro_notificacion";
                Det_notificacion_estado_proc_iyc obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_emision", nro_emision);
                    cmd.Parameters.AddWithValue("@nro_notificacion", nro_notificacion);
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
                throw;
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

