using System;


namespace SampleProject.Business.Exceptions
{
    public class UnauthorizedException : Exception, IS27Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
