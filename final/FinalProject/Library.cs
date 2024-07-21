using System;
using System.Collections.Generic;

public class Library
{
    public List<Book> Books { get; set; }
    public List<Patron> Patrons { get; set; }
    public List<Author> Authors { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Patrons = new List<Patron>();
        Authors = new List<Author>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void AddPatron(Patron patron)
    {
        Patrons.Add(patron);
    }

    public void AddAuthor(Author author)
    {
        Authors.Add(author);
    }

    public Book FindBookByTitle(string title)
    {
        return Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public Patron FindPatronByName(string name)
    {
        return Patrons.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Author FindAuthorByName(string name)
    {
        return Authors.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void ListCheckedOutBooks(Patron patron)
    {
        Console.WriteLine($"{patron.Name}'s checked out books:");
        foreach (var book in Books)
        {
            if (book.Borrower == patron)
            {
                Console.WriteLine($"- {book.Title}");
            }
        }
    }
}