namespace NNLibrary.MLPProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// XORProblem Class, that uses MLP to solve XOR problems
    /// </summary>
    public class XORProblem : MLPProblem
    {
        public static int defaultInputElements = 2, defaultOutputElements = 1;
        public static List<int> defaultHiddenLayers = new List<int>(new int[] { 6, 6 });

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the XORProblem class.
        /// </summary>
        public XORProblem(int mySamplesNum)
        {
            InputElements = defaultInputElements;
            OutputElements = defaultOutputElements;
            HiddenLayers = defaultHiddenLayers;

            SamplesNum = mySamplesNum;

            this.Rnd = new Random();

            this.Create_Samples_And_Results();
        }

        /// <summary>
        /// Initializes a new instance of the XORProblem class.
        /// </summary>
        /// <param name="mySamplesNum">Number of samples</param>
        /// <param name="myTestingNum">Number of testing samples</param>
        /// <param name="myInputElements">The number of input Elements in the network</param>
        /// <param name="myOutputElements">The number of output Elements in the network</param>
        /// <param name="myHiddenLayers">List carries the number of nodes in each layer</param>
        public XORProblem(int mySamplesNum, int myTestingNum, int myInputElements, int myOutputElements, List<int> myHiddenLayers)
        {
            InputElements = myInputElements;
            OutputElements = myOutputElements;

            HiddenLayers = myHiddenLayers;

            SamplesNum = mySamplesNum;

            this.Rnd = new Random();

            this.Create_Samples_And_Results();
        }

        #endregion Constructor

        /// <summary>
        /// Gets the Type of this problem
        /// </summary>
        public override ProblemType Type
        {
            get { return ProblemType.XOR; }
        }

        #region Helping Functions

        /// <summary>
        /// Calculate Desired Output
        /// </summary>
        /// <param name="sample">List of values in this Sample</param>
        /// <returns>result of a_XOR_b</returns>
        protected List<double> GetDesiredOutput(List<double> sample)
        {
            List<double> result = new List<double>(1);

            result.Add(Math.Abs(sample[0] - sample[1]));

            return result;
        }

        #endregion Helping Functions

        #region Overrided Initializations

        /// <summary>
        /// Initialize the Training and Testing Lists
        /// </summary>
        protected override void Create_Samples_And_Results()
        {
            // Initialize Samples Lists
            this.Samples = new List<List<double>>();
            this.SamplesResults = new List<List<double>>();

            // For Training Samples, Add Training Sample, and calc desired output
            for (int i = 0; i < SamplesNum; i++)
            {
                // create two values for this sample
                this.Samples.Add(new List<double>(new double[] { this.Rnd.Next() % 2, this.Rnd.Next() % 2 }));

                // foreach 2 inputs, generate one output
                this.SamplesResults.Add(this.GetDesiredOutput(new List<double>(new double[] { this.Samples[i][0], this.Samples[i][1] })));
            }
        }

        #endregion Overrided Initializations
    }
}