using RestApi.Entities;
using System.Collections.Generic;

namespace RestApi.Persistence
{
    public class GameDbContext
    {
        public List<Game> Games { get; set; }

        public GameDbContext()
        {
            Games = new List<Game>();
        }
    }
}
