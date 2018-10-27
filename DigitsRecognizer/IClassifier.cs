using System;
using System.Collections.Generic;
using System.Text;

namespace DigitsRecognizer
{
    interface IClassifier
    {
        void Train(IEnumerable<Observation> trainingSet);
        string Predict(int[] pixels);
    }
}
