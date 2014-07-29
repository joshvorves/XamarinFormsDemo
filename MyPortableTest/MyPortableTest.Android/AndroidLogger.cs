using MyPortableTest.Services;

namespace MyPortableTest.Droid
{
    public class AndroidLogger : ILogger
    {
        public void Info(string message)
        {
            Android.Util.Log.Info("EventDay", message);
        }

        public void Error(string message)
        {
            Android.Util.Log.Error("EventDay", message);
        }
    }

}
