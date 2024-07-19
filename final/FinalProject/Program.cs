using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Library library = InitializeLibrary();

        Console.WriteLine("Welcome to the Library Management System");

        bool exit = false;
        while (!exit)
        {
            DisplayMainMenu();

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    LookupBooks(library);
                    break;
                case "2":
                    LookupAuthors(library);
                    break;
                case "3":
                    LookupPatrons(library);
                    break;
                case "4":
                    LookupPatronContactInfo(library);
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static Library InitializeLibrary()
    {
        Library library = new Library();

        Book book1 = new Book { ISBN = "1234567890", Title = "Sample Book 1", Author = "Sample Author 1", Genre = Genre.Fiction, Availability = true };
        Book book2 = new Book { ISBN = "0987654321", Title = "Sample Book 2", Author = "Sample Author 2", Genre = Genre.NonFiction, Availability = true };
        library.AddBook(book1);
        library.AddBook(book2);

        Patron patron1 = new Patron { Name = "John Doe", Address = "123 Main St", ContactInformation = "555-1234", MembershipStatus = true };
        Patron patron2 = new Patron { Name = "Jane Smith", Address = "456 Oak Ave", ContactInformation = "555-5678", MembershipStatus = true };
        library.AddPatron(patron1);
        library.AddPatron(patron2);

        return library;
    }

    private static void DisplayMainMenu()
    {
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Lookup Books");
        Console.WriteLine("2. Lookup Authors");
        Console.WriteLine("3. Lookup Patrons");
        Console.WriteLine("4. Lookup Patron Contact Information");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
    }

    private static void LookupBooks(Library library)
    {
        Console.WriteLine("List of Books in the Library:");
        foreach (var book in library.Books)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }
    }

    private static void LookupAuthors(Library library)
    {
        Console.WriteLine("List of Authors:");
        HashSet<string> authors = new HashSet<string>();
        foreach (var book in library.Books)
        {
            authors.Add(book.Author);
        }
        foreach (var author in authors)
        {
            Console.WriteLine(author);
        }
    }

    private static void LookupPatrons(Library library)
    {
        Console.WriteLine("List of Patrons:");
        foreach (var patron in library.Patrons)
        {
            Console.WriteLine($"{patron.Name}");
        }
    }

    private static void LookupPatronContactInfo(Library library)
    {
        Console.WriteLine("Patron Contact Information:");
        foreach (var patron in library.Patrons)
        {
            Console.WriteLine($"Name: {patron.Name}");
            Console.WriteLine($"Address: {patron.Address}");
            Console.WriteLine($"Contact Information: {patron.ContactInformation}");
            Console.WriteLine();
        }
    }
}