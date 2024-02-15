using System;
using System.Text;
using OutputFormatters.Formatters;
using OutputFormatters.Formatters.Interfaces;
using OutputFormatters.Model;

namespace OutputFormatters.Tests
{
    public class DatabaseObjectStoredProcedureRenderer : DatabaseObjectRenderer<StoredProcedure>
    {
        private readonly DatabaseObjectTableRenderer _databaseObjectTableRenderer = new();
        private readonly DatabaseObjectViewRenderer _databaseObjectViewRenderer = new();

        public string Format(StoredProcedure storedProcedure, int initialTabIndentLevel = 0)
        {
            var stringBuilder = new StringBuilder();
            var initialTabIndent = initialTabIndentLevel == 0 ? string.Empty : new string('\t', initialTabIndentLevel);

            stringBuilder.Append($"{initialTabIndent}Stored Procedure: {storedProcedure.Name}");

            var tabIndentLevel = 0;
            foreach (var table in storedProcedure.Dependencies.GetTypes<Table>())
            {
                stringBuilder.Append($"{Environment.NewLine}{_databaseObjectTableRenderer.Format(table, tabIndentLevel + 1)}");
            }

            foreach (var view in storedProcedure.Dependencies.GetTypes<View>())
            {
                stringBuilder.Append($"{Environment.NewLine}{_databaseObjectViewRenderer.Format(view, tabIndentLevel + 1)}");
            }

            return stringBuilder.ToString();
        }
    }
}