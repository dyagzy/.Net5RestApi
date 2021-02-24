using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApiHasnodeArticle.Models.DTO
{
    public class GenreDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
