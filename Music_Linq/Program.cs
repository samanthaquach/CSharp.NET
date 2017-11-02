using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            // var results = from Artist in Artists where Artist.Hometown.Contains("Mount Vernon") select Artist;
            // foreach (var artist in results)
            // {
            //     Console.WriteLine($"The artist is {artist.Age}. This artist is {artist.ArtistName}.");
            // }

            //Who is the youngest artist in our collection of artists?

            // var youngest = Artists.OrderBy(x => x.Age).FirstOrDefault();
            // System.Console.WriteLine($"This artist is {youngest.ArtistName}, and he is {youngest.Age}.");


            //Display all artists with 'William' somewhere in their real name
            // IEnumerable<Artist> Willy = Artists.Where(artist => artist.RealName.Contains("William"));
            // foreach (var artist in Willy)
            // {
            //     Console.WriteLine($"{artist.ArtistName}");
            // }
            // List<Artist> Williams = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            // Console.WriteLine("=============================");
            // foreach (var artist in Williams)
            // {
            //     Console.WriteLine(artist.ArtistName + " - " + artist.RealName);
            // }

            // var billy = from Artist in Artists where Artist.RealName.Contains("William") select Artist;
            // foreach (var artist in billy)
            // {
            //     Console.WriteLine(artist.ArtistName);
            // }

            //Display the 3 oldest artist from Atlanta
            // IEnumerable<Artist> atlanta = Artists.OrderByDescending(x => x.Age).Take(3);
            // foreach (var artist in atlanta)
            // {
            //     Console.WriteLine($"{artist.ArtistName} is the oldest artist.");
            // }
            // var atlanta = Artists.OrderByDescending(x => x.Age).Take(3);
            // foreach (var artist in atlanta)
            // {
            //     Console.WriteLine($"These oldest artists is" +" " +artist.ArtistName);
            // }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            
            // List<string> NonNewYorkGroups = Artists
            //                     .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist; })
            //                     .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
            //                     .Select(artist => artist.Group.GroupName)
            //                     .Distinct()
            //                     .ToList();
            // Console.WriteLine("All groups with members not from New York City:");
            // foreach (var group in NonNewYorkGroups)
            // {
            //     Console.WriteLine(group);
            // }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var Wu = Groups.Where(x => x.GroupName == "Wu-Tang Clan")
                                    .GroupJoin(Artists, x => x.Id, 
                                                        artist => artist.GroupId, 
                                                        (x, artists) => 
                                                        { x.Members = artists.ToList(); return x; })
                                    .Single();
            Console.WriteLine("===============================================");
            foreach (var artist in Wu.Members)
            {
                Console.WriteLine(artist.ArtistName);
            }

        }
    }
}
