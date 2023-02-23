using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_app
{
     public class Output
    {
        public string responseBodyPrettier(string responseBody)
    {   
        string tempData = "";
        string aqiTable ="";
        int aqiQuality = 0;
        // int pm25Quality=0;
        // int pm10Quality=0;
        string[] responseBodyPrettier ={};
        for(int i=0; i<responseBody.Length; i++){
            if(responseBody[i]=='a' && responseBody[i+1]=='q' && responseBody[i+2]=='i' && aqiQuality==0){
                aqiQuality= ((int)responseBody[i+5] - '0')*10+((int)responseBody[i+6] - '0'); //what if aqiQuality is 100+?
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
                
            }
        }
        return tempData;
    }
    public string cleaner(string responseBody){ 
        int index1 = responseBody.IndexOf("idx");
        int index2 = responseBody.IndexOf("iaqi");
        responseBody =  responseBody.Substring(0,index1) + responseBody.Substring(index2,200) ;
            return responseBody;
    }
    }
}