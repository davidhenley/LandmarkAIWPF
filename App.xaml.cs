using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LandmarkAI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string PredictionUrl = "https://eastus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/60be163c-bb40-402b-8dc4-b1515f658c35/classify/iterations/Iteration1/image";
        public const string PredictionKey = "bea84aeda52c40faa2e907b8e3475f82";
        public const string PredictionType = "application/octet-stream";
    }
}
