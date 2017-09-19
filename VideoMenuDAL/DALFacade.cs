using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Repositories;
using VideoMenuDAL.UOW;

namespace VideoMenuDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository { 
            //get {return new VideoRepositoryFakeDB();}
            get
            {
                return new VideoRepositoryEFMemory(new InMemoryContext());
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMem();
            }
        }
    }
}
