using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.Presentation.WebAPI.Dto.Input
{
    public class MemberCredentialInputDTO
    {
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public required string Email { get; set; }
        
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$")]
        [MinLength(8)]
        public required string Password { get; set; }
    }
}
