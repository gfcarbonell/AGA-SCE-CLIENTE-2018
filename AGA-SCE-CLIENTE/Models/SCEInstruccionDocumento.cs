using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Models
{
    public class SCEInstruccionDocumento
    {
        public int IdDocumento { get; set; }
        public int IdInstruccion { get; set; }
        public string NroPackingList { get; set; }
        public int IdArchivo { get; set; }
        public string IdTipo { get; set; }
        public string NombreArchivo { get; set; }
        public string Descripcion { get; set; }
        public double? Tamano { get; set; }
        public byte? Estado { get; set; }
        public virtual SCEInstruccion SCEInstruccion { get; set; }
        public virtual SCETipoDocumento SCETipoDocumento { get; set; }
        //Archivo - DOC
        public virtual SCEArchivo SCEArchivo { get; set; }
    }
}