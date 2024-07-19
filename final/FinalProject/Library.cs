using System;
using System.Collections.Generic;

public class Library
{
    public List<Book> Books { get; set; }
    public List<Patron> Patrons { get; set; }
    public List<Loan> Loans { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Patrons = new List<Patron>();
        Loans = new List<Loan>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddPatron(Patron patron)
    {
        Patrons.Add(patron);
    }

    public void RemovePatron(Patron patron)
    {
        Patrons.Remove(patron);
    }

    public void IssueLoan(Book book, Patron patron, DateTime loanDate, DateTime dueDate)
    {
        var loan = new Loan
        {
            Book = book,
            Patron = patron,
            LoanDate = loanDate,
            DueDate = dueDate
        };
        Loans.Add(loan);
        book.Borrow();
    }

    public void ManageReturns()
    {
  
    }
}