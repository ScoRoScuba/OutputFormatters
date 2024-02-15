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

            result.Should().Contain("StoredProcedure: FooSP");
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
    }
}