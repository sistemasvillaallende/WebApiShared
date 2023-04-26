using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApiShared.Helpers;

namespace WebApiShared.Entities.LOGIN
{
    public class UsuarioConOficina:DALBase
    {
        public int cod_usuario { get; set; }

        public string nombre { get; set; }

        public int legajo { get; set; }

        public bool administrador { get; set; }

        public string nombre_completo { get; set; }

        public string passwd { get; set; }

        public string email { get; set; }

        public bool baja { get; set; }

        public int cod_oficina { get; set; }

        public string nombre_oficina { get; set; }
        public string cuit { get; set; }


        public static UsuarioConOficina ValidUser(string user, string password)
        {
            UsuarioConOficina usuario = (UsuarioConOficina)null;
            SqlConnection sqlConnection = (SqlConnection)null;
            StringBuilder stringBuilder = new StringBuilder();
            MD5Encryption md5Encryption = new MD5Encryption();
            user = user.Replace("'", "").Replace(",", "").Replace("=", "");
            stringBuilder.AppendLine("SELECT U.*, O.nombre_oficina From USUARIOS_V2 U INNER JOIN OFICINAS O ON U.COD_OFICINA = O.codigo_oficina WHERE nombre = @user");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(new SqlParameter("@user", (object)user));
            try
            {
                sqlConnection = DALBase.GetConnection();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = stringBuilder.ToString();
                sqlCommand.Connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int ordinal1 = sqlDataReader.GetOrdinal("cod_usuario");
                int ordinal2 = sqlDataReader.GetOrdinal("nombre");
                int ordinal3 = sqlDataReader.GetOrdinal("legajo");
                int ordinal4 = sqlDataReader.GetOrdinal("administrador");
                int ordinal5 = sqlDataReader.GetOrdinal("nombre_completo");
                int ordinal6 = sqlDataReader.GetOrdinal("passwd");
                int ordinal7 = sqlDataReader.GetOrdinal("email");
                int ordinal8 = sqlDataReader.GetOrdinal("baja");
                int ordinal9 = sqlDataReader.GetOrdinal("COD_OFICINA");
                int ordinal10 = sqlDataReader.GetOrdinal("nombre_oficina");
                int cuit = sqlDataReader.GetOrdinal("cuit");
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader.GetString(sqlDataReader.GetOrdinal("passwd")) ==
                        MD5Encryption.EncryptMD5(password.Trim().ToUpper() +
                        user.Trim().ToUpper()))
                    {
                        usuario = new UsuarioConOficina();
                        if (!sqlDataReader.IsDBNull(ordinal4))
                            usuario.administrador = sqlDataReader.GetBoolean(ordinal4);
                        if (!sqlDataReader.IsDBNull(ordinal8))
                            usuario.baja = sqlDataReader.GetBoolean(ordinal8);
                        if (!sqlDataReader.IsDBNull(ordinal1))
                            usuario.cod_usuario = sqlDataReader.GetInt32(ordinal1);
                        if (!sqlDataReader.IsDBNull(ordinal7))
                            usuario.email = sqlDataReader.GetString(ordinal7);
                        if (!sqlDataReader.IsDBNull(ordinal3))
                            usuario.legajo = sqlDataReader.GetInt32(ordinal3);
                        if (!sqlDataReader.IsDBNull(ordinal2))
                            usuario.nombre = sqlDataReader.GetString(ordinal2);
                        if (!sqlDataReader.IsDBNull(ordinal5))
                            usuario.nombre_completo = sqlDataReader.GetString(ordinal5);
                        if (!sqlDataReader.IsDBNull(ordinal6))
                            usuario.passwd = sqlDataReader.GetString(ordinal6);
                        if (!sqlDataReader.IsDBNull(ordinal9))
                            usuario.cod_oficina = sqlDataReader.GetInt32(ordinal9);
                        if (!sqlDataReader.IsDBNull(ordinal10))
                            usuario.nombre_oficina = sqlDataReader.GetString(ordinal10);
                        if (!sqlDataReader.IsDBNull(cuit))
                            usuario.cuit = sqlDataReader.GetString(cuit);
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la Autenticación!!!.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static UsuarioConOficina getByPk(int cod_usuario)
        {
            SqlConnection sqlConnection = (SqlConnection)null;
            StringBuilder stringBuilder = new StringBuilder();
            UsuarioConOficina usuario = (UsuarioConOficina)null;
            stringBuilder.AppendLine("SELECT U.*, O.nombre_oficina From USUARIOS_V2 U INNER JOIN OFICINAS O ON U.COD_OFICINA = O.codigo_oficina WHERE cod_usuario = @cod_usuario");
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                sqlConnection = DALBase.GetConnection();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = stringBuilder.ToString();
                sqlCommand.Parameters.AddWithValue("@cod_usuario", cod_usuario);
                sqlCommand.Connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int ordinal1 = sqlDataReader.GetOrdinal("cod_usuario");
                int ordinal2 = sqlDataReader.GetOrdinal("nombre");
                int ordinal3 = sqlDataReader.GetOrdinal("legajo");
                int ordinal4 = sqlDataReader.GetOrdinal("administrador");
                int ordinal5 = sqlDataReader.GetOrdinal("nombre_completo");
                int ordinal6 = sqlDataReader.GetOrdinal("passwd");
                int ordinal7 = sqlDataReader.GetOrdinal("email");
                int ordinal8 = sqlDataReader.GetOrdinal("baja");
                int ordinal9 = sqlDataReader.GetOrdinal("COD_OFICINA");
                int ordinal10 = sqlDataReader.GetOrdinal("nombre_oficina");
                int cuit = sqlDataReader.GetOrdinal("cuit");
                while (sqlDataReader.Read())
                {
                    usuario = new UsuarioConOficina();
                    if (!sqlDataReader.IsDBNull(ordinal4))
                        usuario.administrador = sqlDataReader.GetBoolean(ordinal4);
                    if (!sqlDataReader.IsDBNull(ordinal8))
                        usuario.baja = sqlDataReader.GetBoolean(ordinal8);
                    if (!sqlDataReader.IsDBNull(ordinal1))
                        usuario.cod_usuario = sqlDataReader.GetInt32(ordinal1);
                    if (!sqlDataReader.IsDBNull(ordinal7))
                        usuario.email = sqlDataReader.GetString(ordinal7);
                    if (!sqlDataReader.IsDBNull(ordinal3))
                        usuario.legajo = sqlDataReader.GetInt32(ordinal3);
                    if (!sqlDataReader.IsDBNull(ordinal2))
                        usuario.nombre = sqlDataReader.GetString(ordinal2);
                    if (!sqlDataReader.IsDBNull(ordinal5))
                        usuario.nombre_completo = sqlDataReader.GetString(ordinal5);
                    if (!sqlDataReader.IsDBNull(ordinal6))
                        usuario.passwd = sqlDataReader.GetString(ordinal6);
                    if (!sqlDataReader.IsDBNull(ordinal9))
                        usuario.cod_oficina = sqlDataReader.GetInt32(ordinal9);
                    if (!sqlDataReader.IsDBNull(ordinal10))
                        usuario.nombre_oficina = sqlDataReader.GetString(ordinal10);
                    if (!sqlDataReader.IsDBNull(cuit))
                        usuario.cuit = sqlDataReader.GetString(cuit);
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la Autenticación!!!.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static bool ValidaPermiso(string User, string Proceso)
        {
            string strSQL = "";
            strSQL = "SELECT * FROM PROCESOS_V2 a, PROCESOS_x_USUARIO_V2 b, ";
            strSQL += "USUARIOS_V2 c WHERE ";
            strSQL += "c.nombre='" + User + "' AND ";
            strSQL += "c.cod_usuario=b.cod_usuario AND ";
            strSQL += "b.cod_proceso=a.cod_proceso AND ";
            strSQL += "a.proceso='" + Proceso + "'";



            SqlCommand cmd;
            SqlDataReader reader;
            SqlConnection cn = null;
            MD5Encryption objMD5 = new MD5Encryption();

            cn = DALBase.GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL.ToString();
            cmd.Connection.Open();

            try
            {
                //cn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    strSQL = "SELECT * FROM USUARIOS_V2 WHERE ";
                    strSQL += "administrador=1 AND ";
                    strSQL += "nombre='" + User + "'";
                    reader.Close();
                    //cmd = db.GetSqlStringCommand(strSQL);
                    //reader = db.ExecuteReader(cmd);
                    cmd.CommandText = strSQL.ToString();
                    //cmd.Connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la Autorización de Permiso!!!.");
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
