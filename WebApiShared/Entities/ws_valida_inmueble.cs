using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApiShared.Entities.CIDI.Comunicacion;

namespace WebApiShared.Entities
{
    public class ws_valida_inmueble: DALBase
    {
        public string Denominacion { get; set; }
        public string Titular { get; set; }
        public string Direccion { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        

        public ws_valida_inmueble() {
            Direccion = string.Empty;
            Titular = string.Empty;
            Denominacion = string.Empty;
            lat = string.Empty;
            lng = string.Empty;
        }
        private static List<ws_valida_inmueble> mapeo(SqlDataReader dr)
        {
            List<ws_valida_inmueble> lst = new List<ws_valida_inmueble>();
            ws_valida_inmueble obj;
            if (dr.HasRows)
            {
                int circunscripcion = dr.GetOrdinal("circunscripcion");
                int seccion = dr.GetOrdinal("seccion");
                int manzana = dr.GetOrdinal("manzana");
                int parcela = dr.GetOrdinal("parcela");
                int p_h = dr.GetOrdinal("p_h");
                int nom_barrio = dr.GetOrdinal("nom_barrio");
                int nom_calle = dr.GetOrdinal("nom_calle");
                int nro_dom_esp = dr.GetOrdinal("nro_dom_esp");
                int lat = dr.GetOrdinal("lat");
                int _long = dr.GetOrdinal("long");
                int cuil = dr.GetOrdinal("cuil");
                int apellido = dr.GetOrdinal("apellido");
                int nombre = dr.GetOrdinal("nombre");

                while (dr.Read())
                {
                    obj = new ws_valida_inmueble();
                    if (!dr.IsDBNull(circunscripcion)) 
                    {
                        obj.Denominacion =
                            armoDenominacion(dr.GetInt32(circunscripcion),
                            dr.GetInt32(seccion),
                            dr.GetInt32(manzana),
                            dr.GetInt32(parcela),
                            dr.GetInt32(p_h)); 
                            }
                    obj.Direccion = string.Format("{0} {1}, Barrio: {3}",
                        dr.GetString(nom_calle), dr.GetInt32(nro_dom_esp), dr.GetString(nom_barrio));
                    obj.Titular = string.Format("{0}", "{1}",
                        dr.GetString(apellido), dr.GetString(nombre));

                    if (!dr.IsDBNull(lat)) { obj.lat = dr.GetString(lat); }
                    if (!dr.IsDBNull(_long)) { obj.lng = dr.GetString(_long); }

                    lst.Add(obj);

                }
            }
            return lst;
        }
        public static string armoDenominacion(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                StringBuilder denominacion = new StringBuilder();

                if (cir < 10)
                    denominacion.AppendFormat("CIR: 0{0} - ", cir);
                if (cir > 9 && cir < 100)
                    denominacion.AppendFormat("CIR: {0} - ", cir);

                if (sec < 10)
                    denominacion.AppendFormat("SEC: 0{0} - ", sec);
                if (sec > 9 && sec < 100)
                    denominacion.AppendFormat("SEC: {0} - ", sec);

                if (man < 10)
                    denominacion.AppendFormat("MAN: 00{0} - ", man);
                if (man > 9 && man < 100)
                    denominacion.AppendFormat("MAN: 0{0} - ", man);
                if (man > 99)
                    denominacion.AppendFormat("MAN: {0} - ", man);

                if (par < 10)
                    denominacion.AppendFormat("PAR: 00{0} - ", par);
                if (par > 9 && par < 100)
                    denominacion.AppendFormat("PAR: 0{0} - ", par);
                if (par > 99)
                    denominacion.AppendFormat("PAR: {0} - ", par);

                if (p_h < 10)
                    denominacion.AppendFormat("P_H: 00{0}", p_h);
                if (p_h > 9 && p_h < 100)
                    denominacion.AppendFormat("P_H: 0{0}", p_h);
                if (p_h > 99)
                    denominacion.AppendFormat("P_H: {0}", p_h);

                return denominacion.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ws_valida_inmueble getByPk(int circunscripcion, int seccion, int manzana,
            int parcela, int p_h)
        {
            try
            {
                ws_valida_inmueble obj = new ws_valida_inmueble();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT 
	                                        A.circunscripcion, A.seccion, A.manzana, A.parcela, A.p_h,
	                                        B.nom_barrio, C.nom_calle, A.nro_dom_esp, A.lat, A.long,
	                                        A.cuil, D.apellido, D.nombre
                                        FROM INMUEBLES A
                                        INNER JOIN BARRIOS B ON A.cod_barrio = B.COD_BARRIO
                                        INNER JOIN CALLES C ON A.cod_calle_dom_esp = C.COD_CALLE
                                        FULL JOIN VECINO_DIGITAL D ON A.cuil = D.CUIT
                                        WHERE 
	                                        circunscripcion=@circunscripcion 
	                                        AND seccion=@seccion 
	                                        AND manzana=@manzana 
	                                        AND parcela=@parcela 
	                                        AND p_h=@p_h";

                    cmd.Parameters.AddWithValue("@circunscripcion", circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", seccion);
                    cmd.Parameters.AddWithValue("@manzana", manzana);
                    cmd.Parameters.AddWithValue("@parcela", parcela);
                    cmd.Parameters.AddWithValue("@p_h", p_h);

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ws_valida_inmueble> lst = mapeo(dr);
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
    }
}
