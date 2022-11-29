
using Microsoft.EntityFrameworkCore;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;
using MovieLibraryEntities.Models;

namespace MovieLibraryConsole
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var choice = "";
            Console.WriteLine("(1) Search Movie \n(2) Add Movie \n(3) Update Movie \n(4) Delete Movie \n(5) Show All Movies");
            choice = Console.ReadLine();


            if (choice == "1")
            {
                System.Console.WriteLine("Enter Movie Name: ");
                var mov = Console.ReadLine();

                using (var db = new MovieContext())
                {
                   
                    var movie = db.Movies.FirstOrDefault(x => x.Title == mov);
                    System.Console.WriteLine($"({movie.Id}) {movie.Title} {movie.MovieGenres}");
                }
            }
            else if (choice == "2")
            {
                System.Console.WriteLine("Enter NEW Movie Name: ");
                var newmov = Console.ReadLine();

                using (var db = new MovieContext())
                {
                    var movie = new Movie()
                    {
                        Title = newmov
                    };
                    db.Movies.Add(movie);
                    db.SaveChanges();

                    var newMovie = db.Movies.FirstOrDefault(x => x.Title == newmov);
                    System.Console.WriteLine($"({movie.Id}) {movie.Title}");
                }
            }
           
            else if (choice == "3")
            {
                System.Console.WriteLine("Enter Movie Name to Update: ");
                var upmovie = Console.ReadLine();

                System.Console.WriteLine("Enter Updated Movie Name: ");
                var movieUpdate = Console.ReadLine();

                using (var db = new MovieContext())
                {
                    var updateMovie = db.Movies.FirstOrDefault(x => x.Title == upmovie);
                    System.Console.WriteLine($"({updateMovie.Id}) {updateMovie.Title}");

                    updateMovie.Title = movieUpdate;

                    db.Movies.Update(updateMovie);
                    db.SaveChanges();

                }
            }
           
            else if (choice == "4")
            {
                System.Console.WriteLine("Enter Movie Name to Delete: ");
                var moviedel = Console.ReadLine();

                using (var db = new MovieContext())
                {
                    var deleteMovie = db.Movies.FirstOrDefault(x => x.Title == moviedel);
                    System.Console.WriteLine($"({deleteMovie.Id}) {deleteMovie.Title}");

                  
                    db.Movies.Remove(deleteMovie);
                    db.SaveChanges();
                }
                var context = new MovieContext();
                var movies = context.Movies;

                foreach (var movie in movies)
                {
                    Console.WriteLine($"Movie {movie.Title}");
                }

               
            }
            else if (choice == "5")
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


        }
    }
}