using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkAI.Models
{
    public class CustomVisionResponse
    {
        public IList<Prediction> Predictions { get; set; }
    }
}
