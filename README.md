## Connect with Me

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Profile-blue)](https://www.linkedin.com/in/spyros-ponaris-913a6937/)

# C# Features & Weekly Challenges

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/)
[![Language](https://img.shields.io/badge/Language-C%23-239120)](https://learn.microsoft.com/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](#license)

A hands-on collection of **modern C# features** and **weekly practice challenges**, built with **.NET 9**.  
Each challenge focuses on a specific concept (LINQ, async/await, records, Span\<T>, source generators, etc.) with small, runnable samples.

---

## ✨ What’s inside

- **Feature demos:** Small, focused examples of C# features with comments.
- **Weekly challenges:** Practical problems with reference solutions.
- **Console menu:** Run any challenge/demo from one place.

---

## 🧭 Quick Start

```bash
git clone https://github.com/stevsharp/CSshapFeatures.git
cd CSshapFeatures

dotnet build
dotnet run --project src/CSharpWeeklyChallenges
```

## 📚 Challenges

### 🏆 Challenge 01 – Word Frequency Counter

**Task:**  
Write a program that:
- Accepts a block of text (multi-line input).
- Counts how many times each unique word appears.
- Prints the top 5 most frequent words with their counts.
- Ignores case and punctuation.

---

**Example Input:**
```txt
This world is big, and this world is small.
```
Expected Output:

world -> 2
hello -> 2
big   -> 1
small -> 1


### 🏆 Challenge 02 – Custom LINQ Extension Method

**Task:**  
Write a **LINQ extension method** called `ToChunks<T>` that splits an `IEnumerable<T>` into smaller batches (chunks) of a given size.  

---

**Requirements:**
- The extension method should be generic (`IEnumerable<T>`).  
- It should return an `IEnumerable<IEnumerable<T>>`, where each inner collection is a chunk.  
- If the final chunk has fewer items, return it as-is (do not pad).  
- Throw an exception if the chunk size is less than 1.  

---

**Example Usage:**
```csharp
var numbers = Enumerable.Range(1, 10);
var chunks = numbers.ToChunks(3);

foreach (var chunk in chunks)
{
    Console.WriteLine($"[{string.Join(", ", chunk)}]");
}
```
-Use only LINQ for the counting logic.
-Add an option to exclude stopwords (e.g., is, the, and, this).
