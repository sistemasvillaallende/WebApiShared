using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Estados_procuracion : DALBase
    {
        public int codigo_estado { get; set; }
        public string descripcion_estado { get; set; }
        public int tiempo_estado { get; set; }
        public int cod_situacion { get; set; }
        public bool judicial { get; set; }
        public bool emite_plan_cedulon { get; set; }
        public int orden { get; set; }
        public Int16 abogado { get; set; }
        public Int16 quita_deuda { get; set; }
        public int tipo_reporte { get; set; }
        public int emite_notif_cidi { get; set; }

        

        public Estados_procuracion()
        {
            codigo_estado = 0;
            descripcion_estado = string.Empty;
            tiempo_estado = 0;
            cod_situacion = 0;
            judicial = false;
            emite_plan_cedulon = false;
            orden = 0;
            abogado = 0;
            quita_deuda = 0;
            tipo_reporte = 0;
            emite_notif_cidi = 0;   
        }

        private static List<Estados_procuracion> mapeo(SqlDataReader dr)
        {
            List<Estados_procuracion> lst = new List<Estados_procuracion>();
            Estados_procuracion obj;
            if (dr.HasRows)
            {
                int codigo_estado = dr.GetOrdinal("codigo_estado");
                int descripcion_estado = dr.GetOrdinal("descripcion_estado");
                int tiempo_estado = dr.GetOrdinal("tiempo_estado");
                int cod_situacion = dr.GetOrdinal("cod_situacion");
                int judicial = dr.GetOrdinal("judicial");
                int emite_plan_cedulon = dr.GetOrdinal("emite_plan_cedulon");
                int orden = dr.GetOrdinal("orden");
                int abogado = dr.GetOrdinal("abogado");
                int quita_deuda = dr.GetOrdinal("quita_deuda");
                int tipo_reporte = dr.GetOrdinal("tipo_reporte");
                int emite_notif_cidi = dr.GetOrdinal("emite_notif_cidi");

                while (dr.Read())
                {
                    obj = new Estados_procuracion();
                    if (!dr.IsDBNull(codigo_estado)) { obj.codigo_estado = dr.GetInt32(codigo_estado); }
                    if (!dr.IsDBNull(descripcion_estado)) { obj.descripcion_estado = dr.GetString(descripcion_estado); }
                    if (!dr.IsDBNull(tiempo_estado)) { obj.tiempo_estado = dr.GetInt32(tiempo_estado); }
                    if (!dr.IsDBNull(cod_situacion)) { obj.cod_situacion = dr.GetInt32(cod_situacion); }
                    if (!dr.IsDBNull(judicial)) { obj.judicial = dr.GetBoolean(judicial); }
                    if (!dr.IsDBNull(emite_plan_cedulon)) { obj.emite_plan_cedulon = dr.GetBoolean(emite_plan_cedulon); }
                    if (!dr.IsDBNull(orden)) { obj.orden = dr.GetInt32(orden); }
                    if (!dr.IsDBNull(abogado)) { obj.abogado = dr.GetInt16(abogado); }
                    if (!dr.IsDBNull(quita_deuda)) { obj.quita_deuda = dr.GetInt16(quita_deuda); }
                    if (!dr.IsDBNull(tipo_reporte)) { obj.tipo_reporte = dr.GetInt32(tipo_reporte); }
                    if (!dr.IsDBNull(emite_notif_cidi)) { obj.emite_notif_cidi = dr.GetInt32(emite_notif_cidi); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        private static List<Estados_procuracion> mapeo2(SqlDataReader dr)
        {
            List<Estados_procuracion> lst = new List<Estados_procuracion>();
            Estados_procuracion obj;
            if (dr.HasRows)
            {
                int codigo_estado = dr.GetOrdinal("codigo_estado");
                int descripcion_estado = dr.GetOrdinal("descripcion_estado");
                int emite_notif_cidi = dr.GetOrdinal("emite_notif_cidi");
                while (dr.Read())
                {
                    obj = new Estados_procuracion();
                    if (!dr.IsDBNull(codigo_estado)) { obj.codigo_estado = dr.GetInt32(codigo_estado); }
                    if (!dr.IsDBNull(descripcion_estado)) { obj.descripcion_estado = dr.GetString(descripcion_estado); }
                    if (!dr.IsDBNull(emite_notif_cidi)) { obj.emite_notif_cidi = dr.GetInt32(emite_notif_cidi); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Estados_procuracion> ListarEstadosxNotif(int nro_emision,int subsistema)
        {
            try
            {
                List<Estados_procuracion> lst = new List<Estados_procuracion>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    if (subsistema==1)
                    {
                        cmd.CommandText = @"SELECT distinct    codigo_estado= (  SELECT ep.codigo_estado
                                        FROM PROCURA_TASA pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion AND a.Circunscripcion=pa.Circunscripcion
                                         AND a.seccion=pa.seccion AND a.manzana=pa.manzana AND a.parcela=pa.parcela AND a.p_h=pa.p_h),
                                        descripcion_estado= (  SELECT ep.descripcion_estado
                                                                                FROM PROCURA_TASA pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion ),
										 emite_notif_cidi=isnull( (  SELECT ep.emite_notif_cidi
                                                                                FROM PROCURA_TASA pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion AND a.Circunscripcion=pa.Circunscripcion
                                         AND a.seccion=pa.seccion AND a.manzana=pa.manzana AND a.parcela=pa.parcela AND a.p_h=pa.p_h),0)
                    FROM Det_Notificacion_Estado_Proc_INM A (nolock)left join INMUEBLES V ON a.Circunscripcion=v.Circunscripcion
                                         AND a.seccion=v.seccion AND a.manzana=v.manzana AND a.parcela=v.parcela AND a.p_h=v.p_h
                    left join badec b  on b.NRO_BAD=a.Nro_Badec
                    WHERE
                    nro_emision=" + nro_emision.ToString();

                    }
                    if (subsistema == 3)
                    {
                        cmd.CommandText = @"SELECT distinct    codigo_estado= (  SELECT ep.codigo_estado
                                        FROM PROCURA_IYC pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo),
                                        descripcion_estado= (  SELECT ep.descripcion_estado
                                                                                FROM PROCURA_IYC pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo),
										 emite_notif_cidi=isnull( (  SELECT ep.emite_notif_cidi
                                                                                FROM PROCURA_iyc pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo),0)
                    FROM Det_Notificacion_Estado_Proc_iyc A (nolock)left join indycom V ON V.legajo=A.legajo
                    left join badec b  on b.NRO_BAD=a.Nro_Badec
                    WHERE
                    nro_emision=" + nro_emision.ToString();

                    }
                    if (subsistema == 4)
                    {
                        cmd.CommandText = @"SELECT distinct    codigo_estado= (  SELECT ep.codigo_estado
                                        FROM PROCURA_AUTO pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion AND a.Dominio=pa.dominio),
                                        descripcion_estado= (  SELECT ep.descripcion_estado
                                                                                FROM PROCURA_AUTO pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion AND a.Dominio=pa.dominio),
										 emite_notif_cidi=isnull( (  SELECT ep.emite_notif_cidi
                                                                                FROM PROCURA_AUTO pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion AND a.Dominio=pa.dominio),0)
                    FROM Det_Notificacion_Estado_Proc_Auto A (nolock)left join VEHICULOS V ON V.DOMINIO=A.DOMINIO
                    left join badec b  on b.NRO_BAD=a.Nro_Badec
                    WHERE
                    nro_emision=" + nro_emision.ToString();
                    }

                   
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Estados_procuracion> ListarEstadosxNotifNuevas(int nro_emision, int subsistema)
        {
            try
            {
                List<Estados_procuracion> lst = new List<Estados_procuracion>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    if (subsistema == 1)
                    {
                        cmd.CommandText = @"SELECT distinct    codigo_estado= (  SELECT ep.codigo_estado
                                        FROM PROCURA_TASA pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion AND a.Circunscripcion=pa.Circunscripcion
                                         AND a.seccion=pa.seccion AND a.manzana=pa.manzana AND a.parcela=pa.parcela AND a.p_h=pa.p_h),
                                        descripcion_estado= (  SELECT ep.descripcion_estado
                                                                                FROM PROCURA_TASA pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion ),
										 emite_notif_cidi=isnull( (  SELECT ep.emite_notif_cidi
                                                                                FROM PROCURA_TASA pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion AND a.Circunscripcion=pa.Circunscripcion
                                         AND a.seccion=pa.seccion AND a.manzana=pa.manzana AND a.parcela=pa.parcela AND a.p_h=pa.p_h),0)
                    FROM Det_Notificacion_Estado_Proc_INM A (nolock)left join INMUEBLES V ON a.Circunscripcion=v.Circunscripcion
                                         AND a.seccion=v.seccion AND a.manzana=v.manzana AND a.parcela=v.parcela AND a.p_h=v.p_h
                    left join badec b  on b.NRO_BAD=a.Nro_Badec
                    WHERE
                    nro_emision=" + nro_emision.ToString();

                    }
                    if (subsistema == 3)
                    {
                        cmd.CommandText = @"SELECT distinct    codigo_estado= (  SELECT ep.codigo_estado
                                        FROM PROCURA_IYC pa
                                         JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                        AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo),
                                        descripcion_estado= (  SELECT ep.descripcion_estado
                                                                                FROM PROCURA_IYC pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo),
										 emite_notif_cidi=isnull( (  SELECT ep.emite_notif_cidi
                                                                                FROM PROCURA_iyc pa
                                                                                 JOIN ESTADOS_PROCURACION ep ON ep.codigo_estado=pa.codigo_estado_actual
                                                                                AND pa.nro_procuracion=a.Nro_Procuracion AND a.legajo=pa.legajo),0)
                    FROM Det_Notificacion_Estado_Proc_iyc A (nolock)left join indycom V ON V.legajo=A.legajo
                    left join badec b  on b.NRO_BAD=a.Nro_Badec
                    WHERE
                    nro_emision=" + nro_emision.ToString();

                    }
                    if (subsistema == 4)
                    {
                        cmd.CommandText = @"SELECT DISTINCT * FROM ESTADOS_PROCURACION
                                            WHERE codigo_estado IN (
	                                        SELECT Codigo_estado_actual FROM  DET_NOTIFICACION_AUTO
	                                        WHERE nro_emision=@nro_emision)";
                    }

                    cmd.Parameters.AddWithValue("@nro_emision", nro_emision);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Estados_procuracion getByPk(
        int codigo_estado)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Estados_procuracion WHERE");
                sql.AppendLine("codigo_estado = @codigo_estado");
                Estados_procuracion obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Estados_procuracion> lst = mapeo(dr);
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

        public static int insert(Estados_procuracion obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Estados_procuracion(");
                sql.AppendLine("codigo_estado");
                sql.AppendLine(", descripcion_estado");
                sql.AppendLine(", tiempo_estado");
                sql.AppendLine(", cod_situacion");
                sql.AppendLine(", judicial");
                sql.AppendLine(", emite_plan_cedulon");
                sql.AppendLine(", orden");
                sql.AppendLine(", abogado");
                sql.AppendLine(", quita_deuda");
                sql.AppendLine(", tipo_reporte");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@codigo_estado");
                sql.AppendLine(", @descripcion_estado");
                sql.AppendLine(", @tiempo_estado");
                sql.AppendLine(", @cod_situacion");
                sql.AppendLine(", @judicial");
                sql.AppendLine(", @emite_plan_cedulon");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @abogado");
                sql.AppendLine(", @quita_deuda");
                sql.AppendLine(", @tipo_reporte");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo_estado", obj.codigo_estado);
                    cmd.Parameters.AddWithValue("@descripcion_estado", obj.descripcion_estado);
                    cmd.Parameters.AddWithValue("@tiempo_estado", obj.tiempo_estado);
                    cmd.Parameters.AddWithValue("@cod_situacion", obj.cod_situacion);
                    cmd.Parameters.AddWithValue("@judicial", obj.judicial);
                    cmd.Parameters.AddWithValue("@emite_plan_cedulon", obj.emite_plan_cedulon);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@abogado", obj.abogado);
                    cmd.Parameters.AddWithValue("@quita_deuda", obj.quita_deuda);
                    cmd.Parameters.AddWithValue("@tipo_reporte", obj.tipo_reporte);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Estados_procuracion obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Estados_procuracion SET");
                sql.AppendLine("descripcion_estado=@descripcion_estado");
                sql.AppendLine(", tiempo_estado=@tiempo_estado");
                sql.AppendLine(", cod_situacion=@cod_situacion");
                sql.AppendLine(", judicial=@judicial");
                sql.AppendLine(", emite_plan_cedulon=@emite_plan_cedulon");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine(", abogado=@abogado");
                sql.AppendLine(", quita_deuda=@quita_deuda");
                sql.AppendLine(", tipo_reporte=@tipo_reporte");
                sql.AppendLine("WHERE");
                sql.AppendLine("codigo_estado=@codigo_estado");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo_estado", obj.codigo_estado);
                    cmd.Parameters.AddWithValue("@descripcion_estado", obj.descripcion_estado);
                    cmd.Parameters.AddWithValue("@tiempo_estado", obj.tiempo_estado);
                    cmd.Parameters.AddWithValue("@cod_situacion", obj.cod_situacion);
                    cmd.Parameters.AddWithValue("@judicial", obj.judicial);
                    cmd.Parameters.AddWithValue("@emite_plan_cedulon", obj.emite_plan_cedulon);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@abogado", obj.abogado);
                    cmd.Parameters.AddWithValue("@quita_deuda", obj.quita_deuda);
                    cmd.Parameters.AddWithValue("@tipo_reporte", obj.tipo_reporte);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Estados_procuracion obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Estados_procuracion ");
                sql.AppendLine("WHERE");
                sql.AppendLine("codigo_estado=@codigo_estado");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo_estado", obj.codigo_estado);
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

