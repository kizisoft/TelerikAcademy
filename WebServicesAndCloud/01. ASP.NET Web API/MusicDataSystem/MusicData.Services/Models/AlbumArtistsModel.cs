namespace MusicData.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicData.Models;

    public class AlbumArtistsModel : AlbumModel
    {
        public static Expression<Func<Album, AlbumArtistsModel>> FromAlbumWithArtists
        {
            get
            {
                return album => new AlbumArtistsModel()
                {
                    ID = album.ID,
                    Title = album.Title,
                    Producer = album.Producer,
                    Year = album.Year,
                    Artists = album.Artists.Select(artist => new ArtistModel()
                    {
                        ID = artist.ID,
                        FirstName = artist.FirstName,
                        LastName = artist.LastName,
                        DateOfBirth = artist.DateOfBirth,
                        Country = artist.Country
                    })
                };
            }
        }

        public virtual IEnumerable<ArtistModel> Artists { get; set; }
    }
}