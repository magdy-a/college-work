namespace NNLibrary.MLPProblems
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Optical Character recognition Class
    /// </summary>
    public class OCR : MLPProblem
    {
        /// <summary>
        /// Dimensions of the input pattern
        /// </summary>
        private static int Rows = 24, Columns = 18;

        public static int defaultInputElements = Rows * Columns, defaultOutputElements = 10;
        public static List<int> defaultHiddenLayers = new List<int>(new int[] { 100, 100, 100 });

        /// <summary>
        /// The pathes to samples and results files
        /// </summary>
        private string samplesFilePath, resultsFilePath;

        /// <summary>
        /// Initializes a new instance of the OCR class.
        /// </summary>
        /// <param name="mySamples_FilePath">The Path of the samples file</param>
        /// <param name="myResults_FilePath">The Path of the result file</param>
        public OCR(int mySamplesNum, string mySamples_FilePath, string myResults_FilePath)
        {
            this.samplesFilePath = mySamples_FilePath;
            this.resultsFilePath = myResults_FilePath;

            this.InputElements = defaultInputElements;
            this.OutputElements = defaultOutputElements;
            this.HiddenLayers = defaultHiddenLayers;

            this.SamplesNum = mySamplesNum;

            this.Rnd = new Random();

            this.Create_Samples_And_Results();
        }

        /// <summary>
        /// Gets the Type of this problem
        /// </summary>
        public override ProblemType Type
        {
            get { return ProblemType.OCR; }
        }

        /// <summary>
        /// Initialize the Training and Testing Lists
        /// </summary>
        protected override void Create_Samples_And_Results()
        {
            FileStream myFileStreamSamples = new FileStream(this.samplesFilePath, FileMode.Open);
            StreamReader myStreamReaderSamples = new StreamReader(myFileStreamSamples);

            FileStream myFileStreamResults = new FileStream(this.resultsFilePath, FileMode.Open);
            StreamReader myStreamReaderResults = new StreamReader(myFileStreamResults);
            myStreamReaderResults.ReadLine();

            string tmpString;
            string[] tmpSplittedString;
            List<double> tmpList;

            this.Samples = new List<List<double>>();
            this.SamplesResults = new List<List<double>>();

            for (int i = 0; i < SamplesNum; i++)
            {
                // Initialize tmpString and tmpList for new values
                tmpString = string.Empty;

                tmpList = new List<double>();

                // Read a sample
                for (int j = 0; j < Rows; j++)
                {
                    tmpString += myStreamReaderSamples.ReadLine() + ' ';
                }

                // Split each value of the sample
                tmpSplittedString = tmpString.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                // Add them to a list
                for (int j = 0; j < InputElements; j++)
                {
                    tmpList.Add(double.Parse(tmpSplittedString[j]));
                }

                // Add the list to the samples
                this.Samples.Add(tmpList);

                // Initialize tmpList for new values
                tmpList = new List<double>();

                // Split each value of the result
                tmpSplittedString = myStreamReaderResults.ReadLine().Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                // Add them to a list
                for (int j = 0; j < OutputElements; j++)
                {
                    tmpList.Add(double.Parse(tmpSplittedString[j]));
                }

                // Add the list to the results
                this.SamplesResults.Add(tmpList);
            }

            myStreamReaderSamples.Close();
            myStreamReaderResults.Close();

            myFileStreamSamples.Close();
            myFileStreamResults.Close();
        }
    }
}