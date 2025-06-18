using DemoCleanArchitecture.ApplicationCore.Interfaces.Services;
using DemoCleanArchitecture.Domain.Exceptions;
using DemoCleanArchitecture.Domain.Modeles;
using DemoCleanArchitecture.Presentation.WebAPI.Dto.Input;
using DemoCleanArchitecture.Presentation.WebAPI.Tools;
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
        private readonly TokenTool _tokenTool;
        public AuthController(IMemberService memberService, TokenTool tokenTool)
        {
            _memberService = memberService;
            _tokenTool = tokenTool;
        }

        private IActionResult TokenResponse(Member member)
        {
            string token = _tokenTool.Generate(new TokenTool.Data()
            {
                MemberId = member.Id,
                Role = member.Role
            });
            return Ok(new { token });
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register(MemberCredentialInputDTO memberCredential)
        {
            try
            {
                Member member = _memberService.Register(memberCredential.Email, memberCredential.Password);

                return TokenResponse(member);
            }
            catch (MemberException e)
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
                
                return TokenResponse(member);
            }
            catch (MemberException) 
            {
                return BadRequest("Bad credentials");
            }
        }
    }
}
