using System.Collections;
using System;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorVoucher
    {
        private bool m_voucherCalculationModeIsGross;
        private DateTime m_VoucherDate;
        private long m_voucherNumber;
        private string m_description;
        private string m_voucherclass;
        private ArrayList m_voucherLines = new ArrayList();
        private ArrayList m_attachments = new ArrayList();

        public bool voucherCalculationModeIsGross
        {
            get
            {
                return m_voucherCalculationModeIsGross;
            }
            set
            {
                m_voucherCalculationModeIsGross = value;
            }
        }

        public DateTime VoucherDate
        {
            get
            {
                return m_VoucherDate;
            }
            set
            {
                m_VoucherDate = value;
            }
        }

        public string VoucherClass
        {
            get
            {
                return m_voucherclass;
            }
            set
            {
                m_voucherclass = value;
            }
        }

        public long voucherNumber
        {
            get
            {
                return m_voucherNumber;
            }
            set
            {
                m_voucherNumber = value;
            }
        }

        public string Description
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
            }
        }

        public ArrayList voucherLines
        {
            get
            {
                return m_voucherLines;
            }
        }

        public ArrayList attachments
        {
            get
            {
                return m_attachments;
            }
        }

        public void addVoucherLine(NetvisorVoucherLine line)
        {
            m_voucherLines.Add(line);
        }

        public void addAttachment(NetvisorAttachment attachment)
        {
            m_attachments.Add(attachment);
        }
    }
}

