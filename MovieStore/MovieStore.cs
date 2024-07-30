using System;
using MovieManager.Model;
using MovieManager.ExceptionHandling;

namespace MovieStoreName
{
    class MovieStore
    {
        public static MovieManagerClass movieManager = new MovieManagerClass();

        public static void MovieApp()
        {
            
            while (true) 
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Welcome to the Movie Store");
                Console.WriteLine("---------------------------------");

                Console.WriteLine("What action do you want to perform:");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Display All Movies");
                Console.WriteLine("3. Delete Movie");
                Console.WriteLine("4. Exit");

                int userInputForActionToPerform;

                if (!int.TryParse(Console.ReadLine(), out userInputForActionToPerform))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue; 
                }

                try
                {
                    switch (userInputForActionToPerform)
                    {
                        case 1:
                            movieManager.AddMovie();
                            break;
                        case 2:
                            movieManager.DisplayAllMovies();
                            break;
                        case 3:
                            movieManager.RemoveMovie();
                            break;
                        case 4:
                            Console.WriteLine("Exiting...");
                            return; 
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (MovieCapacityIsFull ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NoMovieFound ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
