using System;
using System.Collections.Generic;

namespace RestApi.Entities
{
    public class Game
    {
        public Game()
        {
            Speakers = new List<GameSpeaker>();
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Platform { get; set; }
        public List<GameSpeaker> Speakers { get; set; }

        public bool IsDeleted { get; set; }

        public void Update(string title, string description, DateTime releaseDate, string platform)
        {
            Title = title;
            Description = description;
            ReleaseDate = releaseDate;
            Platform = platform;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
