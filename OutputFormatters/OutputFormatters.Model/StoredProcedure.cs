using System.Collections.Generic;
using System.Linq;
using OutputFormatters.Model;

namespace OutputFormatters.Tests;

public class StoredProcedure : DatabaseObject
{
    public IEnumerable<DatabaseObject> Dependencies { get; set; } = Enumerable.Empty<DatabaseObject>();

    public StoredProcedure(string name)
    {
        Name = name;
    }

    public string Name { get; }

}