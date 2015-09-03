namespace MusicData.ConsoleClient.Modules
{
    internal abstract class AbstractClient
    {
        internal const string Artists = "Artists/";
        internal const string Albums = "Albums/";
        internal const string Songs = "Songs/";

        internal const string ActionGet = "GET/";
        internal const string ActionGetWithAlbums = "GETWITHALBUMS/";
        internal const string ActionGetWithSongs = "GETWITHSONGS/";
        internal const string ActionGetWithArtists = "GETWITHARTISTS/";
        internal const string ActionGetAll = "GETALL/";
        internal const string ActionAddSongArtist = "ADDSONGARTIST?";
        internal const string ActionAddArtistAlbum = "ADDARTISTALBUM?";
        internal const string ActionAdd = "ADD/";
        internal const string ActionUpdate = "UPDATE/";
        internal const string ActionDelete = "DELETE/";
    }
}