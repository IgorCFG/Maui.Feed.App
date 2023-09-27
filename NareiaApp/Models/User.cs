using NareiaApp.Abstractions.Models;

namespace NareiaApp.Models
{
    public class User : IUser
    {
        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public bool HasStories { get; set; }

        public bool IsVerified { get; set; }
    }
}
