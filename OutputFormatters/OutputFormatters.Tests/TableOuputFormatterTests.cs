using System;
using Xunit;
using FluentAssertions;

namespace OutputFormatters.Tests
{
    public class TableOuputFOrmatterTests
    {
        [Fact]
        public void Table_Formatter_Outputs_TableName()
        {
            var table = new Table("foo");

            var formatter = new DatabaseObjectTableFormatter();

            var result = formatter.Format(table);

            result.Should().Be("Table: Foo\r\n");
        }
    }
}