// Helpers/Settings.cs

using EventDay.Api.Client;
using MyPortableTest.Interfaces;
using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;

namespace MyPortableTest.Helpers
{
    /// <summary>
    ///     This is the Settings static class that can be used in your Core solution or in any
    ///     of your client applications. All settings are laid out the same exact way with getters
    ///     and setters.
    /// </summary>
    public static class AppSettings
    {
        private static readonly ISettingsSerializer Serializer;

        static AppSettings()
        {
            Serializer = new JsonSettingsSerializer();
        }

        private static ISettings Settings
        {
            get { return CrossSettings.Current; }
        }

        public static EventState EventState
        {
            get
            {
                return Serializer.Deserialize<EventState>(Settings.GetValueOrDefault<string>(EventStateKey));
            }
            set
            {
                Save(EventStateKey, value);
            }
        }

        public static TicketState UserTicket
        {
            get
            {
                return Serializer.Deserialize<TicketState>(Settings.GetValueOrDefault<string>(UserTicketKey));
            }
            set
            {
                Save(UserTicketKey, value);
            }
        }

        public static bool LoggedIn
        {
            get { return UserTicket != null; }
        }

        public static string AuthCode
        {
            get { return Settings.GetValueOrDefault(AuthCodeKey, ""); }
            set { Save(AuthCodeKey, value); }
        }

        #region Setting Constants

        private const string EventStateKey = "event_state";
        private const string AuthCodeKey = "auth_code";
        private const string UserTicketKey = "user_ticket";

        #endregion

        public static bool TryGetEventState(out EventState state)
        {
            state = EventState;
            return state != null;
        }

        public static bool TryGetUserTicket(out TicketState state)
        {
            state = UserTicket;
            return state != null;
        }

        private static void Save(string key, object value)
        {
            if (!(value is string))
            {
                value = Serializer.Serialize(value);
            }
            Settings.AddOrUpdateValue(key, value);
            Settings.Save();
        }
    }
}