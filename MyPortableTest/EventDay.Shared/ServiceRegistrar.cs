
using MyPortableTest.Helpers;
using MyPortableTest.Interfaces;
using MyPortableTest.Services;//using SQLite;



#if __IOS__
using EventDay.iOS.PlatformSpecific;
#elif __ANDROID__
using EventDayAndroid.PlatformSpecific;
#elif WINDOWS_PHONE
using Windows.Storage;
using EventDay.WindowsPhone.PlatformSpecific;
#endif

namespace MyExpenses.Helpers
{
    public static class ServiceRegistrar
    {

        public static void Startup()
        {

            //            SQLiteConnection connection = null;
            //
            //            string dbLocation = "eventday.sqlite";
            ILogger logger = new NullLogger();

#if __ANDROID__
      //var library = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      //dbLocation = Path.Combine(library, dbLocation);
      ServiceContainer.Register<IHttpClientHelper>(() => new HttpClientHelper());
        logger = new AndroidLogger();
#elif __IOS__

//            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
//            var libraryPath = Path.Combine(docsPath, "../Library/");
//            dbLocation = Path.Combine(libraryPath, dbLocation);
            ServiceContainer.Register<IHttpClientHelper>(() => new HttpClientHelper());

#elif WINDOWS_PHONE
      //dbLocation = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbLocation);
      ServiceContainer.Register<INavigationService>(()=>new NavigationService());
      
#endif

            ServiceContainer.Register<IEventDayService>(() => new EventDayService(logger));
        }

        ///-------Easy way to get any of our view models or services ----//

        public static IEventDayService EventDayService
        {
            get { return ServiceContainer.Resolve<IEventDayService>(); }
        }


    }
#if WINDOWS_PHONE
    /// <summary>
    /// for WP8
    /// </summary>
    public static INavigationService NavigationService
    {
      get { return ServiceContainer.Resolve<INavigationService>(); }
    }
#endif
}
