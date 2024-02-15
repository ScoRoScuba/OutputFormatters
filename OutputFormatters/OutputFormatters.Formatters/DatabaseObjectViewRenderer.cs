using System;
using OutputFormatters.Model;
using System.Text;
using OutputFormatters.Tests;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectViewRenderer
    {
        private readonly DatabaseObjectTableRenderer _databaseObjectTableFormatter = new();
        private readonly DatabaseObjectColumnRenderer _columnRenderer = new();

        public string Format(View view)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"View: {view.Name}");

            foreach (var column in view.Columns)
            {
                stringBuilder.Append($"{Environment.NewLine}\t{_columnRenderer.Format(column)}");
            }

            foreach (var dependency in view.Dependencies)
            {
                stringBuilder.Append($"{Environment.NewLine}\t{_databaseObjectTableFormatter.Format(dependency)}");
            }

            return stringBuilder.ToString();
        }
    }
}