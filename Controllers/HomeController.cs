using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;
using MusicStore.ViewModels;
using System.Data.Entity;
using System.Net;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private MusicStoreContext db = new MusicStoreContext();

        public ActionResult Index()
        {
            IEnumerable<Artist> artist = db.Artists;
            IEnumerable<Songs> songs = db.Songs;
            IEnumerable<Albums> albums = db.Albums;
            ViewBag.ListOfAlbums = albums;
            ViewBag.listOfArtist = artist;
            ViewBag.ListOfSongs = songs;
            return View();
        }

        public ActionResult Songs()
        {
             
            IEnumerable<Songs> songs = db.Songs;
            
            ViewBag.songsList = songs;

            return View();
        }
        [HttpGet]
        public ActionResult SongDetails(int? songid)
        {
            Songs songDetails = db.Songs.Find(songid);
            return View(songDetails);
        }

        public ActionResult Artists()
        {
            IEnumerable<Artist> artists = db.Artists;
            ViewBag.listOfArtists = artists;
            return View();
        }

        [HttpGet]
        public ActionResult ArtistDetails(int? artistid)
        {
            if (artistid ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artistDetails = db.Artists.Find(artistid);
            IEnumerable<Albums> albums = db.Albums;
            ViewBag.AlbumNames = albums;
            if (artistDetails == null)
            {
                return HttpNotFound();
            }
            return View(artistDetails);
        }

        public ActionResult Albums()
        {
            IEnumerable<Albums> albums = db.Albums;
            ViewBag.listOfAlbums= albums;
            return View();
        }

        [HttpGet]
        public ActionResult AlbumDetails(int? albumsid)
        {
            if (albumsid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albums albumsDetails = db.Albums.Find(albumsid);
            IEnumerable<Songs> songs = db.Songs;
            ViewBag.ListOfSongs = songs;
            if (albumsDetails == null)
            {
                return HttpNotFound();
            }
            return View(albumsDetails);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}