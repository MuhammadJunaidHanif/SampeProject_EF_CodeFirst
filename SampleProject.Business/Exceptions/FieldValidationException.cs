using System;

namespace SampleProject.Business.Exceptions
{
    public class FieldValidationException : Exception, IS27Exception
    {
        public string FieldName { get; }
        public FieldValidationException(string fieldName, string message) : base(message)
        {
            FieldName = fieldName;
        }
    }
}
