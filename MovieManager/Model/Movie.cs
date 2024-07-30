using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Model
{
    public class Movie
    {
        public string MovieId { get; set; }

        public string MovieName { get; set; }

        public string MovieGenre    { get; set; }

        public int MovieReleaseYear { get; set; }

        public static int movieCount = 0;

        public Movie() 
        {
            
            movieCount++;
        }
        public static int MovieCount
        {
            get { return movieCount; }
        }

    }
}
