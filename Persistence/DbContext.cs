using RestApi.Entities;

namespace RestApi.Persistence
{
    public class DbContext
    {
        public List<DevEvent> DevEvents { get; set; }

        public DbContext() 
        {
         DevEvents = new List<DevEvent>();
        }
    }
}
