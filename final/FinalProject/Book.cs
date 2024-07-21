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
    public Patron Borrower { get; set; }

    public Book(string isbn, string title, string author, Genre genre, bool availability)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        Genre = genre;
        Availability = availability;
    }

    public void Borrow(Patron patron)
   {
        if (Availability)
        {
            Borrower = patron;
            Availability = false;
            Console.WriteLine($"{patron.Name} has borrowed {Title}");
        }
        else
        {
            Console.WriteLine($"Sorry, {Title} is not available for borrowing.");
        }
    }

    public void Return()
    {
        Borrower = null;
        Availability = true;
        Console.WriteLine($"{Title} has been returned.");
    }

    public void UpdateDetails(string newTitle, string newAuthor, Genre newGenre)
    {
        Title = newTitle;
        Author = newAuthor;
        Genre = newGenre;
    }
}