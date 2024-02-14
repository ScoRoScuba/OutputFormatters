using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using OutputFormatters.Formatters;
using OutputFormatters.Model;

namespace OutputFormatters.Tests
{
    public class TableOuputFormatterTests
    {
        [Fact]
        public void Table_Formatter_Outputs_TableNameCorrectly()
        {
            var table = new Table("Foo");

            var formatter = new DatabaseObjectTableFormatter();

            var result = formatter.Format(table);

            result.Should().Contain("Table: Foo");
        }

        [Fact]
        public void Table_Formatter_Outputs_ColumnsAllCorrectly()
        {
            var table = new Table("Foo");

            var columnA = new Column("Bar", "int");
            var columnB= new Column("Bob", "string");
            table.Columns = new List<Column> { columnA, columnB };

            var formatter = new DatabaseObjectTableFormatter();

            var result = formatter.Format(table);

            result.Should().Contain("\tBar of type int\r\n\tBob of type string");
        }

        [Fact]
        public void Table_Formatter_Outputs_AllTableDataCorrectly()
        {
            var table = new Table("Foo");

            var columnA = new Column("Bar", "int");
            table.Columns = new List<Column> { columnA };

            var formatter = new DatabaseObjectTableFormatter();

            var result = formatter.Format(table);

            result.Should().Be($"Table: Foo{Environment.NewLine}\tBar of type int");
        }
    }
}