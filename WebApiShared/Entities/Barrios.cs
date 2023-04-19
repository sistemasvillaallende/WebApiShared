using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiShared.Entities
{
    public class Barrios : DALBase
    {
        public int COD_BARRIO { get; set; }
        public string NOM_BARRIO { get; set; }
        public Int16 BarrioCerrado { get; set; }

        public Barrios()
        {
            COD_BARRIO = 0;
            NOM_BARRIO = string.Empty;
            BarrioCerrado = 0;
        }

        private static List<Barrios> mapeo(SqlDataReader dr)
        {
            List<Barrios> lst = new List<Barrios>();
            Barrios obj;
            if (dr.HasRows)
            {
                int COD_BARRIO = dr.GetOrdinal("COD_BARRIO");
                int NOM_BARRIO = dr.GetOrdinal("NOM_BARRIO");
                int BarrioCerrado = dr.GetOrdinal("BarrioCerrado");
                while (dr.Read())
                {
                    obj = new Barrios();
                    if (!dr.IsDBNull(COD_BARRIO)) { obj.COD_BARRIO = dr.GetInt32(COD_BARRIO); }
                    if (!dr.IsDBNull(NOM_BARRIO)) { obj.NOM_BARRIO = dr.GetString(NOM_BARRIO); }
                    if (!dr.IsDBNull(BarrioCerrado)) { obj.BarrioCerrado = dr.GetInt16(BarrioCerrado); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Barrios> read()
        {
            try
            {
                List<Barrios> lst = new List<Barrios>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Barrios";
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

        public static Barrios getByPk(
        int COD_BARRIO)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Barrios WHERE");
                sql.AppendLine("COD_BARRIO = @COD_BARRIO");
                Barrios obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@COD_BARRIO", COD_BARRIO);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Barrios> lst = mapeo(dr);
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

        public static int insert(Barrios obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Barrios(");
                sql.AppendLine("COD_BARRIO");
                sql.AppendLine(", NOM_BARRIO");
                sql.AppendLine(", BarrioCerrado");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@COD_BARRIO");
                sql.AppendLine(", @NOM_BARRIO");
                sql.AppendLine(", @BarrioCerrado");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@COD_BARRIO", obj.COD_BARRIO);
                    cmd.Parameters.AddWithValue("@NOM_BARRIO", obj.NOM_BARRIO);
                    cmd.Parameters.AddWithValue("@BarrioCerrado", obj.BarrioCerrado);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Barrios obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Barrios SET");
                sql.AppendLine("NOM_BARRIO=@NOM_BARRIO");
                sql.AppendLine(", BarrioCerrado=@BarrioCerrado");
                sql.AppendLine("WHERE");
                sql.AppendLine("COD_BARRIO=@COD_BARRIO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@COD_BARRIO", obj.COD_BARRIO);
                    cmd.Parameters.AddWithValue("@NOM_BARRIO", obj.NOM_BARRIO);
                    cmd.Parameters.AddWithValue("@BarrioCerrado", obj.BarrioCerrado);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Barrios obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Barrios ");
                sql.AppendLine("WHERE");
                sql.AppendLine("COD_BARRIO=@COD_BARRIO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@COD_BARRIO", obj.COD_BARRIO);
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

