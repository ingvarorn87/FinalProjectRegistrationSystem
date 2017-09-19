using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;


namespace VideoMenuBLL
{
    public interface IGenreService
    {
        GenreBO Create(GenreBO gen);

        List<GenreBO> GetAll();
        GenreBO Update(GenreBO gen);

        
    }
}
