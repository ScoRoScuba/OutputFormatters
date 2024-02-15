using System;
using System.Linq;
using System.Text;
using OutputFormatters.Formatters;
using OutputFormatters.Formatters.Interfaces;
using OutputFormatters.Model;

namespace OutputFormatters.Tests
{
    public class DatabaseObjectStoredProcedureRenderer : DatabaseObjectRenderer<StoredProcedure>
    {
        private readonly DatabaseObjectTableRenderer _databaseObjectTableRenderer = new();

        public string Format(StoredProcedure storedProcedure, int initialTabIndentLevel = 0)
        {
            var stringBuilder = new StringBuilder();

            var initialTabIndent = initialTabIndentLevel == 0 ? string.Empty : new string('\t', initialTabIndentLevel);

            stringBuilder.Append($"{initialTabIndent}StoredProcedure: {storedProcedure.Name}");

            var tabIndentLevel = 0;

            foreach (var table in storedProcedure.Dependencies.Where( d => d.GetType() == typeof(Table)).Select( d => d as Table))
            {
                stringBuilder.Append($"{Environment.NewLine}\t{_databaseObjectTableRenderer.Format(table, tabIndentLevel+1)}");
            }

            return stringBuilder.ToString();
        }
    }
}