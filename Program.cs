using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {   
        string api_path = "API_key.txt";
        string api_key = System.IO.File.ReadAllText(api_path); 
        Console.WriteLine($"Contents of {api_path} = {api_key}");

    }
}