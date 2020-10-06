
namespace FacturacionElectronica.Clases.FactElec
{
    using FacturacionElectronica.Constantes.FactElec;
    using FacturacionElectronica.Models;
    using FacturacionElectronica.Models.FactElect;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class FactElectronica
    {
        public InvoiceType GeneraFacturaBoletaEjemploXML()
        {
            string numeroFactura = "F001-00000001";
            InvoiceType Fa_Bo_XML = new InvoiceType
            {
                //------Namespace necesarios para el UBL
                Cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
                Cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
                Ccts = "urn:un:unece:uncefact:documentation:2",
                Ds = "http://www.w3.org/2000/09/xmldsig#",
                Ext = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2",
                Qdt = "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2",
                Udt = "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2",
                //------
                //-----Datos de pruebas de facturas
                UBLVersionID = new UBLVersionIDType
                {
                    Value = "2.1"
                }
            };
            Fa_Bo_XML.CustomizationID = new CustomizationIDType
            {
                schemeAgencyName = "PE:SUNAT",
                Value = "2.0"
            };
            Fa_Bo_XML.ProfileID = new ProfileIDType
            {
                schemeAgencyName = "PE:SUNAT",
                schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo51",
                schemeName = "Tipo de Operacion",
                Value = "0101"
            };
            Fa_Bo_XML.ID = new IDType
            {
                Value = numeroFactura
            };
            Fa_Bo_XML.IssueDate = new IssueDateType
            {
                Value = Convert.ToDateTime("2020-01-01")
            };
            Fa_Bo_XML.IssueTime = new IssueTimeType
            {
                Value = Convert.ToDateTime("00:00:00")
            };
            Fa_Bo_XML.InvoiceTypeCode = new InvoiceTypeCodeType()
            {
                Value = "01",
                listAgencyName = ConstantesAtributo.PESUNAT,
                listName = "Tipo de Documento",
                listURI = ConstantesAtributo.CATALOGO01
            };
            Fa_Bo_XML.DocumentCurrencyCode = new DocumentCurrencyCodeType
            {
                Value = ConstantesAtributo.PEN,
                listID = "ISO 4217 Alpha",
                listName = "Currency",
                listAgencyName = "United Nations Economic Commission for Europe"
            };
            Fa_Bo_XML.DueDate = new DueDateType
            {
                Value = Convert.ToDateTime("2020-01-01")
            };
            //XmlDocument xmlDoc = new XmlDocument();
            //XmlElement xmlElement = xmlDoc.CreateElement("AdditionalInformation", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1");
            Fa_Bo_XML.UBLExtensions = new UBLExtensionType[]
            {
                new UBLExtensionType
                    {
                        ExtensionContent = new ExtensionContentType
                        {

                        }
                    },
                new UBLExtensionType
                    {
                         ExtensionContent = new ExtensionContentType
                        {

                        }
                    }
            };
            Fa_Bo_XML.AccountingSupplierParty = SupplierPartyType();
            Fa_Bo_XML.AccountingCustomerParty = CustomerPartyType();
            Fa_Bo_XML.AllowanceCharge = AllowanceChargeTypes();
            Fa_Bo_XML.TaxTotal = TaxTotalType();
            Fa_Bo_XML.LegalMonetaryTotal = MonetaryTotal();
            Fa_Bo_XML.InvoiceLine = InvoiceLine();
            //-----
            //-----Generando el archivo XML
            //XmlWriterSettings setting = new XmlWriterSettings();
            //setting.Indent = true;
            //setting.IndentChars = "\t";
            //string rutaXML = string.Format(@"{0}{1}.xml",
            //    Path.GetTempPath(),//Se creacion en la carpeta temporal
            //    numeroFactura);
            //var Eje = JsonConvert.SerializeObject(Fa_Bo_XML);
            //using (XmlWriter writer = XmlWriter.Create(rutaXML, setting))
            //{
            //    Type typeToSerialize = typeof(InvoiceType);
            //    XmlSerializer xs = new XmlSerializer(typeToSerialize);
            //    xs.Serialize(writer, Fa_Bo_XML);
            //}
            return Fa_Bo_XML;
        }

        public Response<Documentos> GeneraDocumentoElectronicoXML(InvoiceType Documento)
        {
            String RucEmisor = Documento.AccountingSupplierParty.Party.PartyIdentification[0].ID.Value;
            String TipoDocumento = Documento.InvoiceTypeCode.Value;
            String NumeroDocumento = Documento.ID.Value;

            Documento.Cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
            Documento.Cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
            Documento.Ccts = "urn:un:unece:uncefact:documentation:2";
            Documento.Ds = "http://www.w3.org/2000/09/xmldsig#";
            Documento.Ext = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2";
            Documento.Qdt = "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2";
            Documento.Udt = "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2";
            //-----Generando el archivo XML
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            setting.IndentChars = "\t";
            string rutaXML = string.Format(@"{0}{1}-{2}-{3}.xml",
                Path.GetTempPath(),//Se creacion en la carpeta temporal
                RucEmisor, TipoDocumento, NumeroDocumento);
            using (XmlWriter writer = XmlWriter.Create(rutaXML, setting))
            {
                Type typeToSerialize = typeof(InvoiceType);
                XmlSerializer xs = new XmlSerializer(typeToSerialize);
                xs.Serialize(writer, Documento);
            }
            if (File.Exists(rutaXML))
            {
                // string RutaCertificado = @"D:\FACTURACION ELECTRONICA\20509992461.pfx";
                string RutaCertificado = @"D:\FACTURACION ELECTRONICA\20602944302.pfx";
                string PassCertificado = "q7rBEixPWHGt2CkA";

                //ProcesosSunat FacBol = new ProcesosSunat();
                //FacBol.EnvioSunatDocumento(RucEmisor, TipoDocumento, NumeroDocumento, "123456789", "20509992461MODDATOS", "MODDATOS", @"D:\FACTURACION ELECTRONICA\20509992461.pfx", rutaXML);
                var serializar = new Serializador
                {
                    RutaCertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(RutaCertificado)),
                    PasswordCertificado = PassCertificado,
                    TipoDocumento = 1//rbRetenciones.Checked ? 0 : 1
                };
                var byteArray = File.ReadAllBytes(rutaXML);
                // Firmamos el XML.
                var tramaFirmado = serializar.FirmarXml(Convert.ToBase64String(byteArray));
                // Le damos un nuevo nombre al archivo
                var nombreArchivo = $"{RucEmisor}-{TipoDocumento}-{NumeroDocumento}";
                // Escribimos el archivo XML ya firmado en una nueva ubicación.
                using (var fs = File.Create($"{nombreArchivo}.xml"))
                {
                    var byteFirmado = Convert.FromBase64String(tramaFirmado[0]);
                    fs.Write(byteFirmado, 0, byteFirmado.Length);
                }

                // Ahora lo empaquetamos en un ZIP.
                var tramaZip = serializar.GenerarZip(tramaFirmado[0], nombreArchivo);
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                Response<Documentos> Respuesta = new Response<Documentos>()
                {
                    Message = "Operacion exitosa.",
                    CodResponse = "0",
                    Data = new Documentos
                    {
                        Documento = NumeroDocumento,
                        Ruc = RucEmisor,
                        Caja = "001",
                        Estado = "GENERADO",
                        TipoDocumento = TipoDocumento,
                        FechaRegistroSet = DateTime.UtcNow,
                        FechaRegistro = DateTime.Now,
                        IdTramaNavigation = new DocumentosTramas
                        {
                            Firmaxml = tramaFirmado[0],
                            Json = JsonConvert.SerializeObject(Documento, Newtonsoft.Json.Formatting.None, settings),
                            Xml = System.Text.Encoding.UTF8.GetString(byteArray),
                            Hash= tramaFirmado[1],
                            Xmlzip = tramaZip,
                            Cdr=""
                        }
                    }
                };
                return Respuesta;
            } else
            {
                Response<Documentos> Respuesta = new Response<Documentos>()
                {
                    Message = "Error no hay acceso al directorio temporal XML u no existe!",
                    CodResponse = "-1",
                    Data = new Documentos
                    {

                    }
                };
                return Respuesta;
            }
        }
        //Emisor
        #region AccountingSupplierParty
        private SupplierPartyType SupplierPartyType()
        {
            //Datos del Emisor
            SupplierPartyType accountingSupplierParty = new SupplierPartyType()
            {
                Party = new PartyType
                {
                    PartyIdentification = new PartyIdentificationType[]
                    {
                           new PartyIdentificationType
                           {
                               ID = new IDType
                               {
                                   Value ="20509992461",
                                   schemeID="6",
                                   schemeName="Documento de Identidad",
                                   schemeAgencyName = ConstantesAtributo.PESUNAT,
                                   schemeURI = ConstantesAtributo.CATALOGO06
                               }
                           }
                    },
                    PartyName = new PartyNameType[]
                    {
                            new PartyNameType
                            {
                                Name = new NameType1
                                {
                                     Value = "Nombre comercial del emisor electronico C an..1500"
                                }
                            }
                    },
                    PartyLegalEntity = new PartyLegalEntityType[]
                    {
                            new PartyLegalEntityType
                            {
                                RegistrationName = new RegistrationNameType
                                {
                                    Value = "Apellidos y nombres,denominación o razón social M an..1500"
                                },
                                RegistrationAddress = new AddressType
                                {
                                    AddressLine = new AddressLineType[]
                                    {
                                        new AddressLineType
                                        {
                                            Line = new LineType
                                            {
                                                Value="Direccion completa y detallada"
                                            }
                                        }
                                    },
                                    CitySubdivisionName = new CitySubdivisionNameType
                                    {
                                        Value = "Urbanizacion |an..25"
                                    },
                                    CityName = new CityNameType
                                    {
                                        Value="Provincia|an..30"
                                    },
                                    ID= new IDType
                                    {
                                        Value="Codigo de ubigeo |an6",
                                        schemeAgencyName = ConstantesAtributo.PEINEI,
                                        schemeName="Ubigeos"
                                    },
                                    CountrySubentity = new CountrySubentityType
                                    {
                                        Value="Departamento|an..30"
                                    },
                                    District = new DistrictType
                                    {
                                        Value ="Distrito |an..30"
                                    },
                                    Country = new CountryType
                                    {
                                        IdentificationCode = new IdentificationCodeType
                                        {
                                           Value= "Codigo de Pais |an2",
                                           listID ="ISO 3166-1",
                                           listAgencyName ="United Nations Economic Commission for Europe",
                                           listName="Country"
                                        }
                                    }
                                }
                            }
                    },

                    //PartyTaxScheme = new PartyTaxSchemeType[]
                    //{
                    //    new PartyTaxSchemeType
                    //    {
                    //        RegistrationName = new RegistrationNameType()
                    //        {
                    //            Value=EN[11].ToString()
                    //        },
                    //        CompanyID = new CompanyIDType()
                    //        {
                    //            Value = EN[17].ToString(),
                    //            schemeID=EN[17].ToString(),
                    //            schemeName="SUNAT:Identificador de Documento de Identidad",
                    //            schemeAgencyName = ConstantesAtributo.PESUNAT,
                    //            schemeURI= ConstantesAtributo.CATALOGO06
                    //        },
                    //        RegistrationAddress = new AddressType
                    //        {
                    //            AddressTypeCode = new AddressTypeCodeType()
                    //            {
                    //                Value="0000"
                    //            }
                    //        }
                    //    }
                    //},
                    //PostalAddress = new AddressType
                    //{
                    //    ID = new IDType { Value = "0001" },
                    //    District = new DistrictType { Value = EN[16].ToString() },
                    //    CityName = new CityNameType { Value = EN[14].ToString() },
                    //    StreetName = new StreetNameType { Value = "" },
                    //    CitySubdivisionName = new CitySubdivisionNameType { Value = "" },
                    //    Country = new CountryType
                    //    {
                    //        IdentificationCode = new IdentificationCodeType { Value = "" }
                    //    },
                    //    CountrySubentity = new CountrySubentityType { Value = "" },

                    //}
                },
            };
            return accountingSupplierParty;
        }
        #endregion

        #region Signature
        private SignatureType[] SignatureTypes(TramaDocumento Doc)
        {
            try
            {
                string[] EN = Doc.EN.Split('|');
                //informacion adicional a la firma
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
                                        schemeID = EN[8].ToString(),
                                        Value = EN[8].ToString()
                                    }
                                }
                            },
                            PartyName = new PartyNameType[]
                            {
                                new PartyNameType
                                {
                                    Name = new NameType1{ Value=EN[10].ToString() }
                                }
                            }
                        },
                        DigitalSignatureAttachment = new AttachmentType
                        {
                            ExternalReference = new ExternalReferenceType
                            {
                                URI = new URIType { Value= EN[8].ToString() }
                            }
                        }
                    }
                };
                return signatureCac;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        //Receptor
        #region AccountingCustomerParty
        private CustomerPartyType CustomerPartyType()
        {
            // datos del cliente
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
                                    Value="Apellidos y nombres, denominación o razón social del adquirente o usuario | an..1500",
                                },
                                RegistrationAddress = new AddressType
                                {
                                    AddressLine = new AddressLineType []
                                    {
                                        new AddressLineType
                                        {
                                            Line = new LineType
                                            {
                                                Value="Direccion completa y detallada | an..200"
                                            }
                                        }
                                    },
                                    CitySubdivisionName = new CitySubdivisionNameType
                                    {
                                        Value = "Urbanizacion | an..25"
                                    },
                                    CityName = new CityNameType
                                    {
                                        Value = "Provincia | an..30"
                                    },
                                    ID = new IDType
                                    {
                                        Value ="Codigo ubigeo | an6",
                                        schemeAgencyName = ConstantesAtributo.PEINEI,
                                        schemeName = "Ubigeos"
                                    },
                                    CountrySubentity =  new CountrySubentityType
                                    {
                                        Value = "Departamento | an..30"
                                    },
                                    District = new DistrictType
                                    {
                                        Value ="Distrito | an..30"
                                    },
                                    Country = new CountryType
                                    {
                                        IdentificationCode = new IdentificationCodeType
                                        {
                                            Value = "Codigo pais | an2",
                                            listID = ConstantesAtributo.ISO_3166_1,
                                            listAgencyName = ConstantesAtributo.UNITED_NATIONS_ECONOMIC,
                                           listName = "Country"
                                        }
                                    }
                                },
                                ShareholderParty = new ShareholderPartyType[]
                                {
                                    //new ShareholderPartyType
                                    //{
                                    //   Party = new PartyType
                                    //   {
                                    //       PartyIdentification = new PartyIdentificationType[]
                                    //       {
                                    //           new PartyIdentificationType
                                    //           {
                                    //               ID = new IDType
                                    //               {
                                    //                   Value="Tipo de Documento identidad"
                                    //               }
                                    //           }
                                    //       }
                                    //   }
                                    //}
                                }
                            }
                    },
                    PartyIdentification = new PartyIdentificationType[]
                    {
                        new PartyIdentificationType
                        {
                            ID= new IDType
                            {
                              Value=  "Número de documento |an..15",
                              schemeID ="Tipo de Documento de Identidad",
                              schemeName = "Documento de Identidad",
                              schemeAgencyName  = ConstantesAtributo.PESUNAT,
                              schemeURI= ConstantesAtributo.CATALOGO06,
                            }
                        }
                    },
                    //PartyName = new PartyNameType[]
                    //{
                    //        new PartyNameType
                    //        {
                    //            Name = new NameType1{Value=EN[19].ToString()}
                    //        }
                    //},
                    //PostalAddress = new AddressType
                    //{
                    //    ID = new IDType { Value = "0001" },
                    //    District = new DistrictType { Value = "Distrito" },
                    //    CityName = new CityNameType { Value = "Ciudad" },
                    //    StreetName = new StreetNameType { Value = "Calle 1" },
                    //    CitySubdivisionName = new CitySubdivisionNameType { Value = "" },
                    //    Country = new CountryType
                    //    {
                    //        IdentificationCode = new IdentificationCodeType { Value = "PE" }
                    //    },
                    //    CountrySubentity = new CountrySubentityType { Value = "" },

                    //}
                },
                //AdditionalAccountID = new AdditionalAccountIDType[]
                //{
                //        new AdditionalAccountIDType{ Value=EN[18].ToString()}
                //},
                //CustomerAssignedAccountID = new CustomerAssignedAccountIDType { Value = EN[18].ToString() }
            };
            return accountingCustomerParty;
        }
        #endregion

        //Descuentos o Recargos globales
        #region AllowanceCharge
        private AllowanceChargeType[] AllowanceChargeTypes()
        {
            List<AllowanceChargeType> AllowanceCharge = new List<AllowanceChargeType>
            {
                //new AllowanceChargeType()
                //{
                //   ChargeIndicator = new ChargeIndicatorType()
                //   {
                //       Value = DEDR[1].ToString() == "true" ? true : false
                //   },
                //                   AllowanceChargeReasonCode = new AllowanceChargeReasonCodeType()
                //                   {
                //                       Value = DEDR[3].ToString()
                //                   },
                //                   MultiplierFactorNumeric = new MultiplierFactorNumericType()
                //                   {
                //                       Value = Convert.ToDecimal(DEDR[4].ToString())
                //                   },
                //                   Amount = new AmountType2()
                //                   {
                //                       Value = Convert.ToDecimal(DEDR[2].ToString()),
                //                       currencyID = Moneda
                //                   },
                //                   BaseAmount = new BaseAmountType()
                //                   {
                //                       Value = Convert.ToDecimal(DEDR[5].ToString()),
                //                       currencyID = Moneda
                //                   }
                //}
            };
            return AllowanceCharge.ToArray();
        }

        #endregion

        #region TaxTotal
        private TaxTotalType[] TaxTotalType()
        {
            //Impuestos
            List<TaxTotalType> taxTotal = new List<TaxTotalType>();
            //foreach (var Impuestos in Doc.DI)
            //{
            //    string[] DI = Impuestos.Split('|');

            //}
            TaxTotalType taxTotalType = new TaxTotalType()
            {
                TaxAmount = new TaxAmountType
                {
                    currencyID = "PEN",
                    Value = Convert.ToDecimal("1000")
                },
                TaxSubtotal = new TaxSubtotalType[]
                    {
                            new TaxSubtotalType
                            {
                                TaxAmount = new TaxAmountType
                                {
                                    currencyID="PEN",
                                    Value=Convert.ToDecimal("1000")
                                },
                                TaxableAmount= new TaxableAmountType
                                {
                                    Value=Convert.ToDecimal("1000")
                                },
                                TaxCategory = new TaxCategoryType
                                {
                                    ID= new IDType
                                    {
                                        Value="S"
                                    },
                                    TierRange= new TierRangeType
                                    {
                                        Value="S"
                                    },
                                    TaxExemptionReasonCode= new TaxExemptionReasonCodeType
                                    {
                                        Value=""
                                    },
                                    TaxScheme = new TaxSchemeType
                                    {
                                        ID= new IDType
                                        {
                                            Value="Id Tributo"
                                        },
                                        Name= new NameType1
                                        {
                                            Value="Nombre de tributo"
                                        },
                                        TaxTypeCode= new TaxTypeCodeType
                                        {
                                            Value="Código internacional de tributo"
                                        }
                                    }
                                },
                                Percent=  new PercentType1{ Value=18 }
                            }
                    },

            };
            taxTotal.Add(taxTotalType);
            return taxTotal.ToArray();
        }
        #endregion

        //Valores totales del documento
        #region LegalMonetaryTotal
        private MonetaryTotalType MonetaryTotal()
        {
            MonetaryTotalType legalMonetaryTotal = new MonetaryTotalType()
            {
                //Total valor de venta 
                LineExtensionAmount = new LineExtensionAmountType
                {
                    Value = Convert.ToDecimal(100),
                    currencyID = ConstantesAtributo.PEN
                },
                //Total precio de venta (incluye impuestos)
                TaxInclusiveAmount = new TaxInclusiveAmountType
                {
                    Value = Convert.ToDecimal(99),
                    currencyID = ConstantesAtributo.PEN
                },
                //Monto total de Descuentos
                AllowanceTotalAmount = new AllowanceTotalAmountType
                {
                    Value = Convert.ToDecimal(80),
                    currencyID = ConstantesAtributo.PEN
                },
                //Otros Cargos del Comprobante
                ChargeTotalAmount = new ChargeTotalAmountType
                {
                    Value = Convert.ToDecimal(70),
                    currencyID = ConstantesAtributo.PEN
                },
                //Total de Anticipos
                PrepaidAmount = new PrepaidAmountType
                {
                    Value = 0,
                    currencyID = ConstantesAtributo.PEN
                },
                //Importe total de la venta
                PayableAmount = new PayableAmountType
                {
                    Value = Convert.ToDecimal(50),
                }

            };
            return legalMonetaryTotal;
        }
        #endregion

        //Informacion de las lineas del documento
        #region InvoiceLine
        /// <summary>
        /// Generacion de InvoiceLine
        /// </summary>
        /// <returns></returns>
        private InvoiceLineType[] InvoiceLine()
        {

            List<InvoiceLineType> Items_Respuesta = new List<InvoiceLineType>();
            //foreach (var item in ITEM_collection)
            //{

            //}
            #region InvoiceLine
            //string[] DE = item.DE.Split('|');
            //string[] DEDR = item.DEDR.Split('|');
            //List<string> DEIM_LIST = item.DEIM;
            //string[] DEDI = item.DEDI.Split('|');
            InvoiceLineType Linea = new InvoiceLineType();
            {
                //numero de orden del item
                Linea.ID = new IDType()
                {
                    Value = "Numero de Orden del Item"
                };
                //(InvoicedQuantity)cantidad de unidades del item
                Linea.InvoicedQuantity = new InvoicedQuantityType()
                {
                    Value = Convert.ToDecimal(3),
                    unitCode = "Codigo Unitario",
                    unitCodeListID = "UN/ECE rec 20",
                    unitCodeListAgencyName = "United Nations Economic Commission for Europe"
                };
                //(LineExtensionAmount)Valor de Venta del item
                Linea.LineExtensionAmount = new LineExtensionAmountType()
                {
                    Value = Convert.ToDecimal(50),
                    currencyID = ConstantesAtributo.PEN
                };

                #region PricingReference
                Linea.PricingReference = new PricingReferenceType()
                {
                    //AlternativeConditionPrice
                    AlternativeConditionPrice = new PriceType[]
                    {
                               new PriceType()
                               {
                                   //(PriceAmount) precoi de venta unitario/ valor referencial
                                   PriceAmount = new PriceAmountType()
                                   {
                                       Value=Convert.ToDecimal(50),
                                       currencyID=ConstantesAtributo.PEN
                                   },
                                   //(PriceTypeCode) codigo de tipo de precio
                                   PriceTypeCode = new PriceTypeCodeType()
                                   {
                                       Value = "Codigo de Tipo de Precio",
                                       listName = "SUNAT:Indicador de Tipo de Precio",
                                       listAgencyName = ConstantesAtributo.PESUNAT,
                                       listURI = ConstantesAtributo.CATALOGO16
                                   }
                               }
                    }
                };
                #endregion

                #region Delivery

                #endregion

                //Descuentos o Recargos de la linea
                #region AllowanceCharge
                Linea.AllowanceCharge = new AllowanceChargeType[]
                {
                            new AllowanceChargeType()
                            {
                                ChargeIndicator =  new ChargeIndicatorType()
                                {
                                    Value= true
                                },
                                AllowanceChargeReasonCode = new AllowanceChargeReasonCodeType()
                                {
                                    Value="Codigo de cargo o descuento"
                                },
                                MultiplierFactorNumeric = new MultiplierFactorNumericType()
                                {
                                    Value = Convert.ToDecimal(0.13)
                                },
                                Amount = new AmountType2()
                                {
                                    Value = Convert.ToDecimal(20),
                                    currencyID= ConstantesAtributo.PEN
                                },
                                BaseAmount = new BaseAmountType()
                                {
                                    Value = Convert.ToDecimal(30),
                                    currencyID= ConstantesAtributo.PEN
                                }
                            }
                };
                #endregion

                //Monto de tributo del item
                #region TaxTotal
                List<TaxTotalType> taxTotals = new List<TaxTotalType>();
                //foreach (var DEIM_Item in DEIM_LIST)
                //{
                //    string[] DEIM = DEIM_Item.Split('|');

                //}

                TaxTotalType taxTotalType = new TaxTotalType()

                {
                    //Monto de tributo del ítem

                    TaxAmount = new TaxAmountType()

                    {
                        Value = Convert.ToDecimal(50),
                        currencyID = ConstantesAtributo.PEN
                    },


                    TaxSubtotal = new TaxSubtotalType[]
                    {
                        new TaxSubtotalType()
                        {
                                        //Monto de la Operacion
                                        
                            TaxableAmount = new TaxableAmountType()
                                        {
                                             Value=Convert.ToDecimal(10),
                                             currencyID = ConstantesAtributo.PEN
                                        },
                                        //Monto de Tributo por Item
                                        TaxAmount = new TaxAmountType()
                                        {
                                             Value=Convert.ToDecimal(15),
                                             currencyID = ConstantesAtributo.PEN
                                        },

                                        TaxCategory =  new TaxCategoryType()
                                        {
                                            ID = new IDType()
                                            {
                                                Value="S",
                                                schemeID = ConstantesAtributo.UNECE5305,
                                                schemeAgencyID ="6"
                                            },
                                            Percent= new PercentType1
                                            {
                                                Value = Convert.ToDecimal(14)
                                            },
                                            TaxExemptionReasonCode= new TaxExemptionReasonCodeType()
                                            {
                                                Value =  "Codigo de tipo de afeectacion del igv",
                                                listAgencyName = ConstantesAtributo.PESUNAT,
                                                listName = "SUNAT:Codigo de Tipo de Afectación del IGV",
                                                listURI=ConstantesAtributo.CATALOGO07
                                            },
                                            TaxScheme = new TaxSchemeType()
                                            {
                                                ID = new IDType()
                                                {
                                                    Value= "Codigo del tributo",
                                                },
                                                Name = new NameType1()
                                                {
                                                    Value= "Nombre del tributo",
                                                },
                                                TaxTypeCode = new TaxTypeCodeType()
                                                {
                                                    Value= "Codigo Internacional del producto"
                                                }
                                            }

                                        }
                                    }
                    }
                };
                taxTotals.Add(taxTotalType);
                Linea.TaxTotal = taxTotals.ToArray();

                #endregion

                #region Item
                Linea.Item = new ItemType()
                {
                    Description = new DescriptionType[]
                    {
                                new DescriptionType()
                                {
                                    Value = "Descripcion del item"
                                }
                    },
                    SellersItemIdentification = new ItemIdentificationType()
                    {
                        ID = new IDType()
                        {
                            Value = "Codigo de producto"
                        }
                    },
                    CommodityClassification = new CommodityClassificationType[]
                    {
                                new CommodityClassificationType()
                                {
                                    ItemClassificationCode = new ItemClassificationCodeType()
                                    {
                                        Value = "Catalogo 25 sunat"
                                    }
                                }
                    }
                };
                #endregion

                #region Price
                Linea.Price = new PriceType()
                {
                    PriceAmount = new PriceAmountType()
                    {
                        Value = Convert.ToDecimal(50),
                    }
                };
                #endregion
            }
            #endregion

            Items_Respuesta.Add(Linea);
            return Items_Respuesta.ToArray();
        }

        #endregion

    }
}
