namespace MusicData.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicData.Models;

    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSongExpression
        {
            get
            {
                return song => new SongModel()
                {
                    ID = song.ID,
                    Title = song.Title,
                    Year = song.Year,
                    Genre = song.Genre,
                    AlbumID = song.AlbumID,
                    Album = song.Album.Title
                };
            }
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public DateTimeOffset? Year { get; set; }

        public Genre Genre { get; set; }

        public int? AlbumID { get; set; }

        public virtual string Album { get; set; }

        internal static SongModel FromSong(Song song)
        {
            return new SongModel()
            {
                Title = song.Title,
                Year = song.Year,
                Genre = song.Genre,
                AlbumID = song.AlbumID,
                Album = song.Album.Title
            };
        }

        internal static Song ToSong(SongModel songModel, Song song = null)
        {
            if (song == null)
            {
                song = new Song();
            }

            song.Title = songModel.Title;
            song.Year = songModel.Year;
            song.Genre = songModel.Genre;
            song.AlbumID = songModel.AlbumID;

            return song;
        }
    }
}