namespace DemoCleanArchitecture.Domain.Exceptions
{
    public class MemberException : Exception
    {
        public MemberException(string? message) : base(message) { }
    }
    public class AccountAlreadyExistMemberException : MemberException
    {
        public AccountAlreadyExistMemberException()
            : base("This account already exist.") { }
    }
    public class AccountNoExistMemberException : MemberException
    {
        public AccountNoExistMemberException()
            : base("This account don't exist.") { }
    }
    public class InvalidCredentialsMemberException : MemberException
    {
        public InvalidCredentialsMemberException()
            : base("Credentials are invalid.") { }
    }
    public class ForbiddenEmailMemberException : MemberException
    {
        public ForbiddenEmailMemberException()
            : base("Email domain is forbidden.") { }
    }
}
