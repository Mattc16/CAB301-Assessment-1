namespace CAB301_Assessment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create some member objects
            Member member1 = new Member("John", "Doe", "1234567890", "1234");
            Member member2 = new Member("Alice", "Smith", "9876543210", "5678");
            Member member3 = new Member("Bob", "Johnson", "4567890123", "9012");

            // Create a member collection with capacity of 3
            MemberCollection memberCollection = new MemberCollection(3);

            // Add members to the collection
            memberCollection.Add(member1);
            memberCollection.Add(member2);
            memberCollection.Add(member3);

            // Display the members in the collection
            Console.WriteLine("Members in the collection:");
            Console.WriteLine(memberCollection.ToString());

            // Search for a member
            Console.WriteLine("Search for a member:");
            Console.WriteLine("Is John Doe in the collection? " + memberCollection.Search("Doe", "John"));

            // Delete a member
            Console.WriteLine("Delete a member:");
            memberCollection.Delete("Doe", "John");
            Console.WriteLine("Members in the collection after deletion:");
            Console.WriteLine(memberCollection.ToString());

            // Clear the collection
            Console.WriteLine("Clear the collection:");
            memberCollection.Clear();
            Console.WriteLine("Members in the collection after clearing:");
            Console.WriteLine(memberCollection.ToString());
        }
    }
}