using Newtonsoft.Json;

namespace Maui.Feed.App.Data.Models
{
    public class FeedCollection
    {
        [JsonProperty("items")]
        public IEnumerable<FeedItem> Items { get; set; }
    }
}
