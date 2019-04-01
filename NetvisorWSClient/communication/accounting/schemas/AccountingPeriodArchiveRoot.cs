[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot("Root", IsNullable = false)]
public partial class AccountingPeriodArchiveXml
{
    private AccountingPeriodArchiveResponseStatus responseStatusField;

    private RootAccountingPeriodArchive accountingPeriodArchiveField;

    /// <remarks/>
    public AccountingPeriodArchiveResponseStatus ResponseStatus
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
    public RootAccountingPeriodArchive AccountingPeriodArchive
    {
        get
        {
            return this.accountingPeriodArchiveField;
        }
        set
        {
            this.accountingPeriodArchiveField = value;
        }
    }
}

/// <remarks/>
[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot("ResponseStatus", IsNullable = false)]
public partial class AccountingPeriodArchiveResponseStatus
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
public partial class RootAccountingPeriodArchive
{
    private string organizationIdentifierField;

    private string companynameField;

    private RootAccountingPeriodArchiveAccountingPeriod[] accountingPeriodsField;

    /// <remarks/>
    public string OrganizationIdentifier
    {
        get
        {
            return this.organizationIdentifierField;
        }
        set
        {
            this.organizationIdentifierField = value;
        }
    }

    /// <remarks/>
    public string Companyname
    {
        get
        {
            return this.companynameField;
        }
        set
        {
            this.companynameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItem("AccountingPeriod", IsNullable = false)]
    public RootAccountingPeriodArchiveAccountingPeriod[] AccountingPeriods
    {
        get
        {
            return this.accountingPeriodsField;
        }
        set
        {
            this.accountingPeriodsField = value;
        }
    }
}

/// <remarks/>
[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public partial class RootAccountingPeriodArchiveAccountingPeriod
{
    private byte periodIdField;

    private string startDateField;

    private string endDateField;

    private byte statusField;

    private RootAccountingPeriodArchiveAccountingPeriodAccountingPeriodArchiveDocument[] accountingPeriodArchiveDocumentField;

    /// <remarks/>
    public byte PeriodId
    {
        get
        {
            return this.periodIdField;
        }
        set
        {
            this.periodIdField = value;
        }
    }

    /// <remarks/>
    public string StartDate
    {
        get
        {
            return this.startDateField;
        }
        set
        {
            this.startDateField = value;
        }
    }

    /// <remarks/>
    public string EndDate
    {
        get
        {
            return this.endDateField;
        }
        set
        {
            this.endDateField = value;
        }
    }

    /// <remarks/>
    public byte Status
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
    [System.Xml.Serialization.XmlElement("AccountingPeriodArchiveDocument")]
    public RootAccountingPeriodArchiveAccountingPeriodAccountingPeriodArchiveDocument[] AccountingPeriodArchiveDocument
    {
        get
        {
            return this.accountingPeriodArchiveDocumentField;
        }
        set
        {
            this.accountingPeriodArchiveDocumentField = value;
        }
    }
}

/// <remarks/>
[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public partial class RootAccountingPeriodArchiveAccountingPeriodAccountingPeriodArchiveDocument
{
    private byte documentIdField;

    private string addedTimeStampField;

    private string filenameField;

    private uint sizeInBytesField;

    private string mimeTypeField;

    private byte typeField;

    /// <remarks/>
    public byte DocumentId
    {
        get
        {
            return this.documentIdField;
        }
        set
        {
            this.documentIdField = value;
        }
    }

    /// <remarks/>
    public string AddedTimeStamp
    {
        get
        {
            return this.addedTimeStampField;
        }
        set
        {
            this.addedTimeStampField = value;
        }
    }

    /// <remarks/>
    public string Filename
    {
        get
        {
            return this.filenameField;
        }
        set
        {
            this.filenameField = value;
        }
    }

    /// <remarks/>
    public uint SizeInBytes
    {
        get
        {
            return this.sizeInBytesField;
        }
        set
        {
            this.sizeInBytesField = value;
        }
    }

    /// <remarks/>
    public string MimeType
    {
        get
        {
            return this.mimeTypeField;
        }
        set
        {
            this.mimeTypeField = value;
        }
    }

    /// <remarks/>
    public byte Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }
}


