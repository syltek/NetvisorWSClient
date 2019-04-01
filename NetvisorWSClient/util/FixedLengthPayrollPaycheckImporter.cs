using Microsoft.VisualBasic;
using System.Collections;
using System;
using System.IO;

namespace NetvisorWSClient.util
{
    public class FixedLengthPayrollPaycheckImporter
    {
        private const int MINROWLENGTH = 92;
        private const int MAXROWLENGTH = 106;

        private const int INDEX = 0;
        private const int LENGHT = 1;
        // Index,Lenght
        private int[,] m_InstructionsTable = new[] { { 0, 3 }, { 4, 2 }, { 6, 7 }, { 27, 2 }, { 30, 4 }, { 35, 8 }, { 44, 8 }, { 55, 10 }, { 66, 8 }, { 75, 8 }, { 84, 8 }, { 93, 4 }, { 98, 8 } };

        private enum Fields : int
        {
            RECORD = 0,
            ORG = 1,
            PIN = 2,
            MONTH = 3,
            PAYMENTTYPE = 4,
            AMOUNT = 5,
            COSTPLACE = 6,
            UNITPRICE = 7,
            TRANSFERDATE = 8,
            FIRSTDATE = 9,
            LASTDATE = 10,
            SENDID = 11,
            ACCOUNT = 12
        }

        private string m_file = null;
        private ArrayList m_importedFileRows = new ArrayList();
        private ArrayList m_importedFileProcessError = new ArrayList();
        private ArrayList m_rowsList = new ArrayList();
        private bool m_isProcessingOk;
        private ArrayList m_rowsUniquePersonalNumbers = new ArrayList();


        public FixedLengthPayrollPaycheckImporter()
        {
        }

        public string File
        {
            get
            {
                return m_file;
            }
            set
            {
                m_file = value;
            }
        }

        public bool ProcessFile()
        {
            m_isProcessingOk = ReadReceivedFile();
            m_isProcessingOk = ProcessRows();

            return m_isProcessingOk;
        }

        private void addFileRow(string row)
        {
            m_importedFileRows.Add(row);
        }

        public int FileRowCount()
        {
            return m_importedFileRows.Count;
        }

        private void addFileProcessErrorRow(string errorRow)
        {
            m_importedFileProcessError.Add(errorRow);
        }

        public ArrayList getFileProcessErrorRows()
        {
            return m_importedFileProcessError;
        }

        public int FileProcessErrorRowCount()
        {
            return m_importedFileProcessError.Count;
        }

        private bool ReadReceivedFile()
        {
            bool isReadOk = true;
            StringReader reader = new StringReader(m_file);

            try
            {
                string Line = reader.ReadLine();
                int rowCount = 0;

                while (!(Line == null))
                {
                    if (Line.Length >= MINROWLENGTH)
                    {
                        rowCount += 1;
                        addFileRow(Line);
                    }

                    Line = reader.ReadLine();
                }

                if (rowCount != this.m_importedFileRows.Count)
                    isReadOk = false;
            }
            catch (Exception ex)
            {
                isReadOk = false;
                throw new Exception("READ-error : " + ex.StackTrace.ToString());
            }

            finally
            {
                reader.Close();
            }

            return isReadOk;
        }

        private void addRowObjects(Row obj)
        {
            this.m_rowsList.Add(obj);
        }

        /// <summary>
        /// Palauttaa listan row olioita
        /// </summary>
        /// <remarks>Palauttaa tyhjän listan, jos luku epäonnistui</remarks>
        public ArrayList getAllRowObjectsList()
        {
            if (this.m_isProcessingOk)
                return m_rowsList;
            else
                return new ArrayList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>ArrayList of row objects</returns>
        /// <remarks></remarks>
        public ArrayList getUniquePersonalNumbersList()
        {
            foreach (Row obj in m_rowsList)
            {
                bool pinExists = isRowPersonalNumberListed(obj.PersonalNumber);
                if (pinExists == false)
                    AddUniquePersonalNumberToList(obj.PersonalNumber);
            }

            return m_rowsUniquePersonalNumbers;
        }

        /// <summary>
        /// Row olio-listasta haku annetulla yksilöllisellä henkilönumerolla
        /// </summary>
        /// <param name="personalnumber"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ArrayList SearchByPersonalNumber(int personalnumber)
        {
            ArrayList tempArrayList = new ArrayList();
            foreach (Row obj in m_rowsList)
            {
                if (obj.PersonalNumber == personalnumber)
                    tempArrayList.Add(obj);
            }

            return tempArrayList;
        }

        private void AddUniquePersonalNumberToList(int pin)
        {
            m_rowsUniquePersonalNumbers.Add(pin);
        }

        /// <summary>
        /// Tarkastetaan onko henkilönumero jo listassa
        /// </summary>
        /// <param name="personalnumber"></param>
        private bool isRowPersonalNumberListed(int personalnumber)
        {
            bool isFound = false;
            foreach (int existingPin in this.m_rowsUniquePersonalNumbers)
            {
                if (existingPin == personalnumber)
                    return true;
            }

            return isFound;
        }

        /// <summary>
        /// Käsittelee tiedosto rivit row-olioiksi
        /// </summary>
        private bool ProcessRows()
        {
            bool isInitializeOk = true;
            int RowCounter = 1;

            foreach (string row in this.m_importedFileRows)
            {
                try
                {
                    string record = row.Substring(m_InstructionsTable[Fields.RECORD, INDEX], m_InstructionsTable[Fields.RECORD, LENGHT]);
                    string organisation = row.Substring(m_InstructionsTable[Fields.ORG, INDEX], m_InstructionsTable[Fields.ORG, LENGHT]);
                    string personalnumber = row.Substring(m_InstructionsTable[Fields.PIN, INDEX], m_InstructionsTable[Fields.PIN, LENGHT]);

                    string month = "";
                    try
                    {
                        month = row.Substring(m_InstructionsTable[Fields.MONTH, INDEX], m_InstructionsTable[Fields.MONTH, LENGHT]);

                        month.Trim(" ");

                        if (month.Length < 2 || month.Length > 2)
                            month = Constants.vbNullString;
                    }
                    catch (Exception ex)
                    {
                        month = Constants.vbNullString;
                        Console.WriteLine("month : " + ex.StackTrace);
                    }

                    string paymenttype = row.Substring(m_InstructionsTable[Fields.PAYMENTTYPE, INDEX], m_InstructionsTable[Fields.PAYMENTTYPE, LENGHT]);
                    string amount = row.Substring(m_InstructionsTable[Fields.AMOUNT, INDEX], m_InstructionsTable[Fields.AMOUNT, LENGHT]);
                    string costplace = row.Substring(m_InstructionsTable[Fields.COSTPLACE, INDEX], m_InstructionsTable[Fields.COSTPLACE, LENGHT]);
                    string unitprice = row.Substring(m_InstructionsTable[Fields.UNITPRICE, INDEX], m_InstructionsTable[Fields.UNITPRICE, LENGHT]);
                    string transferdate = row.Substring(m_InstructionsTable[Fields.TRANSFERDATE, INDEX], m_InstructionsTable[Fields.TRANSFERDATE, LENGHT]);
                    string firstdate = row.Substring(m_InstructionsTable[Fields.FIRSTDATE, INDEX], m_InstructionsTable[Fields.FIRSTDATE, LENGHT]);
                    string lastdate = row.Substring(m_InstructionsTable[Fields.LASTDATE, INDEX], m_InstructionsTable[Fields.LASTDATE, LENGHT]);

                    string sendid = "";

                    if (row.Length >= 97)
                    {
                        try
                        {
                            sendid = row.Substring(m_InstructionsTable[Fields.SENDID, INDEX], m_InstructionsTable[Fields.SENDID, LENGHT]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("SenID->" + ex.StackTrace);
                            sendid = Constants.vbNullString;
                        }
                    }
                    else
                        sendid = Constants.vbNullString;

                    string accountnumber = "";

                    if (row.Length == 106)
                    {
                        try
                        {
                            accountnumber = row.Substring(m_InstructionsTable[Fields.ACCOUNT, INDEX], m_InstructionsTable[Fields.ACCOUNT, LENGHT]);
                        }
                        catch (Exception ex)
                        {
                            accountnumber = Constants.vbNullString;
                        }
                    }
                    else
                        accountnumber = Constants.vbNullString;

                    Row objRow = new Row(RowCounter);
                    objRow.Record = record;
                    objRow.Oraganisation = organisation;
                    objRow.PersonalNumber = int.Parse(personalnumber);

                    if (Information.IsNumeric(month))
                        objRow.Month = int.Parse(month);
                    else
                        objRow.Month = 0;

                    objRow.PaymentType = int.Parse(paymenttype);

                    try
                    {
                        int tempamount = int.Parse(amount);
                        objRow.Amount = tempamount / (double)100;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("virhe amount : " + ex.StackTrace);
                        throw new Exception("amount : " + ex.StackTrace);
                    }

                    objRow.CostPlace = int.Parse(costplace);

                    if (Information.IsNumeric(unitprice))
                    {
                        try
                        {
                            int tempunitprice = int.Parse(unitprice);
                            objRow.UnitPrice = tempunitprice / (double)100;

                            if (objRow.Amount < 0 & objRow.UnitPrice < 0)
                            {
                                float tempacalc = -(objRow.Amount * objRow.UnitPrice);
                                objRow.CalculatedAmount = tempacalc;
                            }
                            else
                                objRow.CalculatedAmount = objRow.Amount * objRow.UnitPrice;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("virhe costplace : " + ex.StackTrace);
                            throw new Exception("unitprice : " + ex.StackTrace);
                        }
                    }
                    else
                        objRow.UnitPrice = 0;

                    try
                    {
                        objRow.TransferDate = parseDate(transferdate);
                        objRow.FirstDate = parseDate(firstdate);
                        objRow.LastDate = parseDate(lastdate);

                        if (Information.IsNumeric(sendid))
                            objRow.SendId = sendid;
                        else
                            objRow.SendId = 0;

                        objRow.AccountNumber = accountnumber;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("TimeFormat error");
                    }

                    this.addRowObjects(objRow);
                    RowCounter += 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("messagevirhe : " + ex.Message);
                    Console.WriteLine("stackvirhe : " + ex.StackTrace);
                    string rowError = "Row : " + RowCounter + " Error : " + ex.Message + " processing row: " + row;
                    Console.WriteLine(rowError);
                    addFileProcessErrorRow(rowError);
                    isInitializeOk = false;
                }
            }

            return isInitializeOk;
        }

        /// <summary>
        /// Konvertoi päivämäärän
        /// </summary>
        /// <param name="dateFormat">"vvvvkkpp</param>
        /// <returns>"pp.kk.vvvv"</returns>
        private DateTime parseDate(string dateFormat)
        {
            int vvvv = dateFormat.Substring(0, 4);
            int kk = dateFormat.Substring(4, 2);
            int pp = dateFormat.Substring(6, 2);

            DateTime returnDate = new DateTime(vvvv, kk, pp);
            return returnDate.ToShortDateString();
        }
    }

    public class Row
    {
        private int m_objectID;
        private string m_record;
        private string m_organisation;
        private int m_personalNumber;
        private int m_month;
        private int m_paymenttype;
        private float m_amount;
        private float m_unitprice;
        private float m_calculatedamount;
        private int m_costplace;
        private DateTime m_transferdate;
        private DateTime m_firstdate;
        private DateTime m_lastdate;
        private long m_sendid;
        private string m_accountnumber;

        public Row(int ID)
        {
            m_objectID = ID;
        }

        public int ObjectID
        {
            get
            {
                return m_objectID;
            }
        }

        public bool hasCalculatedAmount()
        {
            if (this.CalculatedAmount > 0)
                return true;
            else
                return false;
        }
        public string Record
        {
            get
            {
                return m_record;
            }
            set
            {
                m_record = value;
            }
        }

        public string Oraganisation
        {
            get
            {
                return m_organisation;
            }
            set
            {
                m_organisation = value;
            }
        }

        public int PersonalNumber
        {
            get
            {
                return m_personalNumber;
            }
            set
            {
                m_personalNumber = value;
            }
        }

        public int Month
        {
            get
            {
                return m_month;
            }
            set
            {
                m_month = value;
            }
        }

        public int PaymentType
        {
            get
            {
                return m_paymenttype;
            }
            set
            {
                m_paymenttype = value;
            }
        }

        public float Amount
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

        public float UnitPrice
        {
            get
            {
                return m_unitprice;
            }
            set
            {
                m_unitprice = value;
            }
        }

        public float CalculatedAmount
        {
            get
            {
                return m_calculatedamount;
            }
            set
            {
                m_calculatedamount = value;
            }
        }

        public int CostPlace
        {
            get
            {
                return m_costplace;
            }
            set
            {
                m_costplace = value;
            }
        }

        public DateTime TransferDate
        {
            get
            {
                return m_transferdate;
            }
            set
            {
                m_transferdate = value;
            }
        }

        public DateTime FirstDate
        {
            get
            {
                return m_firstdate;
            }
            set
            {
                m_firstdate = value;
            }
        }

        public DateTime LastDate
        {
            get
            {
                return m_lastdate;
            }
            set
            {
                m_lastdate = value;
            }
        }

        public int SendId
        {
            get
            {
                return m_sendid;
            }
            set
            {
                m_sendid = value;
            }
        }


        public string AccountNumber
        {
            get
            {
                return m_accountnumber;
            }
            set
            {
                m_accountnumber = value;
            }
        }
    }
}
