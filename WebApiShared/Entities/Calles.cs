using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiShared.Entities
{
    public class Calles : DALBase
    {
        public int cod_calle { get; set; }
        public string nom_calle { get; set; }
        public int cod_barrio { get; set; }

        public Calles()
        {
            cod_calle = 0;
            nom_calle = string.Empty;
        }

        private static List<Calles> mapeo(SqlDataReader dr)
        {
            List<Calles> lst = new List<Calles>();
            Calles obj;
            if (dr.HasRows)
            {
                int COD_CALLE = dr.GetOrdinal("COD_CALLE");
                int NOM_CALLE = dr.GetOrdinal("NOM_CALLE");
                int cod_barrio = dr.GetOrdinal("cod_barrio");
                while (dr.Read())
                {
                    obj = new Calles();
                    if (!dr.IsDBNull(COD_CALLE)) { obj.cod_calle = dr.GetInt32(COD_CALLE); }
                    if (!dr.IsDBNull(NOM_CALLE)) { obj.nom_calle = dr.GetString(NOM_CALLE); }
                    if (!dr.IsDBNull(cod_barrio)) { obj.cod_barrio = dr.GetInt32(cod_barrio); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Calles> read()
        {
            try
            {
                List<Calles> lst = new List<Calles>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Calles";
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
        public static List<Calles> read(int cod_barrio)
        {
            try
            {
                List<Calles> lst = new List<Calles>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT *FROM Calles A
                                        INNER JOIN CALLES_X_BARRIO B ON A.COD_CALLE=B.cod_calle
                                        WHERE B.cod_barrio=@COD_BARRIO";
                    cmd.Parameters.AddWithValue("@cod_barrio", cod_barrio);
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

        public static Calles getByPk(
        int COD_CALLE)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                Calles obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT *FROM Calles A
                                        INNER JOIN CALLES_X_BARRIO B ON A.COD_CALLE=B.cod_calle
                                        WHERE B.COD_CALLE=@COD_CALLE";
                    cmd.Parameters.AddWithValue("@COD_CALLE", COD_CALLE);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Calles> lst = mapeo(dr);
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

