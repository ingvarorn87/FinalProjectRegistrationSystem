using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL;
using VideoMenuDAL.Entities;


namespace VideoMenuBLL.Services
{
    class GenreService : IGenreService
    {
        DALFacade facade;
        public GenreService(DALFacade facade)
        {
            this.facade = facade;
        }

        public GenreBO Create(GenreBO gen)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newGen = uow.GenreRepository.Create(Convert(gen));
                uow.Complete();
                return Convert(newGen);
            }
        }

        public List<GenreBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.GenreRepository.GetAll();
                return uow.GenreRepository.GetAll().Select(g => Convert(g)).ToList();
            }
        }

        public GenreBO Update(GenreBO gen)
        {
            throw new NotImplementedException();
        }

        private Genre Convert(GenreBO vid)
        {
            return new Genre()
            {
                Id = vid.Id,
                Name = vid.Name
            };
        }
        private GenreBO Convert(Genre vid)
        {
            return new GenreBO()
            {
                Id = vid.Id,
                Name = vid.Name
            };
        }
    }
}
