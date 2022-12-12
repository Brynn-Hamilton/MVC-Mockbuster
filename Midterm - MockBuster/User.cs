using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm___MockBuster
{
    public class User
    {
        public static List<Movie> FilterGenre(string genre, List<Movie> movies)
        {
            List<Movie> GenreResult = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Genre.Select(genreElement => genreElement.ToLower()).Contains(genre.ToLower()))
                {
                    GenreResult.Add(movie);
                }
            }
            return GenreResult;
        }

        public static List<Movie> FilterMovie(string title, List<Movie> movies)
        {
            List<Movie> MovieResult = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.MovieName.ToLower() == title.ToLower())
                {
                    MovieResult.Add(movie);
                }
            }
            return MovieResult;
        }

        public static List<Movie> FilterActor(string actorName, List<Movie> movies)
        {
            List<Movie> ActorResult = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.MainActor.ToLower() == actorName.ToLower())
                {
                    ActorResult.Add(movie);
                }
            }
            return ActorResult;
        }

        public static List<Movie> FilterDirector(string directorName, List<Movie> movies)
        {
            List<Movie> DirectorResult = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Director.ToLower() == directorName.ToLower())
                {
                    DirectorResult.Add(movie);
                }
            }
            return DirectorResult;
        }

    }
}
