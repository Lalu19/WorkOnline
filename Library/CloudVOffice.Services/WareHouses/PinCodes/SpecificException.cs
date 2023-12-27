using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.PinCodes
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
