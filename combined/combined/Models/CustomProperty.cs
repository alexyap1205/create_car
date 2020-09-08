namespace combined.Models
{
    public enum CustomPropertyType
    {
        INTEGER,
        BOOLEAN,
        STRING
    }
    
    public class CustomProperty
    {
        public string Name { get; }
        public CustomPropertyType Type { get; }

        public CustomProperty(string name, CustomPropertyType type)
        {
            Name = name;
            Type = type;
        }
    }
}