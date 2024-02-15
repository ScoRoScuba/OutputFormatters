using System;
using System.Text;
using OutputFormatters.Formatters.Interfaces;
using OutputFormatters.Model;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectStoredProcedureRenderer : IDatabaseObjectRenderer<StoredProcedure>
    {
        private readonly DatabaseObjectTableRenderer _databaseObjectTableRenderer = new();
        private readonly DatabaseObjectViewRenderer _databaseObjectViewRenderer = new();

        public string Render(StoredProcedure storedProcedure, int initialTabIndentLevel = 0)
        {
            var stringBuilder = new StringBuilder();
            var initialTabIndent = initialTabIndentLevel == 0 ? string.Empty : new string('\t', initialTabIndentLevel);

            stringBuilder.Append($"{initialTabIndent}Stored Procedure: {storedProcedure.Name}");

            var tabIndentLevel = 0;
            foreach (var table in storedProcedure.Tables)
            {
                stringBuilder.Append($"{Environment.NewLine}{_databaseObjectTableRenderer.Render(table, tabIndentLevel + 1)}");
            }

            foreach (var view in storedProcedure.Views)
            {
                stringBuilder.Append($"{Environment.NewLine}{_databaseObjectViewRenderer.Render(view, tabIndentLevel + 1)}");
            }

            return stringBuilder.ToString();
        }
    }
}