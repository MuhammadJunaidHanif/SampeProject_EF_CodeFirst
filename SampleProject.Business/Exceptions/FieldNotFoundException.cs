using System;

namespace SampleProject.Business.Exceptions
{
    public class FieldNotFoundException : Exception, IS27Exception
    {
        public string FieldName { get; }
        public FieldNotFoundException(string fieldName, string message) : base(message)
        {
            FieldName = fieldName;
        }
    }
}
