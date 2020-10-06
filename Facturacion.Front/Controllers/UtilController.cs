
namespace Facturacion.Front.Controllers
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    public class UtilController
    {
        public readonly string ruta = Application.StartupPath;

        public void GuardarErrores(object obj, Exception ex)
        {
            try
            {
                string fecha = System.DateTime.Now.ToString("yyyyMMdd");
                string hora = System.DateTime.Now.ToString("HH:mm:ss");
                string hora2 = System.DateTime.Now.ToString("HHmm");
                string Carpeta = ruta + @"/log/" + fecha;
                string path = ruta + @"/log/" + fecha + @"/" + fecha + "_" + hora2 + ".txt";
                if (!Directory.Exists(Carpeta))
                {
                    Directory.CreateDirectory(Carpeta);
                }
                StreamWriter sw = new StreamWriter(path, true);

                StackTrace stacktrace = new StackTrace();
                sw.WriteLine(" ");
                sw.WriteLine("Objeto : " + obj.GetType().FullName);
                sw.WriteLine("Fecha  : " + fecha + " " + hora);
                sw.WriteLine("Mensaje: " + stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
                sw.WriteLine("-------------------------------------------------------------------------------------------------");

                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }
    }
    public class EspacioNombres
    {
        public const string xmlnsRetention = "urn:sunat:names:specification:ubl:peru:schema:xsd:Retention-1";
        public const string xmlnsInvoice = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2";
        public const string xmlnsCreditNote = "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2";
        public const string xmlnsDebitNote = "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2";
        public const string xmlnsVoidedDocuments = "urn:sunat:names:specification:ubl:peru:schema:xsd:VoidedDocuments-1";
        public const string xmlnsSummaryDocuments = "urn:sunat:names:specification:ubl:peru:schema:xsd:SummaryDocuments-1";
        //public const string sac = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1";
        public const string cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
        public const string cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
        public const string udt = "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2";
        public const string ccts = "urn:un:unece:uncefact:documentation:2";
        public const string ext = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2";
        public const string qdt = "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2";
        public const string ds = "http://www.w3.org/2000/09/xmldsig#";
        public const string xsi = "http://www.w3.org/2001/XMLSchema-instance";
    }
}
