using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DemoCleanArchitecture.Infrastructure.Database.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;
        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public Member Create(Member data)
        {
            EntityEntry<Member> memberCreated = _context.Member.Add(data);
            _context.SaveChanges();

            return memberCreated.Entity;
        }

        public Member? GetByEmail(string email)
        {
            var member = _context.Member
                .Select(m => new { m.Id, m.Email, m.Role })
                .SingleOrDefault(m => m.Email == email);

            if (member is null) return null;

            return new Member()
            {
                Id = member.Id,
                Email = member.Email,
                Role = member.Role,
                Password = null
            };
        }

        public string GetHashPassword(long id)
        {
            return _context.Member.First(m => m.Id == id).Password ?? throw new Exception("No Password O_o");
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetAll(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Member? GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Member Update(long id, Member data)
        {
            throw new NotImplementedException();
        }
    }
}
