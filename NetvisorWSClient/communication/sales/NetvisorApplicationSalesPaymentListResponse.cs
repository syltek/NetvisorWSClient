using Microsoft.VisualBasic;
using System.Collections;
using System;
using System.Xml;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationSalesPaymentListResponse : NetvisorApplicationResponse
    {
        private const string BANK_STATUS_ERROR_NO_ACCOUNT_FOUND = "NO_ACCOUNT_FOUND";
        private const string BANK_STATUS_ERROR_NO_PAYMENT_SERVICE_ACCOUNT = "NO_PAYMENT_SERVICE_ACCOUNT";
        private const string BANK_STATUS_ERROR_IN_DUE_DATE = "ERROR_IN_DUE_DATE";
        private const string BANK_STATUS_ERROR_BALANCE_IS_EXCEEDED = "BALANCE_IS_EXCEEDED";
        private const string BANK_STATUS_ERROR_PAYER_HAS_CANCELLED = "PAYER_HAS_CANCELLED";
        private const string BANK_STATUS_ERROR_FORM_NOT_CORRECT = "FORM_NOT_CORRECT";
        private const string BANK_STATUS_ERROR_BANK_HAS_CANCELLED = "BANK_HAS_CANCELLED";
        private const string BANK_STATUS_ERROR_CANCELLATION_NOT_CLEARING = "CANCELLATION_NOT_CLEARING";
        private const string BANK_STATUS_ERROR_AUTHORIZATION_IS_MISSING = "AUTHORIZATION_IS_MISSING";

        public NetvisorApplicationSalesPaymentListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getPaymentList()
        {
            ArrayList paymentList = new ArrayList();
            XmlDocument paymentListDocument = new XmlDocument();

            paymentListDocument.LoadXml(base.responseData);

            foreach (XmlNode paymentNode in paymentListDocument.SelectNodes("/Root/SalesPaymentList/SalesPayment"))
            {
                NetvisorSalesPaymentListPayment paymentListPayment = new NetvisorSalesPaymentListPayment();

                {
                    var withBlock = paymentListPayment;
                    withBlock.netvisorKey = System.Convert.ToInt32(paymentNode.SelectSingleNode("NetvisorKey").InnerText);
                    withBlock.name = paymentNode.SelectSingleNode("Name").InnerText;
                    withBlock.paymentDate = System.Convert.ToDateTime(paymentNode.SelectSingleNode("Date").InnerText);
                    withBlock.sum = System.Convert.ToDecimal(paymentNode.SelectSingleNode("Sum").InnerText);
                    withBlock.referenceNumber = paymentNode.SelectSingleNode("ReferenceNumber").InnerText;

                    if (Strings.Len(paymentNode.SelectSingleNode("ForeignCurrencyAmount").InnerText) > 0)
                        withBlock.foreignCurrencyAmount = System.Convert.ToDecimal(paymentNode.SelectSingleNode("ForeignCurrencyAmount").InnerText);

                    withBlock.invoiceNumber = paymentNode.SelectSingleNode("InvoiceNumber").InnerText;

                    if (paymentNode.SelectSingleNode("BankStatus").InnerText == "OK")
                        withBlock.bankStatus = NetvisorSalesPaymentListPayment.bankStatuses.ok;
                    else
                    {
                        withBlock.bankStatus = NetvisorSalesPaymentListPayment.bankStatuses.failed;

                        string errorDescriptionCode = paymentNode.SelectSingleNode("BankStatusErrorDescription").Attributes["code"].InnerText;
                        switch (errorDescriptionCode)
                        {
                            case BANK_STATUS_ERROR_NO_ACCOUNT_FOUND:
                                {
                                    withBlock.returnCode = NetvisorSalesPaymentListPayment.returnCodes.noAccountFound;
                                    break;
                                }

                            case BANK_STATUS_ERROR_NO_PAYMENT_SERVICE_ACCOUNT:
                                {
                                    withBlock.returnCode = NetvisorSalesPaymentListPayment.returnCodes.noPaymentServiceAccount;
                                    break;
                                }

                            case BANK_STATUS_ERROR_IN_DUE_DATE:
                                {
                                    withBlock.returnCode = NetvisorSalesPaymentListPayment.returnCodes.errorInDueDate;
                                    break;
                                }

                            case BANK_STATUS_ERROR_BALANCE_IS_EXCEEDED:
                                {
                                    withBlock.returnCode = NetvisorSalesPaymentListPayment.returnCodes.balanceIsExceeded;
                                    break;
                                }

                            case BANK_STATUS_ERROR_PAYER_HAS_CANCELLED:
                                {
                                    withBlock.returnCode = NetvisorSalesPaymentListPayment.returnCodes.payerHasCancelled;
                                    break;
                                }

                            case BANK_STATUS_ERROR_FORM_NOT_CORRECT:
                                {
                                    withBlock.returnCode = NetvisorSalesPaymentListPayment.returnCodes.formNotCorrect;
                                    break;
                                }

                            case BANK_STATUS_ERROR_BANK_HAS_CANCELLED:
                                {
                                    withBlock.returnCode = NetvisorSalesPaymentListPayment.returnCodes.bankHasCancelled;
                                    break;
                                }

                            case BANK_STATUS_ERROR_CANCELLATION_NOT_CLEARING:
                                {
                                    withBlock.returnCode = NetvisorSalesPaymentListPayment.returnCodes.cancellationNotClearing;
                                    break;
                                }

                            case BANK_STATUS_ERROR_AUTHORIZATION_IS_MISSING:
                                {
                                    withBlock.returnCode = NetvisorSalesPaymentListPayment.returnCodes.authorizationIsMissing;
                                    break;
                                }

                            default:
                                {
                                    throw new ApplicationException("Invalid BankStatusErrorDescription code: " + errorDescriptionCode);
                                    break;
                                }
                        }

                        withBlock.returnCodeDescription = paymentNode.SelectSingleNode("BankStatusErrorDescription").InnerText;
                    }
                }

                paymentList.Add(paymentListPayment);
            }

            return paymentList;
        }
    }
}
