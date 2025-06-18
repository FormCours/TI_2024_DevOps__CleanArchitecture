using DemoCleanArchitecture.ApplicationCore.Interfaces.Services;
using DemoCleanArchitecture.Domain.Exceptions;
using DemoCleanArchitecture.Domain.Modeles;
using DemoCleanArchitecture.Presentation.WebAPI.Dto.Input;
using DemoCleanArchitecture.Presentation.WebAPI.Dto.Output;
using DemoCleanArchitecture.Presentation.WebAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCleanArchitecture.Presentation.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthorOutputDTO>))]
        public IActionResult GetAll()
        {
            // TODO Ajouter des QueryParams -> Page/NbElement
            IEnumerable<Author> authors = _authorService.GetAll(1, 20);

            return Ok(authors.Select(a => a.ToDTO()));

            // Utilisation du mapper alternative ↓
            // return Ok(authors.Select(AuthorMapper.ToDTO));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDetailOutputDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetById([FromRoute] long id)
        {
            try
            {
                Author author = _authorService.GetById(id);
                return Ok(author.ToDetailDTO());
            }
            catch (AuthorNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AuthorDetailOutputDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Create([FromBody] AuthorInputDTO author)
        {
            Author authorCreated = _authorService.Create(author.ToModel());

            return CreatedAtAction(
                nameof(GetById), 
                new { id = authorCreated.Id }, 
                authorCreated.ToDetailDTO()
            );
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDetailOutputDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Update([FromRoute] long id, [FromBody] AuthorInputDTO author)
        {
            // TODO Implement this methode :o
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
