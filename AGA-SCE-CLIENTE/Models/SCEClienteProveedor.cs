using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Models
{
    public class SCEClienteProveedor
    {
        public SCEClienteProveedor()
        {
            SCEInstruccion1 = new HashSet<SCEInstruccion>();
            SCEInstruccion2 = new HashSet<SCEInstruccion>();
            SCEInstruccion3 = new HashSet<SCEInstruccion>();
            SCEInstruccion4 = new HashSet<SCEInstruccion>();
            SCEProyeccionComercial = new HashSet<SCEProyeccionComercial>();
        }
        public string IdClienteProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Direccion2 { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Atencion { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
        public short Estado { get; set; }

        public virtual ICollection<SCEInstruccion> SCEInstruccion1 { get; set; }
        public virtual ICollection<SCEInstruccion> SCEInstruccion2 { get; set; }
        public virtual ICollection<SCEInstruccion> SCEInstruccion3 { get; set; }
        public virtual ICollection<SCEInstruccion> SCEInstruccion4 { get; set; }
        public virtual ICollection<SCEProyeccionComercial> SCEProyeccionComercial { get; set; }
    }
}