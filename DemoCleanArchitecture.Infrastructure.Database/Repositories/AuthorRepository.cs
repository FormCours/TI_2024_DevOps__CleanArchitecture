using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DemoCleanArchitecture.Infrastructure.Database.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll(int offset, int limit)
        {
            return _context.Author
                .AsNoTracking()
                .Skip(offset).Take(limit)
                .ToList();
        }

        public Author? GetById(long id)
        {
            return _context.Author.SingleOrDefault(a => a.Id == id);
        }

        public Author Create(Author data)
        {
            EntityEntry<Author> element = _context.Author.Add(data);
            _context.SaveChanges();

            return element.Entity;
        }

        public Author Update(long id, Author data)
        {
            Author author = _context.Author.Single(a => a.Id == id);
            author.FirstName = data.FirstName;
            author.LastName = data.LastName;
            author.BirthDate = data.BirthDate;
            author.Pseudo = data.Pseudo;

            _context.SaveChanges();
            return author;
        }
        public bool Delete(long id)
        {
            Author? target = _context.Author.SingleOrDefault(a => a.Id == id);

            if (target is null)
            {
                return false;
            }

            _context.Remove(target);
            _context.SaveChanges();
            return true;
        }
    }
}
