using FluentAssertions;
using OutputFormatters.Formatters;
using OutputFormatters.Model;
using Xunit;

namespace OutputFormatters.Tests
{
    public class ColumnRendererTests
    {
        [Fact]
        public void Column_Renderer_OutputsColumnCorrectly()
        {
            var column = new Column("Bar", "int");

            var renderer = new DatabaseObjectColumnRenderer();

            var result = renderer.Render(column);

            result.Should().Be("Bar of type int");
        }
    }
}
