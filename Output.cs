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
        responseBody =  responseBody.Substring(0,index1) + responseBody.Substring(index2,130);
        responseBody = responseBody.Replace("{", "").Replace("}", " ").Replace(":", " ").Replace(",", "").Replace("\"", "").Replace("data","").Replace("v","");
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
}}

// {"status":"ok","data":{"aqi":65,"idx":8689,"attributions":[{"url":"http://monitoring.krakow.pios.gov.pl/","name":"Regional Inspectorate for Environmental Protection in Krakow 
// (WIOŚ - Wojewódzki Inspektorat Ochrony Środowiska w Krakowie)","logo":"poland-wios-krakowie.png"},{"url":"http://powietrze.gios.gov.pl/","name":"Główny inspektorat ochrony środowiska
// ","logo":"poland-wios-national.png"},{"url":"https://waqi.info/","name":"World Air Quality Index Project"}],"city":{"geo":[50.057447,19.946008],"name":"Kraków-ul. Dietla, Małopolska, Poland
// ","url":"https://aqicn.org/city/poland/malopolska/krakow-ul.-dietla","location":""},"dominentpol":"pm25","iaqi":{"co":{"v":0.1},"dew":{"v":6},"h":{"v":76},"no2":{"v":9.6},"o3":{"v":13.3},
// "p":{"v":1002},"pm10":{"v":28},"pm25":{"v":65},"so2":{"v":1.7},"t":{"v":10},"w":{"v":7.7},"wg":{"v":13.3}},"time":{"s":"2023-02-24 14:00:00","tz":"+01:00","v":1677247200,
// "iso":"2023-02-24T14:00:00+01:00"},"forecast":{"daily":{"o3":[{"avg":18,"day":"2023-02-24","max":24,"min":13},{"avg":22,"day":"2023-02-25","max":28,"min":15},{"avg":24,"day":
// "2023-02-26","max":29,"min":20},{"avg":24,"day":"2023-02-27","max":29,"min":20},{"avg":19,"day":"2023-02-28","max":19,"min":19}],"pm10":[{"avg":22,"day":"2023-02-24","max":30,"min":13},
// {"avg":11,"day":"2023-02-25","max":26,"min":6},{"avg":14,"day":"2023-02-26","max":23,"min":9},{"avg":20,"day":"2023-02-27","max":30,"min":12},{"avg":27,"day":"2023-02-28","max":28,"min":27}],
// "pm25":[{"avg":70,"day":"2023-02-24","max":86,"min":50},{"avg":37,"day":"2023-02-25","max":76,"min":18},{"avg":46,"day":"2023-02-26","max":67,"min":27},{"avg":60,"day":"2023-02-27","max":80,
// "min":44},{"avg":80,"day":"2023-02-28","max":83,"min":80}]}},"debug":{"sync":"2023-02-24T22:14:13+09:00"}}}