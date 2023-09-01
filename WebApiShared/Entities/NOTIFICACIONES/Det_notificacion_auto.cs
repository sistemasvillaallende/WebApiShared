using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiShared.Entities;

namespace SIIMVA_WEB
{
    public class Det_notificacion_auto : DALBase
    {
        public int Nro_emision { get; set; }
        public int Nro_notificacion { get; set; }
        public string Dominio { get; set; }
        public int Nro_badec { get; set; }
        public string Nombre { get; set; }
        public string Nom_barrio_dom_esp { get; set; }
        public string Nom_calle_dom_esp { get; set; }
        public string Nro_dom_esp { get; set; }
        public string Ciudad_dom_esp { get; set; }
        public string Provincia_dom_esp { get; set; }
        public string Pais_dom_esp { get; set; }
        public string Cod_postal_esp { get; set; }
        public int Nro_proc { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public string Periodo { get; set; }
        public decimal Debe { get; set; }
        public int Nro_plan { get; set; }
        public DateTime Vencimiento { get; set; }
        public Int16 Cod_tipo_procuracion { get; set; }
        public bool Bloqueado { get; set; }
        public Int16 Codigo_procurador { get; set; }
        public bool TieneHonorarios { get; set; }
        public Int16 Tipo_descuento { get; set; }
        public Int16 Cod_formulario { get; set; }
        public Int16 Codigo_estado_actual { get; set; }
        public Int16 ParaImprimir { get; set; }
        public Int16 CedulonSi { get; set; }
        public int Nro_cedulon { get; set; }
        public string Barcode39 { get; set; }
        public string Barcodeint25 { get; set; }
        public Int16 pagado { get; set; }
        public decimal monto_original { get; set; }
        public decimal interes { get; set; }
        public decimal descuento { get; set; }
        public decimal importe_pagar { get; set; }
        public DateTime Fecha_baja_real { get; set; }
        public int Nro_secuencia { get; set; }
        public int Nro_orden { get; set; }
        public string cuit { get; set; }
        public int notificado_cidi { get; set; }
        public string cuit_valido { get; set; }
        public Det_notificacion_auto()
        {
            Nro_emision = 0;
            Nro_notificacion = 0;
            Dominio = string.Empty;
            Nro_badec = 0;
            Nombre = string.Empty;
            Nom_barrio_dom_esp = string.Empty;
            Nom_calle_dom_esp = string.Empty;
            Nro_dom_esp = string.Empty;
            Ciudad_dom_esp = string.Empty;
            Provincia_dom_esp = string.Empty;
            Pais_dom_esp = string.Empty;
            Cod_postal_esp = string.Empty;
            Nro_proc = 0;
            Fecha_vencimiento = DateTime.Now;
            Periodo = string.Empty;
            Debe = 0;
            Nro_plan = 0;
            Vencimiento = DateTime.Now;
            Cod_tipo_procuracion = 0;
            Bloqueado = false;
            Codigo_procurador = 0;
            TieneHonorarios = false;
            Tipo_descuento = 0;
            Cod_formulario = 0;
            Codigo_estado_actual = 0;
            ParaImprimir = 0;
            CedulonSi = 0;
            Nro_cedulon = 0;
            Barcode39 = string.Empty;
            Barcodeint25 = string.Empty;
            pagado = 0;
            monto_original = 0;
            interes = 0;
            descuento = 0;
            importe_pagar = 0;
            Fecha_baja_real = DateTime.Now;
            Nro_secuencia = 0;
            Nro_orden = 0;
            notificado_cidi= 0;
            cuit = string.Empty;
            notificado_cidi = 0;
   
        }

        private static List<Det_notificacion_auto> mapeo(SqlDataReader dr)
        {
            List<Det_notificacion_auto> lst = new List<Det_notificacion_auto>();
            Det_notificacion_auto obj;
            if (dr.HasRows)
            {
                int Nro_emision = dr.GetOrdinal("Nro_emision");
                int Nro_notificacion = dr.GetOrdinal("Nro_notificacion");
                int Dominio = dr.GetOrdinal("Dominio");
                int Nro_badec = dr.GetOrdinal("Nro_badec");
                int Nombre = dr.GetOrdinal("Nombre");
                int Nom_barrio_dom_esp = dr.GetOrdinal("Nom_barrio_dom_esp");
                int Nom_calle_dom_esp = dr.GetOrdinal("Nom_calle_dom_esp");
                int Nro_dom_esp = dr.GetOrdinal("Nro_dom_esp");
                int Ciudad_dom_esp = dr.GetOrdinal("Ciudad_dom_esp");
                int Provincia_dom_esp = dr.GetOrdinal("Provincia_dom_esp");
                int Pais_dom_esp = dr.GetOrdinal("Pais_dom_esp");
                int Cod_postal_esp = dr.GetOrdinal("Cod_postal_esp");
                int Nro_proc = dr.GetOrdinal("Nro_proc");
                int Fecha_vencimiento = dr.GetOrdinal("Fecha_vencimiento");
                int Periodo = dr.GetOrdinal("Periodo");
                int Debe = dr.GetOrdinal("Debe");
                int Nro_plan = dr.GetOrdinal("Nro_plan");
                int Vencimiento = dr.GetOrdinal("Vencimiento");
                int Cod_tipo_procuracion = dr.GetOrdinal("Cod_tipo_procuracion");
                int Bloqueado = dr.GetOrdinal("Bloqueado");
                int Codigo_procurador = dr.GetOrdinal("Codigo_procurador");
                int TieneHonorarios = dr.GetOrdinal("TieneHonorarios");
                int Tipo_descuento = dr.GetOrdinal("Tipo_descuento");
                int Cod_formulario = dr.GetOrdinal("Cod_formulario");
                int Codigo_estado_actual = dr.GetOrdinal("Codigo_estado_actual");
                int ParaImprimir = dr.GetOrdinal("ParaImprimir");
                int CedulonSi = dr.GetOrdinal("CedulonSi");
                int Nro_cedulon = dr.GetOrdinal("Nro_cedulon");
                int Barcode39 = dr.GetOrdinal("Barcode39");
                int Barcodeint25 = dr.GetOrdinal("Barcodeint25");
                int pagado = dr.GetOrdinal("pagado");
                int monto_original = dr.GetOrdinal("monto_original");
                int interes = dr.GetOrdinal("interes");
                int descuento = dr.GetOrdinal("descuento");
                int importe_pagar = dr.GetOrdinal("importe_pagar");
                int Fecha_baja_real = dr.GetOrdinal("Fecha_baja_real");
                int Nro_secuencia = dr.GetOrdinal("Nro_secuencia");
                int Nro_orden = dr.GetOrdinal("Nro_orden");
                int notificado_cidi = dr.GetOrdinal("notificado_cidi");
                int cuit = dr.GetOrdinal("cuit");
                int Notificado_cidi = dr.GetOrdinal("Notificado_cidi");
                int estado_Actual = dr.GetOrdinal("estado_Actual");

                while (dr.Read())
                {
                    obj = new Det_notificacion_auto();
                    if (!dr.IsDBNull(Nro_emision)) { obj.Nro_emision = dr.GetInt32(Nro_emision); }
                    if (!dr.IsDBNull(Nro_notificacion)) { obj.Nro_notificacion = dr.GetInt32(Nro_notificacion); }
                    if (!dr.IsDBNull(Dominio)) { obj.Dominio = dr.GetString(Dominio); }
                    if (!dr.IsDBNull(Nro_badec)) { obj.Nro_badec = dr.GetInt32(Nro_badec); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(Nom_barrio_dom_esp)) { obj.Nom_barrio_dom_esp = dr.GetString(Nom_barrio_dom_esp); }
                    if (!dr.IsDBNull(Nom_calle_dom_esp)) { obj.Nom_calle_dom_esp = dr.GetString(Nom_calle_dom_esp); }
                    if (!dr.IsDBNull(Nro_dom_esp)) { obj.Nro_dom_esp = dr.GetString(Nro_dom_esp); }
                    if (!dr.IsDBNull(Ciudad_dom_esp)) { obj.Ciudad_dom_esp = dr.GetString(Ciudad_dom_esp); }
                    if (!dr.IsDBNull(Provincia_dom_esp)) { obj.Provincia_dom_esp = dr.GetString(Provincia_dom_esp); }
                    if (!dr.IsDBNull(Pais_dom_esp)) { obj.Pais_dom_esp = dr.GetString(Pais_dom_esp); }
                    if (!dr.IsDBNull(Cod_postal_esp)) { obj.Cod_postal_esp = dr.GetString(Cod_postal_esp); }
                    if (!dr.IsDBNull(Nro_proc)) { obj.Nro_proc = dr.GetInt32(Nro_proc); }
                    if (!dr.IsDBNull(Fecha_vencimiento)) { obj.Fecha_vencimiento = dr.GetDateTime(Fecha_vencimiento); }
                    if (!dr.IsDBNull(Periodo)) { obj.Periodo = dr.GetString(Periodo); }
                    if (!dr.IsDBNull(Debe)) { obj.Debe = dr.GetDecimal(Debe); }
                    if (!dr.IsDBNull(Nro_plan)) { obj.Nro_plan = dr.GetInt32(Nro_plan); }
                    if (!dr.IsDBNull(Vencimiento)) { obj.Vencimiento = dr.GetDateTime(Vencimiento); }
                    if (!dr.IsDBNull(Cod_tipo_procuracion)) { obj.Cod_tipo_procuracion = dr.GetInt16(Cod_tipo_procuracion); }
                    if (!dr.IsDBNull(Bloqueado)) { obj.Bloqueado = dr.GetBoolean(Bloqueado); }
                    if (!dr.IsDBNull(Codigo_procurador)) { obj.Codigo_procurador = dr.GetInt16(Codigo_procurador); }
                    if (!dr.IsDBNull(TieneHonorarios)) { obj.TieneHonorarios = dr.GetBoolean(TieneHonorarios); }
                    if (!dr.IsDBNull(Tipo_descuento)) { obj.Tipo_descuento = dr.GetInt16(Tipo_descuento); }
                    if (!dr.IsDBNull(Cod_formulario)) { obj.Cod_formulario = dr.GetInt16(Cod_formulario); }
                    if (!dr.IsDBNull(Codigo_estado_actual)) { obj.Codigo_estado_actual = dr.GetInt16(Codigo_estado_actual); }
                    if (!dr.IsDBNull(ParaImprimir)) { obj.ParaImprimir = dr.GetInt16(ParaImprimir); }
                    if (!dr.IsDBNull(CedulonSi)) { obj.CedulonSi = dr.GetInt16(CedulonSi); }
                    if (!dr.IsDBNull(Nro_cedulon)) { obj.Nro_cedulon = dr.GetInt32(Nro_cedulon); }
                    if (!dr.IsDBNull(Barcode39)) { obj.Barcode39 = dr.GetString(Barcode39); }
                    if (!dr.IsDBNull(Barcodeint25)) { obj.Barcodeint25 = dr.GetString(Barcodeint25); }
                    if (!dr.IsDBNull(pagado)) { obj.pagado = dr.GetInt16(pagado); }
                    if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                    if (!dr.IsDBNull(interes)) { obj.interes = dr.GetDecimal(interes); }
                    if (!dr.IsDBNull(descuento)) { obj.descuento = dr.GetDecimal(descuento); }
                    if (!dr.IsDBNull(importe_pagar)) { obj.importe_pagar = dr.GetDecimal(importe_pagar); }
                    if (!dr.IsDBNull(Fecha_baja_real)) { obj.Fecha_baja_real = dr.GetDateTime(Fecha_baja_real); }
                    if (!dr.IsDBNull(Nro_secuencia)) { obj.Nro_secuencia = dr.GetInt32(Nro_secuencia); }
                    if (!dr.IsDBNull(Nro_orden)) { obj.Nro_orden = dr.GetInt32(Nro_orden); }
                    if (!dr.IsDBNull(notificado_cidi)) { obj.notificado_cidi = dr.GetInt16(notificado_cidi); }
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
             
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Det_notificacion_auto> read(int Nro_emision)
        {
            try
            {
                List<Det_notificacion_auto> lst = new List<Det_notificacion_auto>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, D.CUIT, C.descripcion_estado AS estado_Actual
                                        FROM DET_NOTIFICACION_AUTO A
                                        INNER JOIN VEHICULOS B ON A.Dominio = B.DOMINIO
                                        INNER JOIN ESTADOS_PROCURACION C 
                                        ON A.Codigo_estado_actual=codigo_estado
                                        INNER JOIN BADEC D ON B.NRO_BAD=D.NRO_BAD
                                        WHERE Nro_emision = @Nro_emision";
                    cmd.Parameters.AddWithValue("@Nro_emision", Nro_emision);
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

        public static Det_notificacion_auto getByPk(
        int Nro_emision, int Nro_notificacion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT d.*, ");
                sql.AppendLine(" estado_Actualizado= (  SELECT ep.descripcion_estado ");
                sql.AppendLine("        FROM PROCURA_AUTO pa  ");
                sql.AppendLine("        JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual ");
                sql.AppendLine("      AND pa.nro_procuracion=d.Nro_Procuracion AND d.Dominio=pa.dominio),b.cuit ");
                sql.AppendLine("FROM Det_notificacion_auto d ");
                sql.AppendLine("WHERE d.Nro_emision = @Nro_emision");
                sql.AppendLine("AND d.Nro_notificacion = @Nro_notificacion");
     
                Det_notificacion_auto obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", Nro_emision);
                    cmd.Parameters.AddWithValue("@Nro_notificacion", Nro_notificacion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Det_notificacion_auto> lst = mapeo(dr);
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

        public static int insert(Det_notificacion_auto obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Det_notificacion_auto(");
                sql.AppendLine("Nro_emision");
                sql.AppendLine(", Nro_notificacion");
                sql.AppendLine(", Dominio");
                sql.AppendLine(", Nro_badec");
                sql.AppendLine(", Nombre");
                sql.AppendLine(", Nom_barrio_dom_esp");
                sql.AppendLine(", Nom_calle_dom_esp");
                sql.AppendLine(", Nro_dom_esp");
                sql.AppendLine(", Ciudad_dom_esp");
                sql.AppendLine(", Provincia_dom_esp");
                sql.AppendLine(", Pais_dom_esp");
                sql.AppendLine(", Cod_postal_esp");
                sql.AppendLine(", Nro_proc");
                sql.AppendLine(", Fecha_vencimiento");
                sql.AppendLine(", Periodo");
                sql.AppendLine(", Debe");
                sql.AppendLine(", Nro_plan");
                sql.AppendLine(", Vencimiento");
                sql.AppendLine(", Cod_tipo_procuracion");
                sql.AppendLine(", Bloqueado");
                sql.AppendLine(", Codigo_procurador");
                sql.AppendLine(", TieneHonorarios");
                sql.AppendLine(", Tipo_descuento");
                sql.AppendLine(", Cod_formulario");
                sql.AppendLine(", Codigo_estado_actual");
                sql.AppendLine(", ParaImprimir");
                sql.AppendLine(", CedulonSi");
                sql.AppendLine(", Nro_cedulon");
                sql.AppendLine(", Barcode39");
                sql.AppendLine(", Barcodeint25");
                sql.AppendLine(", pagado");
                sql.AppendLine(", monto_original");
                sql.AppendLine(", interes");
                sql.AppendLine(", descuento");
                sql.AppendLine(", importe_pagar");
                sql.AppendLine(", Fecha_baja_real");
                sql.AppendLine(", Nro_secuencia");
                sql.AppendLine(", Nro_orden");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nro_emision");
                sql.AppendLine(", @Nro_notificacion");
                sql.AppendLine(", @Dominio");
                sql.AppendLine(", @Nro_badec");
                sql.AppendLine(", @Nombre");
                sql.AppendLine(", @Nom_barrio_dom_esp");
                sql.AppendLine(", @Nom_calle_dom_esp");
                sql.AppendLine(", @Nro_dom_esp");
                sql.AppendLine(", @Ciudad_dom_esp");
                sql.AppendLine(", @Provincia_dom_esp");
                sql.AppendLine(", @Pais_dom_esp");
                sql.AppendLine(", @Cod_postal_esp");
                sql.AppendLine(", @Nro_proc");
                sql.AppendLine(", @Fecha_vencimiento");
                sql.AppendLine(", @Periodo");
                sql.AppendLine(", @Debe");
                sql.AppendLine(", @Nro_plan");
                sql.AppendLine(", @Vencimiento");
                sql.AppendLine(", @Cod_tipo_procuracion");
                sql.AppendLine(", @Bloqueado");
                sql.AppendLine(", @Codigo_procurador");
                sql.AppendLine(", @TieneHonorarios");
                sql.AppendLine(", @Tipo_descuento");
                sql.AppendLine(", @Cod_formulario");
                sql.AppendLine(", @Codigo_estado_actual");
                sql.AppendLine(", @ParaImprimir");
                sql.AppendLine(", @CedulonSi");
                sql.AppendLine(", @Nro_cedulon");
                sql.AppendLine(", @Barcode39");
                sql.AppendLine(", @Barcodeint25");
                sql.AppendLine(", @pagado");
                sql.AppendLine(", @monto_original");
                sql.AppendLine(", @interes");
                sql.AppendLine(", @descuento");
                sql.AppendLine(", @importe_pagar");
                sql.AppendLine(", @Fecha_baja_real");
                sql.AppendLine(", @Nro_secuencia");
                sql.AppendLine(", @Nro_orden");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Nro_notificacion", obj.Nro_notificacion);
                    cmd.Parameters.AddWithValue("@Dominio", obj.Dominio);
                    cmd.Parameters.AddWithValue("@Nro_badec", obj.Nro_badec);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Nom_barrio_dom_esp", obj.Nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@Nom_calle_dom_esp", obj.Nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@Nro_dom_esp", obj.Nro_dom_esp);
                    cmd.Parameters.AddWithValue("@Ciudad_dom_esp", obj.Ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@Provincia_dom_esp", obj.Provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@Pais_dom_esp", obj.Pais_dom_esp);
                    cmd.Parameters.AddWithValue("@Cod_postal_esp", obj.Cod_postal_esp);
                    cmd.Parameters.AddWithValue("@Nro_proc", obj.Nro_proc);
                    cmd.Parameters.AddWithValue("@Fecha_vencimiento", obj.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@Periodo", obj.Periodo);
                    cmd.Parameters.AddWithValue("@Debe", obj.Debe);
                    cmd.Parameters.AddWithValue("@Nro_plan", obj.Nro_plan);
                    cmd.Parameters.AddWithValue("@Vencimiento", obj.Vencimiento);
                    cmd.Parameters.AddWithValue("@Cod_tipo_procuracion", obj.Cod_tipo_procuracion);
                    cmd.Parameters.AddWithValue("@Bloqueado", obj.Bloqueado);
                    cmd.Parameters.AddWithValue("@Codigo_procurador", obj.Codigo_procurador);
                    cmd.Parameters.AddWithValue("@TieneHonorarios", obj.TieneHonorarios);
                    cmd.Parameters.AddWithValue("@Tipo_descuento", obj.Tipo_descuento);
                    cmd.Parameters.AddWithValue("@Cod_formulario", obj.Cod_formulario);
                    cmd.Parameters.AddWithValue("@Codigo_estado_actual", obj.Codigo_estado_actual);
                    cmd.Parameters.AddWithValue("@ParaImprimir", obj.ParaImprimir);
                    cmd.Parameters.AddWithValue("@CedulonSi", obj.CedulonSi);
                    cmd.Parameters.AddWithValue("@Nro_cedulon", obj.Nro_cedulon);
                    cmd.Parameters.AddWithValue("@Barcode39", obj.Barcode39);
                    cmd.Parameters.AddWithValue("@Barcodeint25", obj.Barcodeint25);
                    cmd.Parameters.AddWithValue("@pagado", obj.pagado);
                    cmd.Parameters.AddWithValue("@monto_original", obj.monto_original);
                    cmd.Parameters.AddWithValue("@interes", obj.interes);
                    cmd.Parameters.AddWithValue("@descuento", obj.descuento);
                    cmd.Parameters.AddWithValue("@importe_pagar", obj.importe_pagar);
                    cmd.Parameters.AddWithValue("@Fecha_baja_real", obj.Fecha_baja_real);
                    cmd.Parameters.AddWithValue("@Nro_secuencia", obj.Nro_secuencia);
                    cmd.Parameters.AddWithValue("@Nro_orden", obj.Nro_orden);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Det_notificacion_auto obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Det_notificacion_auto SET");
                sql.AppendLine("Nro_badec=@Nro_badec");
                sql.AppendLine(", Nombre=@Nombre");
                sql.AppendLine(", Nom_barrio_dom_esp=@Nom_barrio_dom_esp");
                sql.AppendLine(", Nom_calle_dom_esp=@Nom_calle_dom_esp");
                sql.AppendLine(", Nro_dom_esp=@Nro_dom_esp");
                sql.AppendLine(", Ciudad_dom_esp=@Ciudad_dom_esp");
                sql.AppendLine(", Provincia_dom_esp=@Provincia_dom_esp");
                sql.AppendLine(", Pais_dom_esp=@Pais_dom_esp");
                sql.AppendLine(", Cod_postal_esp=@Cod_postal_esp");
                sql.AppendLine(", Nro_proc=@Nro_proc");
                sql.AppendLine(", Fecha_vencimiento=@Fecha_vencimiento");
                sql.AppendLine(", Periodo=@Periodo");
                sql.AppendLine(", Debe=@Debe");
                sql.AppendLine(", Nro_plan=@Nro_plan");
                sql.AppendLine(", Vencimiento=@Vencimiento");
                sql.AppendLine(", Cod_tipo_procuracion=@Cod_tipo_procuracion");
                sql.AppendLine(", Bloqueado=@Bloqueado");
                sql.AppendLine(", Codigo_procurador=@Codigo_procurador");
                sql.AppendLine(", TieneHonorarios=@TieneHonorarios");
                sql.AppendLine(", Tipo_descuento=@Tipo_descuento");
                sql.AppendLine(", Cod_formulario=@Cod_formulario");
                sql.AppendLine(", Codigo_estado_actual=@Codigo_estado_actual");
                sql.AppendLine(", ParaImprimir=@ParaImprimir");
                sql.AppendLine(", CedulonSi=@CedulonSi");
                sql.AppendLine(", Nro_cedulon=@Nro_cedulon");
                sql.AppendLine(", Barcode39=@Barcode39");
                sql.AppendLine(", Barcodeint25=@Barcodeint25");
                sql.AppendLine(", pagado=@pagado");
                sql.AppendLine(", monto_original=@monto_original");
                sql.AppendLine(", interes=@interes");
                sql.AppendLine(", descuento=@descuento");
                sql.AppendLine(", importe_pagar=@importe_pagar");
                sql.AppendLine(", Fecha_baja_real=@Fecha_baja_real");
                sql.AppendLine(", Nro_secuencia=@Nro_secuencia");
                sql.AppendLine(", Nro_orden=@Nro_orden");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_emision=@Nro_emision");
                sql.AppendLine("AND Nro_notificacion=@Nro_notificacion");
                sql.AppendLine("AND Dominio=@Dominio");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Nro_notificacion", obj.Nro_notificacion);
                    cmd.Parameters.AddWithValue("@Dominio", obj.Dominio);
                    cmd.Parameters.AddWithValue("@Nro_badec", obj.Nro_badec);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Nom_barrio_dom_esp", obj.Nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@Nom_calle_dom_esp", obj.Nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@Nro_dom_esp", obj.Nro_dom_esp);
                    cmd.Parameters.AddWithValue("@Ciudad_dom_esp", obj.Ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@Provincia_dom_esp", obj.Provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@Pais_dom_esp", obj.Pais_dom_esp);
                    cmd.Parameters.AddWithValue("@Cod_postal_esp", obj.Cod_postal_esp);
                    cmd.Parameters.AddWithValue("@Nro_proc", obj.Nro_proc);
                    cmd.Parameters.AddWithValue("@Fecha_vencimiento", obj.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@Periodo", obj.Periodo);
                    cmd.Parameters.AddWithValue("@Debe", obj.Debe);
                    cmd.Parameters.AddWithValue("@Nro_plan", obj.Nro_plan);
                    cmd.Parameters.AddWithValue("@Vencimiento", obj.Vencimiento);
                    cmd.Parameters.AddWithValue("@Cod_tipo_procuracion", obj.Cod_tipo_procuracion);
                    cmd.Parameters.AddWithValue("@Bloqueado", obj.Bloqueado);
                    cmd.Parameters.AddWithValue("@Codigo_procurador", obj.Codigo_procurador);
                    cmd.Parameters.AddWithValue("@TieneHonorarios", obj.TieneHonorarios);
                    cmd.Parameters.AddWithValue("@Tipo_descuento", obj.Tipo_descuento);
                    cmd.Parameters.AddWithValue("@Cod_formulario", obj.Cod_formulario);
                    cmd.Parameters.AddWithValue("@Codigo_estado_actual", obj.Codigo_estado_actual);
                    cmd.Parameters.AddWithValue("@ParaImprimir", obj.ParaImprimir);
                    cmd.Parameters.AddWithValue("@CedulonSi", obj.CedulonSi);
                    cmd.Parameters.AddWithValue("@Nro_cedulon", obj.Nro_cedulon);
                    cmd.Parameters.AddWithValue("@Barcode39", obj.Barcode39);
                    cmd.Parameters.AddWithValue("@Barcodeint25", obj.Barcodeint25);
                    cmd.Parameters.AddWithValue("@pagado", obj.pagado);
                    cmd.Parameters.AddWithValue("@monto_original", obj.monto_original);
                    cmd.Parameters.AddWithValue("@interes", obj.interes);
                    cmd.Parameters.AddWithValue("@descuento", obj.descuento);
                    cmd.Parameters.AddWithValue("@importe_pagar", obj.importe_pagar);
                    cmd.Parameters.AddWithValue("@Fecha_baja_real", obj.Fecha_baja_real);
                    cmd.Parameters.AddWithValue("@Nro_secuencia", obj.Nro_secuencia);
                    cmd.Parameters.AddWithValue("@Nro_orden", obj.Nro_orden);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Det_notificacion_auto obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Det_notificacion_auto ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_emision=@Nro_emision");
                sql.AppendLine("AND Nro_notificacion=@Nro_notificacion");
                sql.AppendLine("AND Dominio=@Dominio");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_emision", obj.Nro_emision);
                    cmd.Parameters.AddWithValue("@Nro_notificacion", obj.Nro_notificacion);
                    cmd.Parameters.AddWithValue("@Dominio", obj.Dominio);
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

