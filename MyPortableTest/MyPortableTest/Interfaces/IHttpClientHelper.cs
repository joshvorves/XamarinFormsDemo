using System.Net.Http;

namespace MyPortableTest.Interfaces
{
    public class IHttpClientHelper
    {
        HttpMessageHandler MessageHandler { get; set; }
    }
}
