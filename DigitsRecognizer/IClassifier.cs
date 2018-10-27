using System;
using System.Collections.Generic;
using System.Text;

namespace DigitsRecognizer
{
    public interface IClassifier
    {
        void Train(IEnumerable<Observation> trainingSet);
        string Predict(int[] pixels);
    }
}
