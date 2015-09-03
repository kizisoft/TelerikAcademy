namespace MusicData.Data
{
    using System.Data.Entity;

    using MusicData.Models;

    public class MusicDataContext : DbContext, IMusicDataContext
    {
        public MusicDataContext()
            : base("MusicDataConnectionDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicDataContext, Configuration>());
        }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Song> Songs { get; set; }


        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}