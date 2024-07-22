using System;

public class Program
{
    private static Library library = new Library();

    public static void Main(string[] args)
    {
        InitializeLibrary();

        bool exit = false;
        while (!exit)
        {
            DisplayMenu();
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

    private static void DisplayMenu()
    {
        Console.WriteLine("Library Management System Menu");
        Console.WriteLine("==============================");
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
        Console.Write("Enter your choice: ");
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
            Console.WriteLine($"Availability: {(foundBook.IsAvailable ? "Available" : "Not Available")}");
            if (!foundBook.IsAvailable)
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

        Book newBook = new Book
        {
            ISBN = isbn,
            Title = title,
            Author = author,
            Genre = genre,
            IsAvailable = availability
        };
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

        Patron newPatron = new Patron
        {
            Name = patronName,
            ContactInfo = contactInfo
        };
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

        library.BorrowItem(book, patron);
        Console.WriteLine($"{book.Title} checked out to {patron.Name} successfully.");
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

        Patron patron = book.Borrower;
        if (patron == null)
        {
            Console.WriteLine($"{book.Title} is not currently checked out.");
            return;
        }

        library.ReturnItem(book, patron);
        Console.WriteLine($"{book.Title} returned by {patron.Name} successfully.");
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

    private static void InitializeLibrary()
    {
        Author author1 = new Author("John Doe", "A mysterious author");
        Book book1 = new Book
        {
            ISBN = "1234567890",
            Title = "Sample Book",
            Author = author1.Name,
            Genre = Genre.Fiction,
            IsAvailable = true
        };
        author1.AddBook(book1);
        library.AddAuthor(author1);
    }
}
