using System;
using System.Collections.Generic;
using System.IO;

public class JournalManager
{
    private List<JournalEntry> journal = new List<JournalEntry>();
    private Random random = new Random();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
//taken from Chat gpt
    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            DisplayMenu();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    LoadJournal();
                    break;
                case "4":
                    SaveJournal();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Load the journal from a file");
        Console.WriteLine("4. Save the journal to a file");
        Console.WriteLine("5. Quit");
    }

    private void WriteNewEntry()
    {
        int randomIndex = random.Next(prompts.Count);
        string prompt = prompts[randomIndex];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };

        journal.Add(entry);

        Console.WriteLine("Entry added successfully.");
    }

    private void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in journal)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    private void SaveJournal()
    {
        Console.Write("Enter file name to save: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in journal)
                {
                    writer.WriteLine($"Date: {entry.Date}");
                    writer.WriteLine($"Prompt: {entry.Prompt}");
                    writer.WriteLine($"Response: {entry.Response}");
                    writer.WriteLine();
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    private void LoadJournal()
    {
        Console.Write("Enter file name to load: ");
        string fileName = Console.ReadLine();

        try
        {
            journal.Clear(); 

            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string dateLine = reader.ReadLine();
                    string promptLine = reader.ReadLine();
                    string responseLine = reader.ReadLine();

                
                    DateTime date = DateTime.Parse(dateLine.Substring(6));

                 
                    string prompt = promptLine.Substring(8);

                 
                    string response = responseLine.Substring(10);

                    
                    JournalEntry entry = new JournalEntry
                    {
                        Prompt = prompt,
                        Response = response,
                        Date = date
                    };

               
                    journal.Add(entry);
                }
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}