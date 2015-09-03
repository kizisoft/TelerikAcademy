namespace MusicData.ConsoleClient.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using MusicData.ConsoleClient.Models;

    internal class SongsClient : AbstractClient
    {
        private HttpClient client;

        internal SongsClient(HttpClient client)
        {
            this.client = client;
        }

        internal void CreateSong()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("         Create Song");
            Console.WriteLine();

            Console.Write("Title: ");
            var title = Console.ReadLine();

            Console.Write("Date of song (dd-mm-yyyy): ");
            var year = DateTimeOffset.Parse(Console.ReadLine());

            Console.Write("Genre: ");
            var genre = int.Parse(Console.ReadLine());

            Console.Write("Album ID: ");
            var albumIDString = Console.ReadLine();
            int? albumID;
            if (albumIDString == string.Empty || albumIDString == null)
            {
                albumID = null;
            }
            else
            {
                albumID = int.Parse(albumIDString);
            }

            Console.WriteLine();
            Console.WriteLine("Creating song...");
            var song = new SongModel
            {
                Title = title,
                Year = year,
                Genre = (Genre)genre,
                AlbumID = albumID
            };

            HttpResponseMessage response = client.PostAsJsonAsync(Songs + ActionAdd, song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        internal void GetAllSongs()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("        Get All Songs");
            Console.WriteLine();
            Console.WriteLine("Getting songs...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Songs + ActionGetAll).Result;
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<SongModel>>().Result;

                foreach (var song in songs)
                {
                    var year = song.Year.Day + "-" + song.Year.Month + "-" + song.Year.Year;
                    Console.WriteLine("[ID]{0} [Title]{1}, [Genre]{2}, [Year]{3}, [Album]{4}", song.ID, song.Title, song.Genre, year, song.Album);
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        internal void GetSong()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("       Get Song By ID");
            Console.WriteLine();

            Console.Write("Artist ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Getting song...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Songs + ActionGet + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<SongModel>().Result;
                var year = song.Year.Day + "-" + song.Year.Month + "-" + song.Year.Year;
                Console.WriteLine("[ID]{0} [Title]{1} [Year]{2} [Genre]{3} [Album]{4}", song.ID, song.Title, year, song.Genre, song.Album);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine();
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        internal void UpdateSong()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("         Update Song");
            Console.WriteLine();

            Console.Write("Song ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Title: ");
            var title = Console.ReadLine();

            Console.Write("Date of song (dd-mm-yyyy): ");
            var year = DateTimeOffset.Parse(Console.ReadLine());

            Console.Write("Genre: ");
            var genre = int.Parse(Console.ReadLine());

            Console.Write("Album ID: ");
            var albumIDString = Console.ReadLine();
            int? albumID;
            if (albumIDString == string.Empty || albumIDString == null)
            {
                albumID = null;
            }
            else
            {
                albumID = int.Parse(albumIDString);
            }

            Console.WriteLine();
            Console.WriteLine("Updating song...");
            var song = new SongModel
            {
                Title = title,
                Year = year,
                Genre = (Genre)genre,
                AlbumID = albumID
            };

            HttpResponseMessage response = client.PutAsJsonAsync(Songs + ActionUpdate + id, song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Song updated!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        internal void DeleteSong()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("      Delete Song By ID");
            Console.WriteLine();

            Console.Write("Song ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Deleting song...");
            Console.WriteLine();

            HttpResponseMessage response = client.DeleteAsync(Songs + ActionDelete + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<SongModel>().Result;
                var year = song.Year.Day + "-" + song.Year.Month + "-" + song.Year.Year;
                Console.WriteLine("[ID]{0} [Title]{1} [Year]{2} [Genre]{3} [Album]{4}", song.ID, song.Title, year, song.Genre, song.Album);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("Song deleted!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine();
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        internal void AddSongArtist()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("       Add Song's Artist");
            Console.WriteLine();

            Console.Write("Song ID: ");
            var songId = int.Parse(Console.ReadLine());

            Console.Write("Artist ID: ");
            var artistId = int.Parse(Console.ReadLine());

            HttpResponseMessage response = client.PutAsJsonAsync(Songs + ActionAddSongArtist + "songId=" + songId + "&artistId=" + artistId, new SongModel()).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("Artist was successfully added to Song!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine();
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}