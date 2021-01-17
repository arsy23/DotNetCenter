namespace DotNetCenter.Core.ExceptionHandlers
{
    using System;
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) 
            : base(message)
        { }
    }
}
