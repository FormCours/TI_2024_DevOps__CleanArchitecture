namespace DemoCleanArchitecture.Domain.Exceptions
{
    public class NotFoundException<TId> : Exception
        where TId : struct
    {
        public TId Id { get; init; }
        public NotFoundException(string subject, TId id)
            : base($"The {subject} with id {id} is not found")
        { }
    }

    public class AuthorNotFoundException : NotFoundException<long>
    {
        public AuthorNotFoundException(long id) : base("Author", id) { }
    }
}
