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

       public void AddGame(VideoGame game)
       {
            var gameRepo = new VideoGameRepository();
            gameRepo.AddVideoGame(game);
       }

        public void UpdateGame(VideoGame? game)
        { 
            var gameRepo = new VideoGameRepository();

            if (game.Name != "string") 
            {
                game.Name = game.Name;
                gameRepo.UpdateVideoGame(game);
            }
            if (game.Studio != "string")
            {
                game.Studio = game.Studio;
                gameRepo.UpdateVideoGame(game);
            }
            if (game.Size != null && game.Size != 0)
            {
                game.Size = game.Size;
                gameRepo.UpdateVideoGame(game);
            }
        }
        public void RemoveGame(VideoGame game) 
        {
            var gameRepo = new VideoGameRepository();
            gameRepo.DeleteVideoGame(game);
        }

    }
}
