using System;
using Xunit;
using FluentAssertions;
using OutputFormatters.Formatters;
using OutputFormatters.Model;

namespace OutputFormatters.Tests
{
    public class TableRendererTests
    {
        [Fact]
        public void Table_Formatter_Outputs_TableNameCorrectly()
        {
            var table = new Table("Foo");

            var renderer = new DatabaseObjectTableRenderer();

            var result = renderer.Render(table);

            result.Should().Contain("Table: Foo");
        }

        [Fact]
        public void Table_Formatter_Outputs_ColumnsAllCorrectly()
        {
            var table = new Table("Foo");

            table.AddColumn(new Column("Bar", "int"));
            table.AddColumn(new Column("Bob", "string"));

            var renderer = new DatabaseObjectTableRenderer();

            var result = renderer.Render(table);

            result.Should().Contain("\tBar of type int\r\n\tBob of type string");
        }

        [Fact]
        public void Table_Formatter_Outputs_AllTableDataCorrectly()
        {
            var table = new Table("Foo");

            table.AddColumn(new Column("Bar", "int"));

            var renderer = new DatabaseObjectTableRenderer();

            var result = renderer.Render(table);

            result.Should().Be($"Table: Foo{Environment.NewLine}\tBar of type int");
        }
    }
}