[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot("Root", IsNullable = false)]
public partial class PayslipContentRoot
{
    private PayslipContentResponseStatusXml responseStatusField;

    private string payslipDataField;

    /// <remarks/>
    public PayslipContentResponseStatusXml ResponseStatus
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
    public string PayslipData
    {
        get
        {
            return this.payslipDataField;
        }
        set
        {
            this.payslipDataField = value;
        }
    }
}

/// <remarks/>
[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot("ResponseStatus", IsNullable = false)]
public partial class PayslipContentResponseStatusXml
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



