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

            var renderer = new DatabaseObjectViewRenderer();

            var result = renderer.Render(view);

            result.Should().Contain("View: Foo");
        }

        [Fact]
        public void View_Formatter_Outputs_DependenciesCorrectly()
        {
            var view = new View("FooView");

            view.AddDependency(new Table("FooTable"));

            var renderer = new DatabaseObjectViewRenderer();

            var result = renderer.Render(view);

            result.Should().Contain("Table: FooTable");
        }

        [Fact]
        public void View_Formatter_Outputs_ItColumnsCorrectly()
        {
            var view = new View("FooView");

            view.AddDependency(new Column("Bar", "int"));
            view.AddDependency(new Column("Bob", "string"));

            var renderer = new DatabaseObjectViewRenderer();

            var result = renderer.Render(view);

            result.Should().Contain("\tBar of type int\r\n\tBob of type string");
        }

        [Fact]
        public void View_Formatter_Outputs_DepenenciesColumnsOutputtedCorrectly()
        {
            var view = new View("FooView");

            var table = new Table("FooTable");

            table.AddColumn(new Column("Bar", "int"));
            table.AddColumn(new Column("Bob", "string"));

            view.AddDependency(table);

            var renderer = new DatabaseObjectViewRenderer();

            var result = renderer.Render(view);

            result.Should().Contain($"Table: FooTable{Environment.NewLine}\t\tBar of type int{Environment.NewLine}\t\tBob of type string");
        }

        [Fact]
        public void View_Formatter_Outputs_AllDataCorrectly()
        {
            var view = new View("FooView");

            view.AddDependency(new Column("Bar", "int"));
            view.AddDependency(new Column("Bob", "string"));

            var table = new Table("FooTable");

            table.AddColumn(new Column("Bar1", "int"));
            table.AddColumn(new Column("Bob1", "string"));

            view.AddDependency(table);

            var renderer = new DatabaseObjectViewRenderer();

            var result = renderer.Render(view);

            result.Should().Be($"View: FooView{Environment.NewLine}"+
                                        $"\tBar of type int{Environment.NewLine}\tBob of type string{Environment.NewLine}"+
                                        $"\tTable: FooTable{Environment.NewLine}\t\tBar1 of type int{Environment.NewLine}\t\tBob1 of type string");
        }
    }
}
