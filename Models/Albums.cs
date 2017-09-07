using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Albums
    {
        public int AlbumsID { get; set; }
        public int ArtistID { get; set; }
        public List<Songs> Songs { get; set; }
        public Artist Artist { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Reviews> Reviews { get; set; }
        public string PictureArt { get; set; }
    }
}