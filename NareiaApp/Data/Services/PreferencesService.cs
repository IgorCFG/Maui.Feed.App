using Maui.Feed.App.Abstractions.Services;

namespace Maui.Feed.App.Data.Services
{
    class PreferencesService : IPreferencesService
    {
        public string Get(string key, string defaultValue) =>
            Preferences.Get(key, defaultValue);

        public void Set(string key, string value) =>
            Preferences.Set(key, value);
    }
}
