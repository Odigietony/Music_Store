using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Reviews
    {
        public int ReviewsID { get; set; }
        public int AlbumsID { get; set; }
        public Albums Albums { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerEmail { get; set; }
        public string Content { get; set; }
    }
}