using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_app
{
     public class Output
    {
    
    public string cleaner(string responseBody){
        responseBody = responseBody.Replace("{", "").Replace("}", " ").Replace(":", " ").Replace(",", "").Replace("\"", "").Replace("v","").Replace("data", ""); 
        int index1 = responseBody.IndexOf("idx");
        int index2 = responseBody.IndexOf("iaqi");
        responseBody = responseBody.Substring(0,index1)+ responseBody.Substring(index2,75);
        string status="", aqi="", pm25="", pm10="";
        for(int i=0; i<responseBody.Length; i++){
            if(responseBody[i]=='s' && responseBody[i+1]=='t'){
                i+=7;
                while(responseBody[i]!=' '){
                    status+=responseBody[i];
                    i++;
                }
            }
            if(responseBody[i-1]==' ' && responseBody[i]=='a'){
                i+=3;
                while(responseBody[i]!='i'){
                    aqi+=responseBody[i];
                    i++;
                }
            }
            if(responseBody[i-1]=='p' && responseBody[i]=='m' && responseBody[i+1]=='1'){
                i+=5;
                while(responseBody[i]!=' '){
                    pm10+=responseBody[i];
                    i++;
                }
            }
            if(responseBody[i-1]=='p' && responseBody[i]=='m' && responseBody[i+1]=='2'){
                i+=5;
                while(responseBody[i]!=' '){
                    pm25+=responseBody[i];
                    i++;
                }
            }
        }
        string aqiMessage="";
        int aqiInt = int.Parse(aqi);
          
        
        if(aqiInt<50){
            aqiMessage = "Air quality is good";
            }
        else if(aqiInt<100){
            aqiMessage = "Air quality is moderate";
            }
        else if(aqiInt<150){
            aqiMessage = "Air quality is unhealthy for sensitive groups"; 
            }
        else if(aqiInt<200){
            aqiMessage = "Air quality is unhealthy";
            }
        else if(aqiInt<300){
            aqiMessage = "Air quality is very unhealthy";
            }
        else if(aqiInt>300){
            aqiMessage = "Air quality is hazardous";
            }
        responseBody = $"Status: {status}\nAqi:{aqi} - {aqiMessage}\npm25: {pm25}\npm10: {pm10}";
        return responseBody;
    }



    public bool checkIfWorks(string responseBody){
        if(responseBody.Contains("error")){
            return false;
        }
        else{
            return true;
        }
    }




    public string errorMessage(string responseBody){
        string message="";
        
        message = responseBody.Replace("{", "").Replace("}", " ").Replace(":", " ").Replace(",", "").Replace("\"", "").Replace("data", "\n");
        message = message.Remove(13, 1).Insert(6,":").Insert(14,"Message: ");

        return message;
    }


}
}

