using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    
    public class Artist
    {
         
        public int ArtistID { get; set; }
        [Display(Name ="Artist NAme")]
        public string ArtistName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public List<Singles> Singles { get; set; }
        public List<Albums> Albums { get; set; }
        public string ArtistImage { get; set; }
    }
}