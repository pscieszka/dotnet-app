using System;
using System.Net.Http;
using System.Threading.Tasks;


class Output
{
    public string responseBodyPrettier(string responseBody)
    {   
        string tempData = "";
        string aqiTable ="";
        string[] responseBodyPrettier ={};
        for(int i=0; i<responseBody.Length; i++){
            if(responseBody[i]=='a' && responseBody[i+1]=='q' && responseBody[i+2]=='i'){
                int aqiQuality= ((int)responseBody[i+5] - '0')*10+((int)responseBody[i+6] - '0'); //what if aqiQuality is 100+? to fix
                if(aqiQuality<50){
                    aqiTable = "Air quality is good";
                }
                else if(aqiQuality<100){
                    aqiTable = "Air quality is moderate";
                }
                else if(aqiQuality<150){
                    aqiTable = "Air quality is unhealthy for sensitive groups"; 
                }
                else if(aqiQuality<200){
                    aqiTable = "Air quality is unhealthy";
                }
                else if(aqiQuality<300){
                    aqiTable = "Air quality is very unhealthy";
                }
                else if(aqiQuality>300){
                    aqiTable = "Air quality is hazardous";
                }
                tempData = $"aqi={responseBody[i+5]}{responseBody[i+6]} - {aqiTable}";
                break;
            }
        }
        return tempData;
    }
}
class Program
{
    static async Task Main(string[] args)
    {   
        string api_path = "API_key.txt";
        string api_key = System.IO.File.ReadAllText(api_path); 
        Console.WriteLine($"Contents of {api_path} = {api_key}");
        Console.WriteLine("Enter city name: ");
        string? city = Console.ReadLine();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "MyConsoleApp/1.0");

            HttpResponseMessage response = await client.GetAsync($"https://api.waqi.info/feed/{city}/?token={api_key}");

            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
            Output Output = new Output();
            string prettifiedBody = Output.responseBodyPrettier(responseBody);
            Console.WriteLine(prettifiedBody);

            
        }
    }
}

// lista miast wszystkich i jak nie ma to sprawdza algorytm podobienstwo znakow i sprawdza ktore miasto ma najwieksza podobienstwo 

