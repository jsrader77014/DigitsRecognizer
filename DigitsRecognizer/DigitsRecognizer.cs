using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DigitsRecognizer
{
    class DigitsRecognizer
    {
        static void Main(string[] args)
        {
            var distance = new ManhattanDistance();
            var classifier = new BasicClassifier(distance);
            var dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\train.csv";
            Observation[] trainingdata = DataReader.ReadObservations(dataPath);
            //List<int> Selectionlist = new List<int>();
            //for (int i = 0; i < data.Length; i++)
            //{
            //    Selectionlist.Add(i);
            //}
            //Observation[] trainingData = new Observation[(int)(data.Length * .8)];
            //for (int i = 0; i < trainingData.Length; i++)
            //{
            //    Random r = new Random();
            //    int rInt = r.Next(0, Selectionlist.Count);
            //    trainingData[i] = data[rInt];
            //    Selectionlist.RemoveAt(rInt);
            //}

            classifier.Train(trainingdata);

            var testdataPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\test.csv";
            Observation[] testdata = DataReader.ReadObservations(testdataPath);
           
            Evaluator evaluator = new Evaluator();
            evaluator.Predict(testdata, classifier);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < testdata.Length; i++)
            {
                writeProperty(stringBuilder, (i+1).ToString(), true, false);
                writeProperty(stringBuilder, testdata[i].Label, false, true);
            }

            File.WriteAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\sample_submission.csv", stringBuilder.ToString());


            Console.ReadLine();
        }

        

        private static void writeProperty(StringBuilder sb, string value, bool first, bool last)
        {
            if (!value.Contains('\"'))
            {
                if (!first)
                    sb.Append(',');

                sb.Append(value);

                if (last)
                    sb.AppendLine();
            }
            else
            {
                if (!first)
                    sb.Append(",\"");
                else
                    sb.Append('\"');

                sb.Append(value.Replace("\"", "\"\""));

                if (last)
                    sb.AppendLine("\"");
                else
                    sb.Append('\"');
            }
        }

    }
}
