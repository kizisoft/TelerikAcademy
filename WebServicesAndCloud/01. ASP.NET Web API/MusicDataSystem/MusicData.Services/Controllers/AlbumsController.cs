namespace MusicData.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.OData;

    using MusicData.Data;

    public class AlbumsController : ApiController
    {
        private const string BabRequestMessage = "Such Album does not exists!";

        private IMusicDataData data;

        public AlbumsController()
            : this(new MusicDataData())
        {

        }

        public AlbumsController(IMusicDataData data)
        {
            this.data = data;
        }

        [HttpGet]
        [ResponseType(typeof(AlbumModel))]
        public IHttpActionResult Get(int id)
        {
            var album = this.data.Albums.Get(id);
            if (album == null)
            {
                return NotFound();
            }

            var albumModel = AlbumModel.FromAlbum(album);
            return Ok(albumModel);
        }

        [HttpGet]
        [ResponseType(typeof(AlbumArtistsModel))]
        public IHttpActionResult GetWithArtists(int id)
        {
            var albumtModel = this.data.Albums.GetAll().Where(a => a.ID == id).Select(AlbumArtistsModel.FromAlbumWithArtists).FirstOrDefault();

            if (albumtModel == null)
            {
                return NotFound();
            }

            return Ok(albumtModel);
        }

        [HttpGet]
        [ResponseType(typeof(AlbumSongsModel))]
        public IHttpActionResult GetWithSongs(int id)
        {
            var albumModel = this.data.Albums.GetAll().Where(a => a.ID == id).Select(AlbumSongsModel.FromAlbumWithSongs).FirstOrDefault();

            if (albumModel == null)
            {
                return NotFound();
            }

            return Ok(albumModel);
        }

        [HttpGet]
        [ResponseType(typeof(IQueryable<AlbumModel>))]
        public IHttpActionResult GetAll()
        {
            var albumModels = this.data.Albums.GetAll().Select(AlbumModel.FromAlbumExpression);
            return Ok(albumModels);
        }

        [HttpPost]
        [ResponseType(typeof(AlbumModel))]
        public IHttpActionResult Add(AlbumModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAlbum = AlbumModel.ToAlbum(albumModel);

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();

            albumModel.ID = newAlbum.ID;
            return Ok(albumModel);
        }

        [HttpPut]
        [ResponseType(typeof(AlbumModel))]
        public IHttpActionResult Update(int id, AlbumModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAlbum = this.data.Albums.Get(id);
            if (existingAlbum == null)
            {
                return BadRequest(BabRequestMessage);
            }

            AlbumModel.ToAlbum(albumModel, existingAlbum);

            this.data.Albums.Update(existingAlbum);
            this.data.SaveChanges();

            return Ok(albumModel);
        }

        [HttpDelete]
        [ResponseType(typeof(AlbumModel))]
        public IHttpActionResult Delete(int id)
        {
            var existingAlbum = this.data.Albums.Get(id);
            if (existingAlbum == null)
            {
                return BadRequest(BabRequestMessage);
            }

            var albumModel = AlbumModel.FromAlbum(existingAlbum);

            this.data.Albums.Delete(existingAlbum);
            this.data.SaveChanges();

            return Ok(albumModel);
        }
    }
}