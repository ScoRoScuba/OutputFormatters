namespace OutputFormatters.Tests;

public class Column : DatabaseObject 
{
    public Column( string name, string type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; }
    public string Type { get; }
}