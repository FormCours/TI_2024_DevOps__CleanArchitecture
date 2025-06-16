using DemoCleanArchitecture.Domain.Modeles;
using DemoCleanArchitecture.Presentation.WebAPI.Dto.Input;
using DemoCleanArchitecture.Presentation.WebAPI.Dto.Output;

namespace DemoCleanArchitecture.Presentation.WebAPI.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorOutputDTO ToDTO(this Author author)
        {
            return new AuthorOutputDTO()
            {
                Id = author.Id,
                Name = $"{author.FirstName} {author.LastName}",
                Pseudo = author.Pseudo,
            };
        }

        public static AuthorDetailOutputDTO ToDetailDTO(this Author author)
        {
            return new AuthorDetailOutputDTO()
            {
                Id = author.Id,
                Name = $"{author.FirstName} {author.LastName}",
                Pseudo = author.Pseudo,
                BirthDate = author.BirthDate?.ToString("O")
            };
        }

        public static Author ToModel(this AuthorInputDTO authorInput)
        {
            return new Author()
            {
                FirstName = authorInput.FirstName,
                LastName = authorInput.LastName,
                Pseudo = authorInput.Pseudo,
                BirthDate = authorInput.BirthDate
            };
        }
    }
}

