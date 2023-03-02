﻿using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace WebApiShared.Entities.CIDI.Documentos
{
    public class Config
    {
        #region Propiedades

        public static String CiDiUrl
        {
            get
            {
                return "https://cidi.cba.gov.ar/Cuenta/Login";
            }
        }


        public static int CiDiIdAplicacion
        {
            get
            {
                return 521;
            }
        }

        public static String CiDiPassAplicacion
        {
            get
            {
                return "GBHREGahcu52487";
            }
        }

        public static String CiDiKeyAplicacion
        {
            get
            {
                return "365873517459654D49575773436C7370";
            }
        }

        public static String APICuenta
        {
            get
            {
                return "https://cuentacidi.cba.gov.ar/";
            }
        }

        public static String APIComunicacion
        {
            get
            {
                return "https://comunicacioncidi.cba.gov.ar/";
            }
        }

        public static String APIDocumentacion
        {
            get
            {
                return "https://documentacioncidi.cba.gov.ar/";
            }
        }

        public static String APIMobile
        {
            get
            {
                return "https://mobilecidi.cba.gov.ar/";
            }
        }

        public static String CiDiUrlRelacion
        {
            get
            {
                return "https://cidi.cba.gov.ar/relacion/appseleccion";
            }
        }

        public static String CiDi_OK
        {
            get
            {
                return "OK";
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Metodo para obtener el token para enviar a la WebAPI. Este token consiste en un hash SHA512 del Timestamp + KEY de aplicación para validar la integridad y autenticidad de los parámetros utilizados.
        /// </summary>
        /// <param name="TimeStamp">Recibe un TimeStamp con formato debe ser yyyyMMddHHmmssfff Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff")</param>
        /// <returns>String</returns>
        public static String ObtenerToken_SHA512(String TimeStamp)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(TimeStamp + CiDiKeyAplicacion);
            SHA512 SHA512M = new SHA512Managed();
            String token = BitConverter.ToString(SHA512M.ComputeHash(buffer)).Replace("-", "");

            return token;
        }

        /// <summary>
        /// Metodo para obtener el token para enviar a la WebAPI. Este token consiste en un hash SHA1 del Timestamp + KEY de aplicación para validar la integridad y autenticidad de los parámetros utilizados.
        /// </summary>
        /// <param name="TimeStamp">Recibe un TimeStamp con formato debe ser yyyyMMddHHmmssfff Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff")</param>
        /// <returns>String</returns>
        public static String ObtenerToken_SHA1(String TimeStamp)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(TimeStamp + CiDiKeyAplicacion);
            SHA1 SHA1 = new SHA1Managed();
            String token = BitConverter.ToString(SHA1.ComputeHash(buffer)).Replace("-", "");

            return token;
        }

        /// <summary>
        /// Realiza la llamada a la WebAPI de Ciudadano Digital, serializa la Entrada y deserializa la Respuesta.
        /// </summary>
        /// <typeparam name="TEntrada">Declarar el objeto de Entrada al método.</typeparam>
        /// <typeparam name="TRespuesta">Declarar el objeto de Respuesta al método.</typeparam>
        /// <param name="Accion">Recibe la acción específica del controlador de la WebAPI.</param>
        /// <param name="tEntrada">Objeto de entrada de la WebAPI , especificado en TEntrada.</param>
        /// <returns>Objeto de salida de la WebAPI, especificado en TRespuesta.</returns>
        public static TRespuesta LlamarWebAPI<TEntrada, TRespuesta>(String Accion, TEntrada tEntrada)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Accion);
            httpWebRequest.ContentType = "application/json; charset=utf-8";

            String rawjson = JsonConvert.SerializeObject(tEntrada);
            httpWebRequest.Method = "POST";

            var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());

            streamWriter.Write(rawjson);
            streamWriter.Flush();
            streamWriter.Close();

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var streamReader = new StreamReader(httpResponse.GetResponseStream());
            var result = streamReader.ReadToEnd();

            TRespuesta respuesta = JsonConvert.DeserializeObject<TRespuesta>(result);

            return respuesta;
        }

        #endregion
    }

    public class APICuenta
    {
        public class Usuario
        {
            /// <summary>
            /// Obtención del usuario Ciudadano Digital a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario_Aplicacion
            {
                get
                {
                    return Config.APICuenta + "api/Usuario/Obtener_Usuario_Aplicacion";
                }
            }

            /// <summary>
            /// Obtención de un usuario Ciudadano Digital a través del CUIL
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario
            {
                get
                {
                    return Config.APICuenta + "api/Usuario/Obtener_Usuario";
                }
            }

            /// <summary>
            /// Obtención del usuario Ciudadano Digital con datos básicos a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario_Basicos
            {
                get
                {
                    return Config.APICuenta + "api/Usuario/Obtener_Usuario_Basicos";
                }
            }

            /// <summary>
            /// Obtención del usuario Ciudadano Digital con datos básicos a través del CUIL
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.CUIL" tipo="Alfanumérico" long="30">CUIL del usuario.
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario_Basicos_CUIL
            {
                get
                {
                    return Config.APICuenta + "api/Usuario/Obtener_Usuario_Basicos_CUIL";
                }
            }

            /// <summary>
            /// Obtención del usuario Ciudadano Digital con datos básicos y el domicilo a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario_Basicos_Domicilio
            {
                get
                {
                    return Config.APICuenta + "api/Usuario/Obtener_Usuario_Basicos_Domicilio";
                }
            }

            /// <summary>
            /// Obtención del usuario Ciudadano Digital con datos básicos y el domicilio a través del CUIL
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.CUIL" tipo="Alfanumérico" long="30">CUIL del usuario.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario_Basicos_Domicilio_CUIL
            {
                get
                {
                    return Config.APICuenta + "api/Usuario/Obtener_Usuario_Basicos_Domicilio_CUIL";
                }
            }

            /// <summary>
            /// Obtención del usuario Ciudadano Digital con datos básicos y el representado a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario_Basicos_Representado
            {
                get
                {
                    return Config.APICuenta + "api/Usuario/Obtener_Usuario_Basicos_Representado";
                }
            }

            /// <summary>
            /// Obtención de los datos del representado a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Representado
            {
                get
                {
                    return Config.APICuenta + "api/Usuario/Obtener_Representado";
                }
            }

            /// <summary>
            /// Cierre de sesión a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Cerrar_Sesion_Usuario_Aplicacion
            {
                get
                {
                    return Config.APICuenta + "api/Usuario/Cerrar_Sesion_Usuario_Aplicacion";
                }
            }
        }

        public class Representado
        {
            /// <summary>
            /// Obtención de un usuario y sus representados a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene del query string de la cookie encriptada por 
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario_Y_Representados
            {
                get
                {
                    return Config.APICuenta + "api/Representado/Obtener_Usuario_Y_Representados";
                }
            }

            /// <summary>
            /// Obtención de un usuario y sus representados a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario_Lista_Representados
            {
                get
                {
                    return Config.APICuenta + "api/Representado/Obtener_Usuario_Lista_Representados";
                }
            }

            /// <summary>
            /// Obtención del representado y un listado de representantes a través del CUIL/CUIT
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.CuitCuil" tipo="Alfanumérico" long="30">CUIL del usuario o CUIT de la organización.
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Representado_Lista_Representantes
            {
                get
                {
                    return Config.APICuenta + "api/Representado/Obtener_Representado_Lista_Representantes";
                }
            }

            /// <summary>
            /// Obtención del usuario Ciudadano Digital con datos básicos y el representado a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Usuario_Basicos_Representado
            {
                get
                {
                    return Config.APICuenta + "api/Representado/Obtener_Usuario_Basicos_Representado";
                }
            }

            /// <summary>
            /// Obtención de los datos del representado a través de la cookie
            /// </summary>
            /// <param name="Entrada">
            /// name="Entrada.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="Entrada.HashCookie" tipo="Alfanumérico" long="255">Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// name="Entrada.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA1 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="Entrada.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Representado
            {
                get
                {
                    return Config.APICuenta + "api/Representado/Obtener_Representado";
                }
            }
        }

        public class Aplicacion
        {
            /// <summary>
            /// Cambio de contraseña de la aplicación. Para uso interno del desarrollador
            /// </summary>
            /// <param name="IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación (provisto por la gestión del proyecto Ciudadano Digital).</param>
            /// <param name="ContraseniaAnterior">Contraseña actual de la aplicación.</param>
            /// <param name="ContraseniaNueva">Nueva contraseña a establecer para la aplicación.</param>
            /// <param name="TokenValue" tipo="Alfanumérico" long="40">Contraseña de Ciudadano Digital. Consiste en un hash SHA1 del timestamp+SECRET_KEY para validar la integridad y autenticidad de los parámetros utilizados. La SECRET_KEY será una clave acordada entre la Aplicación y el portal.</param>
            /// <param name="TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del mensaje. El formato debe ser yyyyMMddHHmmssfff. Ej: DateTime.Now.ToString("yyyyMMddHHmmssfff");</param>
            /// <returns></returns>
            public static String Cambiar_Contrasenia_Aplicacion
            {
                get
                {
                    return Config.APICuenta + "api/Representado/Cambiar_Contrasenia_Aplicacion";
                }
            }

            /// <summary>
            /// Login de la aplicación y obtención del SesioHash
            /// </summary>
            /// <param name="IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación (provisto por la gestión del proyecto Ciudadano Digital).</param>
            /// <param name="Contrasenia">Contraseña de la aplicación.</param>
            /// <param name="TokenValue" tipo="Alfanumérico" long="40">Contraseña de Ciudadano Digital. Consiste en un hash SHA1 del timestamp+SECRET_KEY para validar la integridad y autenticidad de los parámetros utilizados. La SECRET_KEY será una clave acordada entre la Aplicación y el portal.</param>
            /// <param name="TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del mensaje. El formato debe ser yyyyMMddHHmmssfff. Ej: DateTime.Now.ToString("yyyyMMddHHmmssfff");</param>
            /// <returns></returns>
            public static String Registrar_Aplicacion
            {
                get
                {
                    return Config.APICuenta + "api/Representado/Registrar_Aplicacion";
                }
            }
        }
    }

    public class APIComunicacion
    {
        public class Notificacion
        {
            /// <summary>
            /// Envía notificaciones a ciudadanos a través del CUIL, que se muestran en el portal de Ciudadano Digital.
            /// </summary>
            /// <param name="entrada">EntradaNotificacion</param>
            /// <returns>Respuesta</returns>
            public static String Enviar_Alerta
            {
                get
                {
                    return Config.APIComunicacion + "api/Notificacion/Enviar_Alerta";
                }
            }
        }

        public class SMS
        {
            /// <summary>
            /// Envia un SMS a un usuario Ciudadano Digital a través del Cuil
            /// </summary>
            /// <param name="SMS">Objecto SMS</param>
            /// <returns>ResultadoSMS</returns>
            public static String Enviar
            {
                get
                {
                    return Config.APIComunicacion + "api/SMS/Enviar";
                }
            }

            /// <summary>
            /// Envia un SMS a un usuario Ciudadano Digital a través de la cookie
            /// </summary>
            /// <param name="SMS">Objecto SMS</param>
            /// <returns>ResultadoSMS</returns>
            public static String Enviar_Aplicacion
            {
                get
                {
                    return Config.APIComunicacion + "api/SMS/Enviar_Aplicacion";
                }
            }
        }

        public class Email
        {
            /// <summary>
            /// Envia un email a un usuario Ciudadano Digital a través del Cuil
            /// </summary>
            /// <param name="email">Objecto Email</param>
            /// <returns>ResultadoEmail</returns>
            public static String Enviar
            {
                get
                {
                    return Config.APICuenta + "api/Email/Enviar";
                }
            }

            /// <summary>
            /// Envia un email a un usuario Ciudadano Digital a través de la cookie
            /// </summary>
            /// <param name="email">Objecto Email</param>
            /// <returns>ResultadoEmail</returns>
            public static String Enviar_Aplicacion
            {
                get
                {
                    return Config.APICuenta + "api/Email/Enviar_Aplicacion";
                }
            }
        }
    }

    public class APIDocumentacion
    {
        public class Documentacion
        {
            /// <summary>
            /// Obtención de los documentos del Ciudadano Digital a través del Cuil y la Cookie del operador
            /// </summary>
            /// <param name="entrada">
            /// entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// entrada.HashCookie tipo="Alfanumérico" Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// entrada.CUIL tipo="Alfanumérico" CUIL del usuario.
            /// entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>RespuestaListDoc</returns>
            public static String Obtener_Documentacion
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Documentacion";
                }
            }

            /// <summary>
            /// Obtención de los documentos del Ciudadano Digital a través del Cuil
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// Entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// Entrada.CUIL tipo="Alfanumérico" CUIL del usuario.
            /// Entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>RespuestaList</returns>
            public static String Obtener_Documentacion_Usuario
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Documentacion_Usuario";
                }
            }

            /// <summary>
            /// Obtención de los documentos del Ciudadano Digital a través de la cookie
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// Entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// Entrada.HashCookie tipo="Alfanumérico" Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// Entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>RespuestaList</returns>
            public static String Obtener_Documentacion_Sesion
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Documentacion_Sesion";
                }
            }

            /// <summary>
            /// Obtención de un listado de tipos de documentos permitidos en la plataforma Ciudadano Digital
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// Entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// Entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>RespuestaTipoDoc</returns>
            public static String Obtener_Tipo_Documentos
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Tipo_Documentos";
                }
            }

            /// <summary>
            /// Obtención de una vista previa del listado de documentos del Ciudadano Digital
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.HashCookie tipo="Alfanumérico" Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// Entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff")
            /// Entrada.Cuil tipo="Alfanumérico" CUIL del usuario al que se requiere obtener el documento.
            /// Entrada.DiccionarioDocumentos tipo="Numérico" Diccionario de datos con el identificador del documento y el tipo de documento IdDocumento;IdTipoDocumento
            /// </param>
            /// <returns>RespuestaVistaPrevia</returns>
            public static String Obtener_Vista_Previa
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Vista_Previa";
                }
            }

            /// <summary>
            /// Obtención de un documento específico del Ciudadano Digital
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.HashCookie tipo="Alfanumérico" Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// Entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff")
            /// Entrada.Documentacion.IdDocumento tipo="Numérico" Identificador del documento que se quiere obtener.
            /// Entrada.Cuil tipo="Alfanumérico" CUIL del usuario al que se requiere obtener el documento.
            /// </param>
            /// <returns>RespuestaDoc</returns>
            public static String Obtener_Documento
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Documento";
                }
            }

            /// <summary>
            /// Obtención de la foto de perfil del Ciudadano Digital (Nivel 2)
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// Entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// Entrada.HashCookieOperador tipo="Alfanumérico" Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// Entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// Entrada.CUIL tipo="Alfanumérico" CUIL del usuario.
            /// </param>
            /// <returns>RespuestaList</returns>
            public static String Obtener_Foto_Perfil
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Foto_Perfil";
                }
            }

            /// <summary>
            /// Incorporar un documento en la plataforma al Ciudadano Digital
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.Contrasenia Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.TokenValue Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff");
            /// Entrada.CUIL CUIL del usuario al que se le asocia el documento.
            /// Entrada.HashCookie Valor de la cookie del operador.
            /// Entrada.Documentacion.Imagen Array de byte del documento, cifrado por la librería CryptoManager.
            /// Entrada.Documentacion.Extension Extensión del documento.
            /// Entrada.Documentacion.FechaVencimiento Fecha vencimiento del documento.
            /// Entrada.Documentacion.IdTipo Identificador del tipo documento.
            /// Entrada.Documentacion.Descripcion Descripción del documento.
            /// </param>
            /// <returns>RespuestaDocInsercion</returns>
            public static String Guardar_Documento
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Guardar_Documento";
                }
            }

            /// <summary>
            /// Incorporar un documento en la plataforma al Ciudadano Digital 
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.Contrasenia Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.TokenValue Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff");
            /// Entrada.CUIL CUIL del usuario al que se le asocia el documento.
            /// Entrada.HashCookie Valor de la cookie del operador.
            /// Entrada.Documentacion.Imagen Array de byte del documento, cifrado por la librería CryptoManager.
            /// Entrada.Documentacion.Extension Extensión del documento.
            /// Entrada.Documentacion.FechaVencimiento Fecha vencimiento del documento.
            /// Entrada.Documentacion.IdTipo Identificador del tipo documento.
            /// Entrada.Documentacion.Descripcion Descripción del documento.
            /// </param>
            /// <returns>RespuestaDocInsercion</returns>
            public static String Guardar_Documento_Cuil_Operador
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Guardar_Documento_Cuil_Operador";
                }
            }

            /// <summary>
            /// Borra un documento en la plataforma al Ciudadano Digital
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.Contrasenia Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.TokenValue Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff");
            /// Entrada.CUIL CUIL del usuario al que se le asocia el documento.
            /// Entrada.HashCookie Valor de la cookie del operador.
            /// Entrada.Documentacion.Imagen Array de byte del documento, cifrado por la librería CryptoManager.
            /// Entrada.Documentacion.Extension Extensión del documento.
            /// Entrada.Documentacion.FechaVencimiento Fecha vencimiento del documento.
            /// Entrada.Documentacion.IdTipo Identificador del tipo documento.
            /// Entrada.Documentacion.Descripcion Descripción del documento.
            /// </param>
            /// <returns>RespuestaDocInsercion</returns>
            public static String Eliminar_Documento
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Eliminar_Documento";
                }
            }

            /// <summary>
            /// Borra un conjunto de documentos en la plataforma al Ciudadano Digital
            /// </summary>
            /// <param name="entrada">
            /// Entrada.IdAplicacion El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.Contrasenia Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital
            /// Entrada.TokenValue Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// Entrada.TimeStamp TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff");
            /// Entrada.CUIL CUIL del usuario al que se le asocia el documento.
            /// Entrada.HashCookie Valor de la cookie del operador.
            /// Entrada.Documentacion.Imagen Array de byte del documento, cifrado por la librería CryptoManager.
            /// Entrada.Documentacion.Extension Extensión del documento.
            /// Entrada.Documentacion.FechaVencimiento Fecha vencimiento del documento.
            /// Entrada.Documentacion.IdTipo Identificador del tipo documento.
            /// Entrada.Documentacion.Descripcion Descripción del documento.
            /// </param>
            /// <returns>RespuestaDocInsercion</returns>
            public static String Eliminar_Documentos
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Eliminar_Documentos";
                }
            }

            /// <summary>
            /// Obtención de los permisos que posee el operador (qué tipo de archivos puede ver insertar o borrar) a través de la cookie
            /// </summary>
            /// <param name="entrada">
            /// entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// entrada.HashCookie tipo="Alfanumérico" Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>RespuestaPermiso</returns>
            public static String Obtener_Operador_Permiso
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Operador_Permiso";
                }
            }

            /// <summary>
            /// Obtención del historial de un documento a través del Cuil
            /// </summary>
            /// <param name="entrada">
            /// entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// entrada.HashCookie tipo="Alfanumérico" Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// entrada.Documentacion.IdTipo tipo="Numérico" Identificador del tipo de documento.
            /// entrada.Documentacion.IdDocumento tipo="Numérico" Identificador del documento.
            /// entrada.CUIL tipo="Alfanumérico" CUIL del usuario.
            /// </param>
            /// <returns>RespuestaHistorial</returns>
            public static String Obtener_Historial
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Historial";
                }
            }

            /// <summary>
            /// Obtención de los roles y permisos de los documentos a través de la cookie
            /// </summary>
            /// <param name="entrada">
            /// entrada.IdAplicacion tipo="Numérico" El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// entrada.Contrasenia tipo="Alfanumérico" Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// entrada.HashCookie tipo="Alfanumérico" Valor que se obtiene de la cookie. Nombre de la cookie "CiDi".
            /// entrada.TokenValue tipo="Alfanumérico" Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// entrada.TimeStamp tipo="Alfanumérico" TimeStamp del token. El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff")
            /// </param>
            /// <returns>Usuario</returns>
            public static String Obtener_Roles_Permisos
            {
                get
                {
                    return Config.APIDocumentacion + "api/Documentacion/Obtener_Roles_Permisos";
                }
            }
        }
    }

    public class APIMobile
    {
        public class Mobile
        {
            /// <summary>
            /// Inicio de sesión y obtención del usuario de la cuanta de Ciudadano Digital
            /// </summary>
            /// <param name="Entrada">
            /// name="EntradaLogin.IdAplicacion" tipo="Numérico" long="2">El identificador de aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="EntradaLogin.Contrasenia" tipo="Alfanumérico" long="30">Contraseña de la Aplicación. Provisto por la gestión del proyecto Ciudadano Digital.
            /// name="EntradaLogin.CUIL" tipo="Alfanumérico" long="30">CUIL del usuario.
            /// name="EntradaLogin.ContraseniaUsuario" tipo="Alfanumérico" long="30">Contraseña del usuario
            /// name="EntradaLogin.TokenValue" tipo="Alfanumérico" long="40">Token. Consiste en un hash SHA512 del TimeStamp + SECRET_KEY sin guiones. 
            /// Funciona como validador de la integridad y autenticidad de los parámetros utilizados.
            /// name="EntradaLogin.TimeStamp" tipo="Alfanumérico" long="17">TimeStamp del token. 
            /// El formato debe ser yyyyMMddHHmmssfff. Ej .NET C#: DateTime.Now.ToString("yyyyMMddHHmmssfff").
            /// </param>
            /// <returns>Usuario</returns>
            public static String Login_Usuario
            {
                get
                {
                    return Config.APIMobile + "api/Mobile/Login_Usuario";
                }
            }
        }
    }
}