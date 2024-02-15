using System.Collections.Generic;
using OutputFormatters.Model.Interfaces;

namespace OutputFormatters.Model
{
    public class View : IDatabaseObject
    {
        private readonly List<IDatabaseObject> _dependencies = new();

        public View(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IReadOnlyList<Column> Columns => _dependencies.GetReadOnlyListOfType<Column>();
        public IReadOnlyList<Table> Tables => _dependencies.GetReadOnlyListOfType<Table>();

        public void AddDependency(IDatabaseObject databaseObject)
        {
            _dependencies.Add(databaseObject);
        }
    }
}

