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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string API = "91e0ded32069e0effc0008a6f4a4a6fe";
        public MainWindow()
        {
            InitializeComponent();

        }
        void GetWeather()
        {
            try
            {
                string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + txtCityInput.Text.ToString() + "&units=metric&appid="+API;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

                lblWeatherTemp.Content = "Avarage temp: " + weatherResponse.list[0].Main.temp.ToString() + "°";
                lblWeatherHumidity.Content = "Humidity: " + weatherResponse.list[0].Main.humidity.ToString() + "%";
                lblWeatherDescription.Content = weatherResponse.list[0].weather[0].description.ToString();
                lblWeatherWinds.Content = "Wind Speed: " + weatherResponse.list[0].wind.speed.ToString() + "m/s";
            }

            catch (Exception e)
            {
                MessageBox.Show("Error.Try again");
            }
            }
            private void btnGetWeather_Click(object sender, RoutedEventArgs e)
            {
                GetWeather();
            }
        }
    } 
