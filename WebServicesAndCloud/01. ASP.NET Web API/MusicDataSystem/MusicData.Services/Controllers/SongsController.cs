namespace MusicData.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.OData;

    using MusicData.Data;

    public class SongsController : ApiController
    {
        private const string BabRequestMessage = "Such Song does not exists!";

        private IMusicDataData data;

        public SongsController()
            : this(new MusicDataData())
        {

        }

        public SongsController(IMusicDataData data)
        {
            this.data = data;
        }

        [HttpGet]
        [ResponseType(typeof(SongModel))]
        public IHttpActionResult Get(int id)
        {
            var song = this.data.Songs.Get(id);
            if (song == null)
            {
                return NotFound();
            }

            var songModel = SongModel.FromSong(song);
            return Ok(songModel);
        }

        [HttpGet]
        [ResponseType(typeof(IList<SongModel>))]
        public IHttpActionResult GetAll()
        {
            var songModels = this.data.Songs.GetAll().Select(SongModel.FromSongExpression);
            return Ok(songModels);
        }

        [HttpPost]
        [ResponseType(typeof(SongModel))]
        public IHttpActionResult Add(SongModel songModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAtist = SongModel.ToSong(songModel);

            this.data.Songs.Add(newAtist);
            this.data.SaveChanges();

            songModel.ID = newAtist.ID;
            return Ok(songModel);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddSongArtist(int songId, int artistId)
        {
            var song = this.data.Songs.Get(songId);
            if (song == null)
            {
                return BadRequest("Such song does not exists - invalid id!");
            }

            var artist = this.data.Artists.Get(artistId);
            if (artist == null)
            {
                return BadRequest("Such artist does not exists - invalid id!");
            }

            song.Artists.Add(artist);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [ResponseType(typeof(SongModel))]
        public IHttpActionResult Update(int id, SongModel songModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSong = this.data.Songs.Get(id);
            if (existingSong == null)
            {
                return BadRequest(BabRequestMessage);
            }

            SongModel.ToSong(songModel, existingSong);

            this.data.Songs.Update(existingSong);
            this.data.SaveChanges();

            return Ok(songModel);
        }

        [HttpDelete]
        [ResponseType(typeof(SongModel))]
        public IHttpActionResult Delete(int id)
        {
            var existingSong = this.data.Songs.Get(id);
            if (existingSong == null)
            {
                return BadRequest(BabRequestMessage);
            }

            var songModel = SongModel.FromSong(existingSong);

            this.data.Songs.Delete(existingSong);
            this.data.SaveChanges();

            return Ok(songModel);
        }
    }
}