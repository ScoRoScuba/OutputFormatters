using System;
using OutputFormatters.Model;
using System.Text;
using OutputFormatters.Formatters.Interfaces;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectViewRenderer : IDatabaseObjectRenderer<View>
    {
        private readonly DatabaseObjectTableRenderer _databaseObjectTableRenderer = new();
        private readonly DatabaseObjectColumnRenderer _columnRenderer = new();

        public string Render(View view, int initialTabIndentLevel = 0)
        {
            var stringBuilder = new StringBuilder();
            var initialTabIndent = initialTabIndentLevel == 0 ? string.Empty : new string('\t', initialTabIndentLevel);

            stringBuilder.Append($"{initialTabIndent}View: {view.Name}");

            foreach (var column in view.Columns)
            {
                stringBuilder.Append($"{Environment.NewLine}{_columnRenderer.Render(column, initialTabIndentLevel + 1)}");
            }

            foreach (var table in view.Tables)
            {
                stringBuilder.Append($"{Environment.NewLine}{_databaseObjectTableRenderer.Render(table, initialTabIndentLevel + 1)}");
            }

            return stringBuilder.ToString();
        }
    }
}