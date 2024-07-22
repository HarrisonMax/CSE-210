using System;
using System.Collections.Generic;
using System.Linq;

public class Library
{
    private List<Book> books;
    private List<Patron> patrons;
    private List<Author> authors;
    private List<Publisher> publishers;
    private List<GenreClass> genres;

    public Library()
    {
        books = new List<Book>();
        patrons = new List<Patron>();
        authors = new List<Author>();
        publishers = new List<Publisher>();
        genres = new List<GenreClass>();
    }


    public void AddBook(Book book)
    {
        books.Add(book);
        GetGenreClass(book.Genre).AddBook(book);
    }

    public void AddPatron(Patron patron)
    {
        patrons.Add(patron);
    }

    public void AddAuthor(Author author)
    {
        authors.Add(author);
    }

    public void AddPublisher(Publisher publisher)
    {
        publishers.Add(publisher);
    }

    public void AddGenreClass(GenreClass genreClass)
    {
        genres.Add(genreClass);
    }

    public Book FindBookByTitle(string title)
    {
        return books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public Patron FindPatronByName(string name)
    {
        return patrons.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Author FindAuthorByName(string name)
    {
        return authors.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Publisher FindPublisherByName(string name)
    {
        return publishers.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public GenreClass GetGenreClass(Genre genre)
    {
        return genres.FirstOrDefault(g => g.Name.Equals(genre.ToString(), StringComparison.OrdinalIgnoreCase));
    }

    public void BorrowItem(Book item, Patron patron)
    {
        item.Borrow();
        patron.Borrow();
    }

    public void ReturnItem(Book item, Patron patron)
    {
        item.Return();
        patron.Return();
    }

    public void ListCheckedOutBooks(Patron patron)
    {
        Console.WriteLine($"Books checked out by {patron.Name}:");
        foreach (var book in books.Where(b => !b.IsAvailable && b.Borrower == patron))
        {
            Console.WriteLine($"- {book.Title}");
        }
    }
}