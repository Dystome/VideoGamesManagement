using Microsoft.AspNetCore.Mvc;
using System.Data;
using VideoGamesManagement.BusinessLayer;
using VideoGamesManagement.DataLayer.Entities;
using VideoGamesManagement.DataLayer.Repositories;

namespace VideoGamesManagement.Controllers
{
    [ApiController]
    [Route("/api/v1.0/[controller]")]
    public class VideoGameController : ControllerBase
    {
        public List<VideoGame> _videoGames = new List<VideoGame>();

        private readonly VideoGameService _videoGameService;

        public VideoGameController(VideoGameService videoGameService)
        {
            _videoGameService = videoGameService;
        }

        [HttpGet("allgames")]
        public List<VideoGame> GetAllGames()
        {
            
            _videoGames = _videoGameService.GetVideoGames().ToList();
            return _videoGames;
        }

        [HttpGet("gamename")]
        public List<VideoGame> GetGameByName([FromQuery] string name)
        {
          
            _videoGames = _videoGameService.GetVideoGames().Where(p => p.Name.Contains(name))
                .ToList();
            return _videoGames;
        }

        [HttpGet("gameid")]
        public VideoGame GetGameById([FromQuery] int id)
        {
           
            _videoGames = _videoGameService.GetVideoGames();
            var gameById = _videoGames.Where(p => p.ID == id).FirstOrDefault();
            return gameById;
        }

        [HttpGet("gamecompany")]

        public List<VideoGame> GetGameByCompany([FromQuery] string company)
        {
            
            _videoGames = _videoGameService.GetVideoGames().Where(p => p.Studio.Contains(company))
                .ToList();
            return _videoGames;
        }

        [HttpPost("addnewgame")]
        public IActionResult AddNewGame([FromBody] VideoGame game)
        {
            //Check if game exists
          
            _videoGames = _videoGameService.GetVideoGames();
            var gameExists = _videoGames.Where(p => p.Name.Equals(game.Name, StringComparison.CurrentCultureIgnoreCase) &&
            p.Studio.Equals(game.Studio, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (gameExists != null)
            {
                throw new Exception("Game already exists!");
            }
           
            _videoGameService.AddGame(game);

            return new OkObjectResult("Game was added successfully!");


        }

        [HttpPut("modifygame")]
        public IActionResult ModifyGame([FromBody] VideoGame game)
        {
            
            
            _videoGames = _videoGameService.GetVideoGames();
            var gameExists = _videoGames.Where(p => p.ID == game.ID)
                .FirstOrDefault();
          
            if (game == null)
            {
                throw new Exception("Record does not exist!");
            }
            _videoGameService.UpdateGame(game);

            return new OkObjectResult("Game successfully updated!");

        }

        [HttpDelete("deletegame")]
        public IActionResult DeleteAnimal([FromBody] VideoGame game)
        {
            
            var gameExists = _videoGames.Where(p => p.ID == game.ID)
                .FirstOrDefault();
            if (game == null)
            {
                throw new Exception("Record does not exist!");
            }
            _videoGameService.RemoveGame(game);
            return new OkObjectResult("Game removed successfully!");
        }

        [HttpGet("filter")]
        public List<VideoGame> Filter([FromQuery] string name, [FromQuery] string studio, [FromQuery] int? size)
        {
           
            _videoGames = _videoGame
                
                Service.GetVideoGames();
            if (!string.IsNullOrEmpty(name))
            {
                _videoGames = _videoGames.Where(p => p.Name.Contains(name))
                   .ToList();
            }
            if (!string.IsNullOrEmpty(studio))
            {
                _videoGames = _videoGames.Where(p => p.Studio.Contains(studio))
                   .ToList();
            }
            if (!(size == null))
            {
                _videoGames = _videoGames.Where(p => p.Size == size)
                   .ToList();
            }

            return _videoGames;
        }
    }
}
