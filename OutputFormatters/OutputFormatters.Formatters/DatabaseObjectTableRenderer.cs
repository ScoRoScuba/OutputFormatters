using System;
using System.Text;
using OutputFormatters.Model;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectTableRenderer
    {
        public string Format(Table table, int initialTabIndentLevel = 0)
        {
            var stringBuilder = new StringBuilder();

            var initialTabIndent = initialTabIndentLevel == 0 ? string.Empty : new string( '\t', initialTabIndentLevel);

            stringBuilder.Append($"{initialTabIndent}Table: {table.Name}");

            foreach (var column in table.Columns)
            {
                stringBuilder.Append($"{Environment.NewLine}\t{column.Name} of type {column.Type}");
            }

            return stringBuilder.ToString();
        }
    }
}