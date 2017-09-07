using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ArtistSongsViewModel
    {
        public int ArtistID { get; set; }
        public int SongsID { get; set; }
        public Artist Artist { get; set; }
        public List<Songs> Songs { get; set; }        
    }
}