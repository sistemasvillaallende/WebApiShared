using System.Data;
using System.Data.SqlClient;

namespace WebApiShared.Entities
{
    public class ws_valida_comercio : DALBase
    {
        public int legajo { get; set; }
        public string nom_fantasia { get; set; }
        public string des_com { get; set; }
        public string nom_barrio { get; set; }
        public string nom_calle { get; set; }
        public int nro_dom_esp { get; set; }
        public string tipo_liquidacion { get; set; }
        public string nro_cuit { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public bool dado_baja { get; set; }
        public ws_valida_comercio()
        {
            legajo = 0;
            nom_fantasia = string.Empty;
            des_com = string.Empty;
            nom_barrio = string.Empty;
            nom_calle = string.Empty;
            nro_dom_esp = 0;
            tipo_liquidacion = string.Empty;
            nro_cuit = string.Empty;
            apellido = string.Empty;
            nombre = string.Empty;
            dado_baja = false;
        }
        private static List<ws_valida_comercio> mapeo(SqlDataReader dr)
        {
            List<ws_valida_comercio> lst = new List<ws_valida_comercio>();
            ws_valida_comercio obj;
            if (dr.HasRows)
            {
                int legajo = dr.GetOrdinal("legajo");
                int nom_fantasia = dr.GetOrdinal("nom_fantasia");
                int des_com = dr.GetOrdinal("des_com");
                int nom_barrio = dr.GetOrdinal("nom_barrio");
                int nom_calle = dr.GetOrdinal("nom_calle");
                int nro_dom_esp = dr.GetOrdinal("nro_dom_esp");
                int tipo_liquidacion = dr.GetOrdinal("tipo_liquidacion");
                int nro_cuit = dr.GetOrdinal("nro_cuit");
                int apellido = dr.GetOrdinal("apellido");
                int nombre = dr.GetOrdinal("nombre");
                int dado_baja = dr.GetOrdinal("dado_baja");

                while (dr.Read())
                {
                    obj = new ws_valida_comercio();
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(nom_fantasia)) { obj.nom_fantasia = dr.GetString(nom_fantasia); }
                    if (!dr.IsDBNull(des_com)) { obj.des_com = dr.GetString(des_com); }
                    if (!dr.IsDBNull(nom_barrio)) { obj.nom_barrio = dr.GetString(nom_barrio); }
                    if (!dr.IsDBNull(nom_calle)) { obj.nom_calle = dr.GetString(nom_calle); }
                    if (!dr.IsDBNull(nom_barrio)) { obj.nom_barrio = dr.GetString(nom_barrio); }
                    if (!dr.IsDBNull(nom_calle)) { obj.nom_calle = dr.GetString(nom_calle); }
                    if (!dr.IsDBNull(nro_dom_esp)) { obj.nro_dom_esp = dr.GetInt32(nro_dom_esp); }
                    if (!dr.IsDBNull(tipo_liquidacion)) { obj.tipo_liquidacion = dr.GetString(tipo_liquidacion); }
                    if (!dr.IsDBNull(nro_cuit)) { obj.nro_cuit = dr.GetString(nro_cuit); }
                    if (!dr.IsDBNull(apellido)) { obj.apellido = dr.GetString(apellido); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(dado_baja)) { obj.dado_baja = dr.GetBoolean(dado_baja); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static ws_valida_comercio getByPk(int legajo)
        {
            try
            {
                ws_valida_comercio obj = new ws_valida_comercio();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT 
	                                        A.legajo, A.nom_fantasia, A.des_com,
	                                        B.nom_barrio, C.nom_calle, A.nro_dom_esp, 
	                                        tipo_liquidacion = CASE 
		                                        WHEN A.tipo_liquidacion = 1 THEN 'TRIBUTA MINIMO'
		                                        WHEN A.tipo_liquidacion = 2 THEN 'DDJJ'
	                                        END,
	                                        A.nro_cuit, D.apellido, D.nombre, A.dado_baja
                                        FROM INDYCOM A
                                        INNER JOIN BARRIOS B ON A.cod_barrio = B.COD_BARRIO
                                        INNER JOIN CALLES C ON A.cod_calle_dom_esp = C.COD_CALLE
                                        FULL JOIN VECINO_DIGITAL D ON A.nro_cuit = D.CUIT
                                        WHERE 
	                                        A.legajo=@legajo";

                    cmd.Parameters.AddWithValue("@legajo", legajo);

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ws_valida_comercio> lst = mapeo(dr);
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
