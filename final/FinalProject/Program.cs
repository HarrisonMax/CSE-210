using System;

public class Program
{
    private static Library library = new Library(); // Create a library instance

    public static void Main()
    {
        InitializeLibrary(); // Initialize library with sample data

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Welcome to the Library Management System");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Find Author");
            Console.WriteLine("2. Add Author");
            Console.WriteLine("3. Find Book");
            Console.WriteLine("4. Add Book");
            Console.WriteLine("5. Find Patron");
            Console.WriteLine("6. Add Patron");
            Console.WriteLine("7. Check Out Book");
            Console.WriteLine("8. Return Book");
            Console.WriteLine("9. List Checked Out Books for Patron");
            Console.WriteLine("10. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    FindAuthor();
                    break;
                case "2":
                    AddAuthor();
                    break;
                case "3":
                    FindBook();
                    break;
                case "4":
                    AddBook();
                    break;
                case "5":
                    FindPatron();
                    break;
                case "6":
                    AddPatron();
                    break;
                case "7":
                    CheckOutBook();
                    break;
                case "8":
                    ReturnBook();
                    break;
                case "9":
                    ListCheckedOutBooks();
                    break;
                case "10":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 10.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Method to initialize library with sample data
    private static void InitializeLibrary()
    {
        // Sample authors
        Author author1 = new Author("J.K. Rowling", "British author best known for the Harry Potter series.");
        Author author2 = new Author("George Orwell", "English novelist and essayist, known for Animal Farm and 1984.");

        // Sample books
        Book book1 = new Book("978-0439554930", "Harry Potter and the Philosopher's Stone", "J.K. Rowling", Genre.Fantasy, true);
        Book book2 = new Book("978-0439358071", "Harry Potter and the Chamber of Secrets", "J.K. Rowling", Genre.Fantasy, true);
        Book book3 = new Book("978-0547249640", "Harry Potter and the Deathly Hallows", "J.K. Rowling", Genre.Fantasy, true);
        Book book4 = new Book("978-0451524935", "1984", "George Orwell", Genre.SciFi, true);
        Book book5 = new Book("978-0151072558", "Animal Farm", "George Orwell", Genre.Fiction, true);

        // Add authors to library
        library.AddAuthor(author1);
        library.AddAuthor(author2);

        // Add books to library
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        library.AddBook(book4);
        library.AddBook(book5);
    }

    private static void FindAuthor()
    {
        Console.Write("Enter author's name: ");
        string authorName = Console.ReadLine();

        Author foundAuthor = library.FindAuthorByName(authorName);
        if (foundAuthor != null)
        {
            Console.WriteLine($"Author found: {foundAuthor.Name}");
            Console.WriteLine($"Biography: {foundAuthor.Biography}");
            Console.WriteLine("Books written:");
            foreach (var book in foundAuthor.BooksWritten)
            {
                Console.WriteLine($"- {book.Title}");
            }
        }
        else
        {
            Console.WriteLine("Author not found.");
        }
    }

    private static void AddAuthor()
    {
        Console.Write("Enter author's name: ");
        string authorName = Console.ReadLine();
        Console.Write("Enter author's biography: ");
        string biography = Console.ReadLine();

        Author newAuthor = new Author(authorName, biography);
        library.AddAuthor(newAuthor);

        Console.WriteLine("Author added successfully.");
    }

    private static void FindBook()
    {
        Console.Write("Enter book's title: ");
        string bookTitle = Console.ReadLine();

        Book foundBook = library.FindBookByTitle(bookTitle);
        if (foundBook != null)
        {
            Console.WriteLine($"Book found: {foundBook.Title}");
            Console.WriteLine($"Author: {foundBook.Author}");
            Console.WriteLine($"ISBN: {foundBook.ISBN}");
            Console.WriteLine($"Genre: {foundBook.Genre}");
            Console.WriteLine($"Availability: {(foundBook.Availability ? "Available" : "Not Available")}");
            if (!foundBook.Availability)
            {
                Console.WriteLine($"Borrower: {foundBook.Borrower.Name}");
            }
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    private static void AddBook()
    {
        Console.Write("Enter book's ISBN: ");
        string isbn = Console.ReadLine();
        Console.Write("Enter book's title: ");
        string title = Console.ReadLine();
        Console.Write("Enter book's author: ");
        string author = Console.ReadLine();
        Console.Write("Enter book's genre (Fiction, NonFiction, Mystery, Romance, Biography, SciFi, Fantasy, Thriller, History, Other): ");
        if (!Enum.TryParse(Console.ReadLine(), out Genre genre))
        {
            Console.WriteLine("Invalid genre. Book not added.");
            return;
        }
        Console.Write("Is the book available? (true/false): ");
        if (!bool.TryParse(Console.ReadLine(), out bool availability))
        {
            Console.WriteLine("Invalid availability. Book not added.");
            return;
        }

        Book newBook = new Book(isbn, title, author, genre, availability);
        library.AddBook(newBook);

        Console.WriteLine("Book added successfully.");
    }

    private static void FindPatron()
    {
        Console.Write("Enter patron's name: ");
        string patronName = Console.ReadLine();

        Patron foundPatron = library.FindPatronByName(patronName);
        if (foundPatron != null)
        {
            Console.WriteLine($"Patron found: {foundPatron.Name}");
            Console.WriteLine($"Contact Information: {foundPatron.ContactInfo}");
        }
        else
        {
            Console.WriteLine("Patron not found.");
        }
    }

    private static void AddPatron()
    {
        Console.Write("Enter patron's name: ");
        string patronName = Console.ReadLine();
        Console.Write("Enter patron's contact information: ");
        string contactInfo = Console.ReadLine();

        Patron newPatron = new Patron(patronName, contactInfo);
        library.AddPatron(newPatron);

        Console.WriteLine("Patron added successfully.");
    }

    private static void CheckOutBook()
    {
        Console.Write("Enter patron's name: ");
        string patronName = Console.ReadLine();
        Console.Write("Enter book's title: ");
        string bookTitle = Console.ReadLine();

        Patron patron = library.FindPatronByName(patronName);
        if (patron == null)
        {
            Console.WriteLine("Patron not found.");
            return;
        }

        Book book = library.FindBookByTitle(bookTitle);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        book.Borrow(patron);
    }

    private static void ReturnBook()
    {
        Console.Write("Enter book's title: ");
        string bookTitle = Console.ReadLine();

        Book book = library.FindBookByTitle(bookTitle);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        book.Return();
    }

    private static void ListCheckedOutBooks()
    {
        Console.Write("Enter patron's name: ");
        string patronName = Console.ReadLine();

        Patron patron = library.FindPatronByName(patronName);
        if (patron == null)
        {
            Console.WriteLine("Patron not found.");
            return;
        }

        library.ListCheckedOutBooks(patron);
    }
}