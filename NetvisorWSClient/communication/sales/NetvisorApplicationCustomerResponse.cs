using Microsoft.VisualBasic;
using System.Xml;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationCustomerResponse : NetvisorApplicationResponse
    {
        private const string CUSTOMER_BASE_INFORMATION_PATH = "/Root/Customer/CustomerBaseInformation/";
        private const string CUSTOMER_FINVOICEDETAILS_PATH = "/Root/Customer/CustomerFinvoiceDetails/";
        private const string CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH = "/Root/Customer/CustomerDeliveryDetails/";
        private const string CUSTOMER_CUSTOMERCONTACTDETAILS_PATH = "/Root/Customer/CustomerContactDetails/";
        private const string CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH = "/Root/Customer/CustomerAdditionalInformation/";

        public const string PARAMETER_ID = "id";

        public NetvisorApplicationCustomerResponse(string responseData) : base(responseData)
        {
        }

        public NetvisorCustomer getCustomer()
        {
            NetvisorCustomer customer = new NetvisorCustomer();
            XmlDocument customerDocument = new XmlDocument();
            customerDocument.LoadXml(base.responseData);

            {
                var withBlock = customer;
                withBlock.CustomerIdentifier = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "InternalIdentifier").InnerText;

                if (Strings.Len(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "ExternalIdentifier").InnerText) > 0)
                    withBlock.OrganisationIdentifier = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "ExternalIdentifier").InnerText;

                if (!Information.IsNothing(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "CustomerGroupNetvisorKey")) && Strings.Len(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "CustomerGroupNetvisorKey").InnerText) > 0)
                {
                    withBlock.customerGroupNetvisorKey = System.Convert.ToInt32(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "CustomerGroupNetvisorKey").InnerText);
                    withBlock.customerGroupName = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "CustomerGroupName").InnerText;
                }

                withBlock.Name = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "Name").InnerText;
                withBlock.NameExtension = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "NameExtension").InnerText;
                withBlock.StreetAddress = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "StreetAddress").InnerText;
                withBlock.AdditionalAddressLine = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "AdditionAladdressLine").InnerText;
                withBlock.City = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "City").InnerText;
                withBlock.PostNumber = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "PostNumber").InnerText;

                if (!Information.IsNothing(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "Country")))
                    withBlock.CountryISO3166Code = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "Country").InnerText;

                withBlock.PhoneNumber = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "PhoneNumber").InnerText;
                withBlock.FaxNumber = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "FaxNumber").InnerText;
                withBlock.Email = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "Email").InnerText;
                withBlock.HomePageUri = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "HomePageUri").InnerText;

                if (!Information.IsNothing(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "IsActive")))
                    withBlock.isActive = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH + "IsActive").InnerText;

                withBlock.FinvoiceAddress = customerDocument.SelectSingleNode(CUSTOMER_FINVOICEDETAILS_PATH + "FinvoiceAddress").InnerText;
                withBlock.FinvoiceRouter = customerDocument.SelectSingleNode(CUSTOMER_FINVOICEDETAILS_PATH + "FinvoiceRouterCode").InnerText;

                withBlock.DeliveryName = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH + "DeliveryName").InnerText;
                withBlock.DeliveryStreetAddress = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH + "DeliveryStreetAddress").InnerText;
                withBlock.DeliveryCity = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH + "DeliveryCity").InnerText;
                withBlock.DeliveryPostNumber = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH + "DeliveryPostNumber").InnerText;
                if (!Information.IsNothing(customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH + "DeliveryCountry")))
                    withBlock.DeliveryCountryISO3166Code = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH + "DeliveryCountry").InnerText;

                withBlock.ContactPerson = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERCONTACTDETAILS_PATH + "ContactPerson").InnerText;
                withBlock.ContactPersonEmail = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERCONTACTDETAILS_PATH + "ContactPersonEmail").InnerText;
                withBlock.ContactPersonPhone = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERCONTACTDETAILS_PATH + "ContactPersonPhone").InnerText;

                withBlock.Comment = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH + "Comment").InnerText;
                withBlock.YourDefaultReference = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH + "YourDefaultReference").InnerText;
                withBlock.DefaultTextBeforeInvoiceLines = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH + "DefaultTextBeforeInvoiceLines").InnerText;
                withBlock.DefaultTextAfterInvoiceLines = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH + "DefaultTextAfterInvoiceLines").InnerText;

                if (!Information.IsNothing(customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH + "DefaultSalesPerson")))
                    withBlock.DefaultSalesPerson = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH + "DefaultSalesPerson").InnerText;

                if (Strings.Len(customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH + "BalanceLimit").InnerText) > 0)
                    withBlock.balanceLimit = System.Convert.ToDecimal(customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH + "BalanceLimit").InnerText);
            }

            return customer;
        }
    }
}
