using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Midterm___MockBuster
{
    public class Start
    {
        public List<Movie> movies;

        public Start()
        {
            movies = MovieRepo.GetMovies();
        }

        public void UserMenu()
        {
            string prompt = @"


__/\\\\____________/\\\\____________________________________________/\\\\\\\\\\\\\_________________________________________________________________________        
 _\/\\\\\\________/\\\\\\______________________________/\\\_________\/\\\/////////\\\_______________________________________________________________________       
  _\/\\\//\\\____/\\\//\\\_____________________________\/\\\_________\/\\\_______\/\\\________________________________/\\\___________________________________      
   _\/\\\\///\\\/\\\/_\/\\\_____/\\\\\________/\\\\\\\\_\/\\\\\\\\____\/\\\\\\\\\\\\\\___/\\\____/\\\__/\\\\\\\\\\__/\\\\\\\\\\\_____/\\\\\\\\___/\\/\\\\\\\__     
    _\/\\\__\///\\\/___\/\\\___/\\\///\\\____/\\\//////__\/\\\////\\\__\/\\\/////////\\\_\/\\\___\/\\\_\/\\\//////__\////\\\////____/\\\/////\\\_\/\\\/////\\\_    
     _\/\\\____\///_____\/\\\__/\\\__\//\\\__/\\\_________\/\\\\\\\\/___\/\\\_______\/\\\_\/\\\___\/\\\_\/\\\\\\\\\\____\/\\\_______/\\\\\\\\\\\__\/\\\___\///__   
      _\/\\\_____________\/\\\_\//\\\__/\\\__\//\\\________\/\\\///\\\___\/\\\_______\/\\\_\/\\\___\/\\\_\////////\\\____\/\\\_/\\__\//\\///////___\/\\\_________  
       _\/\\\_____________\/\\\__\///\\\\\/____\///\\\\\\\\_\/\\\_\///\\\_\/\\\\\\\\\\\\\/__\//\\\\\\\\\___/\\\\\\\\\\____\//\\\\\____\//\\\\\\\\\\_\/\\\_________ 
        _\///______________\///_____\/////________\////////__\///____\///__\/////////////_____\/////////___\//////////______\/////______\//////////__\///__________






Please use the arrow keys and hit enter to select your user access.
"
;

            string[] options = { "Client", "Admin", "Quit" };

            Menu mainMenu = new Menu(prompt, options, ConsoleColor.DarkBlue);
            int selectedIndex = mainMenu.Run();
            if(selectedIndex == 0)
            {
                ClientMenu();
            }
            else if(selectedIndex == 1)
            {
                AdminMenu();
            }
            else if(selectedIndex == 2)
            {
                Console.WriteLine("Leaving so soon?");
                Thread.Sleep(600);
                Console.WriteLine("...");
                Thread.Sleep(600);
                Console.WriteLine("bye...");
                Thread.Sleep(1000);
            }
        }

        public void ClientMenu()
        {
            bool toContinue = true;
            while (toContinue)
            {
                string prompt = "What would you like to do?";
                string[] options = { "Filter by movie name", "Filter by main actor/actress", "Filter by genre", "Filter by director", "View movie inventory" };
                Console.WriteLine();
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.Run();
                Clear();
                if (selectedIndex == 0)
                {
                    FilterMovieValidation();
                }
                else if (selectedIndex == 1)
                {
                    FilterActorValidation();
                }
                else if (selectedIndex == 2)
                {
                    FilterGenreValidation();
                }
                else if (selectedIndex == 3)
                {
                    FilterDirectorValidation();
                }
                else if (selectedIndex == 4)
                {
                    DisplayMovies();
                }
                toContinue = KeepGoing();
            }
        }

        public bool KeepGoing()
        {
            Console.WriteLine("Press any key to leave this screen.");
            Console.ReadKey();
            string prompt = "Do you want to continue?";
            string[] options = { "Yes", "No" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            if (selectedIndex == 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Thank you for shopping at MockBuster!");
                Console.WriteLine("Have a great day - Goodbye!");
                return false;
            }
        }

        public void FilterMovieValidation()
        {
            Console.Write("Please enter the name of the movie you'd like to filter by: ");
            string movieTitle = Console.ReadLine();
            Console.WriteLine();
            List<Movie> movieList = User.FilterMovie(movieTitle, movies);
            foreach (Movie movie in movieList)
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }
            if (movieList.Count == 0)
            {
                Console.WriteLine("Sorry, we don't have that movie.");
            }
        }

        public void FilterActorValidation()
        {
            Console.Write("Please enter the name of the actor/actress you'd like to filter by: ");
            string actorName = Console.ReadLine();
            Console.WriteLine();
            List<Movie> movieList = User.FilterActor(actorName, movies);
            foreach (Movie movie in movieList)
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }
            if (movieList.Count == 0)
            {
                Console.WriteLine("Sorry, we don't have any movies with that actor/actress.");
            }
        }

        public void FilterGenreValidation()
        {
            Console.Write("Please enter the genre you'd like to filter by: ");
            string genreInput = Console.ReadLine();
            Console.WriteLine();
            List<Movie> movieList = User.FilterGenre(genreInput, movies);
            foreach (Movie movie in movieList)
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }
            if (movieList.Count == 0)
            {
                Console.WriteLine("Sorry, we don't have any movies in that genre.");
            }
        }

        public void FilterDirectorValidation()
        {
            Console.Write("Please enter the name of the director you'd like to filter by: ");
            string directorName = Console.ReadLine();
            Console.WriteLine();
            List<Movie> movieList = User.FilterDirector(directorName, movies);
            foreach (Movie movie in movieList)
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }
            if (movieList.Count == 0)
            {
                Console.WriteLine("Sorry, we don't have any movies by that director.");
            }
        }

        public void DisplayMovies()
        {
            Console.WriteLine("These are the movies we currently have available.");
            Console.WriteLine();
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }
        }

        public List<string> GetGenreInput()
        {
            List<string> genres = new List<string>();
            bool invalidGenreCount = true;
            while (invalidGenreCount)
            {
                Console.Write("Please enter the number of genres the movie has: ");
                string genreCount = Console.ReadLine();
                if (int.TryParse(genreCount, out int validGenreNum))
                {
                    for (int i = 1; i <= validGenreNum; i++)
                    {
                        Console.Write($"Genre {i}: ");
                        string newGenre = Console.ReadLine();
                        genres.Add(newGenre);
                        invalidGenreCount = false;
                    }
                }
                else
                {
                    Console.WriteLine("You have entered an invalid value.");
                    Console.WriteLine();
                    invalidGenreCount = true;
                }
            }
            return genres;
        }

        public void AddMovie()
        {
            bool toContinue = true;
            while (toContinue)
            {
                Console.Write("Please enter the movie title you want to add: ");
                string newmovieName = Console.ReadLine();
                Console.WriteLine();

                bool movieFound = Admin.CheckMovieExists(newmovieName, movies);
                if (movieFound == true)
                {
                    Console.WriteLine("That movie already exists.");
                    Console.WriteLine();
                }
                else
                {
                    List<string> genres = GetGenreInput();
                    Console.WriteLine();
                    Console.Write("Please enter the name of the lead actor/actress: ");
                    string newActorName = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Please enter the name of the director: ");
                    string newDirectorName = Console.ReadLine();
                    Console.WriteLine();
                    Admin.AddMovie(new Movie(newmovieName, newActorName, genres, newDirectorName), movies);
                    Console.Clear();
                    Console.WriteLine("Your new movie was successfully added to our inventory.");
                    Console.WriteLine();
                    DisplayMovies();
                }
                toContinue = NextStepPrompt();
            }
        }

        public bool NextStepPrompt()
        {
            Console.WriteLine("Press any key to leave this screen.");
            Console.ReadKey();
            string prompt = "Do you want to add another movie?";
            string[] options = { "Yes", "No" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            Clear();
            if (selectedIndex == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AdminMenu()
        {
            bool toContinue = true;
            while (toContinue)
            {
                string prompt = "What would you like to do?";
                string[] options = { "Filter by movie name", "Filter by main actor/actress", "Filter by genre", "Filter by director", "Add movie", "Update movie", "Delete movie", "View movie inventory" };
                Console.WriteLine();
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.Run();
                Clear();
                if (selectedIndex == 0)
                {
                    FilterMovieValidation();
                }
                else if (selectedIndex == 1)
                {
                    FilterActorValidation();
                }
                else if (selectedIndex == 2)
                {
                    FilterGenreValidation();
                }
                else if (selectedIndex == 3)
                {
                    FilterDirectorValidation();
                }
                else if (selectedIndex == 4)
                {
                    AddMovie();
                }
                else if (selectedIndex == 5)
                {
                    UpdateMovieMenu();
                }
                else if (selectedIndex == 6)
                {
                    DeleteMovie();
                }
                else if (selectedIndex == 7)
                {
                    DisplayMovies();
                }
                toContinue = KeepGoing();
            }
        }

        public void UpdateMovieMenu()
        {
            Console.Write("Please enter the title of the movie you want to update: ");
            string existingMovie = Console.ReadLine();
            Console.WriteLine();

            bool movieFound = Admin.CheckMovieExists(existingMovie, movies);
            if (movieFound == true)
            {
                string prompt = "What would you like to update?";
                string[] options = { "Movie Title", "Lead Actor/Actress", "Genre", "Director" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.Run();

                if (selectedIndex == 0)
                {
                    Console.Write("Please enter the new movie title: ");
                    string newMovieTitle = Console.ReadLine();
                    foreach (Movie movie in movies)
                    {
                        if (movie.MovieName.ToLower() == existingMovie.ToLower())
                        {
                            Admin.UpdateMovieTitle(movie, newMovieTitle);
                        }
                    }
                    Console.WriteLine("The title was successfully updated.");
                    Console.WriteLine();
                }
                else if (selectedIndex == 1)
                {
                    Console.Write("Please enter the new lead actor/actress: ");
                    string newLead = Console.ReadLine();
                    Console.WriteLine();
                    foreach (Movie movie in movies)
                    {
                        if (movie.MovieName.ToLower() == existingMovie.ToLower())
                        {
                            Admin.UpdateMovieActor(movie, newLead);
                        }
                    }
                    Console.WriteLine("The lead actor/actress was successfully updated.");
                    Console.WriteLine();
                }
                else if (selectedIndex == 2)
                {
                    List<string> genres = GetGenreInput();
                    foreach (Movie movie in movies)
                    {
                        if (movie.MovieName.ToLower() == existingMovie.ToLower())
                        {
                            Admin.UpdateMovieGenre(movie, genres);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("The genre(s) was/were successfully updated.");
                    Console.WriteLine();
                }
                else if (selectedIndex == 3)
                {
                    Console.Write("Please enter the new director: ");
                    string newDirector = Console.ReadLine();
                    Console.WriteLine();
                    foreach (Movie movie in movies)
                    {
                        if (movie.MovieName.ToLower() == existingMovie.ToLower())
                        {
                            Admin.UpdateMovieDirector(movie, newDirector);
                        }
                    }
                    Console.WriteLine("The director was successfully updated.");
                    Console.WriteLine();
                }
                DisplayMovies();
            }
            else
            {
                Console.WriteLine("Sorry, that movie doesn't exist. Returning to main menu.");
                Console.WriteLine();
            }
        }

        public void DeleteMovie()
        {
            Console.Write("Please enter the title of the movie you want to delete: ");
            string movieName = Console.ReadLine();

            bool movieFound = Admin.CheckMovieExists(movieName, movies);
            if (movieFound == true)
            {
                foreach (Movie movie in movies)
                {
                    if (movie.MovieName.ToLower() == movieName.ToLower())
                    {
                        Admin.DeleteMovie(movie, movies);
                        break;
                    }
                }
                Console.WriteLine("The movie was successfully removed.");
                DisplayMovies();
            }
            else
            {
                Console.WriteLine("Sorry, that movie doesn't exist. Returning to main menu.");
            }
        }
    }
}
