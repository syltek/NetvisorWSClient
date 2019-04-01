namespace NetvisorWSClient.util
{
    public class ReferenceNumberVbaAdapter
    {
        public ReferenceNumberVbaAdapter()
        {
        }

        public ReferenceNumber getReferenceNumber(string number, bool hasChecksum)
        {
            if (isValidReferenceNumber(number, hasChecksum))
                return new ReferenceNumber(number, hasChecksum);
            else
                return null;
        }

        public bool isValidReferenceNumber(string number, bool hasChecksum)
        {
            return ReferenceNumber.isReferenceNumberValid(number, hasChecksum);
        }
    }
}

