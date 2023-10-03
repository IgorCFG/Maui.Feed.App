namespace NareiaApp.Abstractions.Models
{
    public interface IUserModel
    {
        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public bool IsVerified { get; set; }
    }
}
