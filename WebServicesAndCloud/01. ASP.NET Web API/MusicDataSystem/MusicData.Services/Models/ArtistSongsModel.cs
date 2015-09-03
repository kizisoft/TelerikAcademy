namespace MusicData.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicData.Models;

    public class ArtistSongsModel : ArtistModel
    {
        public static Expression<Func<Artist, ArtistSongsModel>> FromArtistWithSongs
        {
            get
            {
                return artist => new ArtistSongsModel()
                {
                    ID = artist.ID,
                    FirstName = artist.FirstName,
                    LastName = artist.LastName,
                    DateOfBirth = artist.DateOfBirth,
                    Country = artist.Country,
                    Songs = artist.Songs.Select(song => new SongModel()
                    {
                        ID = song.ID,
                        Title = song.Title,
                        Genre = song.Genre,
                        Year = song.Year
                    })
                };
            }
        }

        public ArtistSongsModel()
        {
            this.Songs = new HashSet<SongModel>();
        }

        public virtual IEnumerable<SongModel> Songs { get; set; }
    }
}