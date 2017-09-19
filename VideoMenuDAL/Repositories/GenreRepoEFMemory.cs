using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;


namespace VideoMenuDAL.Repositories
{
    class GenreRepoEFMemory : IGenreRepository
    {
        InMemoryContext context;

        public GenreRepoEFMemory(InMemoryContext context)
        {
            this.context = context;
        }

        public Genre Create(Genre gen)
        {
            this.context.Genres.Add(gen);

            return gen;
        }

        public List<Genre> GetAll()
        {
            return this.context.Genres.ToList();
        }
        
    }
}
