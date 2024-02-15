using System.Collections.Generic;
using OutputFormatters.Model.Interfaces;

namespace OutputFormatters.Model
{
    public class StoredProcedure : IDatabaseObject
    {
        private readonly List<IDatabaseObject> _dependencies = new();

        public StoredProcedure(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IReadOnlyList<Table> Tables => _dependencies.GetReadOnlyListOfType<Table>();
        public IReadOnlyList<View> Views => _dependencies.GetReadOnlyListOfType<View>();

        public void AddDependency(IDatabaseObject databaseObject)
        {
            _dependencies.Add(databaseObject);
        }
    }
}