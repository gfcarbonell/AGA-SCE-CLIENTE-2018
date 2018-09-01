using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Models
{
    public class SCETipoDocumento
    {
        public SCETipoDocumento()
        {
            this.SCEInstruccionDocumento = new HashSet<SCEInstruccionDocumento>();
        }
        public string IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<SCEInstruccionDocumento> SCEInstruccionDocumento { get; set; }
    }
}