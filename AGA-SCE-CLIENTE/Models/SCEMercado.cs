using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Models
{
    public class SCEMercado
    {
        public SCEMercado()
        {
            SCEProyeccionComercial = new HashSet<SCEProyeccionComercial>();
        }

        public string IdMercado { get; set; }
        public string Descripcion { get; set; }
        public short Estado { get; set; }
        public virtual ICollection<SCEProyeccionComercial> SCEProyeccionComercial { get; set; }
    }
}