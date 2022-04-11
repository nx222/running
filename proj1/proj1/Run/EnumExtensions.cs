namespace proj1.Extensions;

internal static class EnumExtensions
{
    public static string GetStringValue(this Enum value)
    {
        var type = value.GetType();

        var fieldInfo = type.GetField(value.ToString());

        ArgumentNullException.ThrowIfNull(fieldInfo);

        StringValueAttribute[]? attr = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

        ArgumentNullException.ThrowIfNull(attr);

        if (attr.Any())
        {
            return attr[0].Value;
        }

        throw new ApplicationException($"Unable to get string value. No such attribute: {typeof(StringValueAttribute).Name}");
    }

    public static StatType GetStatType(string value)
    {
        if (value.Equals(StatType.Interval.GetStringValue()))
            return StatType.Interval;
        else if (value.Equals(StatType.Velocity.GetStringValue()))
            return StatType.Velocity;
        else
            throw new InvalidDataException("Invalid value provided.");
    }

    public static UnitType GetUnitType(string value)
    {
        if (value.Equals(UnitType.Kilometers.GetStringValue()))
            return UnitType.Kilometers;
        else if (value.Equals(UnitType.Meters.GetStringValue()))
            return UnitType.Meters;
        else if (value.Equals(UnitType.Miles.GetStringValue()))
            return UnitType.Miles;
        else
            throw new InvalidDataException("Invalid value provided.");
    }
}
