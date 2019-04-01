using NetvisorWSClient.communication.controller;
using NetvisorWSClient.communication.sales;
using NetvisorWSClient.communication.purchase;
using NetvisorWSClient.communication.accounting;
using NetvisorWSClient.communication.webshop;
using NetvisorWSClient.communication.payroll;

namespace NetvisorWSClient.communication
{
    public class NetvisorApplicationResponseFactory
    {
        public static object getNetvisorApplicationResponse(string url, string responseData)
        {
            if (url.Contains(WSClient.ACTION_SALESINVOICE_LIST))
                return new NetvisorApplicationSalesInvoiceListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_PURCHASEINVOICE_LIST))
                return new NetvisorApplicationPurchaseInvoiceListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_CUSTOMER_LIST))
                return new NetvisorApplicationCustomerListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_ACCOUNTING_LEDGER))
                return new NetvisorApplicationAccountingLedgerResponse(responseData);
            else if (url.Contains(WSClient.ACTION_PRODUCT_LIST) & !url.Contains(WSClient.ACTION_WEBSHOP_PRODUCT_LIST))
                return new NetvisorApplicationProductListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_GETPRODUCT))
                return new NetvisorApplicationProductResponse(responseData);
            else if (url.Contains(WSClient.ACTION_SALESPAYMENT_LIST))
                return new NetvisorApplicationSalesPaymentListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_GETSALESINVOICE))
                return new NetvisorApplicationSalesInvoiceResponse(responseData);
            else if (url.Contains(WSClient.ACTION_GETCUSTOMER))
                return new NetvisorApplicationCustomerResponse(responseData);
            else if (url.Contains(WSClient.ACTION_DIMENSION_LIST))
                return new NetvisorApplicationDimensionListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_ACCOUNTING_BUDGET_ACCOUNT_LIST))
                return new NetvisorApplicationAccountingBudgetAccountListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET))
                return new NetvisorApplicationAccountingBudgetAccountBudgetResponse(responseData);
            else if (url.Contains(WSClient.ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET))
                return new NetvisorApplicationAccountingBudgetDimensionBudgetResponse(responseData);
            else if (url.Contains(WSClient.ACTION_WEBSHOP_PRODUCT_LIST))
                return new NetvisorApplicationWebShopProductResponse(responseData);
            else if (url.Contains(WSClient.ACTION_WEBSHOP_PRODUCT_IMAGES))
                return new NetvisorApplicationWebShopProductImageResponse(responseData);
            else if (url.Contains(WSClient.ACTION_ACCOUNTLIST))
                return new NetvisorApplicationAccountListReponse(responseData);
            else if (url.Contains(WSClient.ACTION_ACCOUNTING_PERIODLIST))
                return new NetvisorApplicationAccountingPeriodListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_PAYMENT_LIST))
                return new NetvisorApplicationPaymentListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_SALESPERSONNELLIST))
                return new NetvisorApplicationSalesPersonnelListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_PURCHASEORDER_LIST))
                return new NetvisorApplicationPurchaseOrderListResponse(responseData);
            else if (url.Contains(WSClient.ACTION_GET_PURCHASEORDER))
                return new NetvisorApplicationPurchaseOrderResponse(responseData);
            else if (url.Contains(WSClient.ACTION_PAYSLIPLIST))
                return new NetvisorApplicationPaysliplistResponse(responseData);
            else if (url.Contains(WSClient.ACTION_GETPAYSLIP))
                return new NetvisorApplicationGetPayslipResponse(responseData);
            else
                return new NetvisorApplicationResponse(responseData);
        }
    }
}
