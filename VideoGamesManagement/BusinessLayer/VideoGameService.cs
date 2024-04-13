using VideoGamesManagement.DataLayer.Entities;
using VideoGamesManagement.DataLayer.Repositories;

namespace VideoGamesManagement.BusinessLayer
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IVideoGameRepository _videoGameRepository;

        public VideoGameService(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }
        public List<VideoGame> GetVideoGames()
        {
            var games = _videoGameRepository.GetAllVideoGames();
            return games;
        }

        public void AddGame(VideoGame game)
        {
            _videoGameRepository.AddVideoGames(game);
        }

        public void UpdateGame(VideoGame? game)
        {

            if (game.Name != "string")
            {
                game.Name = game.Name;
                _videoGameRepository.UpdateVideoGame(game);
            }
            if (game.Studio != "string")
            {
                game.Studio = game.Studio;
                _videoGameRepository.UpdateVideoGame(game);
            }
            if (game.Size != null && game.Size != 0)
            {
                game.Size = game.Size;
                _videoGameRepository.UpdateVideoGame(game);
            }
        }
        public void RemoveGame(VideoGame game)
        {
            _videoGameRepository.DeleteVideoGame(game);
        }

    }
}
