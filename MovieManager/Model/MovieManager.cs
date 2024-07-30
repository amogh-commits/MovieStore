using System;
using System.Collections.Generic;
using MovieManager.ExceptionHandling;

namespace MovieManager.Model
{
    public class MovieManagerClass
    {
        public static List<Movie> movies = new List<Movie>();

        public MovieManagerClass()
        {
            movies = Serialization.DeserializeData();
        }
        
        private const int MAXIMUM_CAPACITY = 2;

        public void AddMovie()
        {
            if (movies.Count >= MAXIMUM_CAPACITY)
            {
                throw new MovieCapacityIsFull("Movie Capacity is Full");
            }

            Console.WriteLine("Enter movie Name:");
            string movieName = Console.ReadLine();

            Console.WriteLine("Enter movie Genre:");
            string movieGenre = Console.ReadLine();

            Console.WriteLine("Enter movie release year:");
            if (!int.TryParse(Console.ReadLine(), out int movieReleaseYear))
            {
                Console.WriteLine("Invalid year format.");
                return;
            }

            Movie movie = new Movie
            {
                MovieName = movieName,
                MovieGenre = movieGenre,
                MovieReleaseYear = movieReleaseYear,
                MovieId = GenerateMovieId(movieName, movieGenre, movieReleaseYear)
            };

            movies.Add(movie);
            Console.WriteLine("Movie added successfully");
            Serialization.SerializeData(movies);
        }

        public void DisplayAllMovies()
        {
            if (movies.Count <= 0)
            {
                Console.WriteLine("There are no movies in the Movie Store.");
                return;
            }

            foreach (var movie in movies)
            {
                Console.WriteLine("Movie Details are: ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"ID: {movie.MovieId}");
                Console.WriteLine($"Title: {movie.MovieName}");
                Console.WriteLine($"Genre: {movie.MovieGenre}");
                Console.WriteLine($"Release Year: {movie.MovieReleaseYear}");
                Console.WriteLine("---------------------------------");
            }
        }

        public void RemoveMovie()
        {
            if (movies.Count <= 0)
            {
                throw new NoMovieFound("There are no movies to delete");
            }

            Console.WriteLine("Enter the ID of the movie to remove:");
            string id = Console.ReadLine();

            Movie movieToRemove = movies.Find(m => m.MovieId.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (movieToRemove == null)
            {
                throw new NoMovieFound($"Movie with ID '{id}' not found.");
            }

            movies.Remove(movieToRemove);
            Console.WriteLine("Movie removed successfully.");
            Serialization.SerializeData(movies);
        }

        private string GenerateMovieId(string title, string genre, int year)
        {
            string titlePrefix = title.Length >= 2 ? title.Substring(0, 2).ToUpper() : title.PadRight(2, 'X');
            string genrePrefix = genre.Length >= 2 ? genre.Substring(0, 2).ToUpper() : genre.PadRight(2, 'X');
            string yearSuffix = (year % 100).ToString("00");
            return $"{titlePrefix}{genrePrefix}{yearSuffix}";
        }
    }
}
