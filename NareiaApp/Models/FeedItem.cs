using NareiaApp.Abstractions.Models;

namespace NareiaApp.Models
{
    public class FeedItem : IFeedItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public IUser User { get; set; }
    }
}
