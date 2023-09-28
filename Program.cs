using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class main
{
    static void Main()
    {
        var filetext = File.ReadAllLines("videogames.csv");
        Console.Write(filetext);

        var games = new List<VideoGame>();

        foreach (string line in filetext)
        {
            // Split the line into parts and create a VideoGame object
            string[] parts = line.Split(',');
            if (parts.Length >= 4)
            {
                var game = new VideoGame
                {
                    Title = parts[0],
                    Genre = parts[3],
                    Platform = parts[1],
                    Publisher = parts[4]
                };
                games.Add(game);
            }
        }

        games.Sort();
        
        foreach (var game in games)
        {
            Console.WriteLine(game.ToString());
        }
        


        string selectedPublisher = GetUserInput("\nEnter the publisher: ");
        string selectGenre = GetUserInput("Enter the genre: ");

        // Get and display data for the selected publisher
        GetPublisherData(games, selectedPublisher);

        // Get and display data for the selected genre
        GetGenreData(games, selectGenre);
        

        static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }


        static void GetPublisherData(List<VideoGame> games, string selectedPublisher)
        {
            // Use LINQ to filter and sort games from the selected publisher
            var gamesFromSelectedPublisher = games
                .Where(game => game.Publisher == selectedPublisher)
                .OrderBy(game => game.Title)
                .ToList();

            double totalGamesFromSelectedPublisher = gamesFromSelectedPublisher.Count;
            double percentGamesFromPublisher = (totalGamesFromSelectedPublisher / games.Count) * 100;

            // Display games from the selected publisher
            Console.WriteLine($"\n\nGames from {selectedPublisher}:");
            Console.WriteLine($"Total games: {totalGamesFromSelectedPublisher}");
            System.Console.WriteLine($"Out of {games.Count} games, THQ has {totalGamesFromSelectedPublisher} games, which is {percentGamesFromPublisher:F2}%\n\n");
    
            foreach (var game in gamesFromSelectedPublisher)
            {
                Console.WriteLine(game.ToString());
            }   
        }


        static void GetGenreData(List<VideoGame> games, string selectGenre)
        {
            var gamesInSelectedGenre = games
                .Where(game => game.Genre == selectGenre)
                .OrderBy(game => game.Title)
                .ToList();
                
            double selectGenreGames = games
                .Count(game => game.Genre.Equals(selectGenre, StringComparison.OrdinalIgnoreCase));
            double percentageOfSelectGenreGames = (selectGenreGames / games.Count) * 100;

            foreach (var game in gamesInSelectedGenre)
            {
                Console.WriteLine(game.ToString());
            }

            //Display games with the selected genre
            Console.WriteLine($"\n\nGames in the {selectGenre} genre:");
            System.Console.WriteLine($"Total of {selectGenre} games: {selectGenreGames}");
            System.Console.WriteLine($"Out of {games.Count} games there are {selectGenreGames} {selectGenre} genre games, which is {percentageOfSelectGenreGames:F2}%");
        }

    }
}
