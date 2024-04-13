using Microsoft.AspNetCore.Mvc;
using VideoGamesManagement.DataLayer.Entities;

namespace VideoGamesManagement.BusinessLayer
{
    public interface IVideoGameService
    {
        
        public void UpdateGame(VideoGame videoGame);
        public void RemoveGame(VideoGame videoGame);
        public void AddGame(VideoGame videoGame);
       
        public List<VideoGame> GetVideoGames();
    }
}
