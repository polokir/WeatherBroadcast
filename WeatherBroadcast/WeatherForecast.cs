using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WeatherBroadcast
{
    class WeatherForecast
    {
        private const string API = "91e0ded32069e0effc0008a6f4a4a6fe";
        private string response;

        
        public string temp;
        public string humidity;
        public string description;
        public string winds;
        public string date;



        public void GetWeather(string city,int selector)
        {

            try
            {
                string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&units=metric&appid=" + API;//створенння API запиту
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);//створенння API запиту
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();// cтворення відповіді    
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))//зчитування відповіді
                {
                    response = streamReader.ReadToEnd();
                }
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

                temp = "Avarage temp: " + weatherResponse.list[selector].Main.temp.ToString() + "°";
                humidity = "Humidity: " + weatherResponse.list[selector].Main.humidity.ToString() + "%";
                description = weatherResponse.list[selector].weather[0].description.ToString();
                winds = "Wind Speed: " + weatherResponse.list[selector].wind.speed.ToString() + "m/s";
                date = weatherResponse.list[selector].dt_txt.ToString("F", new System.Globalization.CultureInfo("en-EN"));

            }
            catch
            {
                MessageBox.Show("Check input field:");
            }
        }

        public void NextDays (int selector)
        {
            try
            {
                selector++;
                WeatherResponse weatherResponseSelectorsPlus = JsonConvert.DeserializeObject<WeatherResponse>(response);
                temp = "Avarage temp: " + weatherResponseSelectorsPlus.list[selector].Main.temp.ToString() + "°";
                humidity = "Humidity: " + weatherResponseSelectorsPlus.list[selector].Main.humidity.ToString() + "%";
                description = weatherResponseSelectorsPlus.list[selector].weather[0].description.ToString();
                winds = "Wind Speed: " + weatherResponseSelectorsPlus.list[selector].wind.speed.ToString() + "m/s";
                date = weatherResponseSelectorsPlus.list[selector].dt_txt.ToString("F", new System.Globalization.CultureInfo("en-EN"));
            }
            catch
            {
                MessageBox.Show("Forecast was done only on 5 days");
            }
        }
    }
}

