using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.API.Data;
using Movies.API.Models;

namespace Movies.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly DataContext _context;

        public MovieController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovieAsync() =>
            Ok(await _context.Movies.ToListAsync());
        
        [HttpPost]
        public async Task<ActionResult> CreateMovieAsync()
        {
            var movie = new Movie
            {
                Title = "lorem",
                Genre = "ipsum",
                Rating = "5",
                ImageUrl = "https://github.com",
                ReleaseDate = DateTime.Now,
                Owner = "mike mock"
            };
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieAsync(int id)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound();

            movie.ReleaseDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();

            _context.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
