using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using OutputFormatters.Formatters;
using OutputFormatters.Model;
using System;

namespace OutputFormatters.Tests
{
    public class ViewRendererTests
    {
        [Fact]
        public void View_Formatter_Outputs_ViewNameCorrectly()
        {
            var view = new View("Foo");

            var formatter = new DatabaseObjectViewRenderer();

            var result = formatter.Format(view);

            result.Should().Contain("View: Foo");
        }

        [Fact]
        public void View_Formatter_Outputs_DependenciesCorrectly()
        {
            var view = new View("FooView");

            var table = new Table("FooTable");
            view.Dependencies = new List<Table> {table};

            var formatter = new DatabaseObjectViewRenderer();

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

            var formatter = new DatabaseObjectViewRenderer();

            var result = formatter.Format(view);

            result.Should().Contain("\tBar of type int\r\n\tBob of type string");
        }

        [Fact]
        public void View_Formatter_Outputs_DepenenciesColumnsOutputtedCorrectly()
        {
            var view = new View("FooView");

            var table = new Table("FooTable");

            var columnA = new Column("Bar", "int");
            var columnB = new Column("Bob", "string");
            table.Columns = new List<Column> { columnA, columnB };

            view.Dependencies = new List<Table> { table };

            var formatter = new DatabaseObjectViewRenderer();

            var result = formatter.Format(view);

            result.Should().Contain($"Table: FooTable{Environment.NewLine}\t\tBar of type int{Environment.NewLine}\t\tBob of type string");
        }


        [Fact]
        public void View_Formatter_Outputs_AllDataCorrectly()
        {
            var view = new View("FooView");

            var columnA = new Column("Bar", "int");
            var columnB = new Column("Bob", "string");
            view.Columns = new List<Column> { columnA, columnB };

            var table = new Table("FooTable");

            var columnC = new Column("Bar1", "int");
            var columnD = new Column("Bob1", "string");
            table.Columns = new List<Column> { columnC, columnD };

            view.Dependencies = new List<Table> { table };

            var formatter = new DatabaseObjectViewRenderer();

            var result = formatter.Format(view);

            result.Should().Contain($"View: FooView{Environment.NewLine}"+
                                        $"\tBar of type int{Environment.NewLine}\tBob of type string{Environment.NewLine}"+
                                        $"\tTable: FooTable{Environment.NewLine}\t\tBar1 of type int{Environment.NewLine}\t\tBob1 of type string");
        }
    }
}
