using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DigitsRecognizer
{
    class Evaluator
    {
        public static double Score(Observation obs, IClassifier classifier)
        {
            if (classifier.Predict(obs.Pixels) == obs.Label)
                return 1.0;
            else
                return 0;
        }

        public static double Correct(IEnumerable<Observation> validationSet, IClassifier classifier)
        {
            return validationSet
                .Select(obs => Score(obs, classifier))
                .Average();
                
        }
    }
}
