using Xunit;
using Midterm___MockBuster;
namespace MockBuster_UnitTesting
{
    public class UserTest
    {
        List<Movie> movies;
        public UserTest()
        {
            movies = new List<Movie>
            {
                new Movie("The Shawshank Redemption", "Morgan Freeman", new List<string>{"Drama"},"Frank Darabont"),
                new Movie("The Godfather", "Al Pacino", new List<string>{"Crime","Drama"},"Francis Ford Coppola"),
                new Movie("The Dark Knight", "Christian Bale", new List<string>{"Action", "Crime", "Drama", "Thriller"},"Christopher Nolan"),
                new Movie("The Lord of the Rings: Return of the King", "Ian McKellen", new List<string>{"Action", "Adventure", "Drama", "Fantasy"},"Peter Jackson"),
                new Movie("Inception", "Leonardo DiCaprio", new List<string>{"Action", "Adventure", "Sci-Fi", "Thriller"},"Christopher Nolan"),
            };
        }
 
        [Fact]
        public void MovieFilterFinds()
        {
            // Arrange
            string input = "Inception";

            // Actual
            List<Movie> actual = User.FilterMovie(input, movies);

            // Assert
            Assert.Equal(1, actual.Count);
            Assert.Equal("Inception", actual[0].MovieName);
        }
        [Fact]
        public void MovieFilterDoesNotFind()
        {
            // Arrange
            string input = "The Lion King";

            // Actual
            List<Movie> actual = User.FilterMovie(input, movies);

            // Assert
            Assert.Equal(0, actual.Count);
        }

        [Fact]
        public void ActorFilterFinds()
        {
            // Arrange
            string input = "Morgan Freeman";

            // Actual
            List<Movie> actual = User.FilterActor(input, movies);

            // Assert
            Assert.Equal(1, actual.Count);
            Assert.Equal("The Shawshank Redemption", actual[0].MovieName);

        }
        [Fact]
        public void ActorFilterDoesNotFind()
        {
            // Arrange
            string input = "Angelina Jolie";

            // Actual
            List<Movie> actual = User.FilterActor(input, movies);

            // Assert
            Assert.Equal(0, actual.Count);

        }

        [Fact]
        public void GenreFilterFinds()
        {
            // Arrange
            string input = "Adventure";

            // Actual
            List<Movie> actual = User.FilterGenre(input, movies);

            // Assert
            Assert.Equal(2, actual.Count);
            Assert.Equal("The Lord of the Rings: Return of the King", actual[0].MovieName);
            Assert.Equal("Inception", actual[1].MovieName);
        }
        [Fact]
        public void GenreFilterDoesNotFind()
        {
            // Arrange
            string input = "Horror";

            // Actual
            List<Movie> actual = User.FilterGenre(input, movies);

            // Assert
            Assert.Equal(0, actual.Count);
        }

        [Fact]
        public void DirectorFilterFinds()
        {
            // Arrange
            string input = "Christopher Nolan";

            // Actual
            List<Movie> actual = User.FilterDirector(input, movies);

            // Assert
            Assert.Equal(2, actual.Count);
            Assert.Equal("The Dark Knight", actual[0].MovieName);
            Assert.Equal("Inception", actual[1].MovieName);
        }
        [Fact]
        public void DirectorFilterDoesNotFind()
        {
            // Arrange
            string input = "Steven Spielberg";

            // Actual
            List<Movie> actual = User.FilterDirector(input, movies);

            // Assert
            Assert.Equal(0, actual.Count);
        }
    }
}

public class AdminTest
{
    List<Movie> movies;
    public AdminTest()
    {
        movies = new List<Movie>
            {
                new Movie("The Shawshank Redemption", "Morgan Freeman", new List<string>{"Drama"},"Frank Darabont"),
                new Movie("The Godfather", "Al Pacino", new List<string>{"Crime","Drama"},"Francis Ford Coppola"),
                new Movie("The Dark Knight", "Christian Bale", new List<string>{"Action", "Crime", "Drama", "Thriller"},"Christopher Nolan"),
                new Movie("The Lord of the Rings: Return of the King", "Ian McKellen", new List<string>{"Action", "Adventure", "Drama", "Fantasy"},"Peter Jackson"),
                new Movie("Inception", "Leonardo DiCaprio", new List<string>{"Action", "Adventure", "Sci-Fi", "Thriller"},"Christopher Nolan"),
            };
    }

    [Fact]
    public void MovieAddSuccess()
    {
        // Arrange
        Movie movie = new Movie("WALL-E", "Ben Burtt", new List<string> {"Animation", "Adventure", "Family", "Sci-Fi"}, "Andrew Stanton");

        // Actual
        bool actual = Admin.AddMovie(movie, movies);

        // Assert
        Assert.True(actual);
        Assert.Equal(6, movies.Count);
    }
    [Fact]
    public void MovieAddFail()
    {
        // Arrange
        Movie movie = new Movie("Inception", "Leonardo DiCaprio", new List<string> { "Action", "Adventure", "Sci-Fi", "Thriller" }, "Christopher Nolan");

        // Actual
        bool actual = Admin.AddMovie(movie, movies);

        // Assert
        Assert.False(actual);
        Assert.Equal(5, movies.Count);
    }

    [Fact]
    public void MovieTitleUpdates()
    {
        // Actual
        Admin.UpdateMovieTitle(movies[0], "WALL-E");

        // Assert
        Assert.Equal("WALL-E", movies[0].MovieName);
    }

    [Fact]
    public void ActorUpdates()
    {
        // Actual
        Admin.UpdateMovieActor(movies[3], "Angelina Jolie");

        // Assert
        Assert.Equal("Angelina Jolie", movies[3].MainActor);
    }
    [Fact]
    public void GenreUpdates()
    {
        // Arrange
        List<string> genres = new List<string> { "Drama", "Prison", "Mystery", "Crime Fiction" };
        // Actual
        Admin.UpdateMovieGenre(movies[0], genres);

        // Assert
        Assert.Equal(genres, movies[0].Genre);
    }
    [Fact]
    public void DirectorUpdates()
    {
        // Actual
        Admin.UpdateMovieDirector(movies[2], "Olivia Wilde");

        // Assert
        Assert.Equal("Olivia Wilde", movies[2].Director);
    }

    [Fact]
    public void MovieDeletes()
    {
        Admin.DeleteMovie(movies[3], movies);

        Assert.Equal(4, movies.Count);
    }

    [Fact]
    public void MovieDoesNotDelete()
    {
        // Arrange
        Movie movie = new Movie("WALL-E", "Ben Burtt", new List<string> { "Animation", "Adventure", "Family", "Sci-Fi" }, "Andrew Stanton");

        // Actual
        Admin.DeleteMovie(movie, movies);

        // Assert
        Assert.Equal(5, movies.Count);
    }
}

public class MovieRepoTest
{
    List<Movie> movies;
    public MovieRepoTest()
    {
        movies = new List<Movie>
            {
                new Movie("The Shawshank Redemption", "Morgan Freeman", new List<string>{"Drama"},"Frank Darabont"),
                new Movie("The Godfather", "Al Pacino", new List<string>{"Crime","Drama"},"Francis Ford Coppola"),
                new Movie("The Dark Knight", "Christian Bale", new List<string>{"Action", "Crime", "Drama", "Thriller"},"Christopher Nolan"),
                new Movie("The Lord of the Rings: Return of the King", "Ian McKellen", new List<string>{"Action", "Adventure", "Drama", "Fantasy"},"Peter Jackson"),
                new Movie("Inception", "Leonardo DiCaprio", new List<string>{"Action", "Adventure", "Sci-Fi", "Thriller"},"Christopher Nolan"),
            };
    }
    [Fact]
    public void DoMoviesRetrieve()
    {
        // Actual
        List<Movie> actual = MovieRepo.GetMovies();

        // Assert
        Assert.Equal(movies[0].MovieName, actual[0].MovieName);
        Assert.Equal(movies[0].MainActor, actual[0].MainActor);
        Assert.Equal(movies[0].Director, actual[0].Director);
        Assert.Equal(movies[0].Genre, actual[0].Genre);
        Assert.Equal(movies[1].MovieName, actual[1].MovieName);
        Assert.Equal(movies[2].MovieName, actual[2].MovieName);
        Assert.Equal(movies[3].MovieName, actual[3].MovieName);
        Assert.Equal(movies[4].MovieName, actual[4].MovieName);
    }
}