using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.Presentation.WebAPI.Dto.Input
{
    public class AuthorInputDTO
    {
        [Required]
        [MinLength(2), MaxLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(50)]
        public required string LastName { get; set; }

        [MinLength(2), MaxLength(50)]
        public required string? Pseudo { get; set; }

        public required DateTime? BirthDate { get; set; }
    }
}
