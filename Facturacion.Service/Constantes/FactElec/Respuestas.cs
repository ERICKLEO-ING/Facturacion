namespace FacturacionElectronica.Constantes.FactElec
{
    public static class ErrorGenerico
    {

        public const string Codigo = "10101";
        public const string Mensaje = "Error Genérico detectado";

    }

    public static class ErrorBaseDatos
    {

        public const string Codigo = "10102";
        public const string Mensaje = "Error de Base de Datos";

    }

    public static class ErrorSUNAT
    {

        public const string Codigo = "10103";
        public const string Mensaje = "Error con WebService SUNAT";

    }

    public static class ErrorValidacion
    {
        public const string Codigo = "10104";
        public const string Mensaje = "Error de Validación";
    }

    public static class MensajeExitoso
    {
        public const string Codigo = "10200";
        public const string Mensaje = "Enviado Correctamente";
    }

    public static class Constantes
    {
        public const string FormatoFecha = "yyyy-MM-dd";
        public const string FormatoNumerico = "###0.#0";
        public const string FormatoDecimal_5 = "##0.####0";
    }
    public static class ConstantesAtributo
    {
        public const string ISO_3166_1 = "ISO 3166-1";
        public const string PESUNAT = "PE:SUNAT";
        public const string PEINEI = "PE:INEI";
        public const string CATALOGO01 = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01";
        public const string CATALOGO06 = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
        public const string CATALOGO07 = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
        public const string CATALOGO16 = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16";
        public const string UNECE5305 = "UN/ECE 5305";
        public const string PEN = "PEN";
        public const string UNITED_NATIONS_ECONOMIC = "United Nations Economic Commission for Europe";
    }
}
