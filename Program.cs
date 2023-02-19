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
}// lista miast wszystkich i jak nie ma to sprawdza algorytm podobienstwo znakow i sprawdza ktore miasto ma najwieksza podobienstwo 
class Cities{
    List<string> cities = new List<string>();
    string cityInput(List<string> cities){
        string city;
        Console.WriteLine("Enter city name: ");
        city = Console.ReadLine();
        if(cities.Contains(city)){
            return city;
        }
        else{
            string notFound = "City not found";
            return notFound;
        
    }
}


    


