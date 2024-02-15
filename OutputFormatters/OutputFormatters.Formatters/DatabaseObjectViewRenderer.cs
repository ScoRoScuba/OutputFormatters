using System;
using OutputFormatters.Model;
using System.Text;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectViewRenderer
    {
        private readonly DatabaseObjectTableRenderer _databaseObjectTableFormatter = new DatabaseObjectTableRenderer();

        public string Format(View view)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"View: {view.Name}");

            foreach (var column in view.Columns)
            {
                stringBuilder.Append($"{Environment.NewLine}\t{column.Name} of type {column.Type}");
            }

            foreach (var dependency in view.Dependencies)
            {
                stringBuilder.Append($"{Environment.NewLine}\t{_databaseObjectTableFormatter.Format(dependency)}");
            }

            return stringBuilder.ToString();
        }
    }
}