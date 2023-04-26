using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Resoluciones_multas : DALBase
    {
        public int COD_OFICINA { get; set; }
        public int NRO_EXPEDIENTE { get; set; }
        public string NRO_RESOLUCION { get; set; }
        public int TIPO_RESOLUCION { get; set; }
        public string VISTO { get; set; }
        public string CONSIDERANDO { get; set; }
        public string ART_1 { get; set; }
        public string ART_2 { get; set; }
        public string ART_3 { get; set; }
        public string ART_4 { get; set; }
        public decimal MONTO_MULTA { get; set; }
        public bool ID_RESOLUCION { get; set; }
        public string ART_5 { get; set; }
        public int ANIO { get; set; }
        public int nro_causa { get; set; }
        public string tipo_resolucion { get; set; }
        public string nombre_noti { get; set; }
        public Resoluciones_multas()
        {
            COD_OFICINA = 0;
            NRO_EXPEDIENTE = 0;
            NRO_RESOLUCION = string.Empty;
            TIPO_RESOLUCION = 0;
            VISTO = string.Empty;
            CONSIDERANDO = string.Empty;
            ART_1 = string.Empty;
            ART_2 = string.Empty;
            ART_3 = string.Empty;
            ART_4 = string.Empty;
            MONTO_MULTA = 0;
            ID_RESOLUCION = false;
            ART_5 = string.Empty;
            ANIO = 0;
            nro_causa = 0;  
            tipo_resolucion = string.Empty;
            nombre_noti = string.Empty;
        }

        private static List<Resoluciones_multas> mapeo(SqlDataReader dr)
        {
            List<Resoluciones_multas> lst = new List<Resoluciones_multas>();
            Resoluciones_multas obj;
            if (dr.HasRows)
            {
                int COD_OFICINA = dr.GetOrdinal("COD_OFICINA");
                int NRO_EXPEDIENTE = dr.GetOrdinal("NRO_EXPEDIENTE");
                int NRO_RESOLUCION = dr.GetOrdinal("NRO_RESOLUCION");
                int TIPO_RESOLUCION = dr.GetOrdinal("TIPO_RESOLUCION");
                int VISTO = dr.GetOrdinal("VISTO");
                int CONSIDERANDO = dr.GetOrdinal("CONSIDERANDO");
                int ART_1 = dr.GetOrdinal("ART_1");
                int ART_2 = dr.GetOrdinal("ART_2");
                int ART_3 = dr.GetOrdinal("ART_3");
                int ART_4 = dr.GetOrdinal("ART_4");
                int MONTO_MULTA = dr.GetOrdinal("MONTO_MULTA");
                int ID_RESOLUCION = dr.GetOrdinal("ID_RESOLUCION");
                int ART_5 = dr.GetOrdinal("ART_5");
                int ANIO = dr.GetOrdinal("ANIO");
                while (dr.Read())
                {
                    obj = new Resoluciones_multas();
                    if (!dr.IsDBNull(COD_OFICINA)) { obj.COD_OFICINA = dr.GetInt32(COD_OFICINA); }
                    if (!dr.IsDBNull(NRO_EXPEDIENTE)) { obj.NRO_EXPEDIENTE = dr.GetInt32(NRO_EXPEDIENTE); }
                    if (!dr.IsDBNull(NRO_RESOLUCION)) { obj.NRO_RESOLUCION = dr.GetString(NRO_RESOLUCION); }
                    if (!dr.IsDBNull(TIPO_RESOLUCION)) { obj.TIPO_RESOLUCION = dr.GetInt32(TIPO_RESOLUCION); }
                    if (!dr.IsDBNull(VISTO)) { obj.VISTO = dr.GetString(VISTO); }
                    if (!dr.IsDBNull(CONSIDERANDO)) { obj.CONSIDERANDO = dr.GetString(CONSIDERANDO); }
                    if (!dr.IsDBNull(ART_1)) { obj.ART_1 = dr.GetString(ART_1); }
                    if (!dr.IsDBNull(ART_2)) { obj.ART_2 = dr.GetString(ART_2); }
                    if (!dr.IsDBNull(ART_3)) { obj.ART_3 = dr.GetString(ART_3); }
                    if (!dr.IsDBNull(ART_4)) { obj.ART_4 = dr.GetString(ART_4); }
                    if (!dr.IsDBNull(MONTO_MULTA)) { obj.MONTO_MULTA = dr.GetDecimal(MONTO_MULTA); }
                    if (!dr.IsDBNull(ID_RESOLUCION)) { obj.ID_RESOLUCION = dr.GetBoolean(ID_RESOLUCION); }
                    if (!dr.IsDBNull(ART_5)) { obj.ART_5 = dr.GetString(ART_5); }
                    if (!dr.IsDBNull(ANIO)) { obj.ANIO = dr.GetInt32(ANIO); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static Resoluciones_multas GetResolucion(int NRO_EXPEDIENTE)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine(@"Select s.Nro_Causa,s.anio, r.NRO_EXPEDIENTE, r.visto ,r.considerando,r.ART_1 ,r.ART_2,r.ART_3,r.ART_4 
                               ,t.descripcion as tipo_resolucion ,su.NOMBRE_NOTI
                               from RESOLUCIONES_MULTAS r left join SUMARIOS s on s.NRO_EXPEDIENTE=r.NRO_EXPEDIENTE
                               left join TIPO_RESOLUCION_MULTAS t on t.id_tip_resol_multas=r.TIPO_RESOLUCION
                               left join SUMARIOS su on su.NRO_EXPEDIENTE=s.NRO_EXPEDIENTE
                               where r.nro_expediente=@nro_expediente and r.ID_RESOLUCION=0");
                Resoluciones_multas obj = null;
                List<Resoluciones_multas> lst = new List<Resoluciones_multas>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_EXPEDIENTE", NRO_EXPEDIENTE);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Resoluciones_multas();
                            if (!dr.IsDBNull(0)) { obj.nro_causa = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.ANIO = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.NRO_EXPEDIENTE = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.VISTO = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.CONSIDERANDO = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.ART_1 = dr.GetString(5); }
                            if (!dr.IsDBNull(6)) { obj.ART_2 = dr.GetString(6); }
                            if (!dr.IsDBNull(7)) { obj.ART_3 = dr.GetString(7); }
                            if (!dr.IsDBNull(8)) { obj.ART_4 = dr.GetString(8); }
                            if (!dr.IsDBNull(9)) { obj.tipo_resolucion = dr.GetString(9); }
                            if (!dr.IsDBNull(10)) { obj.nombre_noti= dr.GetString(10); }
                            lst.Add(obj);
                        }
                    }

                    //List<Resoluciones_multas> lst = mapeo(dr);
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

        public static List<Resoluciones_multas> read()
    {
        try
        {
            List<Resoluciones_multas> lst = new List<Resoluciones_multas>();
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT *FROM Resoluciones_multas";
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

    public static Resoluciones_multas getByPk(
    int COD_OFICINA, int NRO_EXPEDIENTE, string NRO_RESOLUCION)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT *FROM Resoluciones_multas WHERE");
            sql.AppendLine("COD_OFICINA = @COD_OFICINA");
            sql.AppendLine("AND NRO_EXPEDIENTE = @NRO_EXPEDIENTE");
            sql.AppendLine("AND NRO_RESOLUCION = @NRO_RESOLUCION");
            Resoluciones_multas obj = null;
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@COD_OFICINA", COD_OFICINA);
                cmd.Parameters.AddWithValue("@NRO_EXPEDIENTE", NRO_EXPEDIENTE);
                cmd.Parameters.AddWithValue("@NRO_RESOLUCION", NRO_RESOLUCION);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Resoluciones_multas> lst = mapeo(dr);
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

    public static int insert(Resoluciones_multas obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Resoluciones_multas(");
            sql.AppendLine("COD_OFICINA");
            sql.AppendLine(", NRO_EXPEDIENTE");
            sql.AppendLine(", NRO_RESOLUCION");
            sql.AppendLine(", TIPO_RESOLUCION");
            sql.AppendLine(", VISTO");
            sql.AppendLine(", CONSIDERANDO");
            sql.AppendLine(", ART_1");
            sql.AppendLine(", ART_2");
            sql.AppendLine(", ART_3");
            sql.AppendLine(", ART_4");
            sql.AppendLine(", MONTO_MULTA");
            sql.AppendLine(", ID_RESOLUCION");
            sql.AppendLine(", ART_5");
            sql.AppendLine(", ANIO");
            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("(");
            sql.AppendLine("@COD_OFICINA");
            sql.AppendLine(", @NRO_EXPEDIENTE");
            sql.AppendLine(", @NRO_RESOLUCION");
            sql.AppendLine(", @TIPO_RESOLUCION");
            sql.AppendLine(", @VISTO");
            sql.AppendLine(", @CONSIDERANDO");
            sql.AppendLine(", @ART_1");
            sql.AppendLine(", @ART_2");
            sql.AppendLine(", @ART_3");
            sql.AppendLine(", @ART_4");
            sql.AppendLine(", @MONTO_MULTA");
            sql.AppendLine(", @ID_RESOLUCION");
            sql.AppendLine(", @ART_5");
            sql.AppendLine(", @ANIO");
            sql.AppendLine(")");
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@COD_OFICINA", obj.COD_OFICINA);
                cmd.Parameters.AddWithValue("@NRO_EXPEDIENTE", obj.NRO_EXPEDIENTE);
                cmd.Parameters.AddWithValue("@NRO_RESOLUCION", obj.NRO_RESOLUCION);
                cmd.Parameters.AddWithValue("@TIPO_RESOLUCION", obj.TIPO_RESOLUCION);
                cmd.Parameters.AddWithValue("@VISTO", obj.VISTO);
                cmd.Parameters.AddWithValue("@CONSIDERANDO", obj.CONSIDERANDO);
                cmd.Parameters.AddWithValue("@ART_1", obj.ART_1);
                cmd.Parameters.AddWithValue("@ART_2", obj.ART_2);
                cmd.Parameters.AddWithValue("@ART_3", obj.ART_3);
                cmd.Parameters.AddWithValue("@ART_4", obj.ART_4);
                cmd.Parameters.AddWithValue("@MONTO_MULTA", obj.MONTO_MULTA);
                cmd.Parameters.AddWithValue("@ID_RESOLUCION", obj.ID_RESOLUCION);
                cmd.Parameters.AddWithValue("@ART_5", obj.ART_5);
                cmd.Parameters.AddWithValue("@ANIO", obj.ANIO);
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void update(Resoluciones_multas obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE  Resoluciones_multas SET");
            sql.AppendLine("TIPO_RESOLUCION=@TIPO_RESOLUCION");
            sql.AppendLine(", VISTO=@VISTO");
            sql.AppendLine(", CONSIDERANDO=@CONSIDERANDO");
            sql.AppendLine(", ART_1=@ART_1");
            sql.AppendLine(", ART_2=@ART_2");
            sql.AppendLine(", ART_3=@ART_3");
            sql.AppendLine(", ART_4=@ART_4");
            sql.AppendLine(", MONTO_MULTA=@MONTO_MULTA");
            sql.AppendLine(", ID_RESOLUCION=@ID_RESOLUCION");
            sql.AppendLine(", ART_5=@ART_5");
            sql.AppendLine(", ANIO=@ANIO");
            sql.AppendLine("WHERE");
            sql.AppendLine("COD_OFICINA=@COD_OFICINA");
            sql.AppendLine("AND NRO_EXPEDIENTE=@NRO_EXPEDIENTE");
            sql.AppendLine("AND NRO_RESOLUCION=@NRO_RESOLUCION");
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@COD_OFICINA", obj.COD_OFICINA);
                cmd.Parameters.AddWithValue("@NRO_EXPEDIENTE", obj.NRO_EXPEDIENTE);
                cmd.Parameters.AddWithValue("@NRO_RESOLUCION", obj.NRO_RESOLUCION);
                cmd.Parameters.AddWithValue("@TIPO_RESOLUCION", obj.TIPO_RESOLUCION);
                cmd.Parameters.AddWithValue("@VISTO", obj.VISTO);
                cmd.Parameters.AddWithValue("@CONSIDERANDO", obj.CONSIDERANDO);
                cmd.Parameters.AddWithValue("@ART_1", obj.ART_1);
                cmd.Parameters.AddWithValue("@ART_2", obj.ART_2);
                cmd.Parameters.AddWithValue("@ART_3", obj.ART_3);
                cmd.Parameters.AddWithValue("@ART_4", obj.ART_4);
                cmd.Parameters.AddWithValue("@MONTO_MULTA", obj.MONTO_MULTA);
                cmd.Parameters.AddWithValue("@ID_RESOLUCION", obj.ID_RESOLUCION);
                cmd.Parameters.AddWithValue("@ART_5", obj.ART_5);
                cmd.Parameters.AddWithValue("@ANIO", obj.ANIO);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void delete(Resoluciones_multas obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE  Resoluciones_multas ");
            sql.AppendLine("WHERE");
            sql.AppendLine("COD_OFICINA=@COD_OFICINA");
            sql.AppendLine("AND NRO_EXPEDIENTE=@NRO_EXPEDIENTE");
            sql.AppendLine("AND NRO_RESOLUCION=@NRO_RESOLUCION");
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@COD_OFICINA", obj.COD_OFICINA);
                cmd.Parameters.AddWithValue("@NRO_EXPEDIENTE", obj.NRO_EXPEDIENTE);
                cmd.Parameters.AddWithValue("@NRO_RESOLUCION", obj.NRO_RESOLUCION);
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

