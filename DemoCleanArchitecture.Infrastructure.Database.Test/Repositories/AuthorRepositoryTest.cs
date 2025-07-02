using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.Domain.Modeles;
using DemoCleanArchitecture.Infrastructure.Database.Repositories;

namespace DemoCleanArchitecture.Infrastructure.Database.Test.Repositories
{
    public class AuthorRepositoryTest : RepositoryTestBase
    {
        // Méthode pour ajouter un set de donnée au mock de la DB.
        // Utile si plusieur sénario de test utilise le même jeu de donnée
        private void SeedContext(AppDbContext context)
        {
            context.Author.AddRange([
                new Author() { Id = 1, FirstName = "Della", LastName = "Duck", Pseudo = "SuperDella", BirthDate = new DateTime(1990, 6, 7) },
                new Author() { Id = 2, FirstName = "Zaza", LastName = "Vanderquack", Pseudo = null, BirthDate = new DateTime(2012, 12, 19) },
                new Author() { Id = 3, FirstName = "Balthazar", LastName = "Picsou", Pseudo = null, BirthDate = new DateTime(1900, 11, 11) },
                new Author() { Id = 4, FirstName = "Donald", LastName = "Duck", Pseudo = "Paperino", BirthDate = new DateTime(1988, 6, 9) },
                new Author() { Id = 5, FirstName = "Daisy", LastName = "Duck", Pseudo = "DaisyD", BirthDate = new DateTime(1989, 6, 7) },
                new Author() { Id = 6, FirstName = "Riri", LastName = "Duck", Pseudo = "Huey", BirthDate = new DateTime(2010, 10, 17) },
                new Author() { Id = 9, FirstName = "Géo", LastName = "Trouvetou", Pseudo = null, BirthDate = new DateTime(1960, 5, 15) },
                new Author() { Id = 10, FirstName = "Flagada", LastName = "Jones", Pseudo = "Goofy", BirthDate = new DateTime(1985, 5, 25) },
                new Author() { Id = 11, FirstName = "Gontran", LastName = "Bonheur", Pseudo = null, BirthDate = new DateTime(1987, 1, 7) },
                new Author() { Id = 12, FirstName = "Miss", LastName = "Tick", Pseudo = "MagicaDeSpell", BirthDate = new DateTime(1905, 12, 12) },
                new Author() { Id = 14, FirstName = "Archibald", LastName = "Gripsou", Pseudo = "FlintheartGlomgold", BirthDate = new DateTime(1902, 9, 18) },
                new Author() { Id = 15, FirstName = "Léna", LastName = "De Sortilège", Pseudo = "Léna", BirthDate = new DateTime(2009, 8, 12) }
            ]);
            context.SaveChanges();
        }

        // Méthodes test du repositorie
        [Fact]
        public void Get_AllAuthorWithEmptyDB__ShouldReturnsEmptyArray()
        {
            // Arrange
            dbContext = new AppDbContext(options);
            IAuthorRepository authorRepository = new AuthorRepository(dbContext);

            int offset = 0;
            int limit = 5;

            int expectedNbResult = 0;
            IEnumerable<Author> expected = [];

            // Action
            IEnumerable<Author> actual = authorRepository.GetAll(offset, limit);
            int actualNbResult = actual.Count();

            // Assert
            Assert.Equal(expectedNbResult, actualNbResult);
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Get_AllAuthorWithSeedDB__ShouldReturnsFiveFirstResult()
        {
            // Arrange
            dbContext = new AppDbContext(options);
            SeedContext(dbContext);

            int offset = 0;
            int limit = 5;
            IAuthorRepository authorRepository = new AuthorRepository(dbContext);

            int expectedNbResult = 5;
            IEnumerable<Author> expected = [
                new Author() { Id = 1, FirstName = "Della", LastName = "Duck", Pseudo = "SuperDella", BirthDate = new DateTime(1990, 6, 7) },
                new Author() { Id = 2, FirstName = "Zaza", LastName = "Vanderquack", Pseudo = null, BirthDate = new DateTime(2012, 12, 19) },
                new Author() { Id = 3, FirstName = "Balthazar", LastName = "Picsou", Pseudo = null, BirthDate = new DateTime(1900, 11, 11) },
                new Author() { Id = 4, FirstName = "Donald", LastName = "Duck", Pseudo = "Paperino", BirthDate = new DateTime(1988, 6, 9) },
                new Author() { Id = 5, FirstName = "Daisy", LastName = "Duck", Pseudo = "DaisyD", BirthDate = new DateTime(1989, 6, 7) }
            ];

            // Action
            IEnumerable<Author> actual = authorRepository.GetAll(offset, limit);
            int actualNbResult = actual.Count();

            // Assert
            Assert.Equal(expectedNbResult, actualNbResult);
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Get_AllAuthorWithSeedDBAndPagination__ShouldReturnsCompleteResult()
        {
            // Arrange
            dbContext = new AppDbContext(options);
            SeedContext(dbContext);

            int offset = 5;
            int limit = 5;
            IAuthorRepository authorRepository = new AuthorRepository(dbContext);

            int expectedNbResult = 5;
            IEnumerable<Author> expected = [
                new Author() { Id = 6, FirstName = "Riri", LastName = "Duck", Pseudo = "Huey", BirthDate = new DateTime(2010, 10, 17) },
                new Author() { Id = 9, FirstName = "Géo", LastName = "Trouvetou", Pseudo = null, BirthDate = new DateTime(1960, 5, 15) },
                new Author() { Id = 10, FirstName = "Flagada", LastName = "Jones", Pseudo = "Goofy", BirthDate = new DateTime(1985, 5, 25) },
                new Author() { Id = 11, FirstName = "Gontran", LastName = "Bonheur", Pseudo = null, BirthDate = new DateTime(1987, 1, 7) },
                new Author() { Id = 12, FirstName = "Miss", LastName = "Tick", Pseudo = "MagicaDeSpell", BirthDate = new DateTime(1905, 12, 12) }
            ];

            // Action
            IEnumerable<Author> actual = authorRepository.GetAll(offset, limit);
            int actualNbResult = actual.Count();

            // Assert
            Assert.Equal(expectedNbResult, actualNbResult);
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Get_AllAuthorWithSeedDBAndPagination__ShouldReturnsPartialResult()
        {
            // Arrange
            dbContext = new AppDbContext(options);
            SeedContext(dbContext);

            int offset = 10;
            int limit = 5;
            IAuthorRepository authorRepository = new AuthorRepository(dbContext);

            int expectedNbResult = 2;
            IEnumerable<Author> expected = [
                new Author() { Id = 14, FirstName = "Archibald", LastName = "Gripsou", Pseudo = "FlintheartGlomgold", BirthDate = new DateTime(1902, 9, 18) },
                new Author() { Id = 15, FirstName = "Léna", LastName = "De Sortilège", Pseudo = "Léna", BirthDate = new DateTime(2009, 8, 12) }
            ];

            // Action
            IEnumerable<Author> actual = authorRepository.GetAll(offset, limit);
            int actualNbResult = actual.Count();

            // Assert
            Assert.Equal(expectedNbResult, actualNbResult);
            Assert.Equivalent(expected, actual);
        }
    }
}
