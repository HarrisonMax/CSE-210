using System;

public enum Genre
{
    Fiction,
    NonFiction,
    Mystery,
    Romance,
    Biography,
    SciFi,
    Fantasy,
    Thriller,
    History,
    Other
}

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public Genre Genre { get; set; }
    public bool Availability { get; set; }

    public void Borrow()
    {
        Availability = false;
    }

    public void Return()
    {
        Availability = true;
    }

    public void UpdateDetails(string newTitle, string newAuthor, Genre newGenre)
    {
        Title = newTitle;
        Author = newAuthor;
        Genre = newGenre;
    }
}