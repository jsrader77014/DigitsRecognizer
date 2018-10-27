using System;

namespace DigitsRecognizer
{
    class DigitsRecognizer
    {
        static void Main(string[] args)
        {
            var trainingPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\train.csv";
            var training = DataReader.ReadObservations(trainingPath);
            Console.ReadLine();
        }
    }
}
