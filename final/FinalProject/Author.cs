using System.Collections.Generic;

public class Author
{
    public string Name { get; set; }
    public string Biography { get; set; }
    public List<Book> BooksWritten { get; set; }

    public Author(string name, string biography)
    {
        Name = name;
        Biography = biography;
        BooksWritten = new List<Book>();
    }

    public void AddBook(Book book)
    {
        BooksWritten.Add(book);
    }
}
