using System.Collections.Generic;
using System.Linq;

namespace OutputFormatters.Model
{
    public class View : DatabaseObject
    {
        public IEnumerable<Column> Columns { get; set; } = Enumerable.Empty<Column>();
        public IEnumerable<Table> Dependencies { get; set; } = Enumerable.Empty<Table>();

        public View(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}

