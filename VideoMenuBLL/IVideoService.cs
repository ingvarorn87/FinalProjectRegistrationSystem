using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;


namespace VideoMenuBLL
{
    public interface IVideoService
    {
        VideoBO Create(VideoBO vid);

        List<VideoBO> GetAll();
        VideoBO Get(int Id);

        VideoBO Update(VideoBO vid);

        VideoBO Delete(int Id);

    }
}
