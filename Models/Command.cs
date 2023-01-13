namespace VersedApi.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string CommandString { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        // TODO: add a platform:String property
        public DateTime CreateOn { get; set; } = DateTime.Now;
    }
}