using System.Net.Http;
using ModernHttpClient;
using MyPortableTest.Interfaces;

namespace MyPortableTest.Helpers.PlatformSpecific
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private HttpMessageHandler handler;
        public HttpMessageHandler MessageHandler
        {
            get { return handler ?? (handler = new NativeMessageHandler()); }
        }
    }
}
