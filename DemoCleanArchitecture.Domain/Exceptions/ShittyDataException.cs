namespace DemoCleanArchitecture.Domain.Exceptions
{
    public class ShittyDataException : Exception
    {
        public string FieldName { get; init; }
        public object FieldValue { get; init; }

        public ShittyDataException(string fieldName, object fieldValue)
            : base($"The field {fieldName} is invalid with value {fieldValue}.")
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
        }
    }
}
