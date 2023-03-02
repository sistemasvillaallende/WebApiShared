using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiShared.Entities
{
    public class Rubros_x_iyc : DALBase
    {
        public int legajo { get; set; }
        public int cod_rubro { get; set; }
        public int Nro_sucursal { get; set; }
        public int cod_minimo { get; set; }
        public int cod_convenio { get; set; }
        public Single cantidad { get; set; }
        public bool Exento { get; set; }
        public bool Descuento { get; set; }
        public decimal Valor { get; set; }

        public Rubros_x_iyc()
        {
            legajo = 0;
            cod_rubro = 0;
            Nro_sucursal = 0;
            cod_minimo = 0;
            cod_convenio = 0;
            cantidad = 0;
            Exento = false;
            Descuento = false;
            Valor = 0;
        }

        private static List<Rubros_x_iyc> mapeo(SqlDataReader dr)
        {
            List<Rubros_x_iyc> lst = new List<Rubros_x_iyc>();
            Rubros_x_iyc obj;
            if (dr.HasRows)
            {
                int legajo = dr.GetOrdinal("legajo");
                int cod_rubro = dr.GetOrdinal("cod_rubro");
                int Nro_sucursal = dr.GetOrdinal("Nro_sucursal");
                int cod_minimo = dr.GetOrdinal("cod_minimo");
                int cod_convenio = dr.GetOrdinal("cod_convenio");
                int cantidad = dr.GetOrdinal("cantidad");
                int Exento = dr.GetOrdinal("Exento");
                int Descuento = dr.GetOrdinal("Descuento");
                int Valor = dr.GetOrdinal("Valor");
                while (dr.Read())
                {
                    obj = new Rubros_x_iyc();
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(cod_rubro)) { obj.cod_rubro = dr.GetInt32(cod_rubro); }
                    if (!dr.IsDBNull(Nro_sucursal)) { obj.Nro_sucursal = dr.GetInt32(Nro_sucursal); }
                    if (!dr.IsDBNull(cod_minimo)) { obj.cod_minimo = dr.GetInt32(cod_minimo); }
                    if (!dr.IsDBNull(cod_convenio)) { obj.cod_convenio = dr.GetInt32(cod_convenio); }
                    if (!dr.IsDBNull(cantidad)) { obj.cantidad = dr.GetFloat(cantidad); }
                    if (!dr.IsDBNull(Exento)) { obj.Exento = dr.GetBoolean(Exento); }
                    if (!dr.IsDBNull(Descuento)) { obj.Descuento = dr.GetBoolean(Descuento); }
                    if (!dr.IsDBNull(Valor)) { obj.Valor = dr.GetDecimal(Valor); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Rubros_x_iyc> read()
        {
            try
            {
                List<Rubros_x_iyc> lst = new List<Rubros_x_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Rubros_x_iyc";
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

        public static Rubros_x_iyc getByPk(
        int legajo, int cod_rubro, int Nro_sucursal)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Rubros_x_iyc WHERE");
                sql.AppendLine("legajo = @legajo");
                sql.AppendLine("AND cod_rubro = @cod_rubro");
                sql.AppendLine("AND Nro_sucursal = @Nro_sucursal");
                Rubros_x_iyc obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@cod_rubro", cod_rubro);
                    cmd.Parameters.AddWithValue("@Nro_sucursal", Nro_sucursal);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Rubros_x_iyc> lst = mapeo(dr);
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

        public static int insert(Rubros_x_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Rubros_x_iyc(");
                sql.AppendLine("legajo");
                sql.AppendLine(", cod_rubro");
                sql.AppendLine(", Nro_sucursal");
                sql.AppendLine(", cod_minimo");
                sql.AppendLine(", cod_convenio");
                sql.AppendLine(", cantidad");
                sql.AppendLine(", Exento");
                sql.AppendLine(", Descuento");
                sql.AppendLine(", Valor");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@legajo");
                sql.AppendLine(", @cod_rubro");
                sql.AppendLine(", @Nro_sucursal");
                sql.AppendLine(", @cod_minimo");
                sql.AppendLine(", @cod_convenio");
                sql.AppendLine(", @cantidad");
                sql.AppendLine(", @Exento");
                sql.AppendLine(", @Descuento");
                sql.AppendLine(", @Valor");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@Nro_sucursal", obj.Nro_sucursal);
                    cmd.Parameters.AddWithValue("@cod_minimo", obj.cod_minimo);
                    cmd.Parameters.AddWithValue("@cod_convenio", obj.cod_convenio);
                    cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                    cmd.Parameters.AddWithValue("@Exento", obj.Exento);
                    cmd.Parameters.AddWithValue("@Descuento", obj.Descuento);
                    cmd.Parameters.AddWithValue("@Valor", obj.Valor);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Rubros_x_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Rubros_x_iyc SET");
                sql.AppendLine("cod_minimo=@cod_minimo");
                sql.AppendLine(", cod_convenio=@cod_convenio");
                sql.AppendLine(", cantidad=@cantidad");
                sql.AppendLine(", Exento=@Exento");
                sql.AppendLine(", Descuento=@Descuento");
                sql.AppendLine(", Valor=@Valor");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND cod_rubro=@cod_rubro");
                sql.AppendLine("AND Nro_sucursal=@Nro_sucursal");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@Nro_sucursal", obj.Nro_sucursal);
                    cmd.Parameters.AddWithValue("@cod_minimo", obj.cod_minimo);
                    cmd.Parameters.AddWithValue("@cod_convenio", obj.cod_convenio);
                    cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                    cmd.Parameters.AddWithValue("@Exento", obj.Exento);
                    cmd.Parameters.AddWithValue("@Descuento", obj.Descuento);
                    cmd.Parameters.AddWithValue("@Valor", obj.Valor);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Rubros_x_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Rubros_x_iyc ");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND cod_rubro=@cod_rubro");
                sql.AppendLine("AND Nro_sucursal=@Nro_sucursal");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@Nro_sucursal", obj.Nro_sucursal);
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

