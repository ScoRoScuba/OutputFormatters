using System.Collections.Generic;
using System.Linq;

namespace OutputFormatters.Model
{
    public class Table : DatabaseObject
    {
        public IEnumerable<Column> Columns { get; set; } = Enumerable.Empty<Column>();

        public Table(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public interface DatabaseObject
    {
        string Name { get; }
    }
}