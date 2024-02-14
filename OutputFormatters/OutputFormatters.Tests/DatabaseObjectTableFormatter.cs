using System;

namespace OutputFormatters.Tests
{
    internal class DatabaseObjectTableFormatter
    {
        public DatabaseObjectTableFormatter()
        {
        }

        public string Format(Table table)
        {
            return "Table: Foo" + Environment.NewLine;
        }
    }
}