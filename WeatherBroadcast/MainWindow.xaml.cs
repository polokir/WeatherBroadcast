using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
   
    public partial class MainWindow : Window
    {
        private const string API = "91e0ded32069e0effc0008a6f4a4a6fe";
        private int selector=0;
        public string response;
        public MainWindow()
        {
            InitializeComponent();

        }
        void GetWeather()
        {

            try
            {
                string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + txtCityInput.Text.ToString() + "&units=metric&appid=" + API;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

                lblWeatherTemp.Content = "Avarage temp: " + weatherResponse.list[selector].Main.temp.ToString() + "°";
                lblWeatherHumidity.Content = "Humidity: " + weatherResponse.list[selector].Main.humidity.ToString() + "%";
                lblWeatherDescription.Content = weatherResponse.list[selector].weather[0].description.ToString();
                lblWeatherWinds.Content = "Wind Speed: " + weatherResponse.list[selector].wind.speed.ToString() + "m/s";
                currentTime.Text = weatherResponse.list[selector].dt_txt.ToString("F");

            }
            catch
            {
                MessageBox.Show("Check input field:");
            }
        }
            private void btnGetWeather_Click(object sender, RoutedEventArgs e)
            {
                GetWeather();
            }
        
        private void SelectorPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selector++;
                WeatherResponse weatherResponseSelectorsPlus = JsonConvert.DeserializeObject<WeatherResponse>(response);
                lblWeatherTemp.Content = "Avarage temp: " + weatherResponseSelectorsPlus.list[selector].Main.temp.ToString() + "°";
                lblWeatherHumidity.Content = "Humidity: " + weatherResponseSelectorsPlus.list[selector].Main.humidity.ToString() + "%";
                lblWeatherDescription.Content = weatherResponseSelectorsPlus.list[selector].weather[0].description.ToString();
                lblWeatherWinds.Content = "Wind Speed: " + weatherResponseSelectorsPlus.list[selector].wind.speed.ToString() + "m/s";
                currentTime.Text = weatherResponseSelectorsPlus.list[selector].dt_txt.ToString("F");
            }
            catch 
            {
                MessageBox.Show("Forecast was done only on 5 days");
            }
        }

        private void SelectorMinus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selector--;
                WeatherResponse weatherResponseSelectorsMinus = JsonConvert.DeserializeObject<WeatherResponse>(response);
                lblWeatherTemp.Content = "Avarage temp: " + weatherResponseSelectorsMinus.list[selector].Main.temp.ToString() + "°";
                lblWeatherHumidity.Content = "Humidity: " + weatherResponseSelectorsMinus.list[selector].Main.humidity.ToString() + "%";
                lblWeatherDescription.Content = weatherResponseSelectorsMinus.list[selector].weather[0].description.ToString();
                lblWeatherWinds.Content = "Wind Speed: " + weatherResponseSelectorsMinus.list[selector].wind.speed.ToString() + "m/s";
                currentTime.Text = weatherResponseSelectorsMinus.list[selector].dt_txt.ToString("F");
            }
            catch
            {
                MessageBox.Show("Sorry we don't have forecast on previos days");
            }
        }
    }
    } 
