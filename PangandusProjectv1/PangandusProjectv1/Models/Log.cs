namespace PangandusProjectv1.Models
{
    //Decided to get the basic logic for Log's made just in case when back in school we have to do a 3rd sprint
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public string Action { get; set; }
    }
}
