using System.Collections.Generic;
using System.Linq;
using OutputFormatters.Model.Interfaces;

namespace OutputFormatters.Model
{
    public static class ModelExtensions
    {
        public static IReadOnlyList<T> GetReadOnlyListOfType<T>(this IList<IDatabaseObject> dependencies)
        {
            return dependencies.Where(d => d.GetType() == typeof(T)).Select(d => (T)d).ToList().AsReadOnly();
        }
    }
}
