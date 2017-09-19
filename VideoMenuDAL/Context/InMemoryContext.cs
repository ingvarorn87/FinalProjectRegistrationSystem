
using Microsoft.EntityFrameworkCore;
using VideoMenuDAL.Entities;


namespace VideoMenuDAL.Context
{
    class InMemoryContext : DbContext
    {
        private static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("TheDB").Options;


        public InMemoryContext() : base(options)
        {
            
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
