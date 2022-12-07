
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;






namespace MovieLibraryConsole.Services
{
    internal class FileService : IFileService
    {

        //private readonly ILogger<IFileService> _logger;
        //public FileService(ILogger<IFileService> logger)
        //{
        //    _logger = logger;
        //}
        public void SearchMovie()
        {
            Console.WriteLine("Enter a name you want to search for");
            var search = Console.ReadLine().ToLower();
            //_logger.LogInformation("Searching for movie");

            using (var context = new MovieContext())
            {
                var moviesearch = (from movie in context.Movies where movie.Title.ToLower().Contains(search) select movie).Distinct().ToList();
                var genresearch = (from genre in context.Genres join movieGenre in context.MovieGenres on genre.Id equals movieGenre.Genre.Id join movie
                in context.Movies on movieGenre.Movie.Id equals movie.Id where movie.Title.ToLower().Contains(search)select genre.Name).Distinct().ToList();
                if (moviesearch != null)
                {
                    foreach (var movie in moviesearch)
                    {
                        Console.WriteLine($"{movie.Id} {movie.Title}");
                        foreach (var genre in genresearch)
                        {
                            Console.WriteLine(genre + "|");
                        }
                    }
                }
                


            }
        }
        public void AddMovie()
        {
            System.Console.WriteLine("Enter NEW Movie Name: ");
            var newmov = Console.ReadLine();

            //System.Console.WriteLine("Enter the release date using mm/dd/yyy format:");
            //var movdate = Console.ReadLine();
            var movdate2 = DateTime.Now;
            DateTime.TryParse(newmov, out movdate2);
            //_logger.LogInformation("Adding new movie");

            using (var db = new MovieContext())
            {
                var movie = new Movie()
                {
                    Title = newmov
                   // ReleaseDate = movdate;

                };
                db.Movies.Add(movie);
                db.SaveChanges();

                var newMovie = db.Movies.FirstOrDefault(x => x.Title == newmov);
                System.Console.WriteLine($"({movie.Id}) {movie.Title} {movie.ReleaseDate}");
            }


        }
        public void UpdateMovie()
        {

            System.Console.WriteLine("Enter Movie Name to Update: ");
            var upmovie = Console.ReadLine();

            System.Console.WriteLine("Enter Updated Movie Name: ");
            var movieUpdate = Console.ReadLine();
            //_logger.LogInformation("Updating movie name");
            using (var db = new MovieContext())
            {
                var updateMovie = db.Movies.FirstOrDefault(x => x.Title == upmovie);
                System.Console.WriteLine($"({updateMovie.Id}) {updateMovie.Title}");

                updateMovie.Title = movieUpdate;

                db.Movies.Update(updateMovie);
                db.SaveChanges();
            }
        }
        public void DeleteMovie()
        {
            System.Console.WriteLine("Enter Movie Name to Delete: ");
            var moviedel = Console.ReadLine();
            //_logger.LogInformation("Deleting movie");

            using (var db = new MovieContext())
            {
                var deleteMovie = db.Movies.FirstOrDefault(x => x.Title == moviedel);
                System.Console.WriteLine($"Deleted: ({deleteMovie.Id}) {deleteMovie.Title}");


                db.Movies.Remove(deleteMovie);
                db.SaveChanges();
            }
            var context = new MovieContext();
            var movies = context.Movies;

            //foreach (var movie in movies)
            //{
            //    Console.WriteLine($"Movie {movie.Title}");
            //}
        }
        public void ShowMovies()
        {
            using (var db = new MovieContext())
            {
                var context = new MovieContext();
                var movies = context.Movies;

                foreach (var movie in movies)
                {
                    Console.WriteLine($"{movie.Id} {movie.Title} {movie.MovieGenres}");
                }
            }
           
        }
        public void AddUser()
        {
            using (var context = new MovieContext())
            {
               User user = new User();
                var choice = "";
                do
                {
                    var userage = 0;
                    Console.WriteLine("Enter your age");
                    var age = Console.ReadLine();
                    while(!int.TryParse(age, out userage))
                    {
                        Console.WriteLine("Please enter your age");
                        age = Console.ReadLine();
                    }
                    if (userage < 17)
                    {
                        Console.WriteLine("User must be over the age of 17");
                        userage = Int32.Parse(Console.ReadLine());
                    }
                    
                    user.Age = userage;
                    Console.WriteLine("Enter your gender M/F");
                    var userSex = Console.ReadLine();

                    user.Gender = userSex;
                    Console.WriteLine("Enter your Zip Code");
                    var zip = Console.ReadLine();
                    user.ZipCode = zip;
                    
                    
                    
                    Console.WriteLine("Enter occupation ID from the following list");
                    foreach (var o in context.Occupations)
                    {
                        Console.WriteLine($"{o.Id} {o.Name} ");
                    }
                    var occid = Console.ReadLine();
                    var oid = 0;
                    while (!int.TryParse(occid, out oid))
                    {
                        Console.WriteLine("Please enter a number from the list");
                            occid = Console.ReadLine(); 
                    }
                    while (oid > 21)
                    {
                        Console.WriteLine("Please enter a number from the list" );

                    }
                    var occsearch = (from o in context.Occupations where o.Id == oid select o).FirstOrDefault();
                    if (occsearch != null)
                    {
                        user.Occupation = occsearch;

                    }

                    
                    Console.WriteLine($"Age: {user.Age} ");
                    Console.WriteLine($"Gender: {user.Gender}");
                    Console.WriteLine($"Zip: {user.ZipCode}");
                    Console.WriteLine($"Occupation: {user.Occupation.Name}");
                    Console.WriteLine("Does this look right y for yes. n for no");

                    choice =Console.ReadLine(); 



                } while (choice != "y"
                );
                //_logger.LogInformation("Adding the user");

                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine($"Added user ID: {user.Id}");

            }
        }
        public void RateMovie()
        {
            UserMovie userMovie = new UserMovie();
            using (var context = new MovieContext())
            {
                //Console.WriteLine("What movie do you want to rate?");
                //var searchmovie = Console.ReadLine;
                //var moviesearch = (from movie in context.Movies where movie.Title.ToLower().Contains(searchmovie) select movie).FirstOrDefault();
                


                


            }



        }

    }
}
