using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WebApiShared.Entities
{
    public class DALBase
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection("Data Source=10.11.15.107;Initial Catalog=SIIMVA;User ID=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Int32 SigPaso(string tableName, string campo, string campoid, int idTabla)
        {
            int id = 0;

            StringBuilder strSQL = new StringBuilder();

            strSQL.AppendLine("SELECT ISNULL(MAX(" + campo + "),0) As Mayor");
            strSQL.AppendLine("FROM " + tableName + " Where " + campoid + "=" + idTabla);

            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = null;

            //cmd.Parameters.Add(new SqlParameter("@campo", campo));
            //cmd.Parameters.Add(new SqlParameter("@table", tableName));

            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    id = dr.GetInt32(0);

                return id + 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo obtener el prox. código, " + ex.Message);
                throw ex;

            }
            finally { cn.Close(); }
        }

        public static Int32 CantDiasvenc(string tableName, string campo, string campoid, int idTabla)
        {
            int id = 0;

            StringBuilder strSQL = new StringBuilder();

            strSQL.AppendLine("SELECT ISNULL(" + campo + ",0) As TotalDias");
            strSQL.AppendLine("FROM " + tableName + " Where " + campoid + "=" + idTabla);

            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = null;

            //cmd.Parameters.Add(new SqlParameter("@campo", campo));
            //cmd.Parameters.Add(new SqlParameter("@table", tableName));

            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    id = dr.GetInt32(0);

                return id + 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo obtener el prox. código, " + ex.Message);
                throw ex;

            }
            finally { cn.Close(); }
        }
        public static string GetNombre(string tableName, string campo, string campoid, int idTabla)
        {
            string descripcion = "";

            StringBuilder strSQL = new StringBuilder();

            strSQL.AppendLine("SELECT " + campo + " As Descripcion");
            strSQL.AppendLine("FROM " + tableName + " Where " + campoid + "=" + idTabla);

            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = null;

            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    descripcion = dr.GetString(0);

                return descripcion;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo obtener el prox. código, " + ex.Message);
                throw ex;

            }
            finally { cn.Close(); }
        }
    }
}
