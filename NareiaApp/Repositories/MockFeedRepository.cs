using NareiaApp.Abstractions.Models;
using NareiaApp.Abstractions.Repositories;
using NareiaApp.Models;

namespace NareiaApp.Repositories
{
    public class MockFeedRepository : IFeedRepository
    {
        #region Fields

        private const int MaxPerGet = 25;

        #endregion

        #region Properties

        public IEnumerable<IUser> MockUsers =>
            new List<IUser>()
            {
                new User
                {
                    Name = "doglasses",
                    PictureUrl = "https://i.pinimg.com/564x/e3/81/f9/e381f94e800c75721a67f1300db80de3.jpg",
                    HasStories = true,
                    IsVerified = true,
                },
                new User
                {
                    Name = "dockey",
                    PictureUrl = "https://pm1.aminoapps.com/7669/788096ac14e5b76eb20204fc6308321ec638fe9ar1-514-752v2_uhq.jpg",
                    HasStories = false,
                    IsVerified = false,
                },
                new User
                {
                    Name = "doguybuilder",
                    PictureUrl = "https://www.ahnegao.com.br/wp-content/uploads/2022/11/imgaleat-6ck-1.jpg",
                    HasStories = false,
                    IsVerified = true,
                },
                new User
                {
                    Name = "hondog",
                    PictureUrl = "https://www.ahnegao.com.br/wp-content/uploads/2018/06/img-1.jpg",
                    HasStories = true,
                    IsVerified = false,
                }
            };

        public IEnumerable<string> MockTitles =>
            new List<string>()
            {
                "Promoting my company's new collection with a photoshoot",
                "Throwback to my vacation in Greece with my friends",
                "What is Lorem Ipsum?",
                "Vivamus lobortis aliquam eleifend. Nulla.",
                "Proin sed scelerisque diam. Quisque.",
            };

        public IEnumerable<string> MockDescriptions =>
            new List<string>()
            {
                "Time for a coffee break ☕️ Loving this new drink from @localcoffeeshop #supportlocal #coffeelover",
                "Vivamus lobortis aliquam eleifend. Nulla.",
                "Proin sed scelerisque diam. Quisque.",
            };

        public IEnumerable<string> MockPhotos =>
            new List<string>()
            {
                "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&w=1000&q=80",
                "https://www.fotor.com/blog/wp-content/uploads/2017/09/photo-composition-e1597393995467-797x1024.jpg",
                "https://www.industrialempathy.com/img/remote/ZiClJf-1920w.jpg",
                "https://www.adobe.com/acrobat/hub/media_173d13651460eb7e12c0ef4cf8410e0960a20f0ee.jpeg?width=1200&format=pjpg&optimize=medium",
                "https://i.insider.com/60638bd66183e1001981966a?width=1136&format=jpeg",
            };

        #endregion

        #region IFeedRepository

        public Task<IEnumerable<IFeedItem>> GetDailyFeedAsync()
        {
            var mockedFeed = CreateMockedFeed();

            return Task.FromResult(mockedFeed);
        }

        #endregion

        #region Private Methods

        private IEnumerable<IFeedItem> CreateMockedFeed()
        {
            var mockedFeed = new List<IFeedItem>();

            for (int i = 0; i < MaxPerGet; i++) 
            {
                var user = MockUsers.ElementAt(Random.Shared.Next(4));
                mockedFeed.Add(new FeedItem
                {
                    Title = MockTitles.ElementAt(Random.Shared.Next(5)),
                    Description = MockDescriptions.ElementAt(Random.Shared.Next(3)),
                    PhotoUrl = MockPhotos.ElementAt(Random.Shared.Next(5)),
                    User = user,
                });
            }

            return mockedFeed;
        }

        #endregion
    }
}
