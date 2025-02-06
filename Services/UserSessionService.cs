using System.Collections.Generic;

namespace EventEase.Services
{
    public class UserSessionService
    {
        private Dictionary<string, object> sessionData = new Dictionary<string, object>();

        public void SetSessionData(string key, object value)
        {
            sessionData[key] = value;
        }

        public T? GetSessionData<T>(string key)
        {
            if (sessionData.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            return default;
        }
    }
}
