using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Edura.WebUI.Infrastructure
{
    public static class SessionExtentions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);

            return data == null ? default : JsonConvert.DeserializeObject<T>(data);
        }
    }
}