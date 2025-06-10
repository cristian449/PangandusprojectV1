namespace PangandusProjectv1.Models
{
    public class AdminDashBoardViewModel
    {
        public string AdminName { get; set; }

        public int TotalUsers { get; set; }

        public int ActiveUsersToday { get; set; }

        public int SystemLogsCount { get; set; }  //At the moment has no use as once again logic for Logs has not been made

        public List<User> RecentUsers { get; set; }
    }
}
