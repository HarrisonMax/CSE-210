using System;

public class Loan
{
    public Book Book { get; set; }
    public Patron Patron { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Fine { get; set; }

    public decimal CalculateFine()
    {
        return Fine;
    }

    public void ExtendLoan(DateTime newDueDate)
    {
        DueDate = newDueDate;
    }

    public void ReturnBook(DateTime returnDate)
    {
        ReturnDate = returnDate;
    }
}