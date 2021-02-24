using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieApiHasnodeArticle.Models;
using MovieApiHasnodeArticle.Models.DTO;
using MovieApiHasnodeArticle.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApiHasnodeArticle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenereRepository _genre;
        private readonly IMapper _mapper;

        public GenreController(IGenereRepository genre, IMapper mapper)
        {
            _genre = genre;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllGenre()
        {
            var ObjList = _genre.GetGenre();
            var objDto = new List<GenreDTO>();
            foreach (var obj in ObjList)
            {
                objDto.Add(_mapper.Map<GenreDTO>(obj));
            }
            return Ok(objDto);
        }

        [HttpGet]
        public IActionResult GetGenreById(Guid id)
        {
            var obj = _genre.GetGenre(id);
            if (obj ==  null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<GenreDTO>(obj);
            return Ok(objDto);
        }

        public IActionResult CreateGenre([FromBody] GenreDTO genreDTO)
        {
            if (genreDTO == null)
            {
                return NotFound(ModelState);
            }

            if (_genre.GenreExist(genreDTO.Name))
            {
                ModelState.AddModelError("", "Name already exist!, please try another name");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           

            var genreObj = _mapper.Map<GenreModel>(genreDTO);
            if (!_genre.CreateGenre(genreObj))
            {
                ModelState.AddModelError("", $" Something went wrong when trying to save record {genreDTO.Name} ");
                return StatusCode(500, ModelState);

            }
            return CreatedAtRoute("GetGenreById", new {  genreId = genreObj.Id}, genreObj);

        }

        public IActionResult UpdateGenre(Guid genreId, [FromBody] GenreDTO genreDto)
        {
            if (genreDto == null || genreId != genreDto.Id)
            {
                return BadRequest(ModelState);
            }

            var genreObj = _mapper.Map<GenreModel>(genreDto);
            if (!_genre.UpdateGenre(genreObj))
            {
                ModelState.AddModelError("", $"Something went wrong updating the record {genreObj.Name} ");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        public IActionResult PartialUpdateGenre(Guid genreId, JsonPatchDocument<GenreDTO> patchDoc)
        {
            var genre = _genre.GetGenre(genreId);
            if (genre == null)
            {
                return NotFound();

            }

            var genrePatchDto = _mapper.Map<GenreDTO>(genre);
            patchDoc.ApplyTo(genrePatchDto, ModelState);
            _mapper.Map(genrePatchDto, genre);
            _genre.UpdateGenre(genre);
            return NoContent();

        }

        public IActionResult Delete(Guid genreId)
        {
            if (!_genre.GenreExist(genreId))
            {
                return NotFound();
            }
            var genreObj = _genre.GetGenre(genreId);
            if (!_genre.DeleteGenre(genreObj))
            {
                ModelState.AddModelError("", $"Something went wrong updating the record {genreObj.Name} ");
                return StatusCode(500, ModelState);
            }
            return NotFound();
        }
    }
}
