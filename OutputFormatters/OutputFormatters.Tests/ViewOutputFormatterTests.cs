using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using OutputFormatters.Formatters;
using OutputFormatters.Model;

namespace OutputFormatters.Tests
{
    public class ViewOutputFormatterTests
    {
        [Fact]
        public void View_Formatter_Outputs_ViewNameCorrectly()
        {
            var view = new View("Foo");

            var formatter = new DatabaseObjectViewFormatter();

            var result = formatter.Format(view);

            result.Should().Contain("View: Foo");
        }

        [Fact]
        public void View_Formatter_Outputs_DependenciesCorrectly()
        {
            var view = new View("FooView");

            var table = new Table("FooTable");
            view.Dependencies = new List<Table> {table};

            var formatter = new DatabaseObjectViewFormatter();

            var result = formatter.Format(view);

            result.Should().Contain("Table: FooTable");
        }

        [Fact]
        public void View_Formatter_Outputs_ItColumnsCorrectly()
        {
            var view = new View("FooView");

            var columnA = new Column("Bar", "int");
            var columnB = new Column("Bob", "string");
            view.Columns = new List<Column> { columnA, columnB };

            var formatter = new DatabaseObjectViewFormatter();

            var result = formatter.Format(view);

            result.Should().Contain("\tBar of type int\r\n\tBob of type string");
        }
    }
}
