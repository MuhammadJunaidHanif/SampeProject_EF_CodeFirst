namespace SampleProject.Business.Exceptions
{
    public static class Exceptions
    {
        public static FieldValidationException FieldValidationException(string fieldName, string message)
                => new FieldValidationException(fieldName, message);
        public static FieldNotFoundException FieldNotFoundException(string fieldName, string message)
                => new FieldNotFoundException(fieldName, message);
        public static UnauthorizedException UnauthorizedException(string message)
               => new UnauthorizedException(message);
        public static DomainErrorException DomainErrorException(string message) => new DomainErrorException(message);
    }
}
