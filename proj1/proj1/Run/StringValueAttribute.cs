[AttributeUsage(AttributeTargets.Field)]
internal class StringValueAttribute : Attribute
{
    public string Value { get; protected set; }

    public StringValueAttribute(string value)
    {
        this.Value = value;
    }
}