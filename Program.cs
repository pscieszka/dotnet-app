using System;
using System.Net.Http;
using System.Threading.Tasks;
using static dotnet_app.Output;
namespace dotnet_app
{

class Program
{
    static async Task Main(string[] args)
    {   
        string api_path = "API_key.txt";
        string api_key = System.IO.File.ReadAllText(api_path); // API key from file
        Console.WriteLine("Enter city name: ");
        string? city = Console.ReadLine();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "MyConsoleApp/1.0");

            HttpResponseMessage response = await client.GetAsync($"https://api.waqi.info/feed/{city}/?token={api_key}");
            Output Output = new Output();
            string responseBody = await response.Content.ReadAsStringAsync();

            if(Output.checkIfWorks(responseBody)){
                responseBody = Output.cleaner(responseBody);
                Console.WriteLine(responseBody);
            }
            else {
                responseBody = Output.errorMessage(responseBody);
                Console.WriteLine(responseBody);
            }

            
        }
    }
}
}

// lista miast wszystkich i jak nie ma to sprawdza algorytm podobienstwo znakow i sprawdza ktore miasto ma najwieksza podobienstwo 

