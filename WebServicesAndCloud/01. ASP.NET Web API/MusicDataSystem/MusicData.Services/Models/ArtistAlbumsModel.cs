namespace MusicData.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicData.Models;

    public class ArtistAlbumsModel : ArtistModel
    {
        public static Expression<Func<Artist, ArtistAlbumsModel>> FromArtistWithAlbums
        {
            get
            {
                return artist => new ArtistAlbumsModel()
                {
                    ID = artist.ID,
                    FirstName = artist.FirstName,
                    LastName = artist.LastName,
                    DateOfBirth = artist.DateOfBirth,
                    Country = artist.Country,
                    Albums = artist.Albums.Select(album => new AlbumModel()
                    {
                        ID = album.ID,
                        Title = album.Title,
                        Producer = album.Producer,
                        Year = album.Year
                    })
                };
            }
        }

        public ArtistAlbumsModel()
        {
            this.Albums = new HashSet<AlbumModel>();
        }

        public IEnumerable<AlbumModel> Albums { get; set; }
    }
}