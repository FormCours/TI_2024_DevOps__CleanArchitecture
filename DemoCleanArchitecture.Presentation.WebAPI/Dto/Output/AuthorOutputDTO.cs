namespace DemoCleanArchitecture.Presentation.WebAPI.Dto.Output
{
    public class AuthorOutputDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string? Pseudo { get; set; }
    }

    public class AuthorDetailOutputDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string? Pseudo { get; set; }
        public required string? BirthDate { get; set; }
    }
}
