using System.Data;
using System.Data.SqlClient;

namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Template_notificacion:DALBase
    {
        public int idTemplate { get; set; }
        public string tituloReporte { get; set; }
        public string Reporte { get; set; }

        public Template_notificacion()
        {
            idTemplate = 0;
            tituloReporte = string.Empty;
            Reporte = string.Empty;
        }
        private static List<Template_notificacion> mapeo(SqlDataReader dr)
        {
            List<Template_notificacion> lst = new List<Template_notificacion>();
            Template_notificacion obj;
            if (dr.HasRows)
            {
                int idTemplate = dr.GetOrdinal("idTemplate");
                int tituloReporte = dr.GetOrdinal("tituloReporte");
                int Reporte = dr.GetOrdinal("Reporte");
                while (dr.Read())
                {
                    obj = new Template_notificacion();
                    if (!dr.IsDBNull(idTemplate)) { obj.idTemplate = dr.GetInt32(idTemplate); }
                    if (!dr.IsDBNull(tituloReporte)) { obj.tituloReporte = dr.GetString(tituloReporte); }
                    if (!dr.IsDBNull(Reporte)) { obj.Reporte = dr.GetString(Reporte); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Template_notificacion> ObtenerTextoReporte(int idTemplate, int subsistema)
        {
            try
            {
                List<Template_notificacion> lst = new List<Template_notificacion>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                            SELECT 
	                            idTemplate=trcp.Id_Template,
	                            tituloReporte=trcp.Titulo_Reporte, 
	                            Reporte=trdp.Detalle             
                            FROM TEMPLATE_REPORTE_CABECERA_PROC trcp              
	                            LEFT JOIN TEMPLATE_REPORTE_DETALLE_PROC trdp ON trdp.Id_Template = trcp.Id_Template     
	                            LEFT JOIN TEMPLATE_PLANTILLA_DETALLE tpd ON tpd.Id_parametro = trdp.Id_parametro        
	                            LEFT JOIN TEMPLATE_TIPO_PARAM ttp ON ttp.Id_parametro = tpd.Id_parametro                
                            WHERE trcp.Cod_estado_proc= @idTemplate AND trcp.es_web=1  AND trcp.Subsistema=@subsistema                    
	                            AND trdp.Nro_version= 
		                            (SELECT MAX(trdp2.Nro_version)                                  
		                            FROM TEMPLATE_REPORTE_DETALLE_PROC trdp2                       
		                            WHERE trdp2.Id_template=trdp.Id_template  AND trdp2.Activo=1)
	                            AND trdp.Id_parametro=3";
                    cmd.Parameters.AddWithValue("@idTemplate", idTemplate);
                    cmd.Parameters.AddWithValue("@subsistema", subsistema);
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

        public static List<Template_notificacion> ObtenerTextoRebeldia(int nro_expediente)
        {
            try
            {
                List<Template_notificacion> lst = new List<Template_notificacion>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT idTemplate=0,tituloReporte='RESOLUCION REPORTE', concat(VISTO ,CONSIDERANDO,ART_1, ART_2, ART_3) as Reporte
                                       FROM RESOLUCIONES_MULTAS WHERE NRO_EXPEDIENTE=@nro_expediente  AND ID_RESOLUCION=0";
                    cmd.Parameters.AddWithValue("@nro_expediente", nro_expediente);
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
