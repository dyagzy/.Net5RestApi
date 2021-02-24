using MovieApiHasnodeArticle.Data;
using MovieApiHasnodeArticle.Models;
using MovieApiHasnodeArticle.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApiHasnodeArticle.Repository
{
    public class GenereRepository : IGenereRepository


    {
        private readonly ApplicationDbContext _dbContext;
        public GenereRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;



        public bool CreateGenre(GenreModel model)
        {
            _dbContext.MyGenreTable.Add(model);
            return Save();
        }

        public bool DeleteGenre(GenreModel model)
        {
            _dbContext.MyGenreTable.Remove(model);
            return Save();
        }

        public bool GenreExist(string name)
        {
            bool value = _dbContext.MyGenreTable.Any(u => u.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool GenreExist(Guid id)
        {
            bool value = _dbContext.MyGenreTable.Any(a => a.Id == a.Id);
            return value;
        }

        public ICollection<GenreModel> GetGenre() => _dbContext.MyGenreTable.OrderBy(a => a.Name).ToList();


        public GenreModel GetGenre(Guid id) => _dbContext.MyGenreTable.FirstOrDefault(a => a.Id == a.Id);


        public bool Save() => _dbContext.SaveChanges() >= 0 ? true : false;
        
           
        public bool UpdateGenre(GenreModel model)
        {
            _dbContext.Update(model);
            return Save();
        }
    }
}
