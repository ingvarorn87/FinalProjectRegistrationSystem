using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
    }
}
