using DemoCleanArchitecture.Domain.Enums;

namespace DemoCleanArchitecture.Domain.Modeles
{
    public class Member
    {
        public long Id { get; set; }
        public required string Email { get; set; }
        public required string? Password { get; set; }
        public required MemberRoleEnum Role { get; set; }
    }
}
