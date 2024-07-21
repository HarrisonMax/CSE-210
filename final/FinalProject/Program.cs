using System;

public class Program
{
    public static void Main()
    {
        Library library = new Library();

        Author author1 = new Author("J.K. Rowling", "British author best known for the Harry Potter series.");
        Author author2 = new Author("George Orwell", "English novelist and essayist, known for Animal Farm and 1984.");

        Book book1 = new Book("978-0439554930", "Harry Potter and the Philosopher's Stone", "J.K. Rowling", Genre.Fantasy, true);
        Book book2 = new Book("978-0439358071", "Harry Potter and the Chamber of Secrets", "J.K. Rowling", Genre.Fantasy, true);
        Book book3 = new Book("978-0547249640", "Harry Potter and the Deathly Hallows", "J.K. Rowling", Genre.Fantasy, true);
        Book book4 = new Book("978-0451524935", "1984", "George Orwell", Genre.SciFi, true);
        Book book5 = new Book("978-0151072558", "Animal Farm", "George Orwell", Genre.Fiction, true);

        author1.BooksWritten.Add(book1);
        author1.BooksWritten.Add(book2);
        author1.BooksWritten.Add(book3);
        author2.BooksWritten.Add(book4);
        author2.BooksWritten.Add(book5);

        library.AddAuthor(author1);
        library.AddAuthor(author2);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        library.AddBook(book4);
        library.AddBook(book5);

        // Add patrons
        Patron patron1 = new Patron("John Doe", "john.doe@example.com");
        Patron patron2 = new Patron("Jane Smith", "jane.smith@example.com");

        // Add patrons to library
        library.AddPatron(patron1);
        library.AddPatron(patron2);

        Book foundBook = library.FindBookByTitle("Harry Potter and the Philosopher's Stone");
        if (foundBook != null)
        {
            foundBook.Borrow(patron1);
        }
        Patron foundPatron = library.FindPatronByName("John Doe");
        if (foundPatron != null)
        {
            library.ListCheckedOutBooks(foundPatron);
        }
    }
}