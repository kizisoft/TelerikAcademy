namespace MusicData.ConsoleClient.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using MusicData.ConsoleClient.Models;

    internal class AlbumsClient : AbstractClient
    {
        private HttpClient client;

        internal AlbumsClient(HttpClient client)
        {
            this.client = client;
        }

        internal void CreateAlbum()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("         Create Album");
            Console.WriteLine();

            Console.Write("Title: ");
            var title = Console.ReadLine();

            Console.Write("Date of album (dd-mm-yyyy): ");
            var year = DateTime.Parse(Console.ReadLine());

            Console.Write("Producer: ");
            var producer = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Creating album...");
            var album = new AlbumModel
            {
                Title = title,
                Year = year,
                Producer = producer
            };

            HttpResponseMessage response = client.PostAsJsonAsync(Albums + ActionAdd, album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Album added!");
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

        internal void GetAllAlbums()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("        Get All Albums");
            Console.WriteLine();
            Console.WriteLine("Getting albums...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Albums + ActionGetAll).Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<AlbumModel>>().Result;

                foreach (var album in albums)
                {
                    var year = album.Year.Value.Day + "-" + album.Year.Value.Month + "-" + album.Year.Value.Year;
                    Console.WriteLine("[ID]{0} [Title]{1}, [Date]{2}, [Producer]{3}", album.ID, album.Title, year, album.Producer);
                }

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

        internal void GetAlbum()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("       Get Album By ID");
            Console.WriteLine();

            Console.Write("Album ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Getting album...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Albums + ActionGet + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<AlbumModel>().Result;
                var year = album.Year.Value.Day + "-" + album.Year.Value.Month + "-" + album.Year.Value.Year;
                Console.WriteLine("[ID]{0} [Title]{1}, [Date]{2}, [Producer]{3}", album.ID, album.Title, year, album.Producer);
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

        internal void UpdateAlbum()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("         Update Album");
            Console.WriteLine();

            Console.Write("Album ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Title: ");
            var title = Console.ReadLine();

            Console.Write("Date of album (dd-mm-yyyy): ");
            var year = DateTime.Parse(Console.ReadLine());

            Console.Write("Producer: ");
            var producer = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Updating album...");
            Console.WriteLine();

            var album = new AlbumModel
            {
                Title = title,
                Year = year,
                Producer = producer
            };

            HttpResponseMessage response = client.PutAsJsonAsync(Albums + ActionUpdate + id, album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Album updated!");
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

        internal void DeleteAlbum()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("      Delete Album By ID");
            Console.WriteLine();

            Console.Write("Album ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Deleting album...");
            Console.WriteLine();

            HttpResponseMessage response = client.DeleteAsync(Artists + ActionDelete + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<AlbumModel>().Result;
                var year = album.Year.Value.Day + "-" + album.Year.Value.Month + "-" + album.Year.Value.Year;
                Console.WriteLine("[ID]{0} [Title]{1}, [Date]{2}, [Producer]{3}", album.ID, album.Title, year, album.Producer);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("Album deleted!");
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

        internal void GetAlbumArtists()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("       Get Album's Artists");
            Console.WriteLine();

            Console.Write("Album ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Getting album's artists...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Albums + ActionGetWithArtists + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<AlbumModel>().Result;
                var year = album.Year.Value.Day + "-" + album.Year.Value.Month + "-" + album.Year.Value.Year;
                Console.WriteLine("[ID]{0} [Title]{1}, [Date]{2}, [Producer]{3}", album.ID, album.Title, year, album.Producer);

                foreach (var artist in album.Artists)
                {
                    var birthDate = artist.DateOfBirth.Value.Day + "-" + artist.DateOfBirth.Value.Month + "-" + artist.DateOfBirth.Value.Year;
                    Console.WriteLine("   [ID]{0} [Name]{1}, [BirthDate]{2}, [Country]{3}", artist.ID, artist.FirstName + " " + artist.LastName, birthDate, artist.Country);
                }

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

        internal void GetAlbumSongs()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("       Get Album's Songs");
            Console.WriteLine();

            Console.Write("Album ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Getting album's songs...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Albums + ActionGetWithSongs + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<AlbumModel>().Result;
                var year = album.Year.Value.Day + "-" + album.Year.Value.Month + "-" + album.Year.Value.Year;
                Console.WriteLine("[ID]{0} [Title]{1}, [Date]{2}, [Producer]{3}", album.ID, album.Title, year, album.Producer);

                foreach (var song in album.Songs)
                {
                    var songYear = song.Year.Day + "-" + song.Year.Month + "-" + song.Year.Year;
                    Console.WriteLine("   [ID]{0} [Title]{1} [Year]{2} [Genre]{3} [Album]{4}", song.ID, song.Title, songYear, song.Genre, song.Album);
                }

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
    }
}