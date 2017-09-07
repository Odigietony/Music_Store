using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Songs
    {
        public int SongsID { get; set; }
        public int AlbumsID { get; set; }
        public Albums Albums { get; set; }
        public Artist Artist { get; set; }
        public string SongName { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    
}