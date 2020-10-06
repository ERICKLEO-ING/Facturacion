using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFact.Models
{
    public class DocumentoElectronicoModel
    {
        public string Ruc { get; set; }
        public string Local { get; set; }
        public string Caja { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public TramaDocumento Trama { get; set; }
    }
    public class TramaDocumento
    {
        public string EN { get; set; }
        public string ENEX { get; set; }
        public List<ITEM> ITEM { get; set; }
        public List<string> DI { get; set; }
    }
    public class ITEM
    {
        public string DE { get; set; }
        public string DEDI { get; set; }
        public string DEDR { get; set; }
        public List<string> DEIM { get; set; }
    }
}
