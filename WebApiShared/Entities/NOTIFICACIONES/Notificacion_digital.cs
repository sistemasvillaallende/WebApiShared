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
                                         WHERE n.cuil=@cuil"  ;
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

        public static Notificacion_digital getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Notificacion_digital WHERE");
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
                throw ex;
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

        public static int insertNotif(string cuil,string subject,string body,int id_tipo_notif,int id_oficina,int id_usuario ,int cod_estado)
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
                //sql.AppendLine(", @nombre");
                sql.AppendLine(")");
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
                    cmd.Parameters.AddWithValue("@cidi_nivel",2);
                    cmd.Parameters.AddWithValue("@estado_notif", cod_estado);
                    cmd.Parameters.AddWithValue("@cuil", cuil);
                    cmd.Parameters.AddWithValue("@subject_notif", subject);
                    cmd.Parameters.AddWithValue("@body_notif", body);
                    cmd.Parameters.AddWithValue("@id_oficina", id_oficina);
                    cmd.Parameters.AddWithValue("@id_usuario",id_usuario);
                   // cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int update(int cidi_nivel )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Notificacion_digital SET");
               
                sql.AppendLine("cidi_nivel=@cidi_nivel");
            
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cidi_nivel", cidi_nivel);              
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
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

    }
}

