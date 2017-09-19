using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Entities;


namespace VideoMenuDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        private static int Id = 1;
        private static List<Video> Videos = new List<Video>();

        public Video Create(Video vid)
        {
            Video newVideo;
            Videos.Add(newVideo = new Video()
            {
                Id = Id++,
                Name = vid.Name,
                
            });
            return newVideo;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            Videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(Videos);
        }
    }
}
