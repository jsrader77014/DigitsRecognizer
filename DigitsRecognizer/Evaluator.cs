using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DigitsRecognizer
{
    public class Evaluator
    {
        public void Predict(IEnumerable<Observation> testSet, IClassifier classifier)
        {
            foreach(Observation observation in testSet)
            {
                observation.Label = classifier.Predict(observation.Pixels);
            }
        }

        public static double Correct(
        IEnumerable<Observation> validationSet,
        IClassifier classifier)
        {
            return validationSet
            .Select(obs => Score(obs, classifier))
            .Average();
        }
        private static double Score(
        Observation obs,
        IClassifier classifier)
        {
            if (classifier.Predict(obs.Pixels) == obs.Label)
                return 1.0;
            else
                return 0.0;
        }
    }
}
