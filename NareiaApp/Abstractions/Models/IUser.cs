namespace NareiaApp.Abstractions.Models
{
    public interface IUser
    {
        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public bool HasStories { get; set; }

        public bool IsVerified { get; set; }
    }
}
