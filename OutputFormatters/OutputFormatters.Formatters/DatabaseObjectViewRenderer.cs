using System;
using OutputFormatters.Model;
using System.Text;
using OutputFormatters.Tests;
using OutputFormatters.Formatters.Interfaces;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectViewRenderer : DatabaseObjectRenderer<View>
    {
        private readonly DatabaseObjectTableRenderer _databaseObjectTableFormatter = new();
        private readonly DatabaseObjectColumnRenderer _columnRenderer = new();

        public string Format(View view, int initialTabIndentLevel = 0)
        {
            var stringBuilder = new StringBuilder();
            var initialTabIndent = initialTabIndentLevel == 0 ? string.Empty : new string('\t', initialTabIndentLevel);

            stringBuilder.Append($"{initialTabIndent}View: {view.Name}");

            foreach (var column in view.Columns)
            {
                stringBuilder.Append($"{Environment.NewLine}{_columnRenderer.Format(column, initialTabIndentLevel + 1)}");
            }

            foreach (var dependency in view.Dependencies)
            {
                stringBuilder.Append($"{Environment.NewLine}{_databaseObjectTableFormatter.Format(dependency, initialTabIndentLevel + 1)}");
            }

            return stringBuilder.ToString();
        }
    }
}