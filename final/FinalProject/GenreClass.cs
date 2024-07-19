using System.Collections.Generic;

public class GenreClass
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Book> Books { get; set; }

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
 
    }
}