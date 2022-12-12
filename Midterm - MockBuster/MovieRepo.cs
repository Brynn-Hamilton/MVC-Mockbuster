using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm___MockBuster
{
    public class MovieRepo
    {
        public static List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie("The Shawshank Redemption", "Morgan Freeman", new List<string>{"Drama"},"Frank Darabont"),
                new Movie("The Godfather", "Al Pacino", new List<string>{"Crime","Drama"},"Francis Ford Coppola"),
                new Movie("The Dark Knight", "Christian Bale", new List<string>{"Action", "Crime", "Drama", "Thriller"},"Christopher Nolan"),
                new Movie("The Lord of the Rings: Return of the King", "Ian McKellen", new List<string>{"Action", "Adventure", "Drama", "Fantasy"},"Peter Jackson"),
                new Movie("Inception", "Leonardo DiCaprio", new List<string>{"Action", "Adventure", "Sci-Fi", "Thriller"},"Christopher Nolan"),
            };
            return movies;
        }
    }
}
