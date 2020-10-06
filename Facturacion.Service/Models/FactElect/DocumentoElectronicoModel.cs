namespace FacturacionElectronica.Models.FactElect
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DocumentoElectronicoModel
    {
        [Required]
        public string Caja { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string TipoDocumento { get; set; }
        [Required]
        public string Documento { get; set; }
        [Required]
        public TramaDocumento Trama { get; set; }
    }
    public class TramaDocumento
    {
        [Required]
        public string EN { get; set; }
        [Required]
        public string ENEX { get; set; }
        [Required]
        public List<Item> ITEM { get; set; }
        [Required]
        public List<string> DI { get; set; }
    }
    public class Item
    {
        [Required]
        public string DE { get; set; }
        [Required]
        public string DEDI { get; set; }
        [Required]
        public string DEDR { get; set; }
        [Required]
        public List<string> DEIM { get; set; }
    }

    public class FirmaDocumento
    {
        public string IdDocumento { get; set; }
        public string Documento { get; set; }
        public string FirmaDigital { get; set; }
    }
}
