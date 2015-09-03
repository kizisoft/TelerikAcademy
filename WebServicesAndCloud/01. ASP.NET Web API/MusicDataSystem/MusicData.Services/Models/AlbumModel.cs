namespace MusicData.Services
{
    using System;
    using System.Linq.Expressions;

    using MusicData.Models;

    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbumExpression
        {
            get
            {
                return album => new AlbumModel()
                {
                    ID = album.ID,
                    Title = album.Title,
                    Producer = album.Producer,
                    Year = album.Year,
                };
            }
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public DateTimeOffset? Year { get; set; }

        public string Producer { get; set; }

        internal static AlbumModel FromAlbum(Album album)
        {
            return new AlbumModel()
            {
                ID = album.ID,
                Title = album.Title,
                Producer = album.Producer,
                Year = album.Year
            };
        }

        internal static Album ToAlbum(AlbumModel albumModel, Album album = null)
        {
            if (album == null)
            {
                album = new Album();
            }

            album.ID = albumModel.ID;
            album.Title = albumModel.Title;
            album.Producer = albumModel.Producer;
            album.Year = albumModel.Year;

            return album;
        }
    }
}