using OutputFormatters.Model.Interfaces;

namespace OutputFormatters.Model
{
    public class Column : IDatabaseObject
    {
        public Column(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public string Type { get; }
    }
}