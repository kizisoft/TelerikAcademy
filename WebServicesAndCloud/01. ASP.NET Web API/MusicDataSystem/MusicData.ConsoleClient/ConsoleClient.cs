namespace MusicData.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;

    using MusicData.ConsoleClient.Modules;

    class ConsoleClient
    {
        private const string ServerUri = "http://localhost:46666/api/";
        private const string HeaderValue = "application/json";

        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(ServerUri)
        };

        static void Main(string[] args)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HeaderValue));

            var isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Music Data System Console Client");
                Console.WriteLine();
                Console.WriteLine("( 1 ) Artists");
                Console.WriteLine("( 2 ) Albums");
                Console.WriteLine("( 3 ) Songs");
                Console.WriteLine("( 0 ) Exit");
                Console.WriteLine();
                Console.Write("Enter a number [0..3]:");
                var key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1': ArtistsMenu();
                        break;
                    case '2': AlbumsMenu();
                        break;
                    case '3': SongsMenu();
                        break;
                    case '0': isRunning = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Incorrect choice!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private static void ArtistsMenu()
        {
            var artistsClient = new ArtistsClient(client);
            var isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Music Data System Console Client");
                Console.WriteLine("            Artists");
                Console.WriteLine();
                Console.WriteLine("( 1 ) Create Artist");
                Console.WriteLine("( 2 ) Get All Artists");
                Console.WriteLine("( 3 ) Get Artist by ID");
                Console.WriteLine("( 4 ) Update Artist");
                Console.WriteLine("( 5 ) Delete Artist");
                Console.WriteLine("( 6 ) Get Artist's Albums");
                Console.WriteLine("( 7 ) Get Artist's Songs");
                Console.WriteLine("( 8 ) Add Artist's Albums");
                Console.WriteLine("( 0 ) Exit");
                Console.WriteLine();
                Console.Write("Enter a number [0..8]:");
                var key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1': artistsClient.CreateArtist();
                        break;
                    case '2': artistsClient.GetAllArtists();
                        break;
                    case '3': artistsClient.GetArtist();
                        break;
                    case '4': artistsClient.UpdateArtist();
                        break;
                    case '5': artistsClient.DeleteArtist();
                        break;
                    case '6': artistsClient.GetArtistAlbums();
                        break;
                    case '7': artistsClient.GetArtistSongs();
                        break;
                    case '8': artistsClient.AddArtistAlbum();
                        break;
                    case '0': isRunning = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Incorrect choice!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private static void AlbumsMenu()
        {
            var albumsClient = new AlbumsClient(client);
            var isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Music Data System Console Client");
                Console.WriteLine("            Albums");
                Console.WriteLine();
                Console.WriteLine("( 1 ) Create Album");
                Console.WriteLine("( 2 ) Get All Albums");
                Console.WriteLine("( 3 ) Get Album by ID");
                Console.WriteLine("( 4 ) Update Album");
                Console.WriteLine("( 5 ) Delete Album");
                Console.WriteLine("( 6 ) Get Album's Artists");
                Console.WriteLine("( 7 ) Get Album's Songs");
                Console.WriteLine("( 0 ) Exit");
                Console.WriteLine();
                Console.Write("Enter a number [0..7]:");
                var key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1': albumsClient.CreateAlbum();
                        break;
                    case '2': albumsClient.GetAllAlbums();
                        break;
                    case '3': albumsClient.GetAlbum();
                        break;
                    case '4': albumsClient.UpdateAlbum();
                        break;
                    case '5': albumsClient.DeleteAlbum();
                        break;
                    case '6': albumsClient.GetAlbumArtists();
                        break;
                    case '7': albumsClient.GetAlbumSongs();
                        break;
                    case '0': isRunning = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Incorrect choice!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private static void SongsMenu()
        {
            var songsClient = new SongsClient(client);
            var isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Music Data System Console Client");
                Console.WriteLine("            Songs");
                Console.WriteLine();
                Console.WriteLine("( 1 ) Create Song");
                Console.WriteLine("( 2 ) Get All Songs");
                Console.WriteLine("( 3 ) Get Song by ID");
                Console.WriteLine("( 4 ) Update Song");
                Console.WriteLine("( 5 ) Delete Song");
                Console.WriteLine("( 6 ) Add Song's Artist");
                Console.WriteLine("( 0 ) Exit");
                Console.WriteLine();
                Console.Write("Enter a number [0..6]:");
                var key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1': songsClient.CreateSong();
                        break;
                    case '2': songsClient.GetAllSongs();
                        break;
                    case '3': songsClient.GetSong();
                        break;
                    case '4': songsClient.UpdateSong();
                        break;
                    case '5': songsClient.DeleteSong();
                        break;
                    case '6': songsClient.AddSongArtist();
                        break;
                    case '0': isRunning = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Incorrect choice!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}