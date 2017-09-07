using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Singles
    {
        public int SinglesID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public Artist Artist { get; set; }
    }
}