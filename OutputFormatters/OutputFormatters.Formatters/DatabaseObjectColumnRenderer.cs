using OutputFormatters.Formatters.Interfaces;
using OutputFormatters.Model;

namespace OutputFormatters.Tests;

public class DatabaseObjectColumnRenderer: DatabaseObjectRenderer<Column>
{
    public string Format(Column column, int initialTabIndentLevel = 0)
    {
        var initialTabIndent = initialTabIndentLevel == 0 ? string.Empty : new string('\t', initialTabIndentLevel);

        return $"{initialTabIndent}{column.Name} of type {column.Type}";
    }
}