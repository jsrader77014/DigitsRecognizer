using System;
using System.Collections.Generic;
using System.Text;

namespace DigitsRecognizer
{
    
    public class Observation
    {
        public string Label { get;  set; }
        public int[] Pixels { get; private set; }

        public Observation(string label, int[] pixels)
        {
            Label = label;
            Pixels = pixels;

        }
    }
}
