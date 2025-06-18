using DemoCleanArchitecture.ApplicationCore.Interfaces.Services;
using DemoCleanArchitecture.Domain.Exceptions;
using DemoCleanArchitecture.Domain.Modeles;
using DemoCleanArchitecture.Presentation.WebAPI.Dto.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCleanArchitecture.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public AuthController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register(MemberCredentialInputDTO memberCredential)
        {
            try
            {
                Member member = _memberService.Register(memberCredential.Email, memberCredential.Password);

                return Ok(new
                {
                    token = "Un magnifique token qui sera dans le commit suivant",
                });
            }
            catch(MemberException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login(MemberCredentialInputDTO memberCredential)
        {
            try
            {
                Member member = _memberService.Login(memberCredential.Email, memberCredential.Password);

                return Ok(new
                {
                    token = "Bah encore un token et on va bientot coder (⊙ˍ⊙)",
                });
            }
            catch (MemberException) 
            {
                return BadRequest("Bad credentials");
            }
        }
    }
}
