using DemoCleanArchitecture.Domain.Modeles;

namespace DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll(int offset, int limit);
        Member? GetById(long id);
        Member Create(Member data);
        Member Update(long id, Member data);
        bool Delete(long id);

        Member? GetByEmail(string email);
        string GetHashPassword(long id);
    }
}
