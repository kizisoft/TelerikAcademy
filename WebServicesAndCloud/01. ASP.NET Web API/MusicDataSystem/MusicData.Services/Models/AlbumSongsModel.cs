namespace MusicData.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicData.Models;

    public class AlbumSongsModel : AlbumModel
    {
        public static Expression<Func<Album, AlbumSongsModel>> FromAlbumWithSongs
        {
            get
            {
                return album => new AlbumSongsModel()
                {
                    ID = album.ID,
                    Title = album.Title,
                    Producer = album.Producer,
                    Year = album.Year,
                    Songs = album.Songs.Select(song => new SongModel()
                    {
                        ID = song.ID,
                        Title = song.Title,
                        Genre = song.Genre,
                        Year = song.Year
                    })
                };
            }
        }

        public virtual IEnumerable<SongModel> Songs { get; set; }
    }
}