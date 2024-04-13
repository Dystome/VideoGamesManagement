using VideoGamesManagement.DataLayer.DBContext;
using VideoGamesManagement.DataLayer.Entities;

namespace VideoGamesManagement.DataLayer.Repositories
{
    public class VideoGameRepository
    {
        private readonly VideoGamesManagementDBContext _gamesManagementDBContext;
        public VideoGameRepository()
        {
            _gamesManagementDBContext = new VideoGamesManagementDBContext();
        }
        public void AddVideoGame(VideoGame videoGame)
        {
            _gamesManagementDBContext.VideoGames.Add(videoGame);
            _gamesManagementDBContext.SaveChanges();
        }
        // Get All VideoGame
        public List<VideoGame> GetAllVideoGame()
        {
            var games = _gamesManagementDBContext.VideoGames.ToList();
            return games;
        }
        // Get By ID
        public VideoGame FindByID(int id)
        {
            try
            {
                var game = _gamesManagementDBContext.VideoGames.Where(p => p.ID == id)
                    .FirstOrDefault();
                return game;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        //Update
        //Remove
        public void DeleteVideoGame(VideoGame game)
        {
            try
            {
                _gamesManagementDBContext.VideoGames.Remove(game);
                _gamesManagementDBContext.SaveChanges();
                Console.WriteLine("VideoGame removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message.ToString());
                throw ex;
            }
        }
        public void UpdateVideoGame(VideoGame game)
        {

            try
            {
                _gamesManagementDBContext.VideoGames.Update(game);
                _gamesManagementDBContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}

