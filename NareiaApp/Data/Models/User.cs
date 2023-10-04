using Newtonsoft.Json;

namespace NareiaApp.Data.Models
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
