namespace src;


public class TestClassComparer : IEqualityComparer<TestClass>
{
    public bool Equals(TestClass x, TestClass y)
    {
        // Check if both are null or if one of them is null
        if (x == null && y == null) return true;
        if (x == null || y == null) return false;

        // Compare by value of MyProperty and MyString
        return x.MyProperty == y.MyProperty && x.MyString == y.MyString;
    }

    public int GetHashCode(TestClass obj)
    {
        // Combine the hash codes of both properties for a unique hash
        return obj.MyProperty.GetHashCode() ^ (obj.MyString?.GetHashCode() ?? 0);
    }
}