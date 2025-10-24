using System;
using System.Collections.Generic;
using System.Linq;

public class FunctionalRemoveDuplicates
{
    //Pure function
    public static IEnumerable<T> RemoveDuplicates<T>(IEnumerable<T> input)
    {
        if (input == null)
            return Enumerable.Empty<T>();

        // HashSet tracks items,  LINQ keeps first occurrences only
        var seen = new HashSet<T>();
        return input.Where(item => seen.Add(item));
    }

    public static void Main()
    {
        // Test cases
        var test1 = new List<int> { 1, 2, 3, 2, 4, 1, 5 };
        var test2 = new List<int> { 1, 1, 1 };
        var test3 = new List<int>(); // empty list

        Console.WriteLine("Test 1: [1, 2, 3, 2, 4, 1, 5]");
        Console.WriteLine("Output -> [" + string.Join(", ", RemoveDuplicates(test1)) + "]");

        Console.WriteLine("\nTest 2: [1, 1, 1]");
        Console.WriteLine("Output -> [" + string.Join(", ", RemoveDuplicates(test2)) + "]");

        Console.WriteLine("\nTest 3: []");
        Console.WriteLine("Output -> [" + string.Join(", ", RemoveDuplicates(test3)) + "]");
    }
}
