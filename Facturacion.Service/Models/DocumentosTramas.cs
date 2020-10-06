using System;
using System.Collections.Generic;

namespace FacturacionElectronica.Models
{
    public partial class DocumentosTramas
    {
        public DocumentosTramas()
        {
            Documentos = new HashSet<Documentos>();
        }

        public Guid IdTrama { get; set; }
        public string Json { get; set; }
        public string Xml { get; set; }
        public string Xmlzip { get; set; }
        public string Firmaxml { get; set; }
        public string Hash { get; set; }
        public string Cdr { get; set; }

        public virtual ICollection<Documentos> Documentos { get; set; }
    }
}
