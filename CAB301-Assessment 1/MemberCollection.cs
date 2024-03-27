//CAB301 assessment 1 
//The implementation of MemberCollection ADT
using System;
using System.Diagnostics.Metrics;
using System.Linq;


//Invariants: Capacity >= Count; Count >=0; and members in this member collection are sorted in alphabetical order by their full name (if there are two members who have the same last name, they are sorted by their first name in alphabetical order).


class MemberCollection : IMemberCollection
{
    // Fields
    private int capacity;
    private int count;
    private Member[] members; //members are sorted in alphabetical order

    // Properties

    // get the capacity of this member collection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member collection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }



    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created

    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return true if this member collection is full; otherwise return false. This member collection remains unchanged.
    public bool IsFull()
    {
        // The member collection is full if the number of members in this member collection is equal to the capacity of this member collection
        return count == capacity;
    }



    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return true if this member collection is empty; otherwise return false. This member collection remains unchanged.
    public bool IsEmpty()
    {
        // The member collection is empty if the number of members in this member collection is equal to 0
        return count == 0;
    }

    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: The given member is added to this member collection and the members remains sorted in alphabetical order by their full names, if the given member does not appear in this member collection; otherwise, the given member is not added to this member collection. 
    // No duplicate has been added into this the member collection
    public void Add(IMember member)
    {
        if (!IsFull())
        {
            // Check if the given member is already in this member collection
            if (!Search(member.LastName, member.FirstName))
            {
                // Find the position where the given member should be inserted
                int i = 0;
                while (i < count && members[i].CompareTo(member) < 0)
                {
                    i++;
                }

                // Move the members in this member collection to make room for the given member
                for (int j = count - 1; j >= i; j--)
                {
                    members[j + 1] = members[j];
                }

                // Insert the given member to this member collection
                members[i] = (Member)member;
                count++;
            }
        }
    }

    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member is removed from this member collection, if the given member is in this member collection and the members in this member collection remains sorted in alphabetical order by their full names; otherwise, no member is removed from this member collection and this member collection remains unchanged. 
    public void Delete(string lastname, string firstname)
    {
        int index = -1;
        for (int i = 0; i < count; i++)
        {
            if (members[i].LastName == lastname && members[i].FirstName == firstname)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            for (int i = index; i < count - 1; i++)
            {
                members[i] = members[i + 1];
            }
            count--;
        }

    }

    // Search a given member by last name and first name in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if the given member is in this member collection; return false otherwise. This member collection remains unchanged.
    public bool Search(string lastname, string firstname)
    {
        for (int i = 0; i < count; i++)
        {
            if (members[i].LastName == lastname && members[i].FirstName == firstname)
            {
                return true;
            }
        }
        return false;
    }
    
    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: Capacity remins unchanged; Number = 0; this member collection is empty.
    public void Clear()
    {
        count = 0;
    }

    // Return a string containing the full name and contact number of all members in this member collection
    // Pre-condition: nil
    // Post-condition: return a string containing the full name and contact number of all members in this member collection
    public string ToString()
    {
        string result = "";
        for (int i = 0; i < count; i++)
        {
            result += members[i].FirstName + " " + members[i].LastName + ": " + members[i].ContactNumber + "\n";
        }
        return result;
    }

}

