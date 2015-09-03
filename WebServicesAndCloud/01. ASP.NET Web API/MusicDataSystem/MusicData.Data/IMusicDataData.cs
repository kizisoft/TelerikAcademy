namespace MusicData.Data
{
    using MusicData.Models;
    using MusicData.Repositories;

    public interface IMusicDataData
    {
        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Album> Albums { get; }

        IGenericRepository<Song> Songs { get; }

        void SaveChanges();
    }
}