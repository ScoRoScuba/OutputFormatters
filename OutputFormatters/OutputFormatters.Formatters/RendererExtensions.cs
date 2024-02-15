using OutputFormatters.Model;
using System.Collections.Generic;
using System.Linq;

namespace OutputFormatters.Formatters
{
    public static class RendererExtensions
    {
        public static IEnumerable<T> GetTypes<T>(this IEnumerable<DatabaseObject> dependencies)
        {
            return dependencies.Where(d => d.GetType() == typeof(T)).Select(d => (T)d);
        }
    }
}
