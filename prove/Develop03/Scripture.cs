using System;

public class Scripture
{
    private ScriptureReference reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = new ScriptureReference(reference);
        Initialize(text);
    }

    private void Initialize(string text)
    {
        words = new List<Word>();

        string[] wordArray = text.Split(' ');

        foreach (var word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{reference}");

        foreach (var word in words)
        {
            Console.Write($"{word.Display()} ");
        }
        Console.WriteLine();
    }

    public bool HideRandomWord()
    {
        Random random = new Random();
        var nonHiddenWords = words.Where(word => !word.IsHidden).ToList();

        if (nonHiddenWords.Count > 0)
        {
            int wordIndex = random.Next(nonHiddenWords.Count);
            nonHiddenWords[wordIndex].IsHidden = true;
            return true;
        }

        return false;
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}