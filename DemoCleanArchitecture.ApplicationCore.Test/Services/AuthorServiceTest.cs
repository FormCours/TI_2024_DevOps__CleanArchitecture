using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.ApplicationCore.Services;
using DemoCleanArchitecture.ApplicationCore.Test.Fakes;
using DemoCleanArchitecture.Domain.Modeles;
using Moq;

namespace DemoCleanArchitecture.ApplicationCore.Test.Services
{
    public class AuthorServiceTest
    {
        // Exemple de test avec un "fake" custom
        [Fact]
        public void Get_AllAuthor_ShouldReturnsAuthorResult()
        {
            // Arrange
            IAuthorRepository authorRepository = new FakeForGetAuthorRepository();
            AuthorService authorService = new AuthorService(authorRepository);

            List<Author> expectedResult = [
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
            int expectedNbResult = 3;

            // Action
            IEnumerable<Author> actualResult = authorService.GetAll(1, 10);

            // Assert
            Assert.Equal(expectedNbResult, actualResult.Count());
            Assert.Equivalent(expectedResult, actualResult);
        }

        [Fact]
        public void Get_AuthorById_ShouldReturnsOneAuthor()
        {
            // Arrange
            IAuthorRepository authorRepository = new FakeForGetAuthorRepository();
            AuthorService authorService = new AuthorService(authorRepository);
            var expectedResult = new Author()
            {
                Id = 2,
                FirstName = "Romain",
                LastName = "Otto",
                Pseudo = "Ryuji",
                BirthDate = new DateTime(2000, 12, 11),
            };

            // Action
            var actualResult = authorService.GetById(2);

            // Assert
            Assert.Equivalent(expectedResult, actualResult);
        }


        // Exemple de test avec le package "Moq"
        [Fact]
        public void Get_AllAuthor_ShouldReturnsAuthorResult_WithMoq()
        {
            // Mock
            List<Author> mockResult = [
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
            int offsetQuery = 0;
            int limitQuery = 10;

            Mock<IAuthorRepository> authorRepository = new Mock<IAuthorRepository>();
            authorRepository.Setup(repo => repo.GetAll(offsetQuery, limitQuery))
                            .Returns(mockResult);

            // Arrange
            AuthorService authorService = new AuthorService(authorRepository.Object);

            List<Author> expectedResult = [
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
            int expectedNbResult = 3;
            int pageServiceQuery = 1;
            int limitServiceQuery = 10;

            // Action
            IEnumerable<Author> actualResult = authorService.GetAll(pageServiceQuery, limitServiceQuery);

            // Assert
            Assert.Equal(expectedNbResult, actualResult.Count());
            Assert.Equivalent(expectedResult, actualResult);
            authorRepository.Verify(repo => repo.GetAll(offsetQuery, limitQuery), Times.Once());
        }

        [Fact]
        public void Get_AuthorById_ShouldReturnsOneAuthor_WithMoq()
        {
            // Mock with Moq
            var mockResult = new Author()
            {
                Id = 2,
                FirstName = "Romain",
                LastName = "Otto",
                Pseudo = "Ryuji",
                BirthDate = new DateTime(2000, 12, 11),
            };

            Mock<IAuthorRepository> authorRepository = new Mock<IAuthorRepository>();
            authorRepository.Setup(repo => repo.GetById(2))
                            .Returns(mockResult);

            // Arrange
            AuthorService authorService = new AuthorService(authorRepository.Object);
            var expectedResult = new Author()
            {
                Id = 2,
                FirstName = "Romain",
                LastName = "Otto",
                Pseudo = "Ryuji",
                BirthDate = new DateTime(2000, 12, 11),
            };

            // Action
            var actualResult = authorService.GetById(2);

            // Assert
            Assert.Equivalent(expectedResult, actualResult);
            authorRepository.Verify(repo => repo.GetById(2), Times.Once());
        }
    }
}
