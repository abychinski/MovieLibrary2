using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryConsole.Services
{
    public interface IFileService
    {
        void ShowMovies();
        void SearchMovie();
        void AddMovie();
        void UpdateMovie();
        void DeleteMovie();
        void AddUser();

    }
}
