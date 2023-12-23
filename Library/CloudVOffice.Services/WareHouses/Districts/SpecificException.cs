using System.Runtime.Serialization;

namespace CloudVOffice.Services.WareHouses.Districts
{
    [Serializable]
    internal class SpecificException : Exception
    {
        public SpecificException()
        {
        }

        public SpecificException(string? message) : base(message)
        {
        }

        public SpecificException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SpecificException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}