﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuDAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
