using System;
using System.Runtime.Serialization;

namespace ApplicationJampay.CardReaderAPI.Exceptions
{
    [Serializable]
    public class InternalErrorException : PCSCException
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="serr">System's error code</param>
        public InternalErrorException(SCardError serr)
            : base(serr) { }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="serr">System's error code</param>
        /// <param name="message">Error message</param>
        public InternalErrorException(SCardError serr, string message)
            : base(serr, message) { }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="serr">System's error code</param>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception</param>
        public InternalErrorException(SCardError serr, string message, Exception innerException)
            : base(serr, message, innerException) { }

        /// <summary>
        /// Serialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected InternalErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}