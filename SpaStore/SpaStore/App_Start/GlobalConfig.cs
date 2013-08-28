using System.Web.Http;
using Newtonsoft.Json.Serialization;
using SpaStore.Filters;

namespace SpaStore
{
    public class GlobalConfig
    {
        public static void CustomizeConfig(HttpConfiguration config)
        {
            // comment this in production
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // apply global validation filter for WebApi
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}