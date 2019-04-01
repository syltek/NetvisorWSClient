public class NetvisorProcessCustomExpence
{
    private string m_CrmProcessIdentifier;
    private string m_InvoicingProductIdentifier;
    private string m_Description;
    private double m_Amount;
    private string m_PriceGroupName;

    public string PriceGroupName
    {
        get
        {
            return m_PriceGroupName;
        }
        set
        {
            m_PriceGroupName = value;
        }
    }

    public string CrmProcessIdentifier
    {
        get
        {
            return m_CrmProcessIdentifier;
        }
        set
        {
            m_CrmProcessIdentifier = value;
        }
    }

    public string InvoicingProductIdentifier
    {
        get
        {
            return m_InvoicingProductIdentifier;
        }
        set
        {
            m_InvoicingProductIdentifier = value;
        }
    }

    public string Description
    {
        get
        {
            return m_Description;
        }
        set
        {
            m_Description = value;
        }
    }

    public double Amount
    {
        get
        {
            return m_Amount;
        }
        set
        {
            m_Amount = value;
        }
    }
}

