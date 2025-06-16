using DemoCleanArchitecture.Domain.Modeles;

namespace DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll(int offset, int limit);
        Author? GetById(long id);
        Author Create(Author data);
        Author Update(long id, Author data);
        bool Delete(long id);
    }
}
