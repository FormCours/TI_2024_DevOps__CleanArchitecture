using Microsoft.EntityFrameworkCore;

namespace DemoCleanArchitecture.Infrastructure.Database.Test
{
    public class RepositoryTestBase : IDisposable
    {
        protected readonly DbContextOptions<AppDbContext> options;
        protected AppDbContext? dbContext;

        public RepositoryTestBase()
        {
            // Option pour générer le DBContext en "In mémory"
            // Le nom de la DB est généré aleatoirement pour assuré sur unicité de la DB
            options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Le "dbContext" sera généré dans chaque test pour assuré leur isolation
        }

        public void Dispose()
        {
            // Cleanup de la DB après chaque test
            dbContext?.Database?.EnsureDeleted();
            dbContext?.Dispose();
        }
    }
}
