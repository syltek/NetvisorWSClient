using System;

public class NetvisorPurchaseOrderListOrder
{
    private int m_netvisorKey;
    private string m_orderNumber;
    private DateTime m_orderDate;
    private string m_orderStatus;
    private string m_vendorName;
    private double m_amount;
    private string m_uri;

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

    public string orderNumber
    {
        get
        {
            return m_orderNumber;
        }
        set
        {
            m_orderNumber = value;
        }
    }

    public DateTime orderDate
    {
        get
        {
            return m_orderDate;
        }
        set
        {
            m_orderDate = value;
        }
    }

    public string orderStatus
    {
        get
        {
            return m_orderStatus;
        }
        set
        {
            m_orderStatus = value;
        }
    }

    public string vendorName
    {
        get
        {
            return m_vendorName;
        }
        set
        {
            m_vendorName = value;
        }
    }

    public double amount
    {
        get
        {
            return m_amount;
        }
        set
        {
            m_amount = value;
        }
    }

    public string uri
    {
        get
        {
            return m_uri;
        }
        set
        {
            m_uri = value;
        }
    }
}

