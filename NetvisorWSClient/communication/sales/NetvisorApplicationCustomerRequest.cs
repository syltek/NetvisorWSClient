using Microsoft.VisualBasic;
using System.Xml;
using System.Text;
using System.IO;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationCustomerRequest
    {
        public const string PARAMETER_METHOD = "method";
        public const string PARAMETER_METHOD_ADD = "add";
        public const string PARAMETER_METHOD_EDIT = "edit";

        public string getCustomerAsXML(NetvisorCustomer customer)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("Customer");

                withBlock.WriteStartElement("CustomerBaseInformation");

                if (Strings.Len(customer.CustomerIdentifier) > 0)
                    withBlock.WriteElementString("InternalIdentifier", customer.CustomerIdentifier);

                if (Strings.Len(customer.OrganisationIdentifier) > 0)
                    withBlock.WriteElementString("ExternalIdentifier", customer.OrganisationIdentifier);

                if (Strings.Len(customer.Name) > 0)
                    withBlock.WriteElementString("Name", customer.Name);

                if (Strings.Len(customer.NameExtension) > 0)
                    withBlock.WriteElementString("NameExtension", customer.NameExtension);

                if (Strings.Len(customer.StreetAddress) > 0)
                    withBlock.WriteElementString("StreetAddress", customer.StreetAddress);

                if (Strings.Len(customer.AdditionalAddressLine) > 0)
                    withBlock.WriteElementString("AdditionAladdressLine", customer.AdditionalAddressLine);

                if (Strings.Len(customer.City) > 0)
                    withBlock.WriteElementString("City", customer.City);

                if (Strings.Len(customer.PostNumber) > 0)
                    withBlock.WriteElementString("PostNumber", customer.PostNumber);

                if (Strings.Len(customer.CountryISO3166Code) > 0)
                    withBlock.WriteElementString("Country", customer.CountryISO3166Code);

                if (Strings.Len(customer.customerGroupName) > 0)
                    withBlock.WriteElementString("CustomerGroupName", customer.customerGroupName);

                if (Strings.Len(customer.PhoneNumber) > 0)
                    withBlock.WriteElementString("PhoneNumber", customer.PhoneNumber);

                if (Strings.Len(customer.FaxNumber) > 0)
                    withBlock.WriteElementString("FaxNumber", customer.FaxNumber);

                if (Strings.Len(customer.Email) > 0)
                    withBlock.WriteElementString("Email", customer.Email);

                if (Strings.Len(customer.HomePageUri) > 0)
                    withBlock.WriteElementString("HomePageUri", customer.HomePageUri);

                int active = 1;

                if (!(customer.isActive == null))
                {
                    if (System.Convert.ToBoolean(customer.isActive))
                        active = 1;
                    else
                        active = 0;
                }

                withBlock.WriteElementString("IsActive", active);

                if (customer.IsPrivateCustomer.HasValue)
                    withBlock.WriteElementString("IsPrivateCustomer", customer.IsPrivateCustomer ? 1 : 0);

                if (Strings.Len(customer.EmailInvoicingAddress) > 0)
                    withBlock.WriteElementString("EmailInvoicingAddress", customer.EmailInvoicingAddress);


                withBlock.WriteEndElement();

                withBlock.WriteStartElement("CustomerFinvoiceDetails");

                if (Strings.Len(customer.FinvoiceAddress) > 0)
                    withBlock.WriteElementString("FinvoiceAddress", customer.FinvoiceAddress);

                if (Strings.Len(customer.FinvoiceRouter) > 0)
                    withBlock.WriteElementString("FinvoiceRouterCode", customer.FinvoiceRouter);

                withBlock.WriteEndElement();

                withBlock.WriteStartElement("CustomerDeliveryDetails");

                if (Strings.Len(customer.DeliveryName) > 0)
                    withBlock.WriteElementString("DeliveryName", customer.DeliveryName);

                if (Strings.Len(customer.DeliveryStreetAddress) > 0)
                    withBlock.WriteElementString("DeliveryStreetAddress", customer.DeliveryStreetAddress);

                if (Strings.Len(customer.DeliveryCity) > 0)
                    withBlock.WriteElementString("DeliveryCity", customer.DeliveryCity);

                if (Strings.Len(customer.DeliveryPostNumber) > 0)
                    withBlock.WriteElementString("DeliveryPostNumber", customer.DeliveryPostNumber);

                if (Strings.Len(customer.DeliveryCountryISO3166Code) > 0)
                    withBlock.WriteElementString("DeliveryCountry", customer.DeliveryCountryISO3166Code);

                withBlock.WriteEndElement();

                withBlock.WriteStartElement("CustomerContactDetails");

                if (Strings.Len(customer.ContactName) > 0)
                    withBlock.WriteElementString("ContactName", customer.ContactName);

                if (Strings.Len(customer.ContactPerson) > 0)
                    withBlock.WriteElementString("ContactPerson", customer.ContactPerson);

                if (Strings.Len(customer.ContactPersonEmail) > 0)
                    withBlock.WriteElementString("ContactPersonEmail", customer.ContactPersonEmail);

                if (Strings.Len(customer.ContactPersonPhone) > 0)
                    withBlock.WriteElementString("ContactPersonPhone", customer.ContactPersonPhone);

                withBlock.WriteEndElement();

                withBlock.WriteStartElement("CustomerAdditionalInformation");

                if (Strings.Len(customer.Comment) > 0)
                    withBlock.WriteElementString("Comment", customer.Comment);

                if (Strings.Len(customer.invoicingLanguage) > 0)
                    withBlock.WriteElementString("InvoicingLanguage", customer.invoicingLanguage);

                if (customer.invoicePrintChannelFormat > 0)
                {
                    withBlock.WriteStartElement("InvoicePrintChannelFormat");
                    withBlock.WriteAttributeString("type", "netvisor");
                    withBlock.WriteString(customer.invoicePrintChannelFormat);
                    withBlock.WriteEndElement();
                }

                if (Strings.Len(customer.YourDefaultReference) > 0)
                    withBlock.WriteElementString("YourDefaultReference", customer.YourDefaultReference);

                if (Strings.Len(customer.DefaultTextBeforeInvoiceLines) > 0)
                    withBlock.WriteElementString("DefaultTextBeforeInvoiceLines", customer.DefaultTextBeforeInvoiceLines);

                if (Strings.Len(customer.DefaultTextAfterInvoiceLines) > 0)
                    withBlock.WriteElementString("DefaultTextAfterInvoiceLines", customer.DefaultTextAfterInvoiceLines);

                if (Strings.Len(customer.SalesPersonID) > 0)
                {
                    withBlock.WriteStartElement("DefaultSalesPerson");
                    withBlock.WriteStartElement("SalesPersonID");
                    withBlock.WriteAttributeString("type", "netvisor");
                    if (customer.SalesPersonID == "0")
                        withBlock.WriteString("");
                    else
                        withBlock.WriteString(customer.SalesPersonID);
                    withBlock.WriteEndElement();
                    withBlock.WriteEndElement();
                }

                withBlock.WriteEndElement();

                withBlock.WriteEndElement();
                withBlock.WriteEndElement();

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return streamReader.ReadToEnd();
        }
    }
}
