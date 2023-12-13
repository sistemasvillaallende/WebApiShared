using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Det_notificacion_estado_proc_inm : DALBase
    {
        public int Nro_emision { get; set; }
        public int Nro_notificacion { get; set; }
        public int Nro_procuracion { get; set; }
        public int Circunscripcion { get; set; }
        public int Seccion { get; set; }
        public int Manzana { get; set; }
        public int Parcela { get; set; }
        public int P_h { get; set; }
        public int Nro_badec { get; set; }
        public string Nombre { get; set; }
        public string Estado_actual { get; set; }
        public DateTime Fecha_inicio_estado { get; set; }
        public DateTime Fecha_fin_estado { get; set; }
        public string Estado_inmueble { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public string Nro { get; set; }
        public DateTime vencimiento { get; set; }
        public int Nro_cedulon { get; set; }
        public decimal debe { get; set; }
        public string Barcode39 { get; set; }
        public string Barcodeint25 { get; set; }
        public decimal Monto_original { get; set; }
        public decimal Interes { get; set; }
        public decimal Descuento { get; set; }
        public decimal Importe_pagar { get; set; }
        public string estado_Actualizado { get; set; }
        public string cuit { get; set; }
        public int notificado_cidi { get; set; }
        public Det_notificacion_estado_proc_inm()
        {
            Nro_emision = 0;
            Nro_notificacion = 0;
            Nro_procuracion = 0;
            Circunscripcion = 0;
            Seccion = 0;
            Manzana = 0;
            Parcela = 0;
            P_h = 0;
            Nro_badec = 0;
            Nombre = string.Empty;
            Estado_actual = string.Empty;
            Fecha_inicio_estado = DateTime.Now;
            Fecha_fin_estado = DateTime.Now;
            Estado_inmueble = string.Empty;
            Barrio = string.Empty;
            Calle = string.Empty;
            Nro = string.Empty;
            vencimiento = DateTime.Now;
            Nro_cedulon = 0;
            debe = 0;
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

        private static List<Det_notificacion_estado_proc_inm> mapeo(SqlDataReader dr)
        {
            List<Det_notificacion_estado_proc_inm> lst = new List<Det_notificacion_estado_proc_inm>();
            Det_notificacion_estado_proc_inm obj;
            if (dr.HasRows)
            {
                int Nro_emision = dr.GetOrdinal("Nro_emision");
                int Nro_notificacion = dr.GetOrdinal("Nro_notificacion");
                int Nro_procuracion = dr.GetOrdinal("Nro_procuracion");
                int Circunscripcion = dr.GetOrdinal("Circunscripcion");
                int Seccion = dr.GetOrdinal("Seccion");
                int Manzana = dr.GetOrdinal("Manzana");
                int Parcela = dr.GetOrdinal("Parcela");
                int P_h = dr.GetOrdinal("P_h");
                int Nro_badec = dr.GetOrdinal("Nro_badec");
                int Nombre = dr.GetOrdinal("Nombre");
                int Estado_actual = dr.GetOrdinal("Estado_actual");
                int Fecha_inicio_estado = dr.GetOrdinal("Fecha_inicio_estado");
                int Fecha_fin_estado = dr.GetOrdinal("Fecha_fin_estado");
                //int Estado_inmueble = dr.GetOrdinal("Estado_inmueble");
                //int Barrio = dr.GetOrdinal("Barrio");
               // int Calle = dr.GetOrdinal("Calle");
               // int Nro = dr.GetOrdinal("Nro");
                int vencimiento = dr.GetOrdinal("vencimiento");
                int Nro_cedulon = dr.GetOrdinal("Nro_cedulon");
                int debe = dr.GetOrdinal("debe");
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
                    obj = new Det_notificacion_estado_proc_inm();
                    if (!dr.IsDBNull(Nro_emision)) { obj.Nro_emision = dr.GetInt32(Nro_emision); }
                    if (!dr.IsDBNull(Nro_notificacion)) { obj.Nro_notificacion = dr.GetInt32(Nro_notificacion); }
                    if (!dr.IsDBNull(Nro_procuracion)) { obj.Nro_procuracion = dr.GetInt32(Nro_procuracion); }
                    if (!dr.IsDBNull(Circunscripcion)) { obj.Circunscripcion = dr.GetInt32(Circunscripcion); }
                    if (!dr.IsDBNull(Seccion)) { obj.Seccion = dr.GetInt32(Seccion); }
                    if (!dr.IsDBNull(Manzana)) { obj.Manzana = dr.GetInt32(Manzana); }
                    if (!dr.IsDBNull(Parcela)) { obj.Parcela = dr.GetInt32(Parcela); }
                    if (!dr.IsDBNull(P_h)) { obj.P_h = dr.GetInt32(P_h); }
                    if (!dr.IsDBNull(Nro_badec)) { obj.Nro_badec = dr.GetInt32(Nro_badec); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(Estado_actual)) { obj.Estado_actual = dr.GetString(Estado_actual); }
                    if (!dr.IsDBNull(Fecha_inicio_estado)) { obj.Fecha_inicio_estado = dr.GetDateTime(Fecha_inicio_estado); }
                    if (!dr.IsDBNull(Fecha_fin_estado)) { obj.Fecha_fin_estado = dr.GetDateTime(Fecha_fin_estado); }
                   // if (!dr.IsDBNull(Estado_inmueble)) { obj.Estado_inmueble = dr.GetString(Estado_inmueble); }
                   // if (!dr.IsDBNull(Barrio)) { obj.Barrio = dr.GetString(Barrio); }
                 //   if (!dr.IsDBNull(Calle)) { obj.Calle = dr.GetString(Calle); }
                  //  if (!dr.IsDBNull(Nro)) { obj.Nro = dr.GetString(Nro); }
                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                    if (!dr.IsDBNull(Nro_cedulon)) { obj.Nro_cedulon = dr.GetInt32(Nro_cedulon); }
                    if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
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

        public static List<Det_notificacion_estado_proc_inm> ListarDetalle(int nro_emision)
        {
            try
            {
                List<Det_notificacion_estado_proc_inm> lst = new List<Det_notificacion_estado_proc_inm>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @" SELECT
                      a.Nro_Emision,a.Nro_Notificacion,a.nro_procuracion,a.Circunscripcion,a.seccion,a.manzana,a.parcela,a.p_h,
					  a.nro_badec, a.nombre,a.Estado_Actual,a.Fecha_Inicio_Estado,a.Fecha_Fin_Estado, a.vencimiento,a.Nro_cedulon,
                      Debe=((SELECT SUM(DEBE)
		   	                    FROM CTASCTES_INMUEBLES C
			                    JOIN DEUDAS_PROC_TASA D ON
				                    D.nro_procuracion=a.nro_procuracion AND
                                    D.nro_transaccion=C.nro_transaccion
                                     )) -
				                       (SELECT SUM(haber)
				                        FROM CTASCTES_INMUEBLES C
				                        JOIN DEUDAS_PROC_TASA D ON
						                    D.nro_procuracion=a.nro_procuracion AND

						                    D.nro_transaccion=C.nro_transaccion) ,
                       a.Barcode39,a.Barcodeint25,a.Monto_original,a.interes, a.Descuento,a.Importe_pagar,
                       estado_Actualizado= (  SELECT ep.descripcion_estado
                                        FROM PROCURA_TASA pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion  ),b.cuit
                                       ,notificado_cidi=isnull( a.Notificado_cidi,0)
                    FROM DET_NOTIFICACION_ESTADO_PROC_INM A (nolock)left join INMUEBLES V ON V.circunscripcion=A.circunscripcion
                          AND V.seccion=A.seccion AND V.manzana=A.manzana AND V.parcela=A.parcela AND V.p_h=A.p_h
      
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

        public static List<Det_notificacion_estado_proc_inm> ListarDetallexEstado(int nro_emision, int cod_estado)
        {
            try
            {
                List<Det_notificacion_estado_proc_inm> lst = new List<Det_notificacion_estado_proc_inm>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @" SELECT
                      a.Nro_Emision,a.Nro_Notificacion,a.nro_procuracion,a.Circunscripcion,a.seccion,a.manzana,a.parcela,a.p_h,a.nro_badec,
                      a.nombre,a.Estado_Actual,a.Fecha_Inicio_Estado,a.Fecha_Fin_Estado, a.vencimiento,a.Nro_cedulon,
                      Debe=((SELECT SUM(DEBE)
		   	                    FROM CTASCTES_INMUEBLES C
			                    JOIN DEUDAS_PROC_TASA D ON
				                    D.nro_procuracion=a.nro_procuracion AND
                                    D.nro_transaccion=C.nro_transaccion
                                     )) -
				                       (SELECT SUM(haber)
				                        FROM CTASCTES_INMUEBLES C
				                        JOIN DEUDAS_PROC_TASA D ON
						                    D.nro_procuracion=a.nro_procuracion AND

						                    D.nro_transaccion=C.nro_transaccion) ,
                       a.Barcode39,a.Barcodeint25,a.Monto_original,a.interes, a.Descuento,a.Importe_pagar,
                       estado_Actualizado= (  SELECT ep.descripcion_estado
                                        FROM PROCURA_TASA pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion ),b.cuit
                       ,notificado_cidi=isnull( a.Notificado_cidi,0)
                    FROM Det_Notificacion_Estado_Proc_inm A (nolock)left join inmuebles i  ON  a.Circunscripcion=i.circunscripcion
										and a.Seccion=i.seccion and a.manzana=i.manzana and a.parcela=i.parcela and a.p_h=i.p_h
                    left join badec b  on b.NRO_BAD=a.Nro_Badec
                    WHERE
                    nro_emision=" + nro_emision.ToString() + @" AND  (SELECT ep.codigo_estado
                                                                      FROM PROCURA_TASA pa
                                                                      JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                      AND pa.nro_procuracion=a.Nro_Procuracion)=" + cod_estado.ToString();
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





        public static List<Det_notificacion_estado_proc_inm> read()
        {
            try
            {
                List<Det_notificacion_estado_proc_inm> lst = new List<Det_notificacion_estado_proc_inm>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Det_notificacion_estado_proc_inm";
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

        public static Det_notificacion_estado_proc_inm getByPk(
        int Nro_emision, int Nro_notificacion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT d.* ,");
                sql.AppendLine("estado_Actualizado = (  SELECT ep.descripcion_estado ");
                sql.AppendLine("                        FROM PROCURA_TASA pa ");
                sql.AppendLine("                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado = pa.codigo_estado_actual ");
                sql.AppendLine("                        AND pa.nro_procuracion = d.Nro_Procuracion  ),b.cuit ");
                sql.AppendLine("  FROM Det_notificacion_estado_proc_inm d ");
                sql.AppendLine(" left join badec b  on b.NRO_BAD = d.Nro_Badec ");
                sql.AppendLine(" where d.Nro_emision = @Nro_emision");
                sql.AppendLine(" AND d.Nro_notificacion = @Nro_notificacion");
                Det_notificacion_estado_proc_inm obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", Nro_emision);
                    cmd.Parameters.AddWithValue("@Nro_notificacion", Nro_notificacion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Det_notificacion_estado_proc_inm> lst = mapeo(dr);
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

        public static int insert(Det_notificacion_estado_proc_inm obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Det_notificacion_estado_proc_inm(");
                sql.AppendLine("Nro_emision");
                sql.AppendLine(", Nro_notificacion");
                sql.AppendLine(", Nro_procuracion");
                sql.AppendLine(", Circunscripcion");
                sql.AppendLine(", Seccion");
                sql.AppendLine(", Manzana");
                sql.AppendLine(", Parcela");
                sql.AppendLine(", P_h");
                sql.AppendLine(", Nro_badec");
                sql.AppendLine(", Nombre");
                sql.AppendLine(", Estado_actual");
                sql.AppendLine(", Fecha_inicio_estado");
                sql.AppendLine(", Fecha_fin_estado");
                sql.AppendLine(", Estado_inmueble");
                sql.AppendLine(", Barrio");
                sql.AppendLine(", Calle");
                sql.AppendLine(", Nro");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", Nro_cedulon");
                sql.AppendLine(", debe");
                sql.AppendLine(", Barcode39");
                sql.AppendLine(", Barcodeint25");
                sql.AppendLine(", Monto_original");
                sql.AppendLine(", Interes");
                sql.AppendLine(", Descuento");
                sql.AppendLine(", Importe_pagar");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nro_emision");
                sql.AppendLine(", @Nro_notificacion");
                sql.AppendLine(", @Nro_procuracion");
                sql.AppendLine(", @Circunscripcion");
                sql.AppendLine(", @Seccion");
                sql.AppendLine(", @Manzana");
                sql.AppendLine(", @Parcela");
                sql.AppendLine(", @P_h");
                sql.AppendLine(", @Nro_badec");
                sql.AppendLine(", @Nombre");
                sql.AppendLine(", @Estado_actual");
                sql.AppendLine(", @Fecha_inicio_estado");
                sql.AppendLine(", @Fecha_fin_estado");
                sql.AppendLine(", @Estado_inmueble");
                sql.AppendLine(", @Barrio");
                sql.AppendLine(", @Calle");
                sql.AppendLine(", @Nro");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @Nro_cedulon");
                sql.AppendLine(", @debe");
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
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Nro_notificacion", obj.Nro_notificacion);
                    cmd.Parameters.AddWithValue("@Nro_procuracion", obj.Nro_procuracion);
                    cmd.Parameters.AddWithValue("@Circunscripcion", obj.Circunscripcion);
                    cmd.Parameters.AddWithValue("@Seccion", obj.Seccion);
                    cmd.Parameters.AddWithValue("@Manzana", obj.Manzana);
                    cmd.Parameters.AddWithValue("@Parcela", obj.Parcela);
                    cmd.Parameters.AddWithValue("@P_h", obj.P_h);
                    cmd.Parameters.AddWithValue("@Nro_badec", obj.Nro_badec);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Estado_actual", obj.Estado_actual);
                    cmd.Parameters.AddWithValue("@Fecha_inicio_estado", obj.Fecha_inicio_estado);
                    cmd.Parameters.AddWithValue("@Fecha_fin_estado", obj.Fecha_fin_estado);
                    cmd.Parameters.AddWithValue("@Estado_inmueble", obj.Estado_inmueble);
                    cmd.Parameters.AddWithValue("@Barrio", obj.Barrio);
                    cmd.Parameters.AddWithValue("@Calle", obj.Calle);
                    cmd.Parameters.AddWithValue("@Nro", obj.Nro);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@Nro_cedulon", obj.Nro_cedulon);
                    cmd.Parameters.AddWithValue("@debe", obj.debe);
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

        public static void update(Det_notificacion_estado_proc_inm obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Det_notificacion_estado_proc_inm SET");
                sql.AppendLine("Nro_procuracion=@Nro_procuracion");
                sql.AppendLine(", Circunscripcion=@Circunscripcion");
                sql.AppendLine(", Seccion=@Seccion");
                sql.AppendLine(", Manzana=@Manzana");
                sql.AppendLine(", Parcela=@Parcela");
                sql.AppendLine(", P_h=@P_h");
                sql.AppendLine(", Nro_badec=@Nro_badec");
                sql.AppendLine(", Nombre=@Nombre");
                sql.AppendLine(", Estado_actual=@Estado_actual");
                sql.AppendLine(", Fecha_inicio_estado=@Fecha_inicio_estado");
                sql.AppendLine(", Fecha_fin_estado=@Fecha_fin_estado");
                sql.AppendLine(", Estado_inmueble=@Estado_inmueble");
                sql.AppendLine(", Barrio=@Barrio");
                sql.AppendLine(", Calle=@Calle");
                sql.AppendLine(", Nro=@Nro");
                sql.AppendLine(", vencimiento=@vencimiento");
                sql.AppendLine(", Nro_cedulon=@Nro_cedulon");
                sql.AppendLine(", debe=@debe");
                sql.AppendLine(", Barcode39=@Barcode39");
                sql.AppendLine(", Barcodeint25=@Barcodeint25");
                sql.AppendLine(", Monto_original=@Monto_original");
                sql.AppendLine(", Interes=@Interes");
                sql.AppendLine(", Descuento=@Descuento");
                sql.AppendLine(", Importe_pagar=@Importe_pagar");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_emision=@Nro_emision");
                sql.AppendLine("AND Nro_notificacion=@Nro_notificacion");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Nro_notificacion", obj.Nro_notificacion);
                    cmd.Parameters.AddWithValue("@Nro_procuracion", obj.Nro_procuracion);
                    cmd.Parameters.AddWithValue("@Circunscripcion", obj.Circunscripcion);
                    cmd.Parameters.AddWithValue("@Seccion", obj.Seccion);
                    cmd.Parameters.AddWithValue("@Manzana", obj.Manzana);
                    cmd.Parameters.AddWithValue("@Parcela", obj.Parcela);
                    cmd.Parameters.AddWithValue("@P_h", obj.P_h);
                    cmd.Parameters.AddWithValue("@Nro_badec", obj.Nro_badec);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Estado_actual", obj.Estado_actual);
                    cmd.Parameters.AddWithValue("@Fecha_inicio_estado", obj.Fecha_inicio_estado);
                    cmd.Parameters.AddWithValue("@Fecha_fin_estado", obj.Fecha_fin_estado);
                    cmd.Parameters.AddWithValue("@Estado_inmueble", obj.Estado_inmueble);
                    cmd.Parameters.AddWithValue("@Barrio", obj.Barrio);
                    cmd.Parameters.AddWithValue("@Calle", obj.Calle);
                    cmd.Parameters.AddWithValue("@Nro", obj.Nro);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@Nro_cedulon", obj.Nro_cedulon);
                    cmd.Parameters.AddWithValue("@debe", obj.debe);
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

        public static void delete(Det_notificacion_estado_proc_inm obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Det_notificacion_estado_proc_inm ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_emision=@Nro_emision");
                sql.AppendLine("AND Nro_notificacion=@Nro_notificacion");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Nro_notificacion", obj.Nro_notificacion);
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

