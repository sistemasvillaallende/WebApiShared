using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiShared.Entities.NOTIFICACIONES
{
    public class Notificacion_digital : DALBase
    {
        public int id_notificacion { get; set; }
        public int tipo_notificacion { get; set; }
        public int nro_emision { get; set; }
        public DateTime fecha_notif { get; set; }
        public string desc_notif { get; set; }
        public int cidi_nivel { get; set; }

        //internal static Notificacion_digital getByPk(int id_notificacion)
        //{
        //    throw new NotImplementedException();
        //}

        public int estado_notif { get; set; }
        public string cuil { get; set; }
        public string subject_notif { get; set; }
        public string body_notif { get; set; }
        public int id_oficina { get; set; }
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string desc_tipo_notif { get; set; }
        public string estado { get; set; }
        public string usuario { get; set; }
        public string oficina { get; set; }
        public int nro_expediente { get; set; }

        public Notificacion_digital()
        {
            id_notificacion = 0;
            tipo_notificacion = 0;
            nro_emision = 0;
            fecha_notif = DateTime.Now;
            desc_notif = string.Empty;
            cidi_nivel = 0;
            estado_notif = 0;
            cuil = string.Empty;
            subject_notif = string.Empty;
            body_notif = string.Empty;
            id_oficina = 0;
            id_usuario = 0;
            nombre = string.Empty;
            nro_expediente = 0;
            desc_tipo_notif = string.Empty;
            estado = string.Empty;
            usuario = string.Empty;
            oficina = string.Empty;
        }

        private static List<Notificacion_digital> mapeo(SqlDataReader dr)
        {
            List<Notificacion_digital> lst = new List<Notificacion_digital>();
            Notificacion_digital obj;
            if (dr.HasRows)
            {
                int id_notificacion = dr.GetOrdinal("id_notificacion");
                int tipo_notificacion = dr.GetOrdinal("tipo_notificacion");
                int nro_emision = dr.GetOrdinal("nro_emision");
                int fecha_notif = dr.GetOrdinal("fecha_notif");
                int desc_notif = dr.GetOrdinal("desc_notif");
                int cidi_nivel = dr.GetOrdinal("cidi_nivel");
                int estado_notif = dr.GetOrdinal("estado_notif");
                int cuil = dr.GetOrdinal("cuil");
                int subject_notif = dr.GetOrdinal("subject_notif");
                int body_notif = dr.GetOrdinal("body_notif");
                int id_oficina = dr.GetOrdinal("id_oficina");
                int id_usuario = dr.GetOrdinal("id_usuario");
                int nombre = dr.GetOrdinal("nombre");
                while (dr.Read())
                {
                    obj = new Notificacion_digital();
                    if (!dr.IsDBNull(id_notificacion)) { obj.id_notificacion = dr.GetInt32(id_notificacion); }
                    if (!dr.IsDBNull(tipo_notificacion)) { obj.tipo_notificacion = dr.GetInt32(tipo_notificacion); }
                    if (!dr.IsDBNull(nro_emision)) { obj.nro_emision = dr.GetInt32(nro_emision); }
                    if (!dr.IsDBNull(fecha_notif)) { obj.fecha_notif = dr.GetDateTime(fecha_notif); }
                    if (!dr.IsDBNull(desc_notif)) { obj.desc_notif = dr.GetString(desc_notif); }
                    if (!dr.IsDBNull(cidi_nivel)) { obj.cidi_nivel = dr.GetInt32(cidi_nivel); }
                    if (!dr.IsDBNull(estado_notif)) { obj.estado_notif = dr.GetInt32(estado_notif); }
                    if (!dr.IsDBNull(cuil)) { obj.cuil = dr.GetString(cuil); }
                    if (!dr.IsDBNull(subject_notif)) { obj.subject_notif = dr.GetString(subject_notif); }
                    if (!dr.IsDBNull(body_notif)) { obj.body_notif = dr.GetString(body_notif); }
                    if (!dr.IsDBNull(id_oficina)) { obj.id_oficina = dr.GetInt32(id_oficina); }
                    if (!dr.IsDBNull(id_usuario)) { obj.id_usuario = dr.GetInt32(id_usuario); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Notificacion_digital> read()
        {
            try
            {
                List<Notificacion_digital> lst = new List<Notificacion_digital>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Notificacion_digital";
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

        public static List<Notificacion_digital> ListarNotificaciones()
        {
            try
            {
                List<Notificacion_digital> lst = new List<Notificacion_digital>();
                Notificacion_digital? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT n.id_notificacion, desc_tipo_notif= tn.descripcion,n.fecha_notif,n.cuil,n.nombre,
                                        case 
                                        when n.estado_notif = 0 then 'NO NOTIFICADO'
                                        WHEN N.estado_notif = 1 THEN 'NOTIFICADO'
                                        END AS ESTADO,n.subject_notif,n.body_notif,usuario = u.NOMBRE,oficina = o.nombre_oficina
                                        FROM NOTIFICACION_DIGITAL N inner join TIPO_NOTIF_DIGITAL tn on tn.tipo_notificacion = n.tipo_notificacion
                                        left join USUARIOS_V2 u on u.COD_USUARIO = n.id_usuario
                                        left join OFICINAS o on o.codigo_oficina = n.id_oficina  ";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Notificacion_digital();
                            if (!dr.IsDBNull(0)) { obj.id_notificacion = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.fecha_notif = dr.GetDateTime(2); }
                            if (!dr.IsDBNull(3)) { obj.cuil = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.nombre = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.estado = dr.GetString(5); }
                            if (!dr.IsDBNull(6)) { obj.subject_notif = dr.GetString(6); }
                            if (!dr.IsDBNull(7)) { obj.body_notif = dr.GetString(7); }
                            if (!dr.IsDBNull(8)) { obj.usuario = dr.GetString(8); }
                            if (!dr.IsDBNull(9)) { obj.oficina = dr.GetString(9); }

                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Notificacion_digital> ListNotifxTipoNotif(int tipo_notificacion)
        {
            try
            {
                List<Notificacion_digital> lst = new List<Notificacion_digital>();
                Notificacion_digital? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT n.id_notificacion, desc_tipo_notif= tn.descripcion,n.fecha_notif,n.cuil,n.nombre,
                                        case 
                                        when n.estado_notif = 0 then 'NO NOTIFICADO'
                                        WHEN N.estado_notif = 1 THEN 'NOTIFICADO'
                                        END AS ESTADO,n.subject_notif,n.body_notif,usuario = u.NOMBRE,oficina = o.nombre_oficina
                                        FROM NOTIFICACION_DIGITAL N inner join TIPO_NOTIF_DIGITAL tn on tn.tipo_notificacion = n.tipo_notificacion
                                        left join USUARIOS_V2 u on u.COD_USUARIO = n.id_usuario
                                        left join OFICINAS o on o.codigo_oficina = n.id_oficina
                                         WHERE n.tipo_notificacion=" + tipo_notificacion.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Notificacion_digital();
                            if (!dr.IsDBNull(0)) { obj.id_notificacion = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.fecha_notif = dr.GetDateTime(2); }
                            if (!dr.IsDBNull(3)) { obj.cuil = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.nombre = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.estado = dr.GetString(5); }
                            if (!dr.IsDBNull(6)) { obj.subject_notif = dr.GetString(6); }
                            if (!dr.IsDBNull(7)) { obj.body_notif = dr.GetString(7); }
                            if (!dr.IsDBNull(8)) { obj.usuario = dr.GetString(8); }
                            if (!dr.IsDBNull(9)) { obj.oficina = dr.GetString(9); }

                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Notificacion_digital> ListNotifxcuil(string cuil)
        {
            try
            {
                List<Notificacion_digital> lst = new List<Notificacion_digital>();
                Notificacion_digital? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT n.id_notificacion, desc_tipo_notif= tn.descripcion,n.fecha_notif,n.cuil,n.nombre,
                                        case 
                                        when n.estado_notif = 0 then 'NO NOTIFICADO'
                                        WHEN N.estado_notif = 1 THEN 'NOTIFICADO'
                                        END AS ESTADO,n.subject_notif,n.body_notif,usuario = u.NOMBRE,oficina = o.nombre_oficina
                                        FROM NOTIFICACION_DIGITAL N inner join TIPO_NOTIF_DIGITAL tn on tn.tipo_notificacion = n.tipo_notificacion
                                        left join USUARIOS_V2 u on u.COD_USUARIO = n.id_usuario
                                        left join OFICINAS o on o.codigo_oficina = n.id_oficina
                                         WHERE n.cuil=@cuil";
                    cmd.Parameters.AddWithValue("@cuil", cuil);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Notificacion_digital();
                            if (!dr.IsDBNull(0)) { obj.id_notificacion = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.fecha_notif = dr.GetDateTime(2); }
                            if (!dr.IsDBNull(3)) { obj.cuil = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.nombre = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.estado = dr.GetString(5); }
                            if (!dr.IsDBNull(6)) { obj.subject_notif = dr.GetString(6); }
                            if (!dr.IsDBNull(7)) { obj.body_notif = dr.GetString(7); }
                            if (!dr.IsDBNull(8)) { obj.usuario = dr.GetString(8); }
                            if (!dr.IsDBNull(9)) { obj.oficina = dr.GetString(9); }

                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Notificacion_digital> ListNotifxEstado(int cod_estado)
        {
            try
            {
                List<Notificacion_digital> lst = new List<Notificacion_digital>();
                Notificacion_digital? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT n.id_notificacion, desc_tipo_notif= tn.descripcion,n.fecha_notif,n.cuil,n.nombre,
                                        case 
                                        when n.estado_notif = 0 then 'NO NOTIFICADO'
                                        WHEN N.estado_notif = 1 THEN 'NOTIFICADO'
                                        END AS ESTADO,n.subject_notif,n.body_notif,usuario = u.NOMBRE,oficina = o.nombre_oficina
                                        FROM NOTIFICACION_DIGITAL N inner join TIPO_NOTIF_DIGITAL tn on tn.tipo_notificacion = n.tipo_notificacion
                                        left join USUARIOS_V2 u on u.COD_USUARIO = n.id_usuario
                                        left join OFICINAS o on o.codigo_oficina = n.id_oficina
                                         WHERE n.estado_notif=" + cod_estado.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Notificacion_digital();
                            if (!dr.IsDBNull(0)) { obj.id_notificacion = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.fecha_notif = dr.GetDateTime(2); }
                            if (!dr.IsDBNull(3)) { obj.cuil = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.nombre = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.estado = dr.GetString(5); }
                            if (!dr.IsDBNull(6)) { obj.subject_notif = dr.GetString(6); }
                            if (!dr.IsDBNull(7)) { obj.body_notif = dr.GetString(7); }
                            if (!dr.IsDBNull(8)) { obj.usuario = dr.GetString(8); }
                            if (!dr.IsDBNull(9)) { obj.oficina = dr.GetString(9); }

                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Notificacion_digital> ListNotifxOficina(int cod_oficina)
        {
            try
            {
                List<Notificacion_digital> lst = new List<Notificacion_digital>();
                Notificacion_digital? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT 
                                            n.id_notificacion, 
                                            desc_tipo_notif= tn.descripcion,
                                            n.fecha_notif,
                                            n.cuil,
                                            n.nombre,
                                            CASE
                                              when n.estado_notif = 0 then 'NO NOTIFICADO'
                                              when N.estado_notif = 1 THEN 'NOTIFICADO'
                                            END AS ESTADO,
                                            n.subject_notif,
                                            n.body_notif,
                                            usuario = u.NOMBRE,
                                            oficina = o.nombre_oficina
                                        FROM NOTIFICACION_DIGITAL N 
                                            INNER JOIN TIPO_NOTIF_DIGITAL tn on tn.tipo_notificacion = n.tipo_notificacion
                                            LEFT JOIN USUARIOS_V2 u on u.COD_USUARIO = n.id_usuario
                                            LEFT JOIN OFICINAS o on o.codigo_oficina = n.id_oficina
                                        WHERE n.id_oficina=" + cod_oficina.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Notificacion_digital();
                            if (!dr.IsDBNull(0)) { obj.id_notificacion = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.fecha_notif = dr.GetDateTime(2); }
                            if (!dr.IsDBNull(3)) { obj.cuil = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.nombre = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.estado = dr.GetString(5); }
                            if (!dr.IsDBNull(6)) { obj.subject_notif = dr.GetString(6); }
                            if (!dr.IsDBNull(7)) { obj.body_notif = dr.GetString(7); }
                            if (!dr.IsDBNull(8)) { obj.usuario = dr.GetString(8); }
                            if (!dr.IsDBNull(9)) { obj.oficina = dr.GetString(9); }

                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Notificacion_digital> GetOficinas(int cod_usuario)
        {
            try
            {
                List<Notificacion_digital> lst = new List<Notificacion_digital>();
                Notificacion_digital? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                                        SELECT o.codigo_oficina as id_oficina,o.nombre_oficina as oficina ,orden=1
                                        FROM USUARIOS_V2 u left join OFICINAS o on o.codigo_oficina=u.COD_OFICINA 
                                        WHERE u.COD_USUARIO=@cod_usuario
                                        UNION
                                        SELECT o.codigo_oficina as id_oficina,o.nombre_oficina as oficina ,orden=2 from OFICINAS o
                                        LEFT JOIN USUARIOS_X_OFICINA uo on uo.COD_OFICINA=o.codigo_oficina
                                        WHERE  uo.COD_USUARIO=@cod_usuario
                                        ORDER BY 3 ";
                    cmd.Parameters.AddWithValue("@cod_usuario", cod_usuario);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Notificacion_digital();
                            if (!dr.IsDBNull(0)) { obj.id_oficina = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.oficina = dr.GetString(1); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Notificacion_digital getByPk()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Notificacion_digital WHERE");
                Notificacion_digital obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Notificacion_digital> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int insert(Notificacion_digital obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Notificacion_digital(");
                sql.AppendLine("id_notificacion");
                sql.AppendLine(", tipo_notificacion");
                sql.AppendLine(", nro_emision");
                sql.AppendLine(", fecha_notif");
                sql.AppendLine(", desc_notif");
                sql.AppendLine(", cidi_nivel");
                sql.AppendLine(", estado_notif");
                sql.AppendLine(", cuil");
                sql.AppendLine(", subject_notif");
                sql.AppendLine(", body_notif");
                sql.AppendLine(", id_oficina");
                sql.AppendLine(", id_usuario");
                sql.AppendLine(", nombre");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_notificacion");
                sql.AppendLine(", @tipo_notificacion");
                sql.AppendLine(", @nro_emision");
                sql.AppendLine(", @fecha_notif");
                sql.AppendLine(", @desc_notif");
                sql.AppendLine(", @cidi_nivel");
                sql.AppendLine(", @estado_notif");
                sql.AppendLine(", @cuil");
                sql.AppendLine(", @subject_notif");
                sql.AppendLine(", @body_notif");
                sql.AppendLine(", @id_oficina");
                sql.AppendLine(", @id_usuario");
                sql.AppendLine(", @nombre");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_notificacion", obj.id_notificacion);
                    cmd.Parameters.AddWithValue("@tipo_notificacion", obj.tipo_notificacion);
                    cmd.Parameters.AddWithValue("@nro_emision", obj.nro_emision);
                    cmd.Parameters.AddWithValue("@fecha_notif", obj.fecha_notif);
                    cmd.Parameters.AddWithValue("@desc_notif", obj.desc_notif);
                    cmd.Parameters.AddWithValue("@cidi_nivel", obj.cidi_nivel);
                    cmd.Parameters.AddWithValue("@estado_notif", obj.estado_notif);
                    cmd.Parameters.AddWithValue("@cuil", obj.cuil);
                    cmd.Parameters.AddWithValue("@subject_notif", obj.subject_notif);
                    cmd.Parameters.AddWithValue("@body_notif", obj.body_notif);
                    cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    cmd.Parameters.AddWithValue("@id_usuario", obj.id_usuario);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insertNotif(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado, int nro_expediente)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Notificacion_digital(");
                // sql.AppendLine("id_notificacion");
                sql.AppendLine(" tipo_notificacion");
                //  sql.AppendLine(", nro_emision");
                sql.AppendLine(", fecha_notif");
                //sql.AppendLine(", desc_notif");
                sql.AppendLine(", cidi_nivel");
                sql.AppendLine(", estado_notif");
                sql.AppendLine(", cuil");
                sql.AppendLine(", subject_notif");
                sql.AppendLine(", body_notif");
                sql.AppendLine(", id_oficina");
                sql.AppendLine(", id_usuario");
                sql.AppendLine(", nro_expediente");
                //  sql.AppendLine(", nombre");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                // sql.AppendLine("@id_notificacion");
                sql.AppendLine(" @tipo_notificacion");
                // sql.AppendLine(", @nro_emision");
                sql.AppendLine(", @fecha_notif");
                //sql.AppendLine(", @desc_notif");
                sql.AppendLine(", @cidi_nivel");
                sql.AppendLine(", @estado_notif");
                sql.AppendLine(", @cuil");
                sql.AppendLine(", @subject_notif");
                sql.AppendLine(", @body_notif");
                sql.AppendLine(", @id_oficina");
                sql.AppendLine(", @id_usuario");
                sql.AppendLine(", @nro_expediente");
                //sql.AppendLine(", @nombre");
                sql.AppendLine(") SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    //  cmd.Parameters.AddWithValue("@id_notificacion", obj.id_notificacion);
                    cmd.Parameters.AddWithValue("@tipo_notificacion", id_tipo_notif);
                    //  cmd.Parameters.AddWithValue("@nro_emision", obj.nro_emision);
                    cmd.Parameters.AddWithValue("@fecha_notif", DateTime.Now);
                    // cmd.Parameters.AddWithValue("@desc_notif", obj.desc_notif);
                    cmd.Parameters.AddWithValue("@cidi_nivel", 2);
                    cmd.Parameters.AddWithValue("@estado_notif", cod_estado);
                    cmd.Parameters.AddWithValue("@cuil", cuil);
                    cmd.Parameters.AddWithValue("@subject_notif", subject);
                    cmd.Parameters.AddWithValue("@body_notif", body);
                    cmd.Parameters.AddWithValue("@id_oficina", id_oficina);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    cmd.Parameters.AddWithValue("@nro_expediente", nro_expediente);
                    // cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insertNotifProc(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado, int nro_procuracion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Notificacion_digital(");
                // sql.AppendLine("id_notificacion");
                sql.AppendLine(" tipo_notificacion");
                //  sql.AppendLine(", nro_emision");
                sql.AppendLine(", fecha_notif");
                //sql.AppendLine(", desc_notif");
                sql.AppendLine(", cidi_nivel");
                sql.AppendLine(", estado_notif");
                sql.AppendLine(", cuil");
                sql.AppendLine(", subject_notif");
                sql.AppendLine(", body_notif");
                sql.AppendLine(", id_oficina");
                sql.AppendLine(", id_usuario");
                sql.AppendLine(", nro_procuracion");
                //  sql.AppendLine(", nombre");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                // sql.AppendLine("@id_notificacion");
                sql.AppendLine(" @tipo_notificacion");
                // sql.AppendLine(", @nro_emision");
                sql.AppendLine(", @fecha_notif");
                //sql.AppendLine(", @desc_notif");
                sql.AppendLine(", @cidi_nivel");
                sql.AppendLine(", @estado_notif");
                sql.AppendLine(", @cuil");
                sql.AppendLine(", @subject_notif");
                sql.AppendLine(", @body_notif");
                sql.AppendLine(", @id_oficina");
                sql.AppendLine(", @id_usuario");
                sql.AppendLine(", @nro_procuracion");
                //sql.AppendLine(", @nombre");
                sql.AppendLine(") SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    //  cmd.Parameters.AddWithValue("@id_notificacion", obj.id_notificacion);
                    cmd.Parameters.AddWithValue("@tipo_notificacion", id_tipo_notif);
                    //  cmd.Parameters.AddWithValue("@nro_emision", obj.nro_emision);
                    cmd.Parameters.AddWithValue("@fecha_notif", DateTime.Now);
                    // cmd.Parameters.AddWithValue("@desc_notif", obj.desc_notif);
                    cmd.Parameters.AddWithValue("@cidi_nivel", 2);
                    cmd.Parameters.AddWithValue("@estado_notif", cod_estado);
                    cmd.Parameters.AddWithValue("@cuil", cuil);
                    if(subject != null)
                        cmd.Parameters.AddWithValue("@subject_notif", subject);
                    else
                        cmd.Parameters.AddWithValue("@subject_notif", " ");
                    cmd.Parameters.AddWithValue("@body_notif", body);
                    cmd.Parameters.AddWithValue("@id_oficina", id_oficina);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    cmd.Parameters.AddWithValue("@nro_procuracion", nro_procuracion);
                    // cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(int id_notificacion, int estado_notif, string body_notif)

        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Notificacion_digital SET");
                sql.AppendLine(" estado_notif=@estado_notif");
                sql.AppendLine(", body_notif=@body_notif");
                sql.AppendLine("WHERE id_notificacion= @id_notificacion");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_notificacion", id_notificacion);
                    cmd.Parameters.AddWithValue("@estado_notif", estado_notif);
                    cmd.Parameters.AddWithValue("@body_notif", body_notif);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void updateSumario(int nro_expediente, int tipo_reporte)

        {
            try
            {
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlDelete = new StringBuilder();
                StringBuilder sqlDelete2 = new StringBuilder();
                if (tipo_reporte == 1)
                {
                    sql.AppendLine("UPDATE sumarios SET");
                    sql.AppendLine(" es_multa_notificada=1,cod_estado=3,fecha_recepcion_noti=@fecha");
                    sql.AppendLine("WHERE  nro_expediente= @nro_expediente");

                }
                if (tipo_reporte == 2)
                {
                    sql.AppendLine("UPDATE  sumarios SET");
                    sql.AppendLine(" es_resolucion_notificada=1,cod_estado=8,fecha_espera_recurso=@fecha");
                    sql.AppendLine("WHERE  nro_expediente= @nro_expediente");

                }

                if (tipo_reporte == 1)
                {
                    sqlDelete.AppendLine(@" delete from CTASCTES_MULTAS where nro_expediente=@nro_expediente 
                                            and categoria_deuda=4 and pagado=0
                                        ");
                    sqlDelete2.AppendLine(@" delete from MULTAS_FACT where nro_expediente=@nro_expediente 
                                            and categoria_deuda=4 and pagado=0
                                        ");
                }

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_expediente", nro_expediente);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    if (tipo_reporte == 1)
                    {
                        cmd.CommandText = sqlDelete.ToString();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@nro_expediente", nro_expediente);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = sqlDelete2.ToString();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@nro_expediente", nro_expediente);
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateProcuracion(int nro_procuracion, int tipo_proc, int nro_notifiicacion, int nro_emision, int cod_estado_actual)

        {
            try
            {
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlUpdProc = new StringBuilder();
                StringBuilder sqlInsEstado = new StringBuilder();
                int estado_sig;

                if (tipo_proc == 1)
                {
                    sql.AppendLine("UPDATE Det_Notificacion_Estado_Proc_inm SET ");
                    sql.AppendLine(" Notificado_cidi=1 ");
                    sql.AppendLine("WHERE  nro_emision= @nro_emision and nro_notificacion= @nro_notificacion ");
                    sql.AppendLine(" and nro_procuracion= @nro_procuracion ");

                    sqlUpdProc.AppendLine(@" update procura_tasa
                                            set codigo_estado_actual=@cod_estado
                                            where nro_procuracion= @nro_procuracion
                                        ");

                }
                if (tipo_proc == 3)
                {
                    sql.AppendLine("UPDATE Det_Notificacion_Estado_Proc_iyc SET ");
                    sql.AppendLine(" Notificado_cidi=1 ");
                    sql.AppendLine("WHERE  nro_emision= @nro_emision and nro_notificacion= @nro_notificacion ");
                    sql.AppendLine(" and nro_procuracion= @nro_procuracion ");

                    sqlUpdProc.AppendLine(@" update procura_iyc 
                                            set codigo_estado_actual=@cod_estado
                                            where nro_procuracion= @nro_procuracion
                                        ");

                }
                if (tipo_proc == 4)
                {
                    sql.AppendLine("UPDATE Det_Notificacion_Estado_Proc_Auto SET");
                    sql.AppendLine(" Notificado_cidi=1");
                    sql.AppendLine("WHERE  nro_emision= @nro_emision and nro_notificacion= @nro_notificacion");
                    sql.AppendLine(" and nro_procuracion= @nro_procuracion");

                    sqlUpdProc.AppendLine(@" update procura_auto 
                                            set codigo_estado_actual=@cod_estado
                                            where nro_procuracion= @nro_procuracion
                                        ");
                }

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_emision", nro_emision);
                    cmd.Parameters.AddWithValue("@nro_notificacion", nro_notifiicacion);
                    cmd.Parameters.AddWithValue("@nro_procuracion", nro_procuracion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    estado_sig = SigEstado("estados_procuracion", "codigo_estado_sig", "codigo_estado", cod_estado_actual);
                    cmd.CommandText = sqlUpdProc.ToString();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nro_procuracion", nro_procuracion);
                    cmd.Parameters.AddWithValue("@cod_estado", estado_sig);
                    cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void updateProcuracionNueva(int nro_procuracion, int tipo_proc, int nro_notifiicacion, int nro_emision, int cod_estado_actual)

        {
            try
            {
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlUpdProc = new StringBuilder();
                StringBuilder sqlInsEstado = new StringBuilder();
                int estado_sig;
                if (tipo_proc == 3)
                {
                    sql.AppendLine("UPDATE DET_NOTIFICACION_IYC SET ");
                    sql.AppendLine(" Notificado_cidi=1 ");
                    sql.AppendLine("WHERE  nro_emision= @nro_emision and nro_notificacion= @nro_notificacion ");
                    sql.AppendLine(" and nro_proc= @nro_procuracion ");

                    sqlUpdProc.AppendLine(@" update procura_iyc 
                                            set codigo_estado_actual=@cod_estado
                                            where nro_procuracion= @nro_procuracion
                                        ");

                }
                if (tipo_proc == 4)
                {
                    sql.AppendLine("UPDATE DET_NOTIFICACION_AUTO SET");
                    sql.AppendLine(" Notificado_cidi=1, Codigo_estado_actual=@cod_estado");
                    sql.AppendLine("WHERE  nro_emision= @nro_emision and nro_notificacion= @nro_notificacion");
                    sql.AppendLine(" and nro_proc= @nro_procuracion");
                    sqlUpdProc.AppendLine(@" update procura_auto 
                                            set codigo_estado_actual=@cod_estado
                                            where nro_procuracion= @nro_procuracion
                                        ");


                }
                /*if (tipo_proc == 1)
                {
                    sql.AppendLine("UPDATE Det_Notificacion_Estado_Proc_inm SET ");
                    sql.AppendLine(" Notificado_cidi=1 ");
                    sql.AppendLine("WHERE  nro_emision= @nro_emision and nro_notificacion= @nro_notificacion ");
                    sql.AppendLine(" and nro_procuracion= @nro_procuracion ");

                    sqlUpdProc.AppendLine(@" update procura_tasa
                                            set codigo_estado_actual=@cod_estado
                                            where nro_procuracion= @nro_procuracion
                                        ");

                }
                if (tipo_proc == 3)
                {
                    sql.AppendLine("UPDATE Det_Notificacion_Estado_Proc_iyc SET ");
                    sql.AppendLine(" Notificado_cidi=1 ");
                    sql.AppendLine("WHERE  nro_emision= @nro_emision and nro_notificacion= @nro_notificacion ");
                    sql.AppendLine(" and nro_procuracion= @nro_procuracion ");

                    sqlUpdProc.AppendLine(@" update procura_iyc 
                                            set codigo_estado_actual=@cod_estado
                                            where nro_procuracion= @nro_procuracion
                                        ");

                }*/

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    estado_sig = SigEstado("estados_procuracion", "codigo_estado_sig", "codigo_estado", cod_estado_actual);
                    cmd.Parameters.AddWithValue("@nro_emision", nro_emision);
                    cmd.Parameters.AddWithValue("@nro_notificacion", nro_notifiicacion);
                    cmd.Parameters.AddWithValue("@nro_procuracion", nro_procuracion);
                    cmd.Parameters.AddWithValue("@cod_estado", estado_sig);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = sqlUpdProc.ToString();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nro_procuracion", nro_procuracion);
                    cmd.Parameters.AddWithValue("@cod_estado", estado_sig);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int InsertarNuevoEstado(int nro_expediente, int cod_usuario, int tipo_reporte, int id_notificacion)

        {
            try
            {
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlUpDate = new StringBuilder();

                sql.AppendLine(@"INSERT INTO HISTORIAL_SUMARIOS
                              (COD_OFICINA, NRO_EXPEDIENTE, NRO_PASO, CODIGO_ESTADO, FECHA_INICIO_ESTADO, FECHA_CAMBIO_ESTADO, OBSERVACIONES, USUARIO)
                              VALUES
                              (@COD_OFICINA, @NRO_EXPEDIENTE, @NRO_PASO, @CODIGO_ESTADO, @FECHA_INICIO_ESTADO,@FECHA_CAMBIO_ESTADO,@OBSERVACIONES ,@USUARIO)");
                int sig = DALBase.SigPaso("HISTORIAL_SUMARIOS", "nro_paso", "nro_expediente", nro_expediente);
                string usuario_hist = DALBase.GetNombre("USUARIOS_V2", "NOMBRE", "COD_USUARIO", cod_usuario);
                DateTime fechaActual = DateTime.Now;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    if (tipo_reporte == 1)
                    {

                        DateTime nuevaFecha = fechaActual.AddDays(5);
                        cmd.CommandText = sql.ToString();
                        cmd.Parameters.AddWithValue("@COD_OFICINA", 122);
                        cmd.Parameters.AddWithValue("@NRO_EXPEDIENTE", nro_expediente);
                        cmd.Parameters.AddWithValue("@NRO_PASO", sig);
                        cmd.Parameters.AddWithValue("@CODIGO_ESTADO", 3);
                        cmd.Parameters.AddWithValue("@FECHA_INICIO_ESTADO", fechaActual);
                        cmd.Parameters.AddWithValue("@FECHA_CAMBIO_ESTADO", nuevaFecha);
                        cmd.Parameters.AddWithValue("@OBSERVACIONES", "CAUSA NOTIFICADA MEDIANTE CIDI - NRO DE NOTIFICACION DIGITAL: " + id_notificacion);
                        cmd.Parameters.AddWithValue("@USUARIO", usuario_hist);
                        cmd.Connection.Open();
                    }
                    if (tipo_reporte == 2)
                    {

                        DateTime nuevaFecha = fechaActual.AddDays(15);
                        cmd.CommandText = sql.ToString();
                        cmd.Parameters.AddWithValue("@COD_OFICINA", 122);
                        cmd.Parameters.AddWithValue("@NRO_EXPEDIENTE", nro_expediente);
                        cmd.Parameters.AddWithValue("@NRO_PASO", sig);
                        cmd.Parameters.AddWithValue("@CODIGO_ESTADO", 8);
                        cmd.Parameters.AddWithValue("@FECHA_INICIO_ESTADO", fechaActual);
                        cmd.Parameters.AddWithValue("@FECHA_CAMBIO_ESTADO", nuevaFecha);
                        cmd.Parameters.AddWithValue("@OBSERVACIONES", "CAUSA CON RESOLUCION NOTIFICADA MEDIANTE CIDI - NRO DE NOTIFICACION DIGITAL: " + id_notificacion);
                        cmd.Parameters.AddWithValue("@USUARIO", usuario_hist);
                        cmd.Connection.Open();



                    }
                    return cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int InsertarNuevoEstadoProc(int nro_procuracion, int tipo_proc, int id_notificacion, int cod_usuario, int cod_estado)

        {
            int paso_sig = 0;
            try
            {
                StringBuilder sql = new StringBuilder();
                // StringBuilder sqlUpDate = new StringBuilder();
                if (tipo_proc == 1)
                {
                    sql.AppendLine(@" INSERT INTO HIST_PROC_TASA
                                          (nro_procuracion ,nro_paso,codigo_estado,fecha_cambio_estado
                                          ,observaciones,fecha_fin_estado,usuario)
                                        VALUES
                                         (@nro_procuracion ,@nro_paso,@codigo_estado,@fecha_cambio_estado
                                          ,@observaciones,@fecha_fin_estado,@usuario)
                
                         ");
                    paso_sig = DALBase.SigPaso("HIST_PROC_TASA", "nro_paso", "nro_procuracion", nro_procuracion);

                }
                if (tipo_proc == 3)
                {
                    sql.AppendLine(@" INSERT INTO HIST_PROC_IYC
                                          (nro_procuracion ,nro_paso,codigo_estado,fecha_cambio_estado
                                          ,observaciones,fecha_fin_estado,usuario)
                                        VALUES
                                         (@nro_procuracion ,@nro_paso,@codigo_estado,@fecha_cambio_estado
                                          ,@observaciones,@fecha_fin_estado,@usuario)
                
                         ");
                    paso_sig = DALBase.SigPaso("HIST_PROC_IYC", "nro_paso", "nro_procuracion", nro_procuracion);

                }
                if (tipo_proc == 4)
                {
                    sql.AppendLine(@" INSERT INTO HIST_PROC_AUTO
                                          (nro_procuracion ,nro_paso,codigo_estado,fecha_cambio_estado
                                          ,observaciones,fecha_fin_estado,usuario)
                                        VALUES
                                         (@nro_procuracion ,@nro_paso,@codigo_estado,@fecha_cambio_estado
                                          ,@observaciones,@fecha_fin_estado,@usuario)
                
                         ");
                    paso_sig =  DALBase.SigPaso("HIST_PROC_AUTO", "nro_paso", "nro_procuracion", nro_procuracion);

                }          
                int dias = 0;
                int estado_sig = 0;
                string usuario_hist = DALBase.GetNombre("USUARIOS_V2", "NOMBRE", "COD_USUARIO", cod_usuario);
                DateTime fechaActual = DateTime.Now;
                estado_sig = SigEstado("estados_procuracion", "codigo_estado_sig", "codigo_estado", cod_estado);
                dias = DALBase.CantDiasvenc("ESTADOS_PROCURACION", "tiempo_estado", "codigo_estado", estado_sig);
                DateTime nuevaFecha = fechaActual.AddDays(dias);

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_procuracion", nro_procuracion);
                    cmd.Parameters.AddWithValue("@nro_paso", paso_sig);          
                    cmd.Parameters.AddWithValue("codigo_estado", estado_sig);           
                    cmd.Parameters.AddWithValue("@fecha_cambio_estado", fechaActual);
                    cmd.Parameters.AddWithValue("@observaciones", "PROCURACION NOTIFICADA MEDIANTE CIDI - NRO DE NOTIFICACION DIGITAL: " + id_notificacion);
                    cmd.Parameters.AddWithValue("@fecha_fin_estado", nuevaFecha);
                    cmd.Parameters.AddWithValue("@usuario", usuario_hist);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(Notificacion_digital obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Notificacion_digital ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static int NotificaProcuracionMasiva(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado, int nro_procuracion,
        //    int subsistema, int nro_emision, int cod_estado_actual)
        //{
        //    try
        //    {
        //        StringBuilder sql = new StringBuilder();
        //        sql.AppendLine("INSERT INTO Notificacion_digital(");
        //        // sql.AppendLine("id_notificacion");
        //        sql.AppendLine(" tipo_notificacion");
        //        //  sql.AppendLine(", nro_emision");
        //        sql.AppendLine(", fecha_notif");
        //        //sql.AppendLine(", desc_notif");
        //        sql.AppendLine(", cidi_nivel");
        //        sql.AppendLine(", estado_notif");
        //        sql.AppendLine(", cuil");
        //        sql.AppendLine(", subject_notif");
        //        sql.AppendLine(", body_notif");
        //        sql.AppendLine(", id_oficina");
        //        sql.AppendLine(", id_usuario");
        //        sql.AppendLine(", nro_procuracion");
        //        //  sql.AppendLine(", nombre");
        //        sql.AppendLine(")");
        //        sql.AppendLine("VALUES");
        //        sql.AppendLine("(");
        //        // sql.AppendLine("@id_notificacion");
        //        sql.AppendLine(" @tipo_notificacion");
        //        // sql.AppendLine(", @nro_emision");
        //        sql.AppendLine(", @fecha_notif");
        //        //sql.AppendLine(", @desc_notif");
        //        sql.AppendLine(", @cidi_nivel");
        //        sql.AppendLine(", @estado_notif");
        //        sql.AppendLine(", @cuil");
        //        sql.AppendLine(", @subject_notif");
        //        sql.AppendLine(", @body_notif");
        //        sql.AppendLine(", @id_oficina");
        //        sql.AppendLine(", @id_usuario");
        //        sql.AppendLine(", @nro_procuracion");
        //        //sql.AppendLine(", @nombre");
        //        sql.AppendLine(") SELECT SCOPE_IDENTITY()");
        //        using (SqlConnection con = GetConnection())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = sql.ToString();
        //            //  cmd.Parameters.AddWithValue("@id_notificacion", obj.id_notificacion);
        //            cmd.Parameters.AddWithValue("@tipo_notificacion", id_tipo_notif);
        //            //  cmd.Parameters.AddWithValue("@nro_emision", obj.nro_emision);
        //            cmd.Parameters.AddWithValue("@fecha_notif", DateTime.Now);
        //            // cmd.Parameters.AddWithValue("@desc_notif", obj.desc_notif);
        //            cmd.Parameters.AddWithValue("@cidi_nivel", 2);
        //            cmd.Parameters.AddWithValue("@estado_notif", cod_estado);
        //            cmd.Parameters.AddWithValue("@cuil", cuil);
        //            if (subject != null)
        //                cmd.Parameters.AddWithValue("@subject_notif", subject);
        //            else
        //                cmd.Parameters.AddWithValue("@subject_notif", " ");
        //            cmd.Parameters.AddWithValue("@body_notif", body);
        //            cmd.Parameters.AddWithValue("@id_oficina", id_oficina);
        //            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
        //            cmd.Parameters.AddWithValue("@nro_procuracion", nro_procuracion);
        //            // cmd.Parameters.AddWithValue("@nombre", obj.nombre);
        //            cmd.Connection.Open();
        //            return Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}

