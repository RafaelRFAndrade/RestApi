using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Entities;
using RestApi.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameDbContext _context;

        public GameController(GameDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            var games = _context.Games.Where(g => !g.IsDeleted).ToList();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(Guid id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public IActionResult CreateGame(Game game)
        {
            _context.Games.Add(game);
            return CreatedAtAction(nameof(GetGameById), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGame(Guid id, Game input)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            game.Update(input.Title, input.Description, input.ReleaseDate, input.Platform);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGameById(Guid id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            game.Delete();
            return NoContent();
        }

        [HttpPost("{id}/speakers")]
        public IActionResult AddGameSpeaker(Guid id, GameSpeaker speaker)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            game.Speakers.Add(speaker);
            return NoContent();
        }
    }
}
