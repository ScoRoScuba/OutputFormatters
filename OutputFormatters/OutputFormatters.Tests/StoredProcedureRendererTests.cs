using System;
using FluentAssertions;
using OutputFormatters.Formatters;
using OutputFormatters.Model;
using Xunit;

namespace OutputFormatters.Tests
{
    public class StoredProcedureRendererTests
    {
        [Fact]
        public void StoredProcedure_Renderer_TableNameCorrectly()
        {
            var storedProcedure = new StoredProcedure("FooSP");

            var renderer= new DatabaseObjectStoredProcedureRenderer();

            var result = renderer.Render(storedProcedure);

            result.Should().Contain("Stored Procedure: FooSP");
        }

        [Fact]
        public void StoredProcedure_Renderer_OutputsDependentTableCorrectly()
        {
            var storedProcedure = new StoredProcedure("FooSP");

            var table = new Table("Foo");

            storedProcedure.AddDependency(table);

            var renderer = new DatabaseObjectStoredProcedureRenderer();

            var result = renderer.Render(storedProcedure);

            result.Should().Contain("Table: Foo");
        }

        [Fact]
        public void StoredProcedure_Renderer_OutputsDependentTableIndentedCorrectly()
        {
            var storedProcedure = new StoredProcedure("FooSP");

            var table = new Table("Foo");

            storedProcedure.AddDependency(table);

            var renderer = new DatabaseObjectStoredProcedureRenderer();

            var result = renderer.Render(storedProcedure);

            result.Should().Contain("\tTable: Foo");
        }

        [Fact]
        public void StoredProcedure_Renderer_OutputsDependentViewIndentedCorrectly()
        {
            var storedProcedure = new StoredProcedure("FooSP");

            var view = new View("FooVw");
            var columnA = new Column("Bar", "int");
            var columnB = new Column("Bob", "string");
            view.AddDependency(columnA);
            view.AddDependency(columnB);

            storedProcedure.AddDependency(view);

            var renderer = new DatabaseObjectStoredProcedureRenderer();

            var result = renderer.Render(storedProcedure);

            result.Should().Contain("\tView: FooVw\r\n\t\tBar of type int\r\n\t\tBob of type string");
        }

        [Fact]
        public void StoredProcedure_Renderer_OutputsDependentsIndentedCorrectly()
        {
            var storedProcedure = new StoredProcedure("FooSP");

            var table = new Table("Baz");
            table.AddColumn(new Column("Bosh", "int"));

            var view = new View("Banana");
            var viewTable = new Table("Salary");
            viewTable.AddColumn(new Column("Bosh", "int"));
            view.AddDependency(viewTable);

            storedProcedure.AddDependency(table);
            storedProcedure.AddDependency(view);

            var renderer = new DatabaseObjectStoredProcedureRenderer();

            var result = renderer.Render(storedProcedure);

            var expected = $"Stored Procedure: FooSP{Environment.NewLine}" +
                           $"\tTable: Baz{Environment.NewLine}" +
                           $"\t\tBosh of type int{Environment.NewLine}" +
                           $"\tView: Banana{Environment.NewLine}" +
                           $"\t\tTable: Salary{Environment.NewLine}" +
                           $"\t\t\tBosh of type int";

            result.Should().Be(expected);
        }
    }
}