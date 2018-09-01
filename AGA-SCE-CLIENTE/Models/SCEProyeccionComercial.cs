using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Models
{
    public class SCEProyeccionComercial
    {
        public int IdProyeccion { get; set; }
        public string IdCampana { get; set; }
        public short Semana { get; set; }
        public string IdCliente { get; set; }
        public string IdMercado { get; set; }
        public string idVariedad { get; set; }
        public string IdEmbalaje { get; set; }
        public decimal Cantidad { get; set; }
        public short Estado { get; set; }
        public short UsuarioCreacion { get; set; }


        public DateTime? FechaCreacion { get; set; }
        public short? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual SCEVariedad SCEVariedad { get; set; }
        public virtual SCECampana SCECampana { get; set; }
        public virtual SCEEmbalaje SCEEmbalaje { get; set; }
        public virtual SCEClienteProveedor SCEClienteProveedor { get; set; }
        public virtual SCEMercado SCEMercado { get; set; }
    }
}