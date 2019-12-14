using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Models
{
    public class CinematicItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Phase { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
