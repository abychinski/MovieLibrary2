using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryConsole.Services
{
    public class MainService : IMainService
    {
        private readonly IFileService _fileservice;

        public MainService(IFileService fileservice)
        {
            _fileservice = fileservice;
        }
        public void Invoke()
        {
            string choice;
            do
            {
                Console.WriteLine("(1) Search Movie \n(2) Add Movie \n(3) Update Movie Name \n(4) Delete Movie \n(5) Show All Movies \n(6) Add New User" +
                    "\n(7) Rate Movie for User \n(8) Exit");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    _fileservice.SearchMovie();
                }
                else if (choice == "2")
                {
                    _fileservice.AddMovie();

                }
                else if (choice == "3")
                {
                    _fileservice.UpdateMovie();
                }
                else if (choice == "4")
                {
                    _fileservice.DeleteMovie();
                }
                else if (choice == "5")
                {
                    _fileservice.ShowMovies();
                }
                else if (choice == "6")
                {
                    _fileservice.AddUser();
                }
                else if (choice == "7")
                {
                    _fileservice.RateMovie();
                }
                //else
                //{
                //    Console.WriteLine("Make a correct selection");
                //}

            } while (choice != "8");

        }
    }
}
