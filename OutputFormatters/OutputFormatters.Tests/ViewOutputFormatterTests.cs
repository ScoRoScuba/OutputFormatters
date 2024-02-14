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
    }
}
