namespace MusicData.ConsoleClient.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using MusicData.ConsoleClient.Models;

    internal class ArtistsClient : AbstractClient
    {
        private HttpClient client;

        internal ArtistsClient(HttpClient client)
        {
            this.client = client;
        }

        internal void CreateArtist()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("         Create Artist");
            Console.WriteLine();

            Console.Write("First Name: ");
            var firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();

            Console.Write("Country: ");
            var country = Console.ReadLine();

            Console.Write("Date of birth (dd-mm-yyyy): ");
            var dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Creating artist...");
            var artist = new ArtistModel
            {
                FirstName = firstName,
                LastName = lastName,
                Country = country,
                DateOfBirth = dateOfBirth
            };

            HttpResponseMessage response = client.PostAsJsonAsync(Artists + ActionAdd, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Artist added!");
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

        internal void GetAllArtists()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("        Get All Artists");
            Console.WriteLine();
            Console.WriteLine("Getting artists...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Artists + ActionGetAll).Result;
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<ArtistModel>>().Result;

                foreach (var artist in artists)
                {
                    var birthDate = artist.DateOfBirth.Value.Day + "-" + artist.DateOfBirth.Value.Month + "-" + artist.DateOfBirth.Value.Year;
                    Console.WriteLine("[ID]{0} [Name]{1}, [BirthDate]{2}, [Country]{3}", artist.ID, artist.FirstName + " " + artist.LastName, birthDate, artist.Country);
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

        internal void GetArtist()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("       Get Artist By ID");
            Console.WriteLine();

            Console.Write("Artist ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Getting artist...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Artists + ActionGet + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<ArtistModel>().Result;
                var birthDate = artist.DateOfBirth.Value.Day + "-" + artist.DateOfBirth.Value.Month + "-" + artist.DateOfBirth.Value.Year;
                Console.WriteLine("[ID]{0} [Name]{1}, [BirthDate]{2}, [Country]{3}", artist.ID, artist.FirstName + " " + artist.LastName, birthDate, artist.Country);
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

        internal void UpdateArtist()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("         Update Artist");
            Console.WriteLine();

            Console.Write("Artist ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("First Name: ");
            var firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();

            Console.Write("Country: ");
            var country = Console.ReadLine();

            Console.Write("Date of birth (dd-mm-yyyy): ");
            var dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Updating artist...");
            Console.WriteLine();

            var artist = new ArtistModel
            {
                FirstName = firstName,
                LastName = lastName,
                Country = country,
                DateOfBirth = dateOfBirth
            };

            HttpResponseMessage response = client.PutAsJsonAsync(Artists + ActionUpdate + id, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Artist updated!");
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

        internal void DeleteArtist()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("      Delete Artist By ID");
            Console.WriteLine();

            Console.Write("Artist ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Deleting artist...");
            Console.WriteLine();

            HttpResponseMessage response = client.DeleteAsync(Artists + ActionDelete + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<ArtistModel>().Result;
                var birthDate = artist.DateOfBirth.Value.Day + "-" + artist.DateOfBirth.Value.Month + "-" + artist.DateOfBirth.Value.Year;
                Console.WriteLine("[ID]{0} [Name]{1}, [BirthDate]{2}, [Country]{3}", artist.ID, artist.FirstName + " " + artist.LastName, birthDate, artist.Country);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("Artist deleted!");
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

        internal void GetArtistAlbums()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("       Get Artist's Albums");
            Console.WriteLine();

            Console.Write("Artist ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Getting artist's albums...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Artists + ActionGetWithAlbums + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<ArtistModel>().Result;
                var birthDate = artist.DateOfBirth.Value.Day + "-" + artist.DateOfBirth.Value.Month + "-" + artist.DateOfBirth.Value.Year;
                Console.WriteLine("[ID]{0} [Name]{1}, [BirthDate]{2}, [Country]{3}", artist.ID, artist.FirstName + " " + artist.LastName, birthDate, artist.Country);

                foreach (var album in artist.Albums)
                {
                    var year = album.Year.Value.Day + "-" + album.Year.Value.Month + "-" + album.Year.Value.Year;
                    Console.WriteLine("   [ID]{0} [Title]{1}, [Date]{2}", album.ID, album.Title, year);
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

        internal void GetArtistSongs()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("       Get Artist's Songs");
            Console.WriteLine();

            Console.Write("Artist ID: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Getting artist's songs...");
            Console.WriteLine();

            HttpResponseMessage response = client.GetAsync(Artists + ActionGetWithSongs + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<ArtistModel>().Result;
                var birthDate = artist.DateOfBirth.Value.Day + "-" + artist.DateOfBirth.Value.Month + "-" + artist.DateOfBirth.Value.Year;
                Console.WriteLine("[ID]{0} [Name]{1}, [BirthDate]{2}, [Country]{3}", artist.ID, artist.FirstName + " " + artist.LastName, birthDate, artist.Country);

                foreach (var song in artist.Songs)
                {
                    var year = song.Year.Day + "-" + song.Year.Month + "-" + song.Year.Year;
                    Console.WriteLine("   [ID]{0} [Title]{1} [Year]{2} [Genre]{3} [Album]{4}", song.ID, song.Title, year, song.Genre, song.Album);
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

        internal void AddArtistAlbum()
        {
            Console.Clear();
            Console.WriteLine("Music Data System Console Client");
            Console.WriteLine("       Add Artist's Album");
            Console.WriteLine();

            Console.Write("Artist ID: ");
            var artistId = int.Parse(Console.ReadLine());

            Console.Write("Album ID: ");
            var albumId = int.Parse(Console.ReadLine());

            HttpResponseMessage response = client.PutAsJsonAsync(Artists + ActionAddArtistAlbum + "artistId=" + artistId + "&albumId=" + albumId, new ArtistModel()).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("Album was successfully added to Artist!");
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