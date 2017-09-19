﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL;
using VideoMenuDAL.Entities;


namespace VideoMenuBLL.Services
{
    class VideoService : IVideoService
    {
        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(Convert(vid));
                uow.Complete();
                return Convert(newVid);
            }
             
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return Convert(newVid);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.VideoRepository.GetAll();
                return uow.VideoRepository.GetAll().Select(v => Convert(v)).ToList();
            }
        }

        public VideoBO Update(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDb = uow.VideoRepository.Get(vid.Id);
                if (videoFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }
                videoFromDb.Name = vid.Name;
                
                uow.Complete();
                return Convert(videoFromDb);
            }
            
        }

        private Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                Name = vid.Name,
                
            };
        }

        private VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                Id = vid.Id,
                Name = vid.Name,
                
            };
        }
    }
}
