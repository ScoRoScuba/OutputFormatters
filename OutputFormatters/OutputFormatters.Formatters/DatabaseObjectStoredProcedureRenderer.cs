using System;
using System.Linq;
using System.Text;
using OutputFormatters.Formatters;
using OutputFormatters.Model;

namespace OutputFormatters.Tests
{
    public class DatabaseObjectStoredProcedureRenderer 
    {
        private readonly DatabaseObjectTableRenderer _databaseObjectTableRenderer = new();

        public string Format(StoredProcedure storedProcedure)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"StoredProcedure: {storedProcedure.Name}");

            var tabIndentLevel = 0;

            foreach (var table in storedProcedure.Dependencies.Where( d => d.GetType() == typeof(Table)).Select( d => d as Table))
            {
                stringBuilder.Append($"{Environment.NewLine}\t{_databaseObjectTableRenderer.Format(table, tabIndentLevel+1)}");
            }

            return stringBuilder.ToString();
        }
    }
}