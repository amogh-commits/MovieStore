using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace MovieManager.Model
{
    public class Serialization
    {
        public static string filePath = ConfigurationManager.AppSettings["fileName"];

        public static void SerializeData(List<Movie> movies)
        {
            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            File.WriteAllText(filePath, json);
            
        }

        public static List<Movie> DeserializeData()
        {
            List<Movie> movies = new List<Movie>();
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                movies = JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
              
            }
            else
            {
                Console.WriteLine("MovieData.json not found. Returning empty list.");
            }
            return movies;
        }
    }
}
