using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.ExceptionHandling
{
    public class MovieCapacityIsFull:Exception
    {
        public MovieCapacityIsFull(string message):base(message)
        {

        }
    }
}
