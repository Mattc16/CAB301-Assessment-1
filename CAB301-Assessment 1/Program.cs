using System;

class Program
{
    static void Main(string[] args)
    {
        TestIsValidContactNumber();
        TestIsValidPin();
        TestCompareTo();
        TestMemberCollection();
    }

    static void TestIsValidContactNumber()
    {
        Console.WriteLine("Testing IsValidContactNumber:");
        Console.WriteLine($"IsValidContactNumber(\"0123456789\"): {IMember.IsValidContactNumber("0123456789")} (Expected: true)");
        Console.WriteLine($"IsValidContactNumber(\"1234567890\"): {IMember.IsValidContactNumber("1234567890")} (Expected: false)");
        Console.WriteLine($"IsValidContactNumber(\"012345678\"): {IMember.IsValidContactNumber("012345678")} (Expected: false)");
        Console.WriteLine($"IsValidContactNumber(\"01234abcde\"): {IMember.IsValidContactNumber("01234abcde")} (Expected: false)");
        Console.WriteLine();
    }

    static void TestIsValidPin()
    {
        Console.WriteLine("Testing IsValidPin:");
        Console.WriteLine($"IsValidPin(\"1234\"): {IMember.IsValidPin("1234")} (Expected: true)");
        Console.WriteLine($"IsValidPin(\"12345\"): {IMember.IsValidPin("12345")} (Expected: true)");
        Console.WriteLine($"IsValidPin(\"123456\"): {IMember.IsValidPin("123456")} (Expected: true)");
        Console.WriteLine($"IsValidPin(\"1234567\"): {IMember.IsValidPin("1234567")} (Expected: false)");
        Console.WriteLine($"IsValidPin(\"123\"): {IMember.IsValidPin("123")} (Expected: false)");
        Console.WriteLine($"IsValidPin(\"abcd\"): {IMember.IsValidPin("abcd")} (Expected: false)");
        Console.WriteLine();
    }

    static void TestCompareTo()
    {
        Console.WriteLine("Testing CompareTo:");
        Member member1 = new Member("John", "Doe");
        Member member2 = new Member("Alice", "Smith");
        Member member3 = new Member("John", "Doe");

        Console.WriteLine($"CompareTo(member1, member2): {member1.CompareTo(member2)} (Expected: -1)");
        Console.WriteLine($"CompareTo(member2, member1): {member2.CompareTo(member1)} (Expected: 1)");
        Console.WriteLine($"CompareTo(member1, member3): {member1.CompareTo(member3)} (Expected: 0)");
        Console.WriteLine();
    }

    static void TestMemberCollection()
    {
        Console.WriteLine("Testing MemberCollection:");

        // Create a member collection with capacity of 3
        MemberCollection memberCollection = new MemberCollection(3);

        // Add members
        memberCollection.Add(new Member("John", "Doe", "1234567890", "1234"));
        memberCollection.Add(new Member("Alice", "Smith", "9876543210", "5678"));
        memberCollection.Add(new Member("Bob", "Johnson", "4567890123", "9012"));

        Console.WriteLine("Members in the collection:");
        Console.WriteLine(memberCollection.ToString());

        // Test IsFull
        Console.WriteLine($"IsFull: {memberCollection.IsFull()} (Expected: true)");

        // Test IsEmpty
        Console.WriteLine($"IsEmpty: {memberCollection.IsEmpty()} (Expected: false)");

        // Test Delete
        memberCollection.Delete("Doe", "John");
        Console.WriteLine("Members in the collection after deletion:");
        Console.WriteLine(memberCollection.ToString());

        // Test Search
        Console.WriteLine($"Search(\"Smith\", \"Alice\"): {memberCollection.Search("Smith", "Alice")} (Expected: true)");
        Console.WriteLine($"Search(\"Doe\", \"John\"): {memberCollection.Search("Doe", "John")} (Expected: false)");

        // Test Clear
        memberCollection.Clear();
        Console.WriteLine("Members in the collection after clearing:");
        Console.WriteLine(memberCollection.ToString());

        Console.WriteLine();
    }
}
