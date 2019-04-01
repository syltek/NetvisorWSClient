using Microsoft.VisualBasic;
using System;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorEmployee
    {
        private string m_employeeidentifier;
        private string m_firstName;
        private string m_lastName;
        private string m_phoneNumber;
        private string m_email;
        private string m_streetAddress;
        private string m_postNumber;
        private string m_city;
        private string m_municipality;
        private string m_country;
        private string m_nationality;
        private string m_language;
        private int m_employeeNumber = -1;
        private string m_profession;
        private string m_payrollrulegroupname;
        private DateTime m_jobbegindate;
        private string m_bankaccountnumber;
        private int m_accountingaccountnumber = -1;
        private string m_BankIdentificationCode;

        public string Employeeidentifier
        {
            get
            {
                return m_employeeidentifier;
            }
            set
            {
                if (Strings.Len(value) > 25)
                    throw new ApplicationException("Employeeidentifier too long");
                else
                    m_employeeidentifier = value;
            }
        }

        public string FirstName
        {
            get
            {
                return m_firstName;
            }
            set
            {
                if (Strings.Len(value) > 250)
                    throw new ApplicationException("First name too long");
                else
                    m_firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return m_lastName;
            }
            set
            {
                if (Strings.Len(value) > 250)
                    throw new ApplicationException("Last name too long");
                else
                    m_lastName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_phoneNumber;
            }
            set
            {
                m_phoneNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return m_email;
            }
            set
            {
                m_email = value;
            }
        }

        public string StreetAddress
        {
            get
            {
                return m_streetAddress;
            }
            set
            {
                if (Strings.Len(value) > 80)
                    throw new ApplicationException("Streetaddress too long");
                else
                    m_streetAddress = value;
            }
        }

        public string PostNumber
        {
            get
            {
                return m_postNumber;
            }
            set
            {
                m_postNumber = value;
            }
        }

        public string City
        {
            get
            {
                return m_city;
            }
            set
            {
                if (Strings.Len(value) > 80)
                    throw new ApplicationException("City too long");
                else
                    m_city = value;
            }
        }

        public string Municipality
        {
            get
            {
                return m_municipality;
            }
            set
            {
                m_municipality = value;
            }
        }

        public string Country
        {
            get
            {
                return m_country;
            }
            set
            {
                if (Strings.Len(value) > 2)
                    throw new ApplicationException("Country too long");
                else
                    m_country = value;
            }
        }

        public string Nationality
        {
            get
            {
                return m_nationality;
            }
            set
            {
                if (Strings.Len(value) > 2)
                    throw new ApplicationException("Nationality too long");
                else
                    m_nationality = value;
            }
        }

        public string Language
        {
            get
            {
                return m_language;
            }
            set
            {
                if (Strings.Len(value) > 2)
                    throw new ApplicationException("Language too long");
                else
                    m_language = value;
            }
        }

        public int EmployeeNumber
        {
            get
            {
                return m_employeeNumber;
            }
            set
            {
                m_employeeNumber = value;
            }
        }

        public string Profession
        {
            get
            {
                return m_profession;
            }
            set
            {
                if (Strings.Len(value) > 80)
                    throw new ApplicationException("Profession too long");
                else
                    m_profession = value;
            }
        }

        public DateTime JobBeginDate
        {
            get
            {
                return m_jobbegindate;
            }
            set
            {
                m_jobbegindate = value;
            }
        }

        public string Payrollrulegroupname
        {
            get
            {
                return m_payrollrulegroupname;
            }
            set
            {
                if (Strings.Len(value) > 50)
                    throw new ApplicationException("Payroll rule group name too long");
                else
                    m_payrollrulegroupname = value;
            }
        }

        public string Bankaccountnumber
        {
            get
            {
                return m_bankaccountnumber;
            }
            set
            {
                if (Strings.Len(value) > 34)
                    throw new ApplicationException("Bank account number too long");
                else
                    m_bankaccountnumber = value;
            }
        }

        public string BankIdentificationCode
        {
            get
            {
                return m_BankIdentificationCode;
            }
            set
            {
                if (Strings.Len(value) > 20)
                    throw new ApplicationException("Bank identification code too long");
                else
                    m_BankIdentificationCode = value;
            }
        }

        public int Accountingaccountnumber
        {
            get
            {
                return m_accountingaccountnumber;
            }
            set
            {
                m_accountingaccountnumber = value;
            }
        }
    }
}

