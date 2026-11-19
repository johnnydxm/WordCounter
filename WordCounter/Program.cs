using System;
using System.Collections.Generic;
using System.Linq;

// Create a dictionary to store words and their counts
Dictionary<string, int> wordCounts = new Dictionary<string, int>();

// Ask the user to enter a sentence
Console.WriteLine(">>> WORD FREQUENCY COUNTER <<<");
Console.Write("Enter a sentence: ");

string line = Console.ReadLine() ?? "";

// Convert to lowercase
line = line.ToLower();

// Remove punctuation
foreach (char punctuation in line.Where(char.IsPunctuation))
{
    line = line.Replace(punctuation.ToString(), "");
}

// Split the sentence into words
string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

// Count each word
foreach (string word in words)
{
    if (wordCounts.TryGetValue(word, out int count))
    {
        // Word already exists, increase its count
        wordCounts[word] = count + 1;
    }
    else
    {
        // New word, start counting from 1
        wordCounts[word] = 1;
    }
}

// Display results alphabetically
Console.WriteLine("\n |>> WORD FREQUENCY <<|");

foreach (var item in wordCounts.OrderBy(x => x.Key))
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}

Console.WriteLine("\nTotal unique words: " + wordCounts.Count);