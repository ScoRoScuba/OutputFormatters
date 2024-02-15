
using System.Text;
using OutputFormatters.Model;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectTableRenderer
    {
        public string Format(Table table)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"Table: {table.Name}");

            foreach (var column in table.Columns)
            {
                stringBuilder.Append($"{Environment.NewLine}\t{column.Name} of type {column.Type}");
            }

            return stringBuilder.ToString();
        }
    }
}