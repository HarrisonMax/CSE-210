public class Staff
{
    public string Name { get; set; }
    public string Position { get; set; }
    public string Credentials { get; set; }

    public bool Authenticate(string username, string password)
    {
        return true; 
    }

    public void ManageLibrary()
    {
  
    }
}