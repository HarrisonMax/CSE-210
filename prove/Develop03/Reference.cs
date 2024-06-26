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
            EndVerse = Chapter;
        }
        
        StartVerse = 1;
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