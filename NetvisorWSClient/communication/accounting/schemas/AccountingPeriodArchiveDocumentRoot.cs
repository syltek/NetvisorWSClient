using System;

[System.Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot("Root", IsNullable = false)]
public partial class AccountingPeriodArchiveDocumentXml
{
    private AccountingPeriodArchiveDocumentResponseStatus responseStatusField;

    private RootAccountingPeriodArchiveDocument accountingPeriodArchiveDocumentField;

    /// <remarks/>
    public AccountingPeriodArchiveDocumentResponseStatus ResponseStatus
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
    public RootAccountingPeriodArchiveDocument AccountingPeriodArchiveDocument
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
[System.Xml.Serialization.XmlRoot("ResponseStatus", IsNullable = false)]
public partial class AccountingPeriodArchiveDocumentResponseStatus
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
public partial class RootAccountingPeriodArchiveDocument
{
    private byte documentIdField;

    private DateTime addedTimeStampField;

    private string filenameField;

    private ushort sizeInBytesField;

    private string mimeTypeField;

    private byte typeField;

    private string contentField;

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
    [System.Xml.Serialization.XmlElement(DataType = "date")]
    public DateTime AddedTimeStamp
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
    public ushort SizeInBytes
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

    /// <remarks/>
    public string Content
    {
        get
        {
            return this.contentField;
        }
        set
        {
            this.contentField = value;
        }
    }
}


