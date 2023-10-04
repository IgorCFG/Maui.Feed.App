using Newtonsoft.Json;

namespace Maui.Feed.App.Data.Models
{
    public class FeedItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("photoUrl")]
        public string PhotoUrl { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
