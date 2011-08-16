namespace GeoffBurnsTaskList.Models
{
    public class DueTask
    {
        public string Task { get; set; }
        public PriorityStatus Priority { get; set; }
        public string DueStatus { get; set; }
    }
}