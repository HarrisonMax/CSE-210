public class Publisher
{
    public string Name { get; set; }
    public string Address { get; set; }

    public Publisher(string name, string address)
    {
        Name = name;
        Address = address;
    }
}