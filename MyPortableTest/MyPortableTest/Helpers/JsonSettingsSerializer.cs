using MyPortableTest.Interfaces;
using Newtonsoft.Json;

namespace MyPortableTest.Helpers
{
    public class JsonSettingsSerializer : ISettingsSerializer
    {
        public string Serialize<T>(T instance)
        {
            return JsonConvert.SerializeObject(instance);
        }

        public T Deserialize<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}