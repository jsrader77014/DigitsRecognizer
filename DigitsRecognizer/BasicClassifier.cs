using System;
using System.Collections.Generic;
using System.Text;

namespace DigitsRecognizer
{
    public class BasicClassifier: IClassifier
    {
        private IEnumerable<Observation> data;
        private IEnumerable<Observation> test;
        private readonly IDistance distance;

        public BasicClassifier(IDistance distance)
        {
            this.distance = distance;
        }

        public void Train(IEnumerable<Observation> trainingSet)
        {
            this.data = trainingSet;
        }

        
      
        string IClassifier.Predict(int[] pixels)
        {
            Observation currentBest = null;
            var shortest = Double.MaxValue;
            foreach(Observation obs in this.data)
            {
                var dist = this.distance.Between(obs.Pixels, pixels);
                if (dist < shortest)
                {
                    shortest = dist;
                    currentBest = obs;
                }
            }
            return currentBest.Label;
        }
    }
}
