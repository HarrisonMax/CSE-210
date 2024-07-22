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
        foreach (var book in Books)
        {
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"ISBN: {book.ISBN}");
            Console.WriteLine($"Genre: {book.Genre}");
            Console.WriteLine();
        }
    }
}