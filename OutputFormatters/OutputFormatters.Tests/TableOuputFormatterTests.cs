using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Data.Common;

namespace OutputFormatters.Tests
{
    public class TableOuputFOrmatterTests
    {
        [Fact]
        public void Table_Formatter_Outputs_TableNameCorrectly()
        {
            var table = new Table("Foo");

            var formatter = new DatabaseObjectTableFormatter();

            var result = formatter.Format(table);

            result.Should().Contain("Table: Foo\r\n");
        }

        [Fact]
        public void Table_Formatter_Outputs_ColumnsCorrectly()
        {
            var table = new Table("Foo");

            var columnA = new Column("Bar", "int");
            table.Columns = new List<Column> { columnA };

            var formatter = new DatabaseObjectTableFormatter();

            var result = formatter.Format(table);

            result.Should().Contain("\tBar of type int");
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