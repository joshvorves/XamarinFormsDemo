namespace MyPortableTest.Interfaces
{
    public interface ISettingsSerializer
    {
        string Serialize<T>(T instance);
        T Deserialize<T>(string text);
    }
}