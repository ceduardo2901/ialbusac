﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ialbusacpr.ialbusac.Estructuras
{
    [Serializable]
    public class SummaryDocuments : IXmlSerializable
    {

        public UBLExtensions UBLExtensions { get; set; }
        public string UBLVersionID { get; set; }
        public string CustomizationID { get; set; }
        public string ID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReferenceDate { get; set; }
        public SignatureCac Signature { get; set; }
        public AccountingSupplierParty AccountingSupplierParty { get; set; }
        public List<VoidedDocumentsLine> SummaryDocumentsLines { get; set; }
        public IFormatProvider Formato { get; set; }

        public SummaryDocuments()
        {
            UBLExtensions = new UBLExtensions();
            Signature = new SignatureCac();
            AccountingSupplierParty = new AccountingSupplierParty();
            SummaryDocumentsLines = new List<VoidedDocumentsLine>();
            UBLVersionID = "2.0";
            CustomizationID = "1.0";
            Formato = new System.Globalization.CultureInfo("es-PE");
        }
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsSummaryDocuments);
            writer.WriteAttributeString("xmlns:cac", EspacioNombres.cac);
            writer.WriteAttributeString("xmlns:cbc", EspacioNombres.cbc);
            writer.WriteAttributeString("xmlns:ds", EspacioNombres.ds);
            writer.WriteAttributeString("xmlns:ext", EspacioNombres.ext);
            writer.WriteAttributeString("xmlns:sac", EspacioNombres.sac);
            writer.WriteAttributeString("xmlns:xsi", EspacioNombres.xsi);

            #region UBLExtensions
            {
                writer.WriteStartElement("ext:UBLExtensions");

                #region UBLExtension
                {
                    writer.WriteStartElement("ext:UBLExtension");
                    #region ExtensionContent
                    {
                        writer.WriteStartElement("ext:ExtensionContent");

                        // En esta zona va el certificado digital.

                        writer.WriteEndElement();

                    }
                    #endregion
                    writer.WriteEndElement();
                }
                #endregion

                writer.WriteEndElement();
            }
            #endregion

            writer.WriteElementString("cbc:UBLVersionID", UBLVersionID);
            writer.WriteElementString("cbc:CustomizationID", CustomizationID);
            writer.WriteElementString("cbc:ID", ID);
            writer.WriteElementString("cbc:ReferenceDate", ReferenceDate.ToString("yyyy-MM-dd"));
            writer.WriteElementString("cbc:IssueDate", IssueDate.ToString("yyyy-MM-dd"));

            #region Signature
            writer.WriteStartElement("cac:Signature");
            writer.WriteElementString("cbc:ID", Signature.ID);

            #region SignatoryParty

            writer.WriteStartElement("cac:SignatoryParty");

            writer.WriteStartElement("cac:PartyIdentification");
            writer.WriteElementString("cbc:ID", Signature.SignatoryParty.PartyIdentification.ID.value);
            writer.WriteEndElement();

            #region PartyName
            writer.WriteStartElement("cac:PartyName");

            //writer.WriteStartElement("cbc:Name");
            //writer.WriteCData(Signature.SignatoryParty.PartyName.Name);
            //writer.WriteEndElement();
            writer.WriteElementString("cbc:Name", Signature.SignatoryParty.PartyName.Name);

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region DigitalSignatureAttachment
            writer.WriteStartElement("cac:DigitalSignatureAttachment");

            writer.WriteStartElement("cac:ExternalReference");
            writer.WriteElementString("cbc:URI", Signature.DigitalSignatureAttachment.ExternalReference.URI.Trim());
            writer.WriteEndElement();

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region AccountingSupplierParty
            writer.WriteStartElement("cac:AccountingSupplierParty");

            writer.WriteElementString("cbc:CustomerAssignedAccountID", AccountingSupplierParty.CustomerAssignedAccountID);
            writer.WriteElementString("cbc:AdditionalAccountID",
                AccountingSupplierParty.AdditionalAccountID.ToString());

            #region Party
            writer.WriteStartElement("cac:Party");

            #region PartyLegalEntity
            writer.WriteStartElement("cac:PartyLegalEntity");

            {
                writer.WriteElementString("cbc:RegistrationName",
                            AccountingSupplierParty.Party.PartyLegalEntity.RegistrationName);
            }

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region SummaryDocumentsLines
            foreach (var item in SummaryDocumentsLines)
            {
                writer.WriteStartElement("sac:SummaryDocumentsLine");
                {
                    writer.WriteElementString("cbc:LineID", item.LineID.ToString());
                    writer.WriteElementString("cbc:DocumentTypeCode", item.DocumentTypeCode);
                    writer.WriteElementString("sac:DocumentSerialID", item.DocumentSerialID);
                    writer.WriteElementString("sac:StartDocumentNumberID", item.StartDocumentNumberID.ToString());
                    writer.WriteElementString("sac:EndDocumentNumberID", item.EndDocumentNumberID.ToString());
                    writer.WriteStartElement("sac:TotalAmount");
                    {
                        writer.WriteAttributeString("currencyID", item.TotalAmount.currencyID);
                        writer.WriteValue(item.TotalAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                    }
                    writer.WriteEndElement();


                    foreach (var billing in item.BillingPayments)
                    {
                        writer.WriteStartElement("sac:BillingPayment");
                        {

                            writer.WriteStartElement("cbc:PaidAmount");
                            {
                                writer.WriteAttributeString("currencyID", item.TotalAmount.currencyID);
                                writer.WriteValue(billing.PaidAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("cbc:InstructionID", billing.InstructionId);
                        }
                        writer.WriteEndElement();
                    }


                    writer.WriteStartElement("cac:AllowanceCharge");
                    {
                        writer.WriteElementString("cbc:ChargeIndicator", item.AllowanceCharge.ChargeIndicator.ToString().ToLower());

                        writer.WriteStartElement("cbc:Amount");
                        {
                            writer.WriteAttributeString("currencyID", item.AllowanceCharge.Amount.currencyID);
                            writer.WriteValue(item.AllowanceCharge.Amount.value.ToString  (Constantes.Constantes.FormatoNumerico).ToLower());
                                     }
                        writer.WriteEndElement();  
                    }
                    writer.WriteEndElement();

                    foreach (var taxTotal in item.TaxTotals)
                    {
                        writer.WriteStartElement("cac:TaxTotal");

                        writer.WriteStartElement("cbc:TaxAmount");
                        writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.currencyID);
                        writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                        writer.WriteEndElement();

                        #region TaxSubtotal
                        {
                            writer.WriteStartElement("cac:TaxSubtotal");

                            writer.WriteStartElement("cbc:TaxAmount");
                            writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.currencyID);
                            writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                            writer.WriteEndElement();

                            #region TaxCategory

                            {
                                writer.WriteStartElement("cac:TaxCategory");

                                #region TaxScheme
                                {
                                    writer.WriteStartElement("cac:TaxScheme");

                                    writer.WriteElementString("cbc:ID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.ID);
                                    writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                                    writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);

                                    writer.WriteEndElement();
                                }
                                #endregion

                                writer.WriteEndElement();
                            }
                            #endregion

                            writer.WriteEndElement();
                        }
                        #endregion

                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
            }
            #endregion
        }
    }
}
