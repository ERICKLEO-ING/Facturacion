using System;
using System.Collections.Generic;

namespace FacturacionElectronica.Models
{
    public partial class Documentos
    {
        public Guid IdDocumento { get; set; }
        public string Ruc { get; set; }
        public string Documento { get; set; }
        public string TipoDocumento { get; set; }
        public string Caja { get; set; }
        public Guid? IdLocal { get; set; }
        public Guid IdTrama { get; set; }
        public string Estado { get; set; }
        public DateTimeOffset? FechaRegistroSet { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual DocumentosTramas IdTramaNavigation { get; set; }
    }
}
