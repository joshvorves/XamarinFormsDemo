 //using SQLite;


#if __IOS__

#elif __ANDROID__
using MyPortableTest.Droid;
#elif WINDOWS_PHONE
using Windows.Storage;

#endif
using MyPortableTest.Interfaces;
using MyPortableTest.Services;

namespace Shared
{
    public static class ServiceRegistrar
    {

        public static void Startup()
        {
            ILogger logger = new NullLogger();

#if __ANDROID__

        logger = new AndroidLogger();
#elif __IOS__

#elif WINDOWS_PHONE
      
#endif

            ServiceContainer.Register<IEventDayService>(() => new EventDayService(logger));
        }

        ///-------Easy way to get any of our view models or services ----//

        public static IEventDayService EventDayService
        {
            get { return ServiceContainer.Resolve<IEventDayService>(); }
        }


    }

    /*
     * #if WINDOWS_PHONE
        /// <summary>
        /// for WP8
        /// </summary>
        public static INavigationService NavigationService
        {
          get { return ServiceContainer.Resolve<INavigationService>(); }
        }
    #endif
     */
}
