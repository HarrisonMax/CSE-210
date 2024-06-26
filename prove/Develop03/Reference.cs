using System;
using System.Reflection;

public class ScriptureReference
{
    private string _bookName;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public ScriptureReference(string bookName, int chapter, int verse)
    {
        _bookName = bookName;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = verse;
    }

    public ScriptureReference(string bookName, int chapter, int startVerse, int endVerse)
    {
        _bookName = bookName;
        _chapter = chapter;
        _verseStart = startVerse;
        _verseEnd = endVerse;
    }

    private string GetScriptureReferenceString()
    {
        if (_verseStart == _verseEnd)
        {
            return $"{_bookName} {_chapter}:{_verseStart}";
        }
        else
        {
            return $"{_bookName} {_chapter}:{_verseStart}-{_verseEnd}";
        }
    }

    public void ShowScriptureReference()
    {
        Console.WriteLine(GetScriptureReferenceString());
    }

    public string GetReferenceString()
    {
        return GetScriptureReferenceString();
    }
}