using EventDay.Portable.Helpers;
using EventDay.Portable.Services;
using MyPortableTest.Interfaces;


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


            ILogger logger = new NullLogger();
            ServiceContainer.Register<IEventDayService>(() => new EventDayService(logger));
        }

//        ///-------Easy way to get any of our view models or services ----//
//        public static AttendeeViewModel Attendee
//        {
//            get { return ServiceContainer.Resolve<AttendeeViewModel>(); }
//        }

//        public static HomeViewModel Home
//        {
//            get { return ServiceContainer.Resolve<HomeViewModel>(); }
//        }

//        public static AboutViewModel About
//        {
//            get { return ServiceContainer.Resolve<AboutViewModel>(); }
//        }

//        public static SessionsViewModel Sessions
//        {
//            get { return ServiceContainer.Resolve<SessionsViewModel>(); }
//        }

//        public static SimpleSessionViewModel SimpleSessions
//        {
//            get { return ServiceContainer.Resolve<SimpleSessionViewModel>(); }
//        }
//        public static LocationViewModel Location
//        {
//            get { return ServiceContainer.Resolve<LocationViewModel>(); }
//        }

//        public static SpeakersViewModel Speakers
//        {
//            get { return ServiceContainer.Resolve<SpeakersViewModel>(); }
//        }

//        public static VenueViewModel Venue
//        {
//            get { return ServiceContainer.Resolve<VenueViewModel>(); }
//        }

//        public static IEventDayService EventDayService
//        {
//            get { return ServiceContainer.Resolve<IEventDayService>(); }
//        }

//        public static MyProfileViewModel MyProfile
//        {
//            get { return ServiceContainer.Resolve<MyProfileViewModel>(); }
//        }

//        public static MyTicketViewModel MyTicket
//        {
//            get { return ServiceContainer.Resolve<MyTicketViewModel>(); }
//        }

//        public static MySessionsViewModel MySession
//        {
//            get { return ServiceContainer.Resolve<MySessionsViewModel>(); }
//        }

//        public static MySpeakersViewModel MySpeakers
//        {
//            get { return ServiceContainer.Resolve<MySpeakersViewModel>(); }
//        }

//        public static MyFeedbackViewModel MyFeedback
//        {
//            get { return ServiceContainer.Resolve<MyFeedbackViewModel>(); }
//        }

//        public static SponsorsViewModel Sponsors
//        {
//            get { return ServiceContainer.Resolve<SponsorsViewModel>(); }
//        }

//        public static SessionTabViewModel SessionTab
//        {
//            get { return ServiceContainer.Resolve<SessionTabViewModel>(); }
//        }
//        public static ILogin LoginService
//        {
//            get { return ServiceContainer.Resolve<ILogin>(); }
//        }

//        public static IAuthService AuthService
//        {
//            get { return ServiceContainer.Resolve<IAuthService>(); }
//        }

//        public static IHttpClientHelper HttpClientHelper
//        {
//            get { return ServiceContainer.Resolve<IHttpClientHelper>(); }
//        }

//        public static IRSSReaderService RSSReaderService
//        {
//            get { return ServiceContainer.Resolve<IRSSReaderService>(); }
//        }

//        public static ISessionReaderService SessionTabReaderService
//        {
//            get { return ServiceContainer.Resolve<ISessionReaderService>(); }
//        }
//#if WINDOWS_PHONE
//    /// <summary>
//    /// for WP8
//    /// </summary>
//    public static INavigationService NavigationService
//    {
//      get { return ServiceContainer.Resolve<INavigationService>(); }
//    }
//#endif
    }
}