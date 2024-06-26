using System;
using System.Reflection;

public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }

    public ScriptureReference(string reference)
    {
        // Example parsing logic for reference like "John 3:16"
        string[] parts = reference.Split(':');
        Book = parts[0];
        
        string versePart = parts[1];
        if (versePart.Contains("-"))
        {
            string[] verseRange = versePart.Split('-');
            Chapter = int.Parse(verseRange[0]);
            EndVerse = int.Parse(verseRange[1]);
        }
        else
        {
            Chapter = int.Parse(versePart);
            EndVerse = Chapter; // Handle single verse scenario
        }
        
        StartVerse = 1; // Assuming the first verse is 1 in the verse range
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}