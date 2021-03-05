namespace DotNetCenter.Core.ExceptionHandlers
{
    using System;

    public abstract class DomainException : Exception
    {
        public DomainException()
        { }
        public DomainException(string businessMessage) 
            : base(businessMessage)
        { }
        public DomainException(string message, Exception innerException) 
            : base(message, innerException)
        { }
    }
}
