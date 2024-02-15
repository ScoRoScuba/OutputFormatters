using System;
using System.Collections.Generic;
using FluentAssertions;
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

            var formatter = new DatabaseObjectStoredProcedureRenderer();

            var result = formatter.Format(storedProcedure);

            result.Should().Contain("Stored Procedure: FooSP");
        }

        [Fact]
        public void StoredProcedure_Renderer_OutputsDependentTableCorrectly()
        {
            var storedProcedure = new StoredProcedure("FooSP");

            var table = new Table("Foo");

            storedProcedure.Dependencies = new List<DatabaseObject> { table };

            var formatter = new DatabaseObjectStoredProcedureRenderer();

            var result = formatter.Format(storedProcedure);

            result.Should().Contain("Table: Foo");
        }

        [Fact]
        public void StoredProcedure_Renderer_OutputsDependentTableIndentedCorrectly()
        {
            var storedProcedure = new StoredProcedure("FooSP");

            var table = new Table("Foo");

            storedProcedure.Dependencies = new List<DatabaseObject> { table };

            var formatter = new DatabaseObjectStoredProcedureRenderer();

            var result = formatter.Format(storedProcedure);

            result.Should().Contain("\tTable: Foo");
        }

        [Fact]
        public void StoredProcedure_Renderer_OutputsDependentViewIndentedCorrectly()
        {
            var storedProcedure = new StoredProcedure("FooSP");

            var view = new View("FooVw");
            var columnA = new Column("Bar", "int");
            var columnB = new Column("Bob", "string");
            view.Columns = new List<Column> { columnA, columnB };

            storedProcedure.Dependencies = new List<DatabaseObject> { view };

            var formatter = new DatabaseObjectStoredProcedureRenderer();

            var result = formatter.Format(storedProcedure);

            result.Should().Contain("\tView: FooVw\r\n\t\tBar of type int\r\n\t\tBob of type string");
        }

        [Fact]
        public void StoredProcedure_Renderer_OutputsDependentsIndentedCorrectly()
        {
            var storedProcedure = new StoredProcedure("FooSP");

            var table = new Table("Baz");
            var columnA = new Column("Bosh", "int");
            table.Columns = new List<Column> { columnA };

            var view = new View("Banana");
            var viewTable = new Table("Salary");
            viewTable.Columns = new List<Column> { columnA };
            view.Dependencies = new List<Table> { viewTable };

            storedProcedure.Dependencies = new List<DatabaseObject> { table, view };
             
            var formatter = new DatabaseObjectStoredProcedureRenderer();

            var result = formatter.Format(storedProcedure);

            var expected = $"Stored Procedure: FooSP{Environment.NewLine}" +
                           $"\tTable: Baz{Environment.NewLine}" +
                           $"\t\tBosh of type int{Environment.NewLine}" +
                           $"\tView: Banana{Environment.NewLine}" +
                           $"\t\tTable: Salary{Environment.NewLine}" +
                           $"\t\t\tBosh of type int";

            result.Should().Contain(expected);
        }
    }
}