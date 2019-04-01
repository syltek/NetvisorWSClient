using System;
using System.Xml;
using System.Text;
using System.IO;

namespace NetvisorWSClient.communication.escan
{
    public class NetvisorApplicationEscanRequest
    {
        public string getEScanDocumentAsXML(EScanDocument document)
        {
            string mimeType;
            switch (document.DocumentMimeType)
            {
                case EScanDocument.SupportedDocumentMimeTypes.APPLICATION_PDF:
                    {
                        mimeType = "application/pdf";
                        break;
                    }

                case EScanDocument.SupportedDocumentMimeTypes.IMAGE_BMP:
                    {
                        mimeType = "image/bmp";
                        break;
                    }

                case EScanDocument.SupportedDocumentMimeTypes.IMAGE_EMF:
                    {
                        mimeType = "image/emf";
                        break;
                    }

                case EScanDocument.SupportedDocumentMimeTypes.IMAGE_EXIF:
                    {
                        mimeType = "image/exif";
                        break;
                    }

                case EScanDocument.SupportedDocumentMimeTypes.IMAGE_GIF:
                    {
                        mimeType = "image/gif";
                        break;
                    }

                case EScanDocument.SupportedDocumentMimeTypes.IMAGE_ICON:
                    {
                        mimeType = "image/icon";
                        break;
                    }

                case EScanDocument.SupportedDocumentMimeTypes.IMAGE_JPEG:
                    {
                        mimeType = "image/jpeg";
                        break;
                    }

                case EScanDocument.SupportedDocumentMimeTypes.IMAGE_PNG:
                    {
                        mimeType = "image/png";
                        break;
                    }

                case EScanDocument.SupportedDocumentMimeTypes.IMAGE_TIFF:
                    {
                        mimeType = "image/tiff";
                        break;
                    }

                case EScanDocument.SupportedDocumentMimeTypes.IMAGE_WMF:
                    {
                        mimeType = "image/wmf";
                        break;
                    }

                default:
                    {
                        throw new InvalidDataException("Unsupported Mime-type: " + document.DocumentMimeType);
                        break;
                    }
            }

            string compression;
            switch (document.Compression)
            {
                case EScanDocument.CompressionSettings.GZIP:
                    {
                        compression = "gzip";
                        break;
                    }

                case EScanDocument.CompressionSettings.NO_COMPRESSION:
                    {
                        compression = "none";
                        break;
                    }

                default:
                    {
                        throw new InvalidDataException("Unsupported compression type: " + document.Compression);
                        break;
                    }
            }

            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("EScanDocument");

                withBlock.WriteElementString("documenttype", document.DocumentType);
                withBlock.WriteElementString("description", document.Description);
                withBlock.WriteElementString("documentmimetype", mimeType);
                withBlock.WriteElementString("compression", compression);
                withBlock.WriteElementString("documentdata", Convert.ToBase64String(document.documentData));

                if (document.targets.Count > 0)
                {
                    withBlock.WriteStartElement("Targets");

                    foreach (int[] target in document.targets)
                    {
                        string escanTarget;
                        switch ((EScanDocument.EScanDocumentTargets)target[0])
                        {
                            case EScanDocument.EScanDocumentTargets.SALES_INVOICE:
                                {
                                    escanTarget = EScanDocument.TARGET_SALES_INVOICE;
                                    break;
                                }

                            case EScanDocument.EScanDocumentTargets.PURCHASE_INVOICE:
                                {
                                    escanTarget = EScanDocument.TARGET_PURCHASE_INVOICE;
                                    break;
                                }

                            case EScanDocument.EScanDocumentTargets.TRIP_EXPENSE_MONEY_TRANSFER:
                                {
                                    escanTarget = escan.EScanDocument.TARGET_TRIP_EXPENSE_MONEY_TRANSFER;
                                    break;
                                }

                            default:
                                {
                                    throw new InvalidDataException("Invalid escan-target type: " + target[0]);
                                    break;
                                }
                        }

                        withBlock.WriteStartElement("TargetLine");
                        withBlock.WriteElementString("Target", escanTarget);
                        withBlock.WriteElementString("TargetIdentifier", target[1]);
                        withBlock.WriteEndElement(); // /TargetLine
                    }

                    withBlock.WriteEndElement(); // /Targets
                }

                withBlock.WriteEndElement(); // /EScanDocument
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return streamReader.ReadToEnd();
        }
    }
}
