namespace MusicData.Services
{
    using System;
    using System.Linq.Expressions;

    using MusicData.Models;

    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtistExpression
        {
            get
            {
                return artist => new ArtistModel()
                {
                    ID = artist.ID,
                    FirstName = artist.FirstName,
                    LastName = artist.LastName,
                    DateOfBirth = artist.DateOfBirth,
                    Country = artist.Country
                };
            }
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }

        internal static ArtistModel FromArtist(Artist artist)
        {
            return new ArtistModel()
            {
                FirstName = artist.FirstName,
                LastName = artist.LastName,
                DateOfBirth = artist.DateOfBirth,
                Country = artist.Country
            };
        }

        internal static Artist ToArtist(ArtistModel artistModel, Artist artist = null)
        {
            if (artist == null)
            {
                artist = new Artist();
            }

            artist.FirstName = artistModel.FirstName;
            artist.LastName = artistModel.LastName;
            artist.DateOfBirth = artistModel.DateOfBirth;
            artist.Country = artistModel.Country;

            return artist;
        }
    }
}