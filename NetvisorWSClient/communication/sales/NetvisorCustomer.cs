using Microsoft.VisualBasic;
using System;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorCustomer
    {
        private const int NAME_MAXIMUM_LENGTH = 250;
        private const int NAME_EXTENSION_MAXIMUM_LENGTH = 250;

        private const int CITY_MAXIMUM_LENGTH = 80;
        private const int STREET_ADDRESS_MAXIMUM_LENGTH = 80;

        private const int DELIVERY_CITY_MAXIMUM_LENGTH = 80;
        private const int DELIVERY_NAME_MAXIMUM_LENGTH = 250;
        private const int DELIVERY_STREET_ADDRESS_MAXIMUM_LENGTH = 80;

        private const int YOUR_DEFAULT_REFERENCE_NUMBER = 200;

        private const int DEFAULT_TEXT_AFTER_INVOICE_LINES_MAXIMUM_LENGTH = 500;
        private const int DEFAULT_TEXT_BEFORE_INVOICE_LINES_MAXIMUM_LENGTH = 500;

        private int m_netvisorKey;
        private int m_customerGroupNetvisorKey;
        private string m_customerGroupName;
        private string m_customerIdentifier;
        private string m_name;
        private string m_nameExtension;
        private string m_organisationIdentifier;
        private string m_city;
        private string m_streetAddress;
        private string m_additionalAddressLine;
        private string m_postNumber;
        private string m_countryISO3166Code;
        private string m_phoneNumber;
        private string m_faxNumber;
        private string m_email;
        private string m_homePageUri;
        private string m_finvoiceAddress;
        private string m_finvoiceRouter;
        private string m_deliveryName;
        private string m_deliveryStreetAddress;
        private string m_deliveryCity;
        private string m_deliveryPostNumber;
        private string m_deliveryCountryISO3166Code;
        private string m_contactName;
        private string m_contactPerson;
        private string m_contactPersonEmail;
        private string m_contactPersonPhone;
        private string m_comment;
        private decimal m_balanceLimit;
        private string m_invoicingLanguage;
        private int m_invoicePrintChannelFormat;
        private object m_isActive;
        private string m_DefaultSalesPerson;
        private string m_SalesPersonID;
        private bool? m_isPrivateCustomer;
        private string m_emailInvoicingAddress;
        private string m_yourDefaultReference;
        private string m_defaultTextBeforeInvoiceLines;
        private string m_defaultTextAfterInvoiceLines;

        public int netvisorKey
        {
            get
            {
                return m_netvisorKey;
            }
            set
            {
                m_netvisorKey = value;
            }
        }

        public int customerGroupNetvisorKey
        {
            get
            {
                return m_customerGroupNetvisorKey;
            }
            set
            {
                m_customerGroupNetvisorKey = value;
            }
        }

        public string customerGroupName
        {
            get
            {
                return m_customerGroupName;
            }
            set
            {
                m_customerGroupName = value;
            }
        }

        public string CustomerIdentifier
        {
            get
            {
                return m_customerIdentifier;
            }
            set
            {
                m_customerIdentifier = value;
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                if (Strings.Len(value) > NAME_MAXIMUM_LENGTH)
                    throw new ApplicationException("Customername too long");
                else
                    m_name = value;
            }
        }

        public string NameExtension
        {
            get
            {
                return m_nameExtension;
            }
            set
            {
                if (Strings.Len(value) > NAME_EXTENSION_MAXIMUM_LENGTH)
                    throw new ApplicationException("Customername extension too long");
                else
                    m_nameExtension = value;
            }
        }

        public string OrganisationIdentifier
        {
            get
            {
                return m_organisationIdentifier;
            }
            set
            {
                m_organisationIdentifier = value;
            }
        }


        public string City
        {
            get
            {
                return m_city;
            }
            set
            {
                if (Strings.Len(value) > CITY_MAXIMUM_LENGTH)
                    throw new ApplicationException("City too long");
                else
                    m_city = value;
            }
        }

        public string StreetAddress
        {
            get
            {
                return m_streetAddress;
            }
            set
            {
                if (Strings.Len(value) > STREET_ADDRESS_MAXIMUM_LENGTH)
                    throw new ApplicationException("Streetaddress too long");
                else
                    m_streetAddress = value;
            }
        }

        public string AdditionalAddressLine
        {
            get
            {
                return m_additionalAddressLine;
            }
            set
            {
                if (Strings.Len(value) > 80)
                    throw new ApplicationException("AdditionalAddressLine too long");
                else
                    m_additionalAddressLine = value;
            }
        }

        public string PostNumber
        {
            get
            {
                return m_postNumber;
            }
            set
            {
                m_postNumber = value;
            }
        }

        public string CountryISO3166Code
        {
            get
            {
                return m_countryISO3166Code;
            }
            set
            {
                m_countryISO3166Code = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_phoneNumber;
            }
            set
            {
                m_phoneNumber = value;
            }
        }

        public string FaxNumber
        {
            get
            {
                return m_faxNumber;
            }
            set
            {
                m_faxNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return m_email;
            }
            set
            {
                m_email = value;
            }
        }

        public string HomePageUri
        {
            get
            {
                return m_homePageUri;
            }
            set
            {
                m_homePageUri = value;
            }
        }

        public string FinvoiceAddress
        {
            get
            {
                return m_finvoiceAddress;
            }
            set
            {
                m_finvoiceAddress = value;
            }
        }

        public string FinvoiceRouter
        {
            get
            {
                return m_finvoiceRouter;
            }
            set
            {
                m_finvoiceRouter = value;
            }
        }

        public string DeliveryName
        {
            get
            {
                return m_deliveryName;
            }
            set
            {
                if (Strings.Len(value) > DELIVERY_NAME_MAXIMUM_LENGTH)
                    throw new ApplicationException("Deliveryname too long");
                else
                    m_deliveryName = value;
            }
        }

        public string DeliveryStreetAddress
        {
            get
            {
                return m_deliveryStreetAddress;
            }
            set
            {
                if (Strings.Len(value) > DELIVERY_STREET_ADDRESS_MAXIMUM_LENGTH)
                    throw new ApplicationException("Delivery streetaddress too long");
                else
                    m_deliveryStreetAddress = value;
            }
        }

        public string DeliveryCity
        {
            get
            {
                return m_deliveryCity;
            }
            set
            {
                if (Strings.Len(value) > DELIVERY_CITY_MAXIMUM_LENGTH)
                    throw new ApplicationException("Deliverycity too long");
                else
                    m_deliveryCity = value;
            }
        }

        public string DeliveryPostNumber
        {
            get
            {
                return m_deliveryPostNumber;
            }
            set
            {
                m_deliveryPostNumber = value;
            }
        }

        public string DeliveryCountryISO3166Code
        {
            get
            {
                return m_deliveryCountryISO3166Code;
            }
            set
            {
                m_deliveryCountryISO3166Code = value;
            }
        }

        public string ContactName
        {
            get
            {
                return m_contactName;
            }
            set
            {
                m_contactName = value;
            }
        }

        public string ContactPerson
        {
            get
            {
                return m_contactPerson;
            }
            set
            {
                m_contactPerson = value;
            }
        }

        public string ContactPersonEmail
        {
            get
            {
                return m_contactPersonEmail;
            }
            set
            {
                m_contactPersonEmail = value;
            }
        }

        public string ContactPersonPhone
        {
            get
            {
                return m_contactPersonPhone;
            }
            set
            {
                m_contactPersonPhone = value;
            }
        }

        public string Comment
        {
            get
            {
                return m_comment;
            }
            set
            {
                m_comment = value;
            }
        }

        public decimal balanceLimit
        {
            get
            {
                return m_balanceLimit;
            }
            set
            {
                m_balanceLimit = value;
            }
        }

        public string invoicingLanguage
        {
            get
            {
                return m_invoicingLanguage;
            }
            set
            {
                m_invoicingLanguage = value;
            }
        }

        public int invoicePrintChannelFormat
        {
            get
            {
                return m_invoicePrintChannelFormat;
            }
            set
            {
                m_invoicePrintChannelFormat = value;
            }
        }

        public object isActive
        {
            get
            {
                return m_isActive;
            }
            set
            {
                m_isActive = value;
            }
        }

        public string DefaultSalesPerson
        {
            get
            {
                return m_DefaultSalesPerson;
            }
            set
            {
                m_DefaultSalesPerson = value;
            }
        }

        public string SalesPersonID
        {
            set
            {
                m_SalesPersonID = value;
            }
            get
            {
                return m_SalesPersonID;
            }
        }

        public bool? IsPrivateCustomer
        {
            get
            {
                return m_isPrivateCustomer;
            }
            set
            {
                m_isPrivateCustomer = value;
            }
        }

        public string EmailInvoicingAddress
        {
            get
            {
                return m_emailInvoicingAddress;
            }
            set
            {
                m_emailInvoicingAddress = value;
            }
        }

        public string YourDefaultReference
        {
            get
            {
                return m_yourDefaultReference;
            }
            set
            {
                if (Strings.Len(value) > YOUR_DEFAULT_REFERENCE_NUMBER)
                    throw new ApplicationException("Your default reference too long");
                else
                    m_yourDefaultReference = value;
            }
        }

        public string DefaultTextBeforeInvoiceLines
        {
            get
            {
                return m_defaultTextBeforeInvoiceLines;
            }
            set
            {
                if (Strings.Len(value) > DEFAULT_TEXT_BEFORE_INVOICE_LINES_MAXIMUM_LENGTH)
                    throw new ApplicationException("Default text before invoice lines too long");
                else
                    m_defaultTextBeforeInvoiceLines = value;
            }
        }

        public string DefaultTextAfterInvoiceLines
        {
            get
            {
                return m_defaultTextAfterInvoiceLines;
            }
            set
            {
                if (Strings.Len(value) > DEFAULT_TEXT_AFTER_INVOICE_LINES_MAXIMUM_LENGTH)
                    throw new ApplicationException("Default text after invoice lines too long");
                else
                    m_defaultTextAfterInvoiceLines = value;
            }
        }
    }
}

