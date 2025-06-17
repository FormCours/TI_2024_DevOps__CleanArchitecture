using DemoCleanArchitecture.Domain.Modeles;

namespace DemoCleanArchitecture.ApplicationCore.Interfaces.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll(int page, int nbElement);
        Author GetById(long id);
        Author Create(Author data);
        Author Update(Author data);
    }
}
