namespace NareiaApp.Abstractions.Models
{
    public interface IFeedItemModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public IUserModel User { get; set; }
    }
}
