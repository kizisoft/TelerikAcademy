namespace MusicData.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.OData;

    using MusicData.Data;

    [EnableQuery]
    public class ArtistsController : ApiController
    {
        private const string BabRequestMessage = "Such Artist does not exists!";

        private IMusicDataData data;

        public ArtistsController()
            : this(new MusicDataData())
        {

        }

        public ArtistsController(IMusicDataData data)
        {
            this.data = data;
        }

        [HttpGet]
        [ResponseType(typeof(ArtistModel))]
        public IHttpActionResult Get(int id)
        {
            var artist = this.data.Artists.Get(id);
            if (artist == null)
            {
                return NotFound();
            }

            var artistModel = ArtistModel.FromArtist(artist);
            return Ok(artistModel);
        }

        [HttpGet]
        [ResponseType(typeof(ArtistAlbumsModel))]
        public IHttpActionResult GetWithAlbums(int id)
        {
            var artistModel = this.data.Artists.GetAll().Where(a => a.ID == id).Select(ArtistAlbumsModel.FromArtistWithAlbums).FirstOrDefault();

            if (artistModel == null)
            {
                return NotFound();
            }

            return Ok(artistModel);
        }

        [HttpGet]
        [ResponseType(typeof(ArtistSongsModel))]
        public IHttpActionResult GetWithSongs(int id)
        {
            var artistModel = this.data.Artists.GetAll().Where(a => a.ID == id).Select(ArtistSongsModel.FromArtistWithSongs).FirstOrDefault();

            if (artistModel == null)
            {
                return NotFound();
            }

            return Ok(artistModel);
        }

        [HttpGet]
        [ResponseType(typeof(IList<ArtistModel>))]
        public IHttpActionResult GetAll()
        {
            var artistModels = this.data.Artists.GetAll().Select(ArtistModel.FromArtistExpression);
            return Ok(artistModels);
        }

        [HttpPost]
        [ResponseType(typeof(ArtistModel))]
        public IHttpActionResult Add(ArtistModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAtist = ArtistModel.ToArtist(artistModel);

            this.data.Artists.Add(newAtist);
            this.data.SaveChanges();

            artistModel.ID = newAtist.ID;
            return Ok(artistModel);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddArtistAlbum(int artistId, int albumId)
        {
            var artist = this.data.Artists.Get(artistId);
            if (artist == null)
            {
                return BadRequest("Such artist does not exists - invalid id!");
            }

            var album = this.data.Albums.Get(albumId);
            if (album == null)
            {
                return BadRequest("Such album does not exists - invalid id!");
            }

            artist.Albums.Add(album);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [ResponseType(typeof(ArtistModel))]
        public IHttpActionResult Update(int id, ArtistModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingArtist = this.data.Artists.Get(id);
            if (existingArtist == null)
            {
                return BadRequest(BabRequestMessage);
            }

            ArtistModel.ToArtist(artistModel, existingArtist);

            this.data.Artists.Update(existingArtist);
            this.data.SaveChanges();

            return Ok(artistModel);
        }

        [HttpDelete]
        [ResponseType(typeof(ArtistModel))]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.data.Artists.Get(id);
            if (existingArtist == null)
            {
                return BadRequest(BabRequestMessage);
            }

            var artistModel = ArtistModel.FromArtist(existingArtist);

            this.data.Artists.Delete(existingArtist);
            this.data.SaveChanges();

            return Ok(artistModel);
        }
    }
}