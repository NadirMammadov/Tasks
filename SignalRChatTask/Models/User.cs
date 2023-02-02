namespace SignalRChatTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public static List<string>? Message { get; set; }
        public string ConnectionId { get; set; }
    }
}
