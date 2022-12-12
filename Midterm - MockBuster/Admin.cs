using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm___MockBuster
{
    public class Admin : User
    {
        public static bool AddMovie(Movie newMovie, List<Movie> movies)
        {
            bool found = CheckMovieExists(newMovie.MovieName, movies);
            if (!found)
            {
               movies.Add(newMovie);
            }
            return !found;
        }

        public static bool CheckMovieExists(string existingMovie, List<Movie> movies)
        {
            bool found = false;
            foreach (Movie movie in movies)
            {
                if (movie.MovieName.ToLower() == existingMovie.ToLower())
                {
                    found = true;
                }
            }
            return found;
        }
        public static void UpdateMovieTitle(Movie existingMovie, string newTitle)
        {
            existingMovie.MovieName = newTitle;
        }
        public static void UpdateMovieGenre(Movie existingMovie, List<string> newGenre)
        {
            existingMovie.Genre = newGenre;
        }
        public static void UpdateMovieActor(Movie existingMovie, string newActor)
        {
            existingMovie.MainActor = newActor;
        }
        public static void UpdateMovieDirector(Movie existingMovie, string newDirector)
        {
            existingMovie.Director = newDirector;
        }

        public static void DeleteMovie(Movie existingMovie, List<Movie> movies)
        {
            bool found = CheckMovieExists(existingMovie.MovieName, movies);
            if (found)
            {
                movies.Remove(existingMovie);
            }
        }
    }
}
