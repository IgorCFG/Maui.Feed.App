namespace Maui.Feed.App.Abstractions.Services
{
    public interface IPreferencesService
    {
        string Get(string key, string defaultValue);

        void Set(string key, string value);
    }
}
