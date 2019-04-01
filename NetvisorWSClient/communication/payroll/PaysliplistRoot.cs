[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot("Root", IsNullable = false)]
public partial class PaysliplistXml
{
    private PaysliplistResponseStatusXml responseStatusField;

    private PayslipXml[] payslipsField;

    /// <remarks/>
    public PaysliplistResponseStatusXml ResponseStatus
    {
        get
        {
            return this.responseStatusField;
        }
        set
        {
            this.responseStatusField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItem("Payslip", IsNullable = false)]
    public PayslipXml[] Payslips
    {
        get
        {
            return this.payslipsField;
        }
        set
        {
            this.payslipsField = value;
        }
    }
}

/// <remarks/>
[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot("ResponseStatus", IsNullable = false)]
public partial class PaysliplistResponseStatusXml
{
    private string statusField;

    private string timeStampField;

    /// <remarks/>
    public string Status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }

    /// <remarks/>
    public string TimeStamp
    {
        get
        {
            return this.timeStampField;
        }
        set
        {
            this.timeStampField = value;
        }
    }
}

/// <remarks/>
[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot("Payslip", IsNullable = false)]
public partial class PayslipXml
{
    private int netvisorkeyField;

    private string companyNameField;

    private int employeeIdField;

    private string employeeNumberField;

    private string employeeNameField;

    private string payperiodStartField;

    private string payperiodEndField;

    private string dueDateField;

    private decimal paidAmountField;

    private string uriField;

    /// <remarks/>
    public int Netvisorkey
    {
        get
        {
            return this.netvisorkeyField;
        }
        set
        {
            this.netvisorkeyField = value;
        }
    }

    /// <remarks/>
    public string CompanyName
    {
        get
        {
            return this.companyNameField;
        }
        set
        {
            this.companyNameField = value;
        }
    }

    /// <remarks/>
    public ushort EmployeeId
    {
        get
        {
            return this.employeeIdField;
        }
        set
        {
            this.employeeIdField = value;
        }
    }

    /// <remarks/>
    public string EmployeeNumber
    {
        get
        {
            return this.employeeNumberField;
        }
        set
        {
            this.employeeNumberField = value;
        }
    }

    /// <remarks/>
    public string EmployeeName
    {
        get
        {
            return this.employeeNameField;
        }
        set
        {
            this.employeeNameField = value;
        }
    }

    /// <remarks/>
    public string PayperiodStart
    {
        get
        {
            return this.payperiodStartField;
        }
        set
        {
            this.payperiodStartField = value;
        }
    }

    /// <remarks/>
    public string PayperiodEnd
    {
        get
        {
            return this.payperiodEndField;
        }
        set
        {
            this.payperiodEndField = value;
        }
    }

    /// <remarks/>
    public string DueDate
    {
        get
        {
            return this.dueDateField;
        }
        set
        {
            this.dueDateField = value;
        }
    }

    /// <remarks/>
    public string PaidAmount
    {
        get
        {
            return this.paidAmountField;
        }
        set
        {
            this.paidAmountField = value;
        }
    }

    /// <remarks/>
    public string Uri
    {
        get
        {
            return this.uriField;
        }
        set
        {
            this.uriField = value;
        }
    }
}
