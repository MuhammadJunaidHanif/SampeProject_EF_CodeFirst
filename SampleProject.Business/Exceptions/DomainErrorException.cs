using System;

namespace SampleProject.Business.Exceptions
{
    public class DomainErrorException : Exception, IS27Exception
    {
        public DomainErrorException(string message) : base(message)
        {
        }
    }
}
