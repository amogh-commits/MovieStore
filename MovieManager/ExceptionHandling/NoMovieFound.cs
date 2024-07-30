using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.ExceptionHandling
{
    public class NoMovieFound:Exception
    {
        public NoMovieFound(string message):base(message) 
        {

        }
    }
}
