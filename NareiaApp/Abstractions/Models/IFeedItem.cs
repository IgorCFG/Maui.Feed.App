namespace NareiaApp.Abstractions.Models
{
    public interface IFeedItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public IUser User { get; set; }
    }
}
