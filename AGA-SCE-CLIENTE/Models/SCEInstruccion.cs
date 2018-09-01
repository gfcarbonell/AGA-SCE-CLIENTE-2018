using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Models
{
    public class SCEInstruccion
    {
        public int IdInstruccion { get; set; }
        public string IdCampana { get; set; }
        public DateTime? Fecha { get; set; }
        public string IdSucursal { get; set; }
        public string IdEncargado { get; set; }
        public string NroPackingList { get; set; }
        public string IdOperador { get; set; }
        public string IdTerminal { get; set; }
        public string Contacto { get; set; }
        public string IdNaviera { get; set; }
        public string Booking { get; set; }
        public string IdEmbarcador { get; set; }
        public string IdBroker { get; set; }
        public string IdConsignatario { get; set; }
        public string IdNotificante { get; set; }
        public string NaveViaje { get; set; }
        public string IdCondicionFlete { get; set; }
        public string IdPuertoEmbarque { get; set; }
        public string IdPuertoDestino { get; set; }
        public DateTime Etd { get; set; }
        public DateTime Eta { get; set; }
        public string IdPartida { get; set; }
        public string IdRegimen { get; set; }
        public byte CertificadoFito { get; set; }
        public DateTime? IngresoPlanta { get; set; }
        public TimeSpan? HoraLLenado { get; set; }
        public DateTime? SalidaIca { get; set; }
        public DateTime? IngresoTerminal { get; set; }
        public string Nota { get; set; }
        public short? Temperature { get; set; }
        public byte Ventilation { get; set; }
        public byte Humedity { get; set; }
        public byte Quest { get; set; }
        public decimal? VGM { get; set; }
        public short Estado { get; set; }
        public short UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public short? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual SCECampana SCECampana { get; set; }
        public virtual SCEClienteProveedor SCEClienteProveedor1 { get; set; }
        public virtual SCEClienteProveedor SCEClienteProveedor2 { get; set; }
        public virtual SCEClienteProveedor SCEClienteProveedor3 { get; set; }
        public virtual SCEClienteProveedor SCEClienteProveedor4 { get; set; }
    }
}