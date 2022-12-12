using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm___MockBuster
{
    public class Movie
    {
        public string MovieName;
        public string MainActor;
        public List<string> Genre;
        public string Director;

        public Movie(string moviename, string mainactor, List<string> genre, string director)
        {
            MovieName = moviename;
            MainActor = mainactor;
            Genre = genre;
            Director = director;
        }

        public override string ToString()
        {
            return $"Movie: {MovieName}\nLead Actor: {MainActor}\nGenre(s): {string.Join(", ", Genre)}\nDirector: {Director}";
        }
    }
}
