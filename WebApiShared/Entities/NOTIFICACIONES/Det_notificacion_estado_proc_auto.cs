using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Det_notificacion_estado_proc_auto : DALBase
    {
        public int Nro_Emision { get; set; }
        public int Nro_Notificacion { get; set; }
        public int Nro_Procuracion { get; set; }
        public string Dominio { get; set; }
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
        public Det_notificacion_estado_proc_auto()
        {
            Nro_Emision = 0;
            Nro_Notificacion = 0;
            Nro_Procuracion = 0;
            Dominio = string.Empty;
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
        }

        private static List<Det_notificacion_estado_proc_auto> mapeo(SqlDataReader dr)
        {
            List<Det_notificacion_estado_proc_auto> lst = new List<Det_notificacion_estado_proc_auto>();
            Det_notificacion_estado_proc_auto obj;
            if (dr.HasRows)
            {
                int Nro_Emision = dr.GetOrdinal("Nro_Emision");
                int Nro_Notificacion = dr.GetOrdinal("Nro_Notificacion");
                int Nro_Procuracion = dr.GetOrdinal("Nro_Procuracion");
                int Dominio = dr.GetOrdinal("Dominio");
                int Nro_Badec = dr.GetOrdinal("Nro_Badec");
                int Nombre = dr.GetOrdinal("Nombre");
                int Estado_Actual = dr.GetOrdinal("Estado_Actual");
                int Fecha_Inicio_Estado = dr.GetOrdinal("Fecha_Inicio_Estado");
                int Fecha_Fin_Estado = dr.GetOrdinal("Fecha_Fin_Estado");
                int vencimiento = dr.GetOrdinal("vencimiento");
                int Nro_cedulon = dr.GetOrdinal("Nro_cedulon");
                //int Debe = dr.GetOrdinal("Debe");
                int Barcode39 = dr.GetOrdinal("Barcode39");
                int Barcodeint25 = dr.GetOrdinal("Barcodeint25");
                //int Monto_original = dr.GetOrdinal("Monto_original");
                //int Interes = dr.GetOrdinal("Interes");
                //int Descuento = dr.GetOrdinal("Descuento");
                //int Importe_pagar = dr.GetOrdinal("Importe_pagar");
                int estado_Actualizado = dr.GetOrdinal("estado_Actualizado");
                int cuit = dr.GetOrdinal("cuit");
                int notificado_cidi = dr.GetOrdinal("notificado_cidi");
                int cuit_valido = dr.GetOrdinal("cuit_valido");

                while (dr.Read())
                {
                    obj = new Det_notificacion_estado_proc_auto();
                    if (!dr.IsDBNull(Nro_Emision)) { obj.Nro_Emision = dr.GetInt32(Nro_Emision); }
                    if (!dr.IsDBNull(Nro_Notificacion)) { obj.Nro_Notificacion = dr.GetInt32(Nro_Notificacion); }
                    if (!dr.IsDBNull(Nro_Procuracion)) { obj.Nro_Procuracion = dr.GetInt32(Nro_Procuracion); }
                    if (!dr.IsDBNull(Dominio)) { obj.Dominio = dr.GetString(Dominio); }
                    if (!dr.IsDBNull(Nro_Badec)) { obj.Nro_Badec = dr.GetInt32(Nro_Badec); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(Estado_Actual)) { obj.Estado_Actual = dr.GetString(Estado_Actual); }
                    if (!dr.IsDBNull(Fecha_Inicio_Estado)) { obj.Fecha_Inicio_Estado = dr.GetDateTime(Fecha_Inicio_Estado); }
                    if (!dr.IsDBNull(Fecha_Fin_Estado)) { obj.Fecha_Fin_Estado = dr.GetDateTime(Fecha_Fin_Estado); }
                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                    if (!dr.IsDBNull(Nro_cedulon)) { obj.Nro_cedulon = dr.GetInt32(Nro_cedulon); }
                    obj.Debe = 0;
                    if (!dr.IsDBNull(Barcode39)) { obj.Barcode39 = dr.GetString(Barcode39); }
                    if (!dr.IsDBNull(Barcodeint25)) { obj.Barcodeint25 = dr.GetString(Barcodeint25); }
                    obj.Monto_original = 0;
                    obj.Interes = 0;
                    obj.Descuento = 0;
                    obj.Importe_pagar = 0;
                    if (!dr.IsDBNull(estado_Actualizado)) { obj.estado_Actualizado = dr.GetString(estado_Actualizado).Trim(); }
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(notificado_cidi)) { obj.notificado_cidi = dr.GetInt16(notificado_cidi); }
                    if (!dr.IsDBNull(cuit_valido)) { obj.cuit_valido = dr.GetString(cuit_valido); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Det_notificacion_estado_proc_auto> ListarDetalle(int nro_emision)
        {
            try
            {
                List<Det_notificacion_estado_proc_auto> lst = new List<Det_notificacion_estado_proc_auto>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @" 
                    SELECT
                        a.Nro_Emision,
                        a.Nro_Notificacion,
                        a.dominio,
                        a.nro_badec,
                        a.nombre, 
                        a.Nro_Procuracion,
                        a.Fecha_Inicio_Estado,
                        a.Fecha_Fin_Estado,
                        0 AS debe,
                        a.Vencimiento,
                        a.Estado_Actual AS Codigo_estado_actual,
                        ep.descripcion_estado AS estado_Actual,
                        a.Nro_cedulon,
                        a.Barcode39,
                        a.Barcodeint25,
                        0 AS monto_original,
                        0 AS interes,
                        0 AS descuento,
                        0 AS importe_pagar,
                        notificado_cidi=isnull( a.Notificado_cidi,0),
                        v.cuit,
                        'CUIT_VALIDADO' AS cuit_valido,
                        ep.descripcion_estado AS estado_Actualizado,
                        vd.CUIT
                    FROM Det_Notificacion_Estado_Proc_Auto a 
                        INNER JOIN NOTIFICACION_ESTADO_PROC_AUTO B ON a.Nro_Emision=B.Nro_Emision
                        LEFT JOIN VEHICULOS V ON V.DOMINIO=a.Dominio
                        INNER JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=B.Cod_Estado_Procuracion
                        LEFT JOIN VECINO_DIGITAL vd ON vd.CUIT = V.CUIT
                    WHERE
                        A.nro_emision=173" + nro_emision.ToString();
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
        public static List<Det_notificacion_estado_proc_auto> ListarDetallexEstado(int nro_emision, int cod_estado)
        {
            try
            {
                List<Det_notificacion_estado_proc_auto> lst = new List<Det_notificacion_estado_proc_auto>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @" SELECT
                      a.Nro_Emision,a.Nro_Notificacion,a.nro_procuracion,a.dominio,a.nro_badec,
                      a.nombre,a.Estado_Actual,a.Fecha_Inicio_Estado,a.Fecha_Fin_Estado, a.vencimiento,a.Nro_cedulon,
                      Debe=((SELECT SUM(DEBE)
		   	                    FROM CTASCTES_AUTOMOTORES C
			                    JOIN DEUDAS_PROC_AUTO D ON
				                    D.nro_procuracion=a.nro_procuracion AND
                                    D.nro_transaccion=C.nro_transaccion
                                     )) -
				                       (SELECT SUM(haber)
				                        FROM CTASCTES_AUTOMOTORES C
				                        JOIN DEUDAS_PROC_AUTO D ON
						                    D.nro_procuracion=a.nro_procuracion AND

						                    D.nro_transaccion=C.nro_transaccion) ,
                       a.Barcode39,a.Barcodeint25,a.Monto_original,a.interes, a.Descuento,a.Importe_pagar,
                       estado_Actualizado= (  SELECT ep.descripcion_estado
                                        FROM PROCURA_AUTO pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion AND a.Dominio=pa.dominio),v.cuit
                       ,notificado_cidi=isnull( a.Notificado_cidi,0),
                       case
				          when v.cuit ='' then 'CUIT_NO_VALIDADO'
				          WHEN (select  count(*) from VECINO_DIGITAL vd  where LTRIM(RTRIM(v.cuit))=LTRIM(RTRIM(vd.cuit )))>0 then 'CUIT_VALIDADO'
				          WHEN (select  count(*) from VECINO_DIGITAL vd  where LTRIM(RTRIM(v.cuit))=LTRIM(RTRIM(vd.cuit )))=0 then 'CUIT_NO_VALIDADO'
				          END AS cuit_valido
                    FROM Det_Notificacion_Estado_Proc_Auto A (nolock)left join VEHICULOS V ON V.DOMINIO=A.DOMINIO
                    left join badec b  on b.NRO_BAD=a.Nro_Badec
                    WHERE
                    nro_emision=" + nro_emision.ToString() + @" AND  (  SELECT ep.codigo_estado
                    FROM PROCURA_AUTO pa
                     JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                    AND pa.nro_procuracion=a.Nro_Procuracion AND a.Dominio=pa.dominio)=" + cod_estado.ToString();
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
        public static Det_notificacion_estado_proc_auto getByPk(int Nro_Emision, int Nro_Notificacion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT d.* ,");
                sql.AppendLine(" estado_Actualizado= (  SELECT ep.descripcion_estado ");
                sql.AppendLine("        FROM PROCURA_AUTO pa  ");
                sql.AppendLine("        JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual ");
                sql.AppendLine("      AND pa.nro_procuracion=d.Nro_Procuracion AND d.Dominio=pa.dominio),cuit ='',cuit_valido='' ");
                sql.AppendLine(" FROM Det_notificacion_estado_proc_auto  d ");
                sql.AppendLine(" left join badec b  on b.NRO_BAD = d.Nro_Badec ");
                sql.AppendLine(" WHERE d.Nro_Emision = @Nro_Emision");
                sql.AppendLine("AND d.Nro_Notificacion = @Nro_Notificacion");
                Det_notificacion_estado_proc_auto obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_Emision", Nro_Emision);
                    cmd.Parameters.AddWithValue("@Nro_Notificacion", Nro_Notificacion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Det_notificacion_estado_proc_auto> lst = mapeo(dr);
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
        public static int insert(Det_notificacion_estado_proc_auto obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Det_notificacion_estado_proc_auto(");
                sql.AppendLine("Nro_Emision");
                sql.AppendLine(", Nro_Notificacion");
                sql.AppendLine(", Nro_Procuracion");
                sql.AppendLine(", Dominio");
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
                sql.AppendLine(", @Dominio");
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
                    cmd.Parameters.AddWithValue("@Dominio", obj.Dominio);
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
        public static void update(Det_notificacion_estado_proc_auto obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Det_notificacion_estado_proc_auto SET");
                sql.AppendLine("Nro_Procuracion=@Nro_Procuracion");
                sql.AppendLine(", Dominio=@Dominio");
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
                    cmd.Parameters.AddWithValue("@Dominio", obj.Dominio);
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
        public static void delete(Det_notificacion_estado_proc_auto obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Det_notificacion_estado_proc_auto ");
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

