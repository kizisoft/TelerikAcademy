namespace MusicData.ConsoleClient.Models
{
    using System;
    using System.Collections.Generic;

    public class ArtistModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }

        public virtual IEnumerable<AlbumModel> Albums { get; set; }

        public virtual IEnumerable<SongModel> Songs { get; set; }
    }
}