using Xamarin.Forms;

namespace MyPortableTest
{
    public class App
    {
        public static Page GetMainPage()
        {
            var navigationPage = new NavigationPage(new MyList());
            //navigationPage.
            return navigationPage;
        }
    }
}