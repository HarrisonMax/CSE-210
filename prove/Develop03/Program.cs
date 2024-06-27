using System;

class Program
{
    static void Main()
    {
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture("John", 3, 16, scriptureText);
        scripture.Execute();
    }
}