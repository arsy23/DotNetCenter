namespace DotNetCenter.Core.ExceptionHandlers
{
    using System;
    using System.Data.Common;
    using System.Runtime.Serialization;
    public  class ApplicationDbException : DbException
    {
        public ApplicationDbException(string message) : base(message)
        { }
        public ApplicationDbException(string message, Exception innerException) : base(message, innerException)
        { }
        public ApplicationDbException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
        public ApplicationDbException(string message, int errorCode) : base(message, errorCode)
        { }
    }
}
