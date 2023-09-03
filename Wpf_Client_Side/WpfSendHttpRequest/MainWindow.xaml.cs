﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net.Http;

namespace WpfSendHttpRequest
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static readonly HttpClient client = new HttpClient();
        

        private async void postBtn_Click(object sender, RoutedEventArgs e)
        {
            var values = new Dictionary<string, string>
              {
                  { "key1", "POST.jpg" },
                  { "key2", "NG" }
              };

            var content = new FormUrlEncodedContent(values);

            
            //string webServer = "http://localhost:62338/Default.aspx"; This will cause redirect and the httpclient will send get request instead of a post request.
            string webServer = "http://localhost:62338/Default";


            //If you don't need to receive message from the server, use the following.
            //client.PostAsync(webServer, content);

            //If the server side doesn't use Response.Write(msgFromServer);Response.End()
            //the webpage's html content will be received by responseString.
            var response = await client.PostAsync(webServer, content);
            var responseString = await response.Content.ReadAsStringAsync();

            lbWebServerResponse.Content = "\n"+responseString;
        }

        private async void getBtn_Click(object sender, RoutedEventArgs e)
        {
            string webServer = "http://localhost:62338/Default";
            string paraStr = "?key1=GET.jpg&key2=良品";
            string httpRequest = webServer + paraStr;

            //If you don't need to receive message from the server, use the following.
            //client.GetStringAsync(httpRequest);

            //If the server side doesn't use Response.Write(msgFromServer);Response.End()
            //the webpage's html content will be received by responseString.
            var responseString = await client.GetStringAsync(httpRequest);
            lbWebServerResponse.Content = "\n" + responseString;

            
        }
    }
}
