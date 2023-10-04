using Newtonsoft.Json;

namespace NareiaApp.Data.Models
{
    public class FeedCollection
    {
        [JsonProperty("items")]
        public IEnumerable<FeedItem> Items { get; set; }
    }
}
