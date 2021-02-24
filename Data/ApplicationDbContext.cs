using Microsoft.EntityFrameworkCore;
using MovieApiHasnodeArticle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApiHasnodeArticle.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public  DbSet<GenreModel> MyGenreTable { get; set; }


    }
}
