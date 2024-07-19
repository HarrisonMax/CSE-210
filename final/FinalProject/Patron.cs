using System;
using System.Collections.Generic;

public class Patron
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactInformation { get; set; }
    public bool MembershipStatus { get; set; }

    public void Register()
    {
        MembershipStatus = true;
    }

    public void UpdateDetails(string newName, string newAddress, string newContactInfo)
    {
        Name = newName;
        Address = newAddress;
        ContactInformation = newContactInfo;
    }

    public void ViewLoans()
    {
        
    }
}