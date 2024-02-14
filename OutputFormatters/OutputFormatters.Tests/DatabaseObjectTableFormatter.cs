using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Text;

namespace OutputFormatters.Tests
{
    public class DatabaseObjectTableFormatter
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