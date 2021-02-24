using MovieApiHasnodeArticle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApiHasnodeArticle.Repository.IRepository
{
   public interface IGenereRepository
    {
        ICollection<GenreModel> GetGenre();
        GenreModel GetGenre(Guid id);
        bool GenreExist(string name);
        bool GenreExist(Guid id);
        bool CreateGenre(GenreModel model);
        bool UpdateGenre(GenreModel model);
        bool DeleteGenre(GenreModel model);

        bool Save();


    }
}
