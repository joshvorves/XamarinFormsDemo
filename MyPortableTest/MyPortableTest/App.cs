using System.Threading.Tasks;
using EventDay.Api.Client;
using MyExpenses.Helpers;
using MyPortableTest.Helpers;
using MyPortableTest.Interfaces;
using Xamarin.Forms;

namespace MyPortableTest
{
    public class App
    {
        private static IEventDayService _eventDayService;
        public static EventState Eventstate;
        public static Page GetMainPage()
        {
            
            ServiceRegistrar.Startup();
            _eventDayService = ServiceRegistrar.EventDayService;
            Eventstate = _eventDayService.GetEntireEvent().Result;

            var navigationPage = new NavigationPage(new MyList());
            //navigationPage.
            return navigationPage;
        }
    }
}
