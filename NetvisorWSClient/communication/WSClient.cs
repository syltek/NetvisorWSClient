using Microsoft.VisualBasic;
using System;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using NetvisorWSClient.util;
using System.Net.Http;
using System.Text;

namespace NetvisorWSClient.communication
{

    public class WSClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();





        public const string BASE_URL_PRODUCTION = "https://isvapi.netvisor.fi/";
        public const string BASE_URL_DEMO = "https://isvapi.netvisor.fi/";
        public const string BASE_URL_ISV = "https://isvapi.netvisor.fi/";

        public const string ACTION_CUSTOMER = "customer.nv";
        public const string ACTION_SALESINVOICE = "salesinvoice.nv";
        public const string ACTION_SALESINVOICE_LIST = "salesinvoicelist.nv";
        public const string ACTION_PURCHASEINVOICE_LIST = "purchaseinvoicelist.nv";
        public const string ACTION_ESCAN = "escan.nv";
        public const string ACTION_ACCOUNTING = "accounting.nv";
        public const string ACTION_CUSTOMER_LIST = "customerlist.nv";
        public const string ACTION_SALESPAYMENT = "salespayment.nv";
        public const string ACTION_PURCHASEINVOICE = "purchaseinvoice.nv";
        public const string ACTION_ACCOUNTING_LEDGER = "accountingledger.nv";
        public const string ACTION_PRODUCT = "product.nv";
        public const string ACTION_PRODUCT_LIST = "productlist.nv";
        public const string ACTION_GETPRODUCT = "getproduct.nv";
        public const string ACTION_PAYROLL_PAYCHECK_BATCH = "payrollpaycheckbatch.nv";
        public const string ACTION_SALESPAYMENT_LIST = "salespaymentlist.nv";
        public const string ACTION_GETSALESINVOICE = "getsalesinvoice.nv";
        public const string ACTION_GETCUSTOMER = "getcustomer.nv";
        public const string ACTION_WORKDAY = "workday.nv";
        public const string ACTION_ACCOUNTING_BUDGET = "accountingbudget.nv";
        public const string ACTION_DELETE_SALESINVOICE = "deletesalesinvoice.nv";
        public const string ACTION_OUTGOINGPAYMENT = "payment.nv";
        public const string ACTION_CRM_PROCESS = "crmprocess.nv";
        public const string ACTION_DIMENSION_LIST = "dimensionlist.nv";
        public const string ACTION_EMPLOYEE = "employee.nv";
        public const string ACTION_ACCOUNTING_BUDGET_ACCOUNT_LIST = "accountingbudgetaccountlist.nv";
        public const string ACTION_ACCOUNTING_BUDGET_ACCOUNT_BUDGET = "accountingbudgetaccountbudget.nv";
        public const string ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET = "accountingbudgetyearbudget.nv";
        public const string ACTION_ACCOUNTING_BUDGET_DIMENSION_BUDGET = "accountingbudgetdimensionbudget.nv";
        public const string ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET = "accountingbudgetdimensionyearbudget.nv";
        public const string ACTION_WEBSHOP_PRODUCT_LIST = "webshopproductlist.nv";
        public const string ACTION_WEBSHOP_PRODUCT_IMAGES = "webshopproductimages.nv";
        public const string ACTION_TRIPEXPENSE = "tripexpense.nv";
        public const string ACTION_ACCOUNTLIST = "accountlist.nv";
        public const string ACTION_ACCOUNTING_PERIODLIST = "accountingperiodlist.nv";
        public const string ACTION_PAYROLL_ADVANCE = "payrolladvance.nv";
        public const string ACTION_PAYMENT_LIST = "paymentlist.nv";
        public const string ACTION_PAYROLL_PERIOD_COLLECTOR = "payrollperiodcollector.nv";
        public const string ACTION_SALESPERSONNELLIST = "salespersonnellist.nv";
        public const string ACTION_PURHASEORDER = "purchaseorder.nv";
        public const string ACTION_PURCHASEORDER_LIST = "purchaseorderlist.nv";
        public const string ACTION_GET_PURCHASEORDER = "getpurchaseorder.nv";
        public const string ACTION_DIMENSIONITEM = "dimensionitem.nv";
        public const string ACTION_EXTERNAL_PAYMENT = "payrollexternalsalarypayment.nv";
        public const string ACTION_PAYSLIPLIST = "paysliplist.nv";
        public const string ACTION_GETPAYSLIP = "getpayslip.nv";

        public enum NetvisorWebServiceIntegrationActions : int
        {
            CUSTOMER = 1,
            SALESINVOICE = 2,
            SALESINVOICE_LIST = 3,
            PURCHASEINVOICE_LIST = 4,
            ESCAN = 6,
            ACCOUNTING = 9,
            CUSTOMER_LIST = 10,
            SALESPAYMENT = 11,
            PURCHASEINVOICE = 12,
            ACCOUNTING_LEDGER = 13,
            PRODUCT = 15,
            PRODUCT_LIST = 16,
            GETPRODUCT = 17,
            PAYROLL_PAYCHECK_BATCH = 18,
            SALESPAYMENT_LIST = 19,
            GETSALESINVOICE = 20,
            GETCUSTOMER = 21,
            WORKDAY = 22,
            ACCOUNTING_BUDGET = 23,
            DELETE_SALESINVOICE = 25,
            OUTGOINGPAYMENT = 26,
            CRM_PROCESS = 29,
            DIMENSION_LIST = 34,
            ACCOUNTING_BUDGET_ACCOUNT_LIST = 36,
            ACTION_ACCOUNTING_BUDGET_ACCOUNT_BUDGET = 37,
            ACTION_ACCOUNTING_BUDGET_DIMENSION_BUDGET = 38,
            EMPLOYEE = 39,
            ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET = 41,
            ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET = 42,
            WEBSHOP_PRODUCT_LIST = 44,
            WEBSHOP_PRODUCT_IMAGES = 45,
            TRIPEXPENSE = 46,
            ACCOUNTLIST = 47,
            ACCOUNTINGPERIODLIST = 48,
            PAYROLL_ADVANCE = 50,
            PAYMENT_LIST = 51,
            PAYROLL_PERIOD_COLLECTOR = 52,
            SALESPERSONNELLIST = 53,
            PURCHASE_ORDER = 54,
            PURCHASEORDERLIST = 55,
            GET_PURCHASEORDER = 56,
            DIMENSIONITEM = 57,
            EXTERNAL_PAYMENT = 58,
            PAYSLIPLIST = 59,
            GET_PAYSLIP = 60
        }

        public enum Environment : int
        {
            PRODUCTION = 1,
            DEMO = 2,
            ISV = 3
        }

        private CustomerSettings m_customerSettings;
        private PartnerSettings m_partnerSettings;
        private Environment m_targetEnvironment;
        private int m_localDevServerPort;
        private string m_overrideDevelHost;
        private string m_baseUrl;

        public WSClient()
        {
        }

        public void SetSettings(CustomerSettings customer, PartnerSettings partner)
        {
            m_customerSettings = customer;
            m_partnerSettings = partner;
        }

        public WSClient(CustomerSettings customer, PartnerSettings partner)
        {
            m_customerSettings = customer;
            m_partnerSettings = partner;
        }

        public WSClient(CustomerSettings customer, PartnerSettings partner, string baseUrl)
        {
            m_customerSettings = customer;
            m_partnerSettings = partner;
            m_baseUrl = baseUrl;
        }

        public int localDevServerPort
        {
            set
            {
                m_localDevServerPort = value;
            }
        }

        public Environment TargetEnvironment
        {
            get
            {
                return m_targetEnvironment;
            }
            set
            {
                m_targetEnvironment = value;
            }
        }

        public string overrideDevelHost
        {
            set
            {
                m_overrideDevelHost = value;
            }
        }

        private NameValueCollection getAuthenticationHeaders(string url, FinnishOrganisationIdentifier targetOrganisation, bool overrideTransactionID = false, string transactionID = "")
        {
            NameValueCollection headers = new NameValueCollection();
            string timestamp = DateTime.Now.ToString();
            string uniqueTransactionIdentifier = new UniqueIdentifierGenerator().identifier;
            Hash h;
            string mac;
            string MACHashCalculationAlgorithm = "SHA256";

            headers.Add("X-Netvisor-Authentication-Sender", m_partnerSettings.ClientName);
            headers.Add("X-Netvisor-Authentication-PartnerId", m_partnerSettings.PartnerIdentifier);
            headers.Add("X-Netvisor-Authentication-MACHashCalculationAlgorithm", MACHashCalculationAlgorithm);
            headers.Add("X-Netvisor-Authentication-Timestamp", timestamp);
            headers.Add("X-Netvisor-Interface-Language", m_customerSettings.CustomerLanguage);

            if (overrideTransactionID && Strings.Len(transactionID) > 0)
            {
                headers.Add("X-Netvisor-Authentication-TransactionId", transactionID);
                uniqueTransactionIdentifier = transactionID;
            }
            else
                headers.Add("X-Netvisor-Authentication-TransactionId", uniqueTransactionIdentifier);

            headers.Add("X-Netvisor-Authentication-CustomerId", m_customerSettings.CustomerIdentifier);

            string organisationID = null;
            if (!Information.IsNothing(targetOrganisation))
                organisationID = targetOrganisation.getHumanReadableFormat();

            headers.Add("X-Netvisor-Organisation-ID", organisationID);

            h = new Hash(url + "&" + m_partnerSettings.ClientName + "&" + m_customerSettings.CustomerIdentifier + "&" + timestamp + "&" + m_customerSettings.CustomerLanguage + "&" + organisationID + "&" + uniqueTransactionIdentifier + "&" + m_customerSettings.CustomerPrivateKey + "&" + m_partnerSettings.PartnerPrivateKey);

            mac = h.getHashAs32CharHexString();

            headers.Add("X-Netvisor-Authentication-MAC", mac);

            return headers;
        }

        public object SendRequest(string fullActionUrl, string postData = null, FinnishOrganisationIdentifier targetOrganisation = null)
        {
            return sendRequest_real(fullActionUrl, postData, targetOrganisation);
        }

        public object SendRequest(NetvisorWebServiceIntegrationActions action, string postData = null, FinnishOrganisationIdentifier targetOrganisation = null, NameValueCollection queryStringParameters = null, bool overrideTransactionID = false, string transactionID = "")
        {
            string fullActionUrl = getActionUrl(action, queryStringParameters);
            return sendRequest_real(fullActionUrl, postData, targetOrganisation, queryStringParameters, overrideTransactionID, transactionID);
        }

        // For those com-interop callers
        public NetvisorApplicationResponse SendSimpleRequest(string fullActionUrl, string postData, FinnishOrganisationIdentifier targetOrganisation)
        {
            NetvisorApplicationResponse response = (NetvisorApplicationResponse)sendRequest_real(fullActionUrl, postData, targetOrganisation);
            return response;
        }

        private object sendRequest_real(string fullActionUrl, string postData = null, FinnishOrganisationIdentifier targetOrganisation = null, NameValueCollection queryStringParameters = null, bool overrideTransactionID = false, string transactionID = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullActionUrl);

            if (Strings.Len(postData) > 0)
                request.Method = "POST";
            else
                request.Method = "GET";

            request.ContentType = "text/xml";

            NameValueCollection headers = getAuthenticationHeaders(fullActionUrl, targetOrganisation, overrideTransactionID, transactionID);
            foreach (string header in headers.Keys)
                request.Headers.Add(header, headers[header]);

            try
            {
                if (Strings.Len(postData) > 0)
                {
                    StreamWriter sWriter = new StreamWriter(request.GetRequestStream());
                    var bytes = Encoding.Default.GetBytes(postData);
                    sWriter.Write(Encoding.UTF8.GetString(bytes));
                    sWriter.Close();
                }
                else
                    request.ContentLength = 0;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string fulldata = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return NetvisorApplicationResponseFactory.getNetvisorApplicationResponse(fullActionUrl, fulldata);
            }
            catch (WebException ex)
            {
                throw new ApplicationException("Could not process url: " + fullActionUrl + ", error: " + ex.ToString() + ", stack: " + ex.StackTrace);
            }
        }

        public string getBaseUrl()
        {
            if ((!string.IsNullOrEmpty(m_baseUrl)))
                return m_baseUrl;
            else
                switch (m_targetEnvironment)
                {
                    case Environment.PRODUCTION:
                        {
                            return BASE_URL_PRODUCTION;
                        }

                    case Environment.DEMO:
                        {
                            return BASE_URL_DEMO;
                        }

                    case Environment.ISV:
                        {
                            return BASE_URL_ISV;
                        }

                    default:
                        {
                            throw new ApplicationException("Target environment not defined, use .targetEnvironment = Environment.PRODUCTION");
                            break;
                        }
                }
        }

        private string getActionUrl(NetvisorWebServiceIntegrationActions action, NameValueCollection queryStringParameters)
        {
            string baseUrl = this.getBaseUrl();
            string actionUrl = null;

            switch (action)
            {
                case NetvisorWebServiceIntegrationActions.CUSTOMER:
                    {
                        actionUrl = ACTION_CUSTOMER;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.SALESINVOICE:
                    {
                        actionUrl = ACTION_SALESINVOICE;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.SALESINVOICE_LIST:
                    {
                        actionUrl = ACTION_SALESINVOICE_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PURCHASEINVOICE_LIST:
                    {
                        actionUrl = ACTION_PURCHASEINVOICE_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ESCAN:
                    {
                        actionUrl = ACTION_ESCAN;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACCOUNTING:
                    {
                        actionUrl = ACTION_ACCOUNTING;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.CUSTOMER_LIST:
                    {
                        actionUrl = ACTION_CUSTOMER_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.SALESPAYMENT:
                    {
                        actionUrl = ACTION_SALESPAYMENT;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PURCHASEINVOICE:
                    {
                        actionUrl = ACTION_PURCHASEINVOICE;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACCOUNTING_LEDGER:
                    {
                        actionUrl = ACTION_ACCOUNTING_LEDGER;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PRODUCT:
                    {
                        actionUrl = ACTION_PRODUCT;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PRODUCT_LIST:
                    {
                        actionUrl = ACTION_PRODUCT_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.GETPRODUCT:
                    {
                        actionUrl = ACTION_GETPRODUCT;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PAYROLL_PAYCHECK_BATCH:
                    {
                        actionUrl = ACTION_PAYROLL_PAYCHECK_BATCH;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.SALESPAYMENT_LIST:
                    {
                        actionUrl = ACTION_SALESPAYMENT_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.GETSALESINVOICE:
                    {
                        actionUrl = ACTION_GETSALESINVOICE;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.GETCUSTOMER:
                    {
                        actionUrl = ACTION_GETCUSTOMER;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.WORKDAY:
                    {
                        actionUrl = ACTION_WORKDAY;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACCOUNTING_BUDGET:
                    {
                        actionUrl = ACTION_ACCOUNTING_BUDGET;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.DELETE_SALESINVOICE:
                    {
                        actionUrl = ACTION_DELETE_SALESINVOICE;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.OUTGOINGPAYMENT:
                    {
                        actionUrl = ACTION_OUTGOINGPAYMENT;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.CRM_PROCESS:
                    {
                        actionUrl = ACTION_CRM_PROCESS;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.DIMENSION_LIST:
                    {
                        actionUrl = ACTION_DIMENSION_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.EMPLOYEE:
                    {
                        actionUrl = ACTION_EMPLOYEE;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACCOUNTING_BUDGET_ACCOUNT_LIST:
                    {
                        actionUrl = ACTION_ACCOUNTING_BUDGET_ACCOUNT_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_ACCOUNT_BUDGET:
                    {
                        actionUrl = ACTION_ACCOUNTING_BUDGET_ACCOUNT_BUDGET;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_DIMENSION_BUDGET:
                    {
                        actionUrl = ACTION_ACCOUNTING_BUDGET_DIMENSION_BUDGET;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET:
                    {
                        actionUrl = ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET:
                    {
                        actionUrl = ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.WEBSHOP_PRODUCT_LIST:
                    {
                        actionUrl = ACTION_WEBSHOP_PRODUCT_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.WEBSHOP_PRODUCT_IMAGES:
                    {
                        actionUrl = ACTION_WEBSHOP_PRODUCT_IMAGES;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.TRIPEXPENSE:
                    {
                        actionUrl = ACTION_TRIPEXPENSE;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACCOUNTLIST:
                    {
                        actionUrl = ACTION_ACCOUNTLIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.ACCOUNTINGPERIODLIST:
                    {
                        actionUrl = ACTION_ACCOUNTING_PERIODLIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PAYROLL_ADVANCE:
                    {
                        actionUrl = ACTION_PAYROLL_ADVANCE;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PAYMENT_LIST:
                    {
                        actionUrl = ACTION_PAYMENT_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PAYROLL_PERIOD_COLLECTOR:
                    {
                        actionUrl = ACTION_PAYROLL_PERIOD_COLLECTOR;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.SALESPERSONNELLIST:
                    {
                        actionUrl = ACTION_SALESPERSONNELLIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PURCHASE_ORDER:
                    {
                        actionUrl = ACTION_PURHASEORDER;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PURCHASEORDERLIST:
                    {
                        actionUrl = ACTION_PURCHASEORDER_LIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.GET_PURCHASEORDER:
                    {
                        actionUrl = ACTION_GET_PURCHASEORDER;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.DIMENSIONITEM:
                    {
                        actionUrl = ACTION_DIMENSIONITEM;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.EXTERNAL_PAYMENT:
                    {
                        actionUrl = ACTION_EXTERNAL_PAYMENT;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.PAYSLIPLIST:
                    {
                        actionUrl = ACTION_PAYSLIPLIST;
                        break;
                    }

                case NetvisorWebServiceIntegrationActions.GET_PAYSLIP:
                    {
                        actionUrl = ACTION_GETPAYSLIP;
                        break;
                    }

                default:
                    {
                        throw new ApplicationException("Invalid Netvisor webservice integration action: " + action);
                        break;
                    }
            }

            string parameters = null;

            if (!(queryStringParameters == null))
            {
                foreach (string key in queryStringParameters.Keys)
                {
                    if (parameters == null)
                        parameters = "?";
                    else
                        parameters += "&";

                    parameters += key + "=" + queryStringParameters[key];
                }
            }

            return string.Concat(baseUrl, actionUrl, parameters);
        }
    }
}

