using LandmarkAI.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Media.Imaging;

namespace LandmarkAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image files(*.png; *.jpg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (dialog.ShowDialog() == true)
            {
                var fileName = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(fileName));

                MakePredictionAsync(fileName);
            }
        }

        private async void MakePredictionAsync(string fileName)
        {
            var file = File.ReadAllBytes(fileName);

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Prediction-Key", App.PredictionKey);

            using var content = new ByteArrayContent(file);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(App.PredictionType);

            var response = await client.PostAsync(App.PredictionUrl, content);

            var data = await response.Content.ReadAsStringAsync();

            var predictions = JsonConvert.DeserializeObject<CustomVisionResponse>(data)?.Predictions ?? new List<Prediction>();
        }
    }
}
