using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Entities;


namespace VideoMenuDAL
{
    public interface IGenreRepository
    {
        Genre Create(Genre gen);

        List<Genre> GetAll();
        
    }
}
