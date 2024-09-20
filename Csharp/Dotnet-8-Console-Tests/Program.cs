using System.ComponentModel;
using System.Text.Json;
using src;

static string GetEnumDescription(Colors color)
{
    var field = color.GetType().GetField(color.ToString());

    if (field == null) return "";

    var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

    if (attributes == null || attributes.Length == 0)
        return color.ToString();

    return attributes[0].Description;
}

var myList = new List<TestClass>(){
    new TestClass{
        MyProperty = 1,
        MyString = "Str 1",
    },
    new TestClass{
        MyProperty = 2,
        MyString = "Str 2",
    },
};

Console.WriteLine(JsonSerializer.Serialize(myList)); // [{"MyProperty":1,"MyString":"Str 1"},{"MyProperty":2,"MyString":"Str 2"}]

var myInts = new List<int>() { 1, 2, 3, 4, 5 };
Console.WriteLine(JsonSerializer.Serialize(myInts)); // [1,2,3,4,5]


foreach (var color in Enum.GetValues(typeof(Colors)))
{
    var description = GetEnumDescription((Colors)color);
    Console.WriteLine($"Color: {color}, id: {(int)color}, Description: {description}");
}