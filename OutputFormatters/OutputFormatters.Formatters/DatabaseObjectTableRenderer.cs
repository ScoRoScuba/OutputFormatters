using System;
using System.Text;
using OutputFormatters.Model;
using OutputFormatters.Tests;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectTableRenderer
    {
        private readonly DatabaseObjectColumnRenderer _columnRenderer = new();
        public string Format(Table table, int initialTabIndentLevel = 0)
        {
            var stringBuilder = new StringBuilder();

            var initialTabIndent = initialTabIndentLevel == 0 ? string.Empty : new string( '\t', initialTabIndentLevel);

            stringBuilder.Append($"{initialTabIndent}Table: {table.Name}");

            foreach (var column in table.Columns)
            {
                stringBuilder.Append($"{Environment.NewLine}{_columnRenderer.Format(column, initialTabIndentLevel+1)}");
            }

            return stringBuilder.ToString();
        }
    }
}