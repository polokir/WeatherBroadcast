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
        private int selector;
        WeatherForecast weatherForecast = new WeatherForecast();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void OutputContent(WeatherForecast forecast)
        {
            lblWeatherTemp.Content = forecast.temp;
            lblWeatherHumidity.Content = forecast.humidity;
            lblWeatherDescription.Content = forecast.description;
            lblWeatherWinds.Content = forecast.winds;
            currentTime.Text = forecast.date;
        }
        
        
        private void btnGetWeather_Click(object sender, RoutedEventArgs e)
        {
            selector = 0;
            weatherForecast.GetWeather(txtCityInput.Text.ToString(), selector);
            OutputContent(weatherForecast);
        }
        
        private void SelectorPlus_Click(object sender, RoutedEventArgs e)
        {
            selector++;
            weatherForecast.NextDays(selector);
            OutputContent(weatherForecast);

        }

        private void SelectorMinus_Click(object sender, RoutedEventArgs e)
        {
            selector--;
            weatherForecast.NextDays(selector);
            OutputContent(weatherForecast);
        }
    }
} 
