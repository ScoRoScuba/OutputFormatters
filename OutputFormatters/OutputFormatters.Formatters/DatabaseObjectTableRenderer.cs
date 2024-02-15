using System;
using System.Text;
using OutputFormatters.Formatters.Interfaces;
using OutputFormatters.Model;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectTableRenderer : IDatabaseObjectRenderer<Table>
    {
        private readonly DatabaseObjectColumnRenderer _columnRenderer = new();

        public string Render(Table table, int initialTabIndentLevel = 0)
        {
            var stringBuilder = new StringBuilder();
            var initialTabIndent = initialTabIndentLevel == 0 ? string.Empty : new string( '\t', initialTabIndentLevel);

            stringBuilder.Append($"{initialTabIndent}Table: {table.Name}");

            foreach (var column in table.Columns)
            {
                stringBuilder.Append($"{Environment.NewLine}{_columnRenderer.Render(column, initialTabIndentLevel+1)}");
            }

            return stringBuilder.ToString();
        }
    }
}