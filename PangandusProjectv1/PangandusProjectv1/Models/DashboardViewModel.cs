namespace PangandusProjectv1.Models
{
    public class DashboardViewModel
    {
        public string FullName { get; set; }
        public decimal AccountBalance { get; set; }
        public string Email { get; set; }

        public int UserID { get; set; } = 15231251; // Kasutajatunnus Praegune placeholder hilisemas sprindis teen loogika kui vaja
        public DateTime MemberSince { get; set; }
    }
}
