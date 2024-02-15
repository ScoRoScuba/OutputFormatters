using FluentAssertions;
using OutputFormatters.Formatters;
using OutputFormatters.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var result = renderer.Format(column);

            result.Should().Contain("Bar of type int");

        }
    }
}
