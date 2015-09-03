namespace MusicData.ConsoleClient.Models
{
    using System;

    public class SongModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTimeOffset Year { get; set; }

        public Genre Genre { get; set; }

        public int ArtistID { get; set; }

        public int? AlbumID { get; set; }

        public string Album { get; set; }
    }
}