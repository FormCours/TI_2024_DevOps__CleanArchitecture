using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.Domain.Modeles;

namespace DemoCleanArchitecture.ApplicationCore.Test.Fakes
{
    internal class FakeForGetAuthorRepository : IAuthorRepository
    {
        private static List<Author> _authors = [
            new Author() {
                Id= 1,
                FirstName= "Robert",
                LastName="Testing",
                Pseudo = null,
                BirthDate= new DateTime(1990, 1, 1),
            },
            new Author() {
                Id= 2,
                FirstName= "Romain",
                LastName="Otto",
                Pseudo = "Ryuji",
                BirthDate= new DateTime(2000, 12, 11),
            },
            new Author() {
                Id= 3,
                FirstName= "Lena",
                LastName="De sortilege",
                Pseudo = "LaMageDu42",
                BirthDate= new DateTime(1996, 6, 13),
            }
        ];

        public IEnumerable<Author> GetAll(int offset, int limit)
        {
            return _authors.Skip(offset).Take(limit);
        }

        public Author? GetById(long id)
        {
            return _authors.FirstOrDefault(a => a.Id == id);
        }
        public Author Create(Author data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Author Update(long id, Author data)
        {
            throw new NotImplementedException();
        }
    }
}
