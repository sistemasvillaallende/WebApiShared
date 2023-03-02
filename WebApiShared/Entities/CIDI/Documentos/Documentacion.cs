﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiShared.Entities.CIDI.Documentos
{
    public class Documentacion
    {
        public int IdDocumento { get; set; }

        public int IdUsuario { get; set; }

        public int IdTipo { get; set; }

        public String NombreTipo { get; set; }

        public String FechaCreacion { get; set; }

        public String FechaVencimiento { get; set; }

        public int IdUbicacion { get; set; }

        public String UbicacionFisica { get; set; }

        public String IdOperador { get; set; }

        public String Operador { get; set; }

        public int IdOrganismo { get; set; }

        public String Organismo { get; set; }

        public byte[] Imagen { get; set; }

        public byte[] VistaPrevia { get; set; }

        public String Extension { get; set; }

        public String Descripcion { get; set; }

        public String Acumulable { get; set; }

        public String Repositorio { get; set; }

        public String CuilOperador { get; set; }

        public String NombreOperador { get; set; }
    }

    public class VistaPrevia
    {
        public String Detalle_Resultado { get; set; }
        public String Codigo_Resultado { get; set; }

        public int Id_Documento { get; set; }
        public byte[] Preview { get; set; }
        public String Extension { get; set; }
    }
}