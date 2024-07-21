using System;

public class Patron
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }

    public Patron(string name, string contactInfo)
    {
        Name = name;
        ContactInfo = contactInfo;
    }
}
