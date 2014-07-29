using Android.App;
using Android.OS;
using Android.Views;
using EventDay.Api.Client;
using MyPortableTest.Helpers;
using MyPortableTest.Interfaces;
using MyPortableTest.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MyPortableTest.Droid
{
    [Activity(Label = "MyPortableTest", MainLauncher = true)]
    public class MainActivity : AndroidActivity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            IEventDayService eventDayService = new EventDayService(new AndroidLogger());
            EventState eventState = await eventDayService.GetEntireEvent();
            AppSettings.EventState = eventState;

            Forms.Init(this, bundle);
            SetPage(App.GetMainPage());
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            return true;
        }
    }
}