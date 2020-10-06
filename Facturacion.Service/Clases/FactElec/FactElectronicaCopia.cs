
namespace FacturacionElectronica.Clases.FactElec
{
    using FacturacionElectronica.Constantes.FactElec;
    using FacturacionElectronica.Models.FactElect;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class FactElectronicaCopia
    {
        public IFormatProvider Formato { get; set; }
        string Moneda = "PEN";

        public void GeneraFacturaBoletaXML()
        {
            string numeroFactura = "F001-0000322";
            InvoiceType facturaXML = new InvoiceType();
            //------Namespace necesarios para el UBL
            facturaXML.Cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
            facturaXML.Cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
            facturaXML.Ccts = "urn:un:unece:uncefact:documentation:2";
            facturaXML.Ds = "http://www.w3.org/2000/09/xmldsig#";
            facturaXML.Ext = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2";
            facturaXML.Qdt = "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2";
            facturaXML.Udt = "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2";
            //------
            //-----Datos de pruebas de facturas
            facturaXML.UBLVersionID = new UBLVersionIDType();
            facturaXML.UBLVersionID.Value = "2.1";

            facturaXML.CustomizationID = new CustomizationIDType();
            facturaXML.CustomizationID.schemeAgencyName = "PE:SUNAT";
            facturaXML.CustomizationID.Value = "2.0";

            facturaXML.ProfileID = new ProfileIDType();
            facturaXML.ProfileID.schemeAgencyName = "PE:SUNAT";
            facturaXML.ProfileID.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo51";
            facturaXML.ProfileID.schemeName = "Tipo de Operacion";
            facturaXML.ProfileID.Value = "0101";

            facturaXML.ID = new IDType();
            facturaXML.ID.Value = numeroFactura;

            facturaXML.IssueDate = new IssueDateType();
            facturaXML.IssueDate.Value = Convert.ToDateTime("2019-01-21");
            facturaXML.IssueTime = new IssueTimeType();
            facturaXML.IssueTime.Value = Convert.ToDateTime("00:00:00");
            //-----
            //-----Generando el archivo XML
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            setting.IndentChars = "\t";
            string rutaXML = string.Format(@"{0}{1}.xml",
                Path.GetTempPath(),//Se creacion en la carpeta temporal
                numeroFactura);
            using (XmlWriter writer = XmlWriter.Create(rutaXML, setting))
            {
                Type typeToSerialize = typeof(InvoiceType);
                XmlSerializer xs = new XmlSerializer(typeToSerialize);
                xs.Serialize(writer, facturaXML);
            }
        }
/*
        #region ValidacionesInvoice
 
        #endregion

        #region GeneracionXML
        public List<String> GeneraDocumentoXML(DocumentoElectronicoModel Doc)
        {
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
            };

            Invoice Factura_Boleta = new Invoice();
            {
                Factura_Boleta.UBLExtensions = uBLExtensions;
                Factura_Boleta.UBLVersionID = new UBLVersionIDType
                {
                    Value = "2.1"
                };
                Factura_Boleta.ID = new IDType
                {
                    Value = "F001-1"
                };
                Factura_Boleta.CustomizationID = new CustomizationIDType
                {
                    Value = "2.0"
                };
                Factura_Boleta.IssueDate = new IssueDateType
                {
                    Value = Convert.ToDateTime("2017-05-14 15:42:20")
                };
                Factura_Boleta.IssueTime = new IssueTimeType
                {
                    Value = Convert.ToDateTime("2017-05-14 15:42:20"),
                };
                Factura_Boleta.DueDate = new DueDateType
                {
                    Value = Convert.ToDateTime("2017-05-15 15:42:20"),
                };
                Factura_Boleta.InvoiceTypeCode = new InvoiceTypeCodeType
                {
                    Value = "01"
                };
                Factura_Boleta.Note = new List<NoteType>
                    {
                        new NoteType { Value = "SETENTA Y UN MIL TRESCIENTOS CINCUENTICUATRO Y 99/100" }
                    }.ToArray();
                Factura_Boleta.DocumentCurrencyCode = new DocumentCurrencyCodeType
                {
                    Value = "PEN"
                };
                Factura_Boleta.LineCountNumeric = new LineCountNumericType
                {
                    Value = 1
                };
                Factura_Boleta.ProfileID = new ProfileIDType
                {
                    Value = "0101"
                };
                Factura_Boleta.OrderReference = new OrderReferenceType
                {
                    ID = new IDType()
                    {
                        Value = "XXXXX"
                    }
                };

                Factura_Boleta.Signature = SignatureTypes(Doc.Trama);
                Factura_Boleta.AccountingSupplierParty = SupplierPartyType(Doc.Trama);
                Factura_Boleta.AccountingCustomerParty = CustomerPartyType(Doc.Trama);
                Factura_Boleta.AllowanceCharge = AllowanceChargeTypes();
                Factura_Boleta.TaxTotal = TaxTotalType(Doc.Trama);
                Factura_Boleta.LegalMonetaryTotal = MonetaryTotal(Doc.Trama);
                Factura_Boleta.InvoiceLine = InvoiceLine(Doc.Trama.ITEM);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Invoice));

            using (Stream stream = new FileStream(@"D:\11111111111-" + Doc.Caja + "-" + Doc.TipoDocumento + "-" + Doc.Documento + ".xml", FileMode.Create))
            using (XmlWriter xmlWriter = new XmlTextWriter(stream, Encoding.Unicode))
            {
                xmlSerializer.Serialize(xmlWriter, Factura_Boleta);
            }

            return new List<string>();
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

        #region AccountingSupplierParty
        private SupplierPartyType SupplierPartyType(TramaDocumento Doc)
        {
            try
            {
                string[] EN = Doc.EN.Split('|');
                //proveedor
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
                                    Value = EN[10].ToString()
                                },
                            }
                        },
                        PartyName = new PartyNameType[]
                        {
                            new PartyNameType
                            {
                                Name = new NameType1 { Value = EN[11].ToString() }
                            }
                        },
                        PartyTaxScheme = new PartyTaxSchemeType[]
                        {
                            new PartyTaxSchemeType
                            {
                                RegistrationName = new RegistrationNameType()
                                {
                                    Value=EN[11].ToString()
                                },
                                CompanyID = new CompanyIDType()
                                {
                                    Value = EN[17].ToString(),
                                    schemeID=EN[17].ToString(),
                                    schemeName="SUNAT:Identificador de Documento de Identidad",
                                    schemeAgencyName = ConstantesAtributo.PESUNAT,
                                    schemeURI= ConstantesAtributo.CATALOGO06
                                },
                                RegistrationAddress = new AddressType
                                {
                                    AddressTypeCode = new AddressTypeCodeType()
                                    {
                                        Value="0000"
                                    }
                                }
                            }
                        },
                        PostalAddress = new AddressType
                        {
                            ID = new IDType { Value = "0001" },
                            District = new DistrictType { Value = EN[16].ToString() },
                            CityName = new CityNameType { Value = EN[14].ToString() },
                            StreetName = new StreetNameType { Value = "" },
                            CitySubdivisionName = new CitySubdivisionNameType { Value = "" },
                            Country = new CountryType
                            {
                                IdentificationCode = new IdentificationCodeType { Value = "" }
                            },
                            CountrySubentity = new CountrySubentityType { Value = "" },

                        }
                    },
                    AdditionalAccountID = new AdditionalAccountIDType[]
                    {
                        new AdditionalAccountIDType{ Value=EN[8].ToString()}
                    },
                    CustomerAssignedAccountID = new CustomerAssignedAccountIDType { Value = EN[8].ToString() }
                };
                return accountingSupplierParty;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        // informacion del cliente
        #region AccountingSupplierParty
        private CustomerPartyType CustomerPartyType(TramaDocumento Doc)
        {
            try
            {
                string[] EN = Doc.EN.Split('|');
                //cliente
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
                                    Value=EN[19].ToString(),
                                }
                            }
                        },
                        PartyName = new PartyNameType[]
                        {
                            new PartyNameType
                            {
                                Name = new NameType1{Value=EN[19].ToString()}
                            }
                        },
                        PostalAddress = new AddressType
                        {
                            ID = new IDType { Value = "0001" },
                            District = new DistrictType { Value = "Distrito" },
                            CityName = new CityNameType { Value = "Ciudad" },
                            StreetName = new StreetNameType { Value = "Calle 1" },
                            CitySubdivisionName = new CitySubdivisionNameType { Value = "" },
                            Country = new CountryType
                            {
                                IdentificationCode = new IdentificationCodeType { Value = "PE" }
                            },
                            CountrySubentity = new CountrySubentityType { Value = "" },

                        }
                    },
                    AdditionalAccountID = new AdditionalAccountIDType[]
                    {
                        new AdditionalAccountIDType{ Value=EN[18].ToString()}
                    },
                    CustomerAssignedAccountID = new CustomerAssignedAccountIDType { Value = EN[18].ToString() }
                };
                return accountingCustomerParty;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        //Descuentos o Recargos globales
        #region AllowanceCharge
        private AllowanceChargeType[] AllowanceChargeTypes()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        //
        #region TaxTotal
        private TaxTotalType[] TaxTotalType(TramaDocumento Doc)
        {
            try
            {
                //Impuestos
                List<TaxTotalType> taxTotal = new List<TaxTotalType>();
                foreach (var Impuestos in Doc.DI)
                {
                    string[] DI = Impuestos.Split('|');
                    TaxTotalType taxTotalType = new TaxTotalType()
                    {
                        TaxAmount = new TaxAmountType
                        {
                            currencyID = "PEN",
                            Value = Convert.ToDecimal(DI[1].ToString())
                        },
                        TaxSubtotal = new TaxSubtotalType[]
                        {
                            new TaxSubtotalType
                            {
                                TaxAmount = new TaxAmountType
                                {
                                    currencyID="PEN",
                                    Value=Convert.ToDecimal(DI[2].ToString())
                                },
                                TaxableAmount= new TaxableAmountType
                                {
                                    Value=Convert.ToDecimal(DI[6].ToString())
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
                                            Value=DI[3].ToString()
                                        },
                                        Name= new NameType1
                                        {
                                            Value=DI[4].ToString()
                                        },
                                        TaxTypeCode= new TaxTypeCodeType
                                        {
                                            Value=DI[5].ToString()
                                        }
                                    }
                                },
                                Percent=  new PercentType1{ Value=18 }
                            }
                        },

                    };
                    taxTotal.Add(taxTotalType);
                }
                return taxTotal.ToArray();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        //Valores totales del documento
        #region LegalMonetaryTotal
        /// <summary>
        /// Generacion de MonetaryTotal
        /// </summary>
        /// <param name="DOC"></param>
        /// <returns></returns>
        private MonetaryTotalType MonetaryTotal(TramaDocumento DOC)
        {
            string[] ENEX = DOC.ENEX.Split('|');
            string[] EN = DOC.EN.Split('|');
            try
            {
                MonetaryTotalType legalMonetaryTotal = new MonetaryTotalType()
                {
                    //Total valor de venta 
                    LineExtensionAmount = new LineExtensionAmountType
                    {
                        Value = Convert.ToDecimal(EN[21].ToString()),
                        currencyID = Moneda
                    },
                    //Total precio de venta (incluye impuestos)
                    TaxInclusiveAmount = new TaxInclusiveAmountType
                    {
                        Value = Convert.ToDecimal(ENEX[9].ToString()),
                        currencyID = Moneda
                    },
                    //Monto total de Descuentos
                    AllowanceTotalAmount = new AllowanceTotalAmountType
                    {
                        Value = Convert.ToDecimal(EN[23].ToString()),
                        currencyID = Moneda
                    },
                    //Otros Cargos del Comprobante
                    ChargeTotalAmount = new ChargeTotalAmountType
                    {
                        Value = Convert.ToDecimal(EN[24].ToString()),
                        currencyID = Moneda
                    },
                    //Total de Anticipos
                    PrepaidAmount = new PrepaidAmountType
                    {
                        Value = 0,
                        currencyID = Moneda
                    },
                    //Importe total de la venta
                    PayableAmount = new PayableAmountType
                    {
                        Value = Convert.ToDecimal(EN[25].ToString()),
                    }

                };
                return legalMonetaryTotal;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        //Informacion de las lineas del documento
        #region InvoiceLine
        /// <summary>
        /// Generacion de InvoiceLine
        /// </summary>
        /// <returns></returns>
        private InvoiceLineType[] InvoiceLine(List<Item> ITEM_collection)
        {
            Moneda = "PEN";
            //string PESUNAT = "PE:SUNAT";
            List<InvoiceLineType> Items_Respuesta = new List<InvoiceLineType>(); ;
            foreach (var item in ITEM_collection)
            {
                #region InvoiceLine
                string[] DE = item.DE.Split('|');
                string[] DEDR = item.DEDR.Split('|');
                List<string> DEIM_LIST = item.DEIM;//.Split('|');
                string[] DEDI = item.DEDI.Split('|');
                InvoiceLineType Linea = new InvoiceLineType();
                {
                    //numero de orden del item
                    Linea.ID = new IDType()
                    {
                        Value = DE[1].ToString()
                    };
                    //(InvoicedQuantity)cantidad de unidades del item
                    Linea.InvoicedQuantity = new InvoicedQuantityType()
                    {
                        Value = Convert.ToDecimal(DE[4].ToString()),
                        unitCode = DE[3].ToString(),
                        unitCodeListID = "UN/ECE rec 20",
                        unitCodeListAgencyName = "United Nations Economic Commission for Europe"
                    };
                    //(LineExtensionAmount)Valor de Venta del item
                    Linea.LineExtensionAmount = new LineExtensionAmountType()
                    {
                        Value = Convert.ToDecimal(DE[5].ToString()),
                        currencyID = Moneda
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
                                       Value=Convert.ToDecimal(DE[2].ToString()),
                                       currencyID=Moneda
                                   },
                                   //(PriceTypeCode) codigo de tipo de precio
                                   PriceTypeCode = new PriceTypeCodeType()
                                   {
                                       Value = DE[7].ToString(),
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
                                    Value= DEDR[1].ToString() == "true"
                                },
                                AllowanceChargeReasonCode = new AllowanceChargeReasonCodeType()
                                {
                                    Value=DEDR[3].ToString()
                                },
                                MultiplierFactorNumeric = new MultiplierFactorNumericType()
                                {
                                    Value = Convert.ToDecimal(DEDR[4].ToString())
                                },
                                Amount = new AmountType2()
                                {
                                    Value = Convert.ToDecimal(DEDR[2].ToString()),
                                    currencyID= Moneda
                                },
                                BaseAmount = new BaseAmountType()
                                {
                                    Value = Convert.ToDecimal(DEDR[5].ToString()),
                                    currencyID= Moneda
                                }
                            }
                    };
                    #endregion

                    //Monto de tributo del item
                    #region TaxTotal
                    List<TaxTotalType> taxTotals = new List<TaxTotalType>();
                    foreach (var DEIM_Item in DEIM_LIST)
                    {
                        string[] DEIM = DEIM_Item.Split('|');
                        TaxTotalType taxTotalType = new TaxTotalType()
                        {
                            //Monto de tributo del ítem
                            TaxAmount = new TaxAmountType()
                            {
                                Value = Convert.ToDecimal(DEIM[1].ToString()),
                                currencyID = Moneda
                            },

                            TaxSubtotal = new TaxSubtotalType[]
                            {
                                    new TaxSubtotalType()
                                    {
                                        //Monto de la Operacion
                                        TaxableAmount = new TaxableAmountType()
                                        {
                                             Value=Convert.ToDecimal(DEIM[2].ToString()),
                                             currencyID = Moneda
                                        },
                                        //Monto de Tributo por Item
                                        TaxAmount = new TaxAmountType()
                                        {
                                             Value=Convert.ToDecimal(DEIM[3].ToString()),
                                             currencyID = Moneda
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
                                                Value = Convert.ToDecimal( DEIM[4].ToString())
                                            },
                                            TaxExemptionReasonCode= new TaxExemptionReasonCodeType()
                                            {
                                                Value =  DEIM[6].ToString(),
                                                listAgencyName = ConstantesAtributo.PESUNAT,
                                                listName = "SUNAT:Codigo de Tipo de Afectación del IGV",
                                                listURI=ConstantesAtributo.CATALOGO07
                                            },
                                            TaxScheme = new TaxSchemeType()
                                            {
                                                ID = new IDType()
                                                {
                                                    Value= DEIM[8].ToString(),

                                                },
                                                Name = new NameType1()
                                                {
                                                    Value= DEIM[9].ToString(),
                                                },
                                                TaxTypeCode = new TaxTypeCodeType()
                                                {
                                                    Value= DEIM[5].ToString()
                                                }
                                            }

                                        }
                                    }
                            }
                        };
                        taxTotals.Add(taxTotalType);
                    }
                    Linea.TaxTotal = taxTotals.ToArray();

                    #endregion

                    #region Item
                    Linea.Item = new ItemType()
                    {
                        Description = new DescriptionType[]
                        {
                                new DescriptionType()
                                {
                                    Value = DEDI[1].ToString()
                                }
                        },
                        SellersItemIdentification = new ItemIdentificationType()
                        {
                            ID = new IDType()
                            {
                                Value = DE[6].ToString()
                            }
                        },
                        CommodityClassification = new CommodityClassificationType[]
                        {
                                new CommodityClassificationType()
                                {
                                    ItemClassificationCode = new ItemClassificationCodeType()
                                    {
                                        Value = DEDI[6].ToString()
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
                            Value = Convert.ToDecimal(DE[8].ToString()),
                        }
                    };
                    #endregion
                }
                #endregion

                Items_Respuesta.Add(Linea);
            }
            return Items_Respuesta.ToArray();
        }

        #endregion
*/
    }
}
