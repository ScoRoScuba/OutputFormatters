using OutputFormatters.Model;

namespace OutputFormatters.Formatters.Interfaces
{
    public interface DatabaseObjectRenderer<in T>
    {
        string Format(T databaseObject, int initialTabIndentLevel = 0);
    }
}
