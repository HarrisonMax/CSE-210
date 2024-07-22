public class Patron
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }

    public void Borrow()
    {
        Console.WriteLine($"{Name} has borrowed an item.");
    }

    public void Return()
    {
        Console.WriteLine($"{Name} has returned an item.");
    }
}