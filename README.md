# qa-analyst-assessment
QA Analyst Technical Assessment – Functional &amp; API Testing
# QA Analyst Technical Assessment

**Candidate:** Ajay Krishna  
**Language Used:** C#  
**Completion Date:** October 24, 2025  

---

## Part 1: Functional Programming – Remove Duplicates
- **Time Spent:** ~30 minutes  
- **Approach:**  
  I have written a simple, pure C# function that removes duplicates from a list while keeping the order of first occurrence.  
  Additionally, I have used LINQ's `Where()` to return only the first appearance of each value and a `HashSet` to keep track of elements that had already been seen.  
  The function consistently yields the same result for the same input and does not alter the input list.
---

## Part 2: API Testing – JSONPlaceholder
- **Time Spent:** ~30 minutes  
- **Approach:**  
  Wrote three API test cases using the xUnit framework in C#.  
  Tested public endpoints from JSONPlaceholder to check GET, POST, and 404 scenarios.  
  Used `HttpClient` for sending requests and `ReadFromJsonAsync` to handle JSON responses.  
  Validated response codes and important fields for correctness.

---

## How to Run

### Part 1
```bash
cd part1-functional
dotnet new console -n Part1
move solution.cs Part1/Program.cs
cd Part1
dotnet run
```

### Part 2
```bash
cd part2-api-testing
dotnet new xunit -n ApiTests
cd ApiTests
dotnet add package System.Net.Http.Json
Copy-Item ../solution.cs JsonPlaceholderApiTests.cs
Remove-Item UnitTest1.cs
dotnet test
```

