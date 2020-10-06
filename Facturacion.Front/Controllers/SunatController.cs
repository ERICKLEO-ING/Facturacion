namespace Facturacion.Front.Controllers
{
    using Facturacion.Front.Properties;
    using Facturacion.Front.Services;
    using Ionic.Zip;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    public class SunatController
    {
        readonly string UsuarioSol;
        readonly string ClaveSol;
        readonly string RucEmisor;
        public SunatController(string NumeroRuc)
        {
            UsuarioSol = NumeroRuc+"MODDATOS";
            ClaveSol = "MODDATOS";
            RucEmisor = NumeroRuc;
        }
        public string EnvioSunatDocumento(string tramaZip, string codigoTipoDoc, string SerieCorrelativo)
        {
            string Respuesta = string.Empty;
            try
            {
                using (var conexion = new ConexionSunat(RucEmisor, UsuarioSol, ClaveSol))
                {
                    var nombreArchivo = $"{RucEmisor}-{codigoTipoDoc}-{SerieCorrelativo}";
                    var resultado = conexion.EnviarDocumento(tramaZip, $"{nombreArchivo}.zip");
                    
                    if (resultado.Item2)
                    {
                        var returnByte = Convert.FromBase64String(resultado.Item1);

                        var rutaArchivo = $"{Directory.GetCurrentDirectory()}\\R-{nombreArchivo}.zip";
                        var fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write);
                        fs.Write(returnByte, 0, returnByte.Length);
                        fs.Close();

                        var sb = new StringBuilder();

                        // Añadimos la respuesta del Servicio.
                        sb.AppendLine(Resources.procesoCorrecto);

                        // Extraemos el XML contenido en el archivo de respuesta como un XML.
                        var rutaArchivoXmlRespuesta = rutaArchivo.Replace(".zip", ".xml");
                        // Procedemos a desempaquetar el archivo y leer el contenido de la respuesta SUNAT.
                        using (var streamZip = ZipFile.Read(File.Open(rutaArchivo,
                            FileMode.Open,
                            FileAccess.ReadWrite)))
                        {
                            // Nos aseguramos de que el ZIP contiene al menos un elemento.
                            if (streamZip.Entries.Any())
                            {
                                streamZip.Entries.First()
                                    .Extract(".", ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                        // Como ya lo tenemos extraido, leemos el contenido de dicho archivo.
                        var xDoc = XDocument.Parse(File.ReadAllText(rutaArchivoXmlRespuesta));

                        var respuesta = xDoc.Descendants(XName.Get("DocumentResponse", EspacioNombres.cac))
                            .Descendants(XName.Get("Response", EspacioNombres.cac))
                            .Descendants().ToList();

                        if (respuesta.Any())
                        {
                            // La respuesta se compone de 3 valores
                            // cbc:ReferenceID
                            // cbc:ResponseCode
                            // cbc:Description
                            // Obtendremos unicamente la Descripción (la última).
                            sb.AppendLine($"Respuesta de SUNAT a las {DateTime.Now}");
                            sb.AppendLine(((XText)respuesta.Nodes().Last()).Value);
                        }

                        Respuesta = sb.ToString();
                        sb.Length = 0; // Limpiamos memoria del StringBuilder.
                    }
                    else

                        Respuesta = resultado.Item1; 
                }
                return Respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
