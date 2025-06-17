using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.ApplicationCore.Interfaces.Services;
using DemoCleanArchitecture.Domain.Exceptions;
using DemoCleanArchitecture.Domain.Modeles;

namespace DemoCleanArchitecture.ApplicationCore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAll(int page, int nbElement)
        {
            int limit = Math.Min(nbElement, 20);
            int offset = (page-1) * limit;

            return _authorRepository.GetAll(offset, limit);
        }

        public Author GetById(long id)
        {
            Author? author = _authorRepository.GetById(id);

            if(author is null)
            {
                throw new AuthorNotFoundException(id);
            }

            return author;
        }

        private static void CheckAuthorBirthdate(Author data)
        {
            if (data.BirthDate is not null && data.BirthDate > DateTime.Today)
            {
                throw new ShittyDataException(nameof(data.BirthDate), data.BirthDate);
            }
        }

        public Author Create(Author data)
        {
            CheckAuthorBirthdate(data);
            return _authorRepository.Create(data);
        }

        public Author Update(Author data)
        {
            CheckAuthorBirthdate(data);
            return _authorRepository.Update(data.Id, data);
        }
    }
}
