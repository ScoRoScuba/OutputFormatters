namespace OutputFormatters.Formatters.Interfaces
{
    public interface IDatabaseObjectRenderer<in T>
    {
        string Render(T databaseObject, int initialTabIndentLevel = 0);
    }
}
