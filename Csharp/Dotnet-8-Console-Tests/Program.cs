using System;
using System.ComponentModel;
using System.Reflection;

public enum Colors
{
    [Description("a red color")]
    Red = 1,
    [Description("a green color")]
    Green = 2,
    [Description("a blue color")]
    Blue = 3
}

public class Program
{
    public static void Main(string[] args)
    {
        foreach (var color in Enum.GetValues(typeof(Colors)))
        {
            var description = GetEnumDescription((Colors)color);
            Console.WriteLine($"Color: {color}, id: {(int)color}, Description: {description}");
        }
    }

    public static string GetEnumDescription(Colors color)
    {
        var field = color.GetType().GetField(color.ToString());

        if (field == null) return "";

        var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return color.ToString();
        }
    }
}
