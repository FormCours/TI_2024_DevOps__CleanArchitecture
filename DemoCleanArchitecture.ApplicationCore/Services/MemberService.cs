using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.ApplicationCore.Interfaces.Services;
using DemoCleanArchitecture.Domain.Constants;
using DemoCleanArchitecture.Domain.Enums;
using DemoCleanArchitecture.Domain.Exceptions;
using DemoCleanArchitecture.Domain.Modeles;
using Isopoh.Cryptography.Argon2;

namespace DemoCleanArchitecture.ApplicationCore.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Member Register(string email, string password)
        {
            if (_memberRepository.GetByEmail(email) is not null) {
                throw new AccountAlreadyExistMemberException();
            }

            // Validation mail -> Ban list
            if(EmailConstant.BlockedDomains.Any(bd => email.ToLower().EndsWith(bd)))
            {
                throw new ForbiddenEmailMemberException();
            }

            Member data = new Member()
            {
                Email = email,
                Password = Argon2.Hash(password),
                Role = MemberRoleEnum.USER
            };
             
            return _memberRepository.Create(data);
        }
        public Member Login(string email, string password)
        {
            Member? member = _memberRepository.GetByEmail(email);
            if(member is null)
            {
                throw new AccountNoExistMemberException();
            }

            string hashPassword = _memberRepository.GetHashPassword(member.Id);
            if(!Argon2.Verify(hashPassword, password))
            {
                throw new InvalidCredentialsMemberException();
            }

            return member;
        }
    }
}
