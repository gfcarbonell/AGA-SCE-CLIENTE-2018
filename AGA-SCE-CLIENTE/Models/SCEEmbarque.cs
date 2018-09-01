using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Models
{
    public class SCEEmbarque
    {
        public string NroPackingList { get; set; }
        public int IdInstruccion { get; set; }
        public string Instruccion { get; set; }
        public string Embarque { get; set; }
        public DateTime FechaEmbarque { get; set; }
        public DateTime FechaArribo { get; set; }
        public decimal Cantidad { get; set; }
    }
}