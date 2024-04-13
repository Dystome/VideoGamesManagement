using Microsoft.AspNetCore.Mvc;
using VideoGamesManagement.DataLayer.Entities;

namespace VideoGamesManagement.DataLayer.Repositories
{
    public interface IVideoGameRepository
    {
        public void AddVideoGames(VideoGame game);
        public void DeleteVideoGame(VideoGame game);
        public List<VideoGame> GetAllVideoGames();
        public VideoGame FindByID(int id);
        public void UpdateVideoGame(VideoGame game);

    }
}
