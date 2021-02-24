using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApiHasnodeArticle.Models.DTO
{
    public class MovieMapper : Profile
       
    {
        public MovieMapper()
        {
            CreateMap<GenreModel, GenreDTO>().ReverseMap();
        }
    }
}
