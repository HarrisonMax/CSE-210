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
    public bool IsAvailable { get; set; }
    public Patron Borrower { get; set; }

    public void Borrow()
    {
        IsAvailable = false;
        Console.WriteLine($"{Title} has been borrowed.");
    }

    public void Return()
    {
        IsAvailable = true;
        Console.WriteLine($"{Title} has been returned.");
    }
}


