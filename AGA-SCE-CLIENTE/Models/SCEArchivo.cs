using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Models
{
    public class SCEArchivo
    {
        public int IdArchivo { get; set; }
        public byte[] DocumentoData { get; set; }
        public byte Estado { get; set; }
    }
}