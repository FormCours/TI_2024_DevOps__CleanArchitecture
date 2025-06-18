using DemoCleanArchitecture.Domain.Modeles;

namespace DemoCleanArchitecture.ApplicationCore.Interfaces.Services
{
    public interface IMemberService
    {
        Member Register(string email, string password);
        Member Login(string email, string password);
    }
}
