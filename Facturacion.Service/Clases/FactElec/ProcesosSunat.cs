namespace FacturacionElectronica.Clases.FactElec
{
    using Ionic.Zip;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using System.Xml.Linq;

    public class ProcesosSunat
    {
        public string EnvioSunatDocumento(string Ruc, string TipoDocumento, string DocumentoElectronico,string PassCertificado, string UsuarioSol, string PassSol, string RutaCertificado, string RutaXML)
        {
            try
            {
                // Una vez validado el XML seleccionado procedemos con obtener el Certificado.
                var serializar = new Serializador
                {
                    RutaCertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(RutaCertificado)),
                    PasswordCertificado = PassCertificado,
                    TipoDocumento = 1//rbRetenciones.Checked ? 0 : 1
                };

                using (var conexion = new ConexionSunat(Ruc, UsuarioSol,PassSol, ""))
                {
                    var byteArray = File.ReadAllBytes(RutaXML);
                    // Firmamos el XML.
                   // var tramaFirmado = serializar.FirmarXml(Convert.ToBase64String(byteArray));
                    // Le damos un nuevo nombre al archivo
                    //var nombreArchivo = $"{Ruc}-{TipoDocumento}-{DocumentoElectronico}";
                    // Escribimos el archivo XML ya firmado en una nueva ubicación.
                    //using (var fs = File.Create($"{nombreArchivo}.xml"))
                    //{
                    //    var byteFirmado = Convert.FromBase64String(tramaFirmado);
                    //    fs.Write(byteFirmado, 0, byteFirmado.Length);
                    //}
                    //// Ahora lo empaquetamos en un ZIP.
                    //var tramaZip = serializar.GenerarZip(tramaFirmado, nombreArchivo);

                  //var resultado = conexion.EnviarDocumento(tramaZip, $"{nombreArchivo}.zip");

                  //  if (resultado.Item2)
                  //  {
                  //      var returnByte = Convert.FromBase64String(resultado.Item1);

                  //      var rutaArchivo = $"{Directory.GetCurrentDirectory()}\\R-{nombreArchivo}.zip";
                  //      var fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write);
                  //      fs.Write(returnByte, 0, returnByte.Length);
                  //      fs.Close();

                  //      var sb = new StringBuilder();

                  //      // Añadimos la respuesta del Servicio.
                  //      sb.AppendLine(Resources.procesoCorrecto);

                  //      // Extraemos el XML contenido en el archivo de respuesta como un XML.
                  //      var rutaArchivoXmlRespuesta = rutaArchivo.Replace(".zip", ".xml");
                  //      // Procedemos a desempaquetar el archivo y leer el contenido de la respuesta SUNAT.
                  //      using (var streamZip = ZipFile.Read(File.Open(rutaArchivo,
                  //          FileMode.Open,
                  //          FileAccess.ReadWrite)))
                  //      {
                  //          // Nos aseguramos de que el ZIP contiene al menos un elemento.
                  //          if (streamZip.Entries.Any())
                  //          {
                  //              streamZip.Entries.First()
                  //                  .Extract(".", ExtractExistingFileAction.OverwriteSilently);
                  //          }
                  //      }
                  //      // Como ya lo tenemos extraido, leemos el contenido de dicho archivo.
                  //      var xDoc = XDocument.Parse(File.ReadAllText(rutaArchivoXmlRespuesta));

                  //      var respuesta = xDoc.Descendants(XName.Get("DocumentResponse", EspacioNombres.cac))
                  //          .Descendants(XName.Get("Response", EspacioNombres.cac))
                  //          .Descendants().ToList();

                  //      if (respuesta.Any())
                  //      {
                  //          // La respuesta se compone de 3 valores
                  //          // cbc:ReferenceID
                  //          // cbc:ResponseCode
                  //          // cbc:Description
                  //          // Obtendremos unicamente la Descripción (la última).
                  //          sb.AppendLine($"Respuesta de SUNAT a las {DateTime.Now}");
                  //          sb.AppendLine(((XText)respuesta.Nodes().Last()).Value);
                  //      }

                  //      //txtResult.Text = sb.ToString();
                  //      sb.Length = 0; // Limpiamos memoria del StringBuilder.
                  //  }
                  //  else { throw new Exception(resultado.Item1.ToString()); }

                    return "";

                }
            }
            catch (FaultException exSer)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
