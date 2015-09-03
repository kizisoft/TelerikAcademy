namespace MusicData.ConsoleClient.Models
{
    using System;
    using System.Collections.Generic;

    public class AlbumModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Producer { get; set; }

        public virtual IEnumerable<ArtistModel> Artists { get; set; }

        public virtual IEnumerable<SongModel> Songs { get; set; }
    }
}