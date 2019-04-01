namespace NetvisorWSClient.util
{
    public class VatCode
    {
        public const string NO_VAT_HANDLING = "NONE";
        public const string DOMESTIC_PURCHASE = "KOOS";
        public const string EU_PURCHASE = "EUOS";
        public const string NON_EU_PURCHASE = "EUUO";
        public const string EU_SERVICE_PURCHASE = "EUPO";
        public const string HUNDREDPERCENT_DEDUCTED_TAX = "100";
        public const string DOMESTIC_SALES = "KOMY";
        public const string EU_SALES = "EUMY";
        public const string NON_EU_SALES = "EUUM";
        public const string EU_SERVICE_SALES = "EUPM";
        public const string EU_SERVICE_SALES_312 = "EUPM312";
        public const string EU_SERVICE_SALES_309 = "EUPM309";
        public const string NO_TAX_SALES = "MUUL";
        public const string NO_DEDUCTIBLE_EU_PURCHASE = "EVTO";
        public const string NO_DEDUCTIBLE_EU_SERVICEPURHASE = "EVPO";

        public enum vatCodes : int
        {
            NO_VAT_HANDLING = 1,
            DOMESTIC_PURCHASE = 2,
            EU_PURCHASE = 3,
            NON_EU_PURCHASE = 4,
            EU_SERVICE_PURCHASE = 5,
            HUNDREDPERCENT_DEDUCTED_TAX = 6,
            DOMESTIC_SALES = 7,
            EU_SALES = 8,
            NON_EU_SALES = 9,
            EU_SERVICE_SALES_312 = 10,
            EU_SERVICE_SALES_309 = 11,
            NO_TAX_SALES = 12,
            NO_DEDUCTIBLE_EU_PURCHASE = 13,
            NO_DEDUCTIBLE_EU_SERVICEPURHASE = 14
        }
    }
}
