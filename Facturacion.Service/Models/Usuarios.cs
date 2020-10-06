using System;
using System.Collections.Generic;

namespace FacturacionElectronica.Models
{
    public partial class Usuarios
    {
        public Guid IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public DateTimeOffset? FechaRegistroSet { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public long? IdTipoUsuario { get; set; }
        public bool? Activo { get; set; }
    }
}
