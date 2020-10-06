using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using EasyFact.Models;
using ErickOrlando.FirmadoSunat;
using ErickOrlando.FirmadoSunatWin.Properties;
using Ionic.Zip;

namespace ErickOrlando.FirmadoSunatWin
{
    public partial class FrmEnviarSunat : Form
    {
        public FrmEnviarSunat()
        {
            InitializeComponent();

            Load += (s, e) => cboTipoDoc.SelectedIndex = 0;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = Resources.seleccionXml;
                    ofd.Filter = Resources.formatosXml;
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtSource.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoTipoDoc;
                switch (cboTipoDoc.SelectedIndex)
                {
                    case 0:
                        codigoTipoDoc = "01";
                        break;
                    case 1:
                        codigoTipoDoc = "03";
                        break;
                    case 2:
                        codigoTipoDoc = "07";
                        break;
                    case 3:
                        codigoTipoDoc = "08";
                        break;
                    case 4:
                        codigoTipoDoc = "20";
                        break;
                    case 5:
                        codigoTipoDoc = "40";
                        break;
                    default:
                        codigoTipoDoc = "01";
                        break;
                }
                // Una vez validado el XML seleccionado procedemos con obtener el Certificado.
                var serializar = new Serializador
                {
                    RutaCertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtRutaCertificado.Text)),
                    PasswordCertificado = txtPassCertificado.Text,
                    TipoDocumento = rbRetenciones.Checked ? 0 : 1
                };

                using (var conexion = new ConexionSunat(txtNroRuc.Text, txtUsuarioSol.Text,
                    txtClaveSol.Text, rbRetenciones.Checked ? "ServicioSunatRetenciones" : string.Empty))
                {
                    var byteArray = File.ReadAllBytes(txtSource.Text);

                    Cursor = Cursors.WaitCursor;

                    // Firmamos el XML.
                    var tramaFirmado = serializar.FirmarXml(Convert.ToBase64String(byteArray));
                    // Le damos un nuevo nombre al archivo
                    var nombreArchivo = $"{txtNroRuc.Text}-{codigoTipoDoc}-{txtSerieCorrelativo.Text}";
                    // Escribimos el archivo XML ya firmado en una nueva ubicación.
                    using (var fs = File.Create($"{nombreArchivo}.xml"))
                    {
                        var byteFirmado = Convert.FromBase64String(tramaFirmado);
                        fs.Write(byteFirmado, 0, byteFirmado.Length);
                    }
                    // Ahora lo empaquetamos en un ZIP.
                    var tramaZip = serializar.GenerarZip(tramaFirmado, nombreArchivo);

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

                        txtResult.Text = sb.ToString();
                        sb.Length = 0; // Limpiamos memoria del StringBuilder.
                    }
                    else
                        txtResult.Text = resultado.Item1;
                }
            }
            catch (FaultException exSer)
            {
                txtResult.Text = exSer.ToString();
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnBrowseCert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = Resources.seleccioneCertificado;
                    ofd.Filter = Resources.formatosCertificado;
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtRutaCertificado.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignatureType[] signatureCac = new SignatureType[]
            {
                    new SignatureType()
                {
                    ID = new IDType { Value= "LlamaSign" },
                    SignatoryParty = new PartyType
                    {
                        PartyIdentification = new PartyIdentificationType[]
                        {
                            new PartyIdentificationType
                            {
                                ID = new IDType
                                {
                                    schemeID = "20600695771",
                                    Value = "20600695771"
                                }
                            }
                        },
                        PartyName = new PartyNameType[]
                        {
                            new PartyNameType
                            {
                                Name = new NameType1{ Value="LLAMA.PE SA" }
                            }
                        }
                    },
                    DigitalSignatureAttachment = new AttachmentType
                    {
                        ExternalReference = new ExternalReferenceType
                        {
                            URI = new URIType { Value= "#LlamaSign" }
                        }
                    }
                }
            };


            SupplierPartyType accountingSupplierParty = new SupplierPartyType()
            {
                Party = new PartyType
                {
                    PartyLegalEntity = new PartyLegalEntityType[]
                    {
                            new PartyLegalEntityType
                            {
                                RegistrationName = new RegistrationNameType
                                {
                                    Value="LLAMA.PE SA"
                                },
                            }
                    },
                    PartyName = new PartyNameType[]
                    {
                            new PartyNameType
                            {
                                Name = new NameType1{Value="LLAMA.PE SA"}
                            }
                    },
                    PostalAddress = new AddressType
                    {
                        ID = new IDType { Value = "0001" },
                        District = new DistrictType { Value = "a" },
                        CityName = new CityNameType { Value = "a" },
                        StreetName = new StreetNameType { Value = "" },
                        CitySubdivisionName = new CitySubdivisionNameType { Value = "" },
                        Country = new CountryType
                        {
                            IdentificationCode = new IdentificationCodeType { Value = "aaa" }
                        },
                        CountrySubentity = new CountrySubentityType { Value = "" },

                    }
                },
                AdditionalAccountID = new AdditionalAccountIDType[]
                {
                        new AdditionalAccountIDType{ Value="20553510661"}
                },
                CustomerAssignedAccountID = new CustomerAssignedAccountIDType { Value = "20553510661" }
            };

            CustomerPartyType accountingCustomerParty = new CustomerPartyType()
            {
                Party = new PartyType
                {
                    PartyLegalEntity = new PartyLegalEntityType[]
                    {
                            new PartyLegalEntityType
                            {
                                RegistrationName = new RegistrationNameType
                                {
                                    Value="TU CLIENTE SAC",
                                }
                            }
                    },
                    PartyName = new PartyNameType[]
                    {
                            new PartyNameType
                            {
                                Name = new NameType1{Value="LLAMA.PE S.A."}
                            }
                    },
                    PostalAddress = new AddressType
                    {
                        ID = new IDType { Value = "0001" },
                        District = new DistrictType { Value = "a" },
                        CityName = new CityNameType { Value = "a" },
                        StreetName = new StreetNameType { Value = "" },
                        CitySubdivisionName = new CitySubdivisionNameType { Value = "" },
                        Country = new CountryType
                        {
                            IdentificationCode = new IdentificationCodeType { Value = "aaa" }
                        },
                        CountrySubentity = new CountrySubentityType { Value = "" },

                    }
                },
                AdditionalAccountID = new AdditionalAccountIDType[]
                {
                        new AdditionalAccountIDType{ Value="20000000001"}
                },
                CustomerAssignedAccountID = new CustomerAssignedAccountIDType { Value = "20000000001" }
            };
            //AccountingCustomerParty 
            List<TaxTotalType> taxTotal = new List<TaxTotalType>()
                {
                    new TaxTotalType()
                    {
                        TaxAmount = new TaxAmountType{currencyID="PEN",Value=Convert.ToDecimal(7891.2)},
                        TaxSubtotal = new TaxSubtotalType[]
                        {
                            new TaxSubtotalType
                            {
                                TaxAmount = new TaxAmountType{currencyID="PEN",Value=Convert.ToDecimal(7891.2)},
                                TaxableAmount= new TaxableAmountType{Value=Convert.ToDecimal(43840.00)},
                                TaxCategory = new TaxCategoryType
                                {
                                    ID= new IDType{ Value="S" },
                                    TierRange= new TierRangeType{ Value="s" },
                                    TaxExemptionReasonCode= new TaxExemptionReasonCodeType
                                    {
                                        Value=""
                                    },
                                    TaxScheme = new TaxSchemeType
                                    {
                                        ID= new IDType{ Value="1000" },
                                        Name= new NameType1{ Value="IGV" },
                                        TaxTypeCode= new TaxTypeCodeType{ Value="VAT" }
                                    }
                                },
                                Percent=  new PercentType1{ Value=18 }
                        }
                    },

                }
                };
            MonetaryTotalType legalMonetaryTotal = new MonetaryTotalType()
            {
                PayableAmount = new PayableAmountType { currencyID = "PEN", Value = 15485 },
                AllowanceTotalAmount = new AllowanceTotalAmountType { currencyID = "PEN", Value = 15424 },
                ChargeTotalAmount = new ChargeTotalAmountType { currencyID = "PEN", Value = 5555 }
            };
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement xmlElement = xmlDoc.CreateElement("AdditionalInformation", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1");
            UBLExtensionType[] uBLExtensions = new UBLExtensionType[]
            {
                    new UBLExtensionType
                    {
                        ExtensionContent = xmlElement
                    },
                    new UBLExtensionType()
                    {
                        ExtensionContent = xmlElement
                    },
                //Extension1 = new UBLExtension { ExtensionContent = new ExtensionContent { AdditionalInformation = new AdditionalInformation { AdditionalMonetaryTotals = new List<AdditionalMonetaryTotal>(), SunatTransaction = new SunatTransaction(), AdditionalProperties = new List<AdditionalProperty>() } } },
                //Extension2 = new UBLExtension { ExtensionContent = new ExtensionContent { AdditionalInformation = new AdditionalInformation { AdditionalMonetaryTotals = new List<AdditionalMonetaryTotal>(), SunatTransaction = new SunatTransaction(), AdditionalProperties = new List<AdditionalProperty>() } } },
            };

            Invoice invoice = new Invoice()
            {
                UBLExtensions = uBLExtensions,
                UBLVersionID = new UBLVersionIDType
                {
                    Value = "2.1"
                },
                ID = new IDType
                {
                    Value = "F001-1"
                },
                CustomizationID = new CustomizationIDType
                {
                    Value = "2.0"
                },
                IssueDate = new IssueDateType
                {
                    Value = Convert.ToDateTime("2017-05-14 15:42:20")
                },
                IssueTime = new IssueTimeType
                {
                    Value = Convert.ToDateTime("2017-05-14 15:42:20"),
                },
                DueDate = new DueDateType
                {
                    Value = Convert.ToDateTime("2017-05-15 15:42:20"),
                },
                InvoiceTypeCode = new InvoiceTypeCodeType
                {
                    Value = "01"
                },
                Note = new List<NoteType>
                    {
                        new NoteType { Value = "SETENTA Y UN MIL TRESCIENTOS CINCUENTICUATRO Y 99/100" }
                    }.ToArray(),
                DocumentCurrencyCode = new DocumentCurrencyCodeType
                {
                    Value = "PEN"
                },
                LineCountNumeric = new LineCountNumericType
                {
                    Value = 1
                },
                Signature = signatureCac,
                AccountingSupplierParty = accountingSupplierParty,
                AccountingCustomerParty = accountingCustomerParty,
                TaxTotal = taxTotal.ToArray(),
                LegalMonetaryTotal = legalMonetaryTotal,
                ProfileID = new ProfileIDType
                {
                    Value = "0101"
                },
                OrderReference = new OrderReferenceType
                {
                    ID = new IDType
                    {
                        Value = ""
                    }
                }
            };

            //XmlSerializer serializer = new XmlSerializer(typeof(Invoice));
            //FileStream fStream = File.Open(@"D:\XML.xml", FileMode.Create);

            //XmlWriter xmlWriter = new XmlTextWriter(fStream, Encoding.Unicode);

            //serializer.Serialize(xmlWriter, invoice);

            //fStream.Close();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Invoice));

            using (Stream stream = new FileStream(@"D:\XML.xml", FileMode.Create))

            using (XmlWriter xmlWriter = new XmlTextWriter(stream, Encoding.Unicode))
            {
                xmlSerializer.Serialize(xmlWriter, invoice);
            }
        }
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }
        }
        static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
        }
    }
}