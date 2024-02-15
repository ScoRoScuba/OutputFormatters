using System.Collections.Generic;
using OutputFormatters.Model.Interfaces;

namespace OutputFormatters.Model
{
    public class Table : IDatabaseObject
    {
        private readonly List<Column> _columns = new();
        public Table(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IReadOnlyList<Column> Columns => _columns.AsReadOnly();

        public void AddColumn(Column column)
        {
            _columns.Add(column);
        }
    }
}