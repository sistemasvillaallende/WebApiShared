using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiShared.Entities
{
    public class Rubros : DALBase
    {
        public int cod_rubro { get; set; }
        public int anio { get; set; }
        public string concepto { get; set; }
        public decimal alicuota_oim { get; set; }
        public decimal alicuota_sys { get; set; }
        public decimal minimo_oim { get; set; }
        public decimal minimo_sys { get; set; }
        public bool incluido_en_oim { get; set; }
        public string observaciones { get; set; }
        public bool activo { get; set; }
        public int cod_tipo_riesgo { get; set; }
        public int cod_tipo_actividad { get; set; }

        public Rubros()
        {
            cod_rubro = 0;
            anio = 0;
            concepto = string.Empty;
            alicuota_oim = 0;
            alicuota_sys = 0;
            minimo_oim = 0;
            minimo_sys = 0;
            incluido_en_oim = false;
            observaciones = string.Empty;
            activo = false;
            cod_tipo_riesgo = 0;
            cod_tipo_actividad = 0;
        }
        private static List<Combo> mapeoReducido(SqlDataReader dr)
        {
            List<Combo> lst = new List<Combo>();
            Combo obj;
            if (dr.HasRows)
            {
                int cod_rubro = dr.GetOrdinal("cod_rubro");
                int concepto = dr.GetOrdinal("concepto");

                while (dr.Read())
                {
                    obj = new Combo();
                    if (!dr.IsDBNull(cod_rubro)) { obj.value = dr.GetInt32(cod_rubro).ToString(); }
                    if (!dr.IsDBNull(concepto)) { obj.text = dr.GetString(concepto); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<Rubros> mapeo(SqlDataReader dr)
        {
            List<Rubros> lst = new List<Rubros>();
            Rubros obj;
            if (dr.HasRows)
            {
                int cod_rubro = dr.GetOrdinal("cod_rubro");
                int anio = dr.GetOrdinal("anio");
                int concepto = dr.GetOrdinal("concepto");
                int alicuota_oim = dr.GetOrdinal("alicuota_oim");
                int alicuota_sys = dr.GetOrdinal("alicuota_sys");
                int minimo_oim = dr.GetOrdinal("minimo_oim");
                int minimo_sys = dr.GetOrdinal("minimo_sys");
                int incluido_en_oim = dr.GetOrdinal("incluido_en_oim");
                int observaciones = dr.GetOrdinal("observaciones");
                int activo = dr.GetOrdinal("activo");
                int cod_tipo_riesgo = dr.GetOrdinal("cod_tipo_riesgo");
                int cod_tipo_actividad = dr.GetOrdinal("cod_tipo_actividad");
                while (dr.Read())
                {
                    obj = new Rubros();
                    if (!dr.IsDBNull(cod_rubro)) { obj.cod_rubro = dr.GetInt32(cod_rubro); }
                    if (!dr.IsDBNull(anio)) { obj.anio = dr.GetInt32(anio); }
                    if (!dr.IsDBNull(concepto)) { obj.concepto = dr.GetString(concepto); }
                    if (!dr.IsDBNull(alicuota_oim)) { obj.alicuota_oim = dr.GetDecimal(alicuota_oim); }
                    if (!dr.IsDBNull(alicuota_sys)) { obj.alicuota_sys = dr.GetDecimal(alicuota_sys); }
                    if (!dr.IsDBNull(minimo_oim)) { obj.minimo_oim = dr.GetDecimal(minimo_oim); }
                    if (!dr.IsDBNull(minimo_sys)) { obj.minimo_sys = dr.GetDecimal(minimo_sys); }
                    if (!dr.IsDBNull(incluido_en_oim)) { obj.incluido_en_oim = dr.GetBoolean(incluido_en_oim); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                    if (!dr.IsDBNull(cod_tipo_riesgo)) { obj.cod_tipo_riesgo = dr.GetInt32(cod_tipo_riesgo); }
                    if (!dr.IsDBNull(cod_tipo_actividad)) { obj.cod_tipo_actividad = dr.GetInt32(cod_tipo_actividad); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Combo> read()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                    @"SELECT *FROM SIIMVA.dbo.RUBROS
                        WHERE anio=YEAR(GETDATE()) AND activo=1 AND periodo_desde NOT LIKE ('%71%') 
                        AND periodo_hasta NOT LIKE ('%71%') AND
                        GETDATE() BETWEEN 
                        CONVERT(DATE, '01-' + SUBSTRING(periodo_desde, 6, 2) + '-' + SUBSTRING(periodo_hasta, 1, 4))
                        AND CONVERT(DATE, '01-' + SUBSTRING(periodo_hasta, 6, 2) + '-' + SUBSTRING(periodo_hasta, 1, 4))
                        ORDER BY concepto";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeoReducido(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Combo> getByComercio(int leg)
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                @"SELECT *FROM SIIMVA.dbo.RUBROS A
                    INNER JOIN SIIMVA.dbo.RUBROS_X_IYC B ON B.cod_rubro = A.cod_rubro
                    INNER JOIN SIIMVA.dbo.INDYCOM C ON B.legajo=C.legajo 
                    WHERE anio=YEAR(GETDATE()) AND activo=1 AND C.legajo = @legago AND periodo_desde 
                    NOT LIKE ('%71%') AND periodo_hasta NOT LIKE ('%71%') AND
                    GETDATE() BETWEEN CONVERT(DATE, '01-' + SUBSTRING(periodo_desde, 6, 2) + '-' + SUBSTRING(periodo_hasta, 1, 4))
                    AND CONVERT(DATE, '01-' + SUBSTRING(periodo_hasta, 6, 2) + '-' + SUBSTRING(periodo_hasta, 1, 4))
                    ORDER BY concepto";

                    cmd.Parameters.AddWithValue("@legago", leg);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeoReducido(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Combo> readBajoRiesgo()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Rubros WHERE COD_TIPO_RIESGO=1 AND activo=1 AND ANIO=YEAR(GETDATE())";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeoReducido(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Rubros getByPk(
        int cod_rubro, int anio)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Rubros WHERE");
                sql.AppendLine("cod_rubro = @cod_rubro");
                sql.AppendLine("AND anio = @anio");
                Rubros obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", cod_rubro);
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Rubros> lst = mapeo(dr);
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

        public static int insert(Rubros obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Rubros(");
                sql.AppendLine("cod_rubro");
                sql.AppendLine(", anio");
                sql.AppendLine(", concepto");
                sql.AppendLine(", alicuota_oim");
                sql.AppendLine(", alicuota_sys");
                sql.AppendLine(", minimo_oim");
                sql.AppendLine(", minimo_sys");
                sql.AppendLine(", incluido_en_oim");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", activo");
                sql.AppendLine(", cod_tipo_riesgo");
                sql.AppendLine(", cod_tipo_actividad");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_rubro");
                sql.AppendLine(", @anio");
                sql.AppendLine(", @concepto");
                sql.AppendLine(", @alicuota_oim");
                sql.AppendLine(", @alicuota_sys");
                sql.AppendLine(", @minimo_oim");
                sql.AppendLine(", @minimo_sys");
                sql.AppendLine(", @incluido_en_oim");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @cod_tipo_riesgo");
                sql.AppendLine(", @cod_tipo_actividad");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@concepto", obj.concepto);
                    cmd.Parameters.AddWithValue("@alicuota_oim", obj.alicuota_oim);
                    cmd.Parameters.AddWithValue("@alicuota_sys", obj.alicuota_sys);
                    cmd.Parameters.AddWithValue("@minimo_oim", obj.minimo_oim);
                    cmd.Parameters.AddWithValue("@minimo_sys", obj.minimo_sys);
                    cmd.Parameters.AddWithValue("@incluido_en_oim", obj.incluido_en_oim);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@cod_tipo_riesgo", obj.cod_tipo_riesgo);
                    cmd.Parameters.AddWithValue("@cod_tipo_actividad", obj.cod_tipo_actividad);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Rubros obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Rubros SET");
                sql.AppendLine("concepto=@concepto");
                sql.AppendLine(", alicuota_oim=@alicuota_oim");
                sql.AppendLine(", alicuota_sys=@alicuota_sys");
                sql.AppendLine(", minimo_oim=@minimo_oim");
                sql.AppendLine(", minimo_sys=@minimo_sys");
                sql.AppendLine(", incluido_en_oim=@incluido_en_oim");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", cod_tipo_riesgo=@cod_tipo_riesgo");
                sql.AppendLine(", cod_tipo_actividad=@cod_tipo_actividad");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_rubro=@cod_rubro");
                sql.AppendLine("AND anio=@anio");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@concepto", obj.concepto);
                    cmd.Parameters.AddWithValue("@alicuota_oim", obj.alicuota_oim);
                    cmd.Parameters.AddWithValue("@alicuota_sys", obj.alicuota_sys);
                    cmd.Parameters.AddWithValue("@minimo_oim", obj.minimo_oim);
                    cmd.Parameters.AddWithValue("@minimo_sys", obj.minimo_sys);
                    cmd.Parameters.AddWithValue("@incluido_en_oim", obj.incluido_en_oim);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@cod_tipo_riesgo", obj.cod_tipo_riesgo);
                    cmd.Parameters.AddWithValue("@cod_tipo_actividad", obj.cod_tipo_actividad);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Rubros obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Rubros ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_rubro=@cod_rubro");
                sql.AppendLine("AND anio=@anio");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
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

