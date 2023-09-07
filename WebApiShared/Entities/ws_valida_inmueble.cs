using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WebApiShared.Entities
{
    public class ws_valida_inmueble: DALBase
    {
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public string nom_barrio { get; set; }
        public string nom_calle { get; set; }
        public int nro_dom_esp { get; set; }
        public string lat { get; set; }
        public string _long { get; set; }
        public string cuil { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }

        public ws_valida_inmueble() {
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            nom_barrio = string.Empty;
            nom_calle = string.Empty;
            nro_dom_esp = 0;
            lat = string.Empty;
            _long = string.Empty;
            cuil = string.Empty;
            apellido = string.Empty;
            nombre = string.Empty;
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
                    if (!dr.IsDBNull(circunscripcion)) { obj.circunscripcion = dr.GetInt32(circunscripcion); }
                    if (!dr.IsDBNull(seccion)) { obj.seccion = dr.GetInt32(seccion); }
                    if (!dr.IsDBNull(manzana)) { obj.manzana = dr.GetInt32(manzana); }
                    if (!dr.IsDBNull(circunscripcion)) { obj.circunscripcion = dr.GetInt32(circunscripcion); }
                    if (!dr.IsDBNull(p_h)) { obj.p_h = dr.GetInt32(p_h); }
                    if (!dr.IsDBNull(nom_barrio)) { obj.nom_barrio = dr.GetString(nom_barrio); }
                    if (!dr.IsDBNull(nom_calle)) { obj.nom_calle = dr.GetString(nom_calle); }
                    if (!dr.IsDBNull(nro_dom_esp)) { obj.nro_dom_esp = dr.GetInt32(nro_dom_esp); }
                    if (!dr.IsDBNull(lat)) { obj.lat = dr.GetString(lat); }
                    if (!dr.IsDBNull(_long)) { obj._long = dr.GetString(_long); }
                    if (!dr.IsDBNull(cuil)) { obj.cuil = dr.GetString(cuil); }
                    if (!dr.IsDBNull(apellido)) { obj.apellido = dr.GetString(apellido); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    lst.Add(obj);
                }
            }
            return lst;
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
