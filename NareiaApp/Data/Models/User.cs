using Newtonsoft.Json;

namespace Maui.Feed.App.Data.Models
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pictureUrl")]
        public string PictureUrl { get; set; }

        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }
    }
}
