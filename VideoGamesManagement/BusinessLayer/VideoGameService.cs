using VideoGamesManagement.DataLayer.Entities;
using VideoGamesManagement.DataLayer.Repositories;

namespace VideoGamesManagement.BusinessLayer
{
    public class VideoGameService
    {
        public List<VideoGame> GetVideoGames()
        {
            var gameRepo = new VideoGameRepository();
            var games = gameRepo.GetAllVideoGame();
            return games;
        }

       

    }
}
