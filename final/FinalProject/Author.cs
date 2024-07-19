using System.Collections.Generic;

public class Author
{
    public string Name { get; set; }
    public string Biography { get; set; }
    public List<Book> BooksWritten { get; set; }

    public void UpdateBiography(string newBiography)
    {
        Biography = newBiography;
    }

    public void ListBooks()
    {

    }
}
