using System;
using System.Collections.Generic;
using System.Text;


namespace VideoMenuBLL.BusinessObjects

{
    public class VideoBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreBO Genre { get; set; }
    }
}
