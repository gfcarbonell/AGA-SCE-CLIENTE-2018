using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Models
{
    public class SCECampana
    {
        public SCECampana()
        {
            SCEInstruccion = new HashSet<SCEInstruccion>();
            SCEProyeccionComercial = new HashSet<SCEProyeccionComercial>();
        }
        public string IdCampana { get; set; }
        public string Descripcion { get; set; }
        public string IdCultivo { get; set; }

        public short Estado { get; set; }
        public virtual ICollection<SCEInstruccion> SCEInstruccion { get; set; }
        public virtual ICollection<SCEProyeccionComercial> SCEProyeccionComercial { get; set; }

    }
}