namespace RestApi.Entities
{
    public class DevEvent
    {

        public DevEvent()
        {
            Speakers = new List<DevEventSpeakers>();
            isDeleted = false;
        }

        public Guid id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DevEventSpeakers> Speakers { get; set;}

        public bool isDeleted { get; set; }

        public void Update(string tittle, string description, DateTime startDate, DateTime endDate)
        {
            Tittle = tittle;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
        public void Delete()
        {
            isDeleted = true;
        }
    }
}
