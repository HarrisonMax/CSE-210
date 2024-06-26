using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private List<Word> _words;
    private ScriptureReference _reference;
    private int _numberOfHiddenWords;

    public Scripture(string bookName, int chapter, int verse, string text)
    {
        _reference = new ScriptureReference(bookName, chapter, verse);
        InitializeWords(text);
    }

    public Scripture(string bookName, int chapter, int startVerse, int endVerse, string text)
    {
        _reference = new ScriptureReference(bookName, chapter, startVerse, endVerse);
        InitializeWords(text);
    }

    private void InitializeWords(string text)
    {
        _words = new List<Word>();
        string[] wordArray = text.Split(new char[] { ' ', ',', '.', ';', ':', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }

        _numberOfHiddenWords = 0;
    }

    private int NumberOfHiddenWords()
    {
        return _words.Count(w => w.IsHidden());
    }

    private bool HideSomeWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, 3); // Hide between 1 to 2 words randomly

        List<Word> wordsToHideList = _words.Where(w => !w.IsHidden()).ToList();

        if (wordsToHideList.Count == 0)
        {
            // No more words left to hide
            return false;
        }

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(wordsToHideList.Count);
            wordsToHideList[index].SetIsHidden(true);
        }

        _numberOfHiddenWords += wordsToHide;
        return true;
    }

    public void ShowScripture()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetReferenceString());

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                for (int i = 0; i < word.GetWord().Length; i++)
                {
                    Console.Write("_");
                }
                Console.Write(" ");
            }
            else
            {
                Console.Write($" {word.GetWord()} ");
            }
        }

        Console.WriteLine();
    }

    public void Execute()
    {
        ShowScripture();
        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");

        while (NumberOfHiddenWords() < _words.Count)
        {
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                return;
            }
            else if (input == "")
            {
                if (!HideSomeWords())
                {
                    Console.WriteLine("\nAll words are now hidden.");
                    return;
                }

                ShowScripture();
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to continue or type 'quit' to exit.");
            }
        }
    }
}