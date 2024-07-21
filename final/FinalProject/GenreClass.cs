using System.Collections.Generic;

public class GenreClass
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Book> Books { get; set; }

    public GenreClass(string name, string description)
    {
        Name = name;
        Description = description;
        Books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void ListBooks()
    {
        Console.WriteLine($"Books in {Name} genre:");
        foreach (var book in Books)
        {
            Console.WriteLine($"- {book.Title} by {book.Author}");
        }
    }
}