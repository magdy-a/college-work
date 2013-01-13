namespace NNLibrary.MLPProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Enumerator for the Problem Type
    /// </summary>
    public enum ProblemType
    {
        /// <summary>
        /// XOR bitwise Problem
        /// </summary>
        XOR,

        /// <summary>
        /// Opticle Character Recognition Problem
        /// </summary>
        OCR,
    }

    /// <summary>
    /// MLP Prolem Class, the parent of all problems
    /// </summary>
    public abstract class MLPProblem
    {
        #region Members

        /// <summary>
        /// Learning Rate for this problem
        /// </summary>
        private double eta;

        /// <summary>
        /// Min Error for this Problem
        /// </summary>
        private double minError;

        /// <summary>
        /// Max Epochs Num for this problem
        /// </summary>
        private int epochsNum;

        /// <summary>
        ///  Numbers for all Samples and Testing Samples from them
        /// </summary>
        private int samplesNum, testingNum;

        /// <summary>
        /// List holding the samples values
        /// </summary>
        private List<List<double>> samples;

        /// <summary>
        /// Samples desired output
        /// </summary>
        private List<List<double>> samplesResults;

        /// <summary>
        /// The number of input elements and output elements
        /// </summary>
        private int inputElements, outputElements;

        /// <summary>
        /// List carries info about the hidden layers, the count of the list is the number of hidden layers, each element in each index, indicates the number of nodes in this layer
        /// </summary>
        private List<int> hiddenLayers;

        /// <summary>
        /// Random Variable
        /// </summary>
        private Random rnd;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MLPProblem class.
        /// </summary>
        public MLPProblem()
        {
        }

        #endregion Constructor

        #region Static Properties

        /// <summary>
        /// Gets or sets Learning Rate for this problem
        /// </summary>
        public double Eta
        {
            get { return this.eta; }
            set { this.eta = value; }
        }

        /// <summary>
        /// Gets or sets Min Error for this Problem
        /// </summary>
        public double MinError
        {
            get { return this.minError; }
            set { this.minError = value; }
        }

        /// <summary>
        /// Gets or sets Max Epochs Num for this problem
        /// </summary>
        public int EpochsNum
        {
            get { return this.epochsNum; }
            set { this.epochsNum = value; }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Type of this problem
        /// </summary>
        public virtual ProblemType Type
        {
            get { return ProblemType.XOR; }
        }

        /// <summary>
        ///  Gets or sets Numbers for all Samples
        /// </summary>
        public int TestingNum
        {
            get { return this.testingNum; }
            set { this.testingNum = value; }
        }

        /// <summary>
        ///  Gets or sets Numbers for Testing Samples
        /// </summary>
        public int SamplesNum
        {
            get { return this.samplesNum; }
            set { this.samplesNum = value; }
        }

        /// <summary>
        /// Gets or sets List holding the samples values
        /// </summary>
        public List<List<double>> Samples
        {
            get { return this.samples; }
            protected set { this.samples = value; }
        }

        /// <summary>
        /// Gets or sets Samples desired output
        /// </summary>
        public List<List<double>> SamplesResults
        {
            get { return this.samplesResults; }
            protected set { this.samplesResults = value; }
        }

        /// <summary>
        /// Gets or sets the number of Input Elements
        /// </summary>
        public int InputElements
        {
            get { return this.inputElements; }
            protected set { this.inputElements = value; }
        }

        /// <summary>
        /// Gets or sets the number of Output Elements
        /// </summary>
        public int OutputElements
        {
            get { return this.outputElements; }
            protected set { this.outputElements = value; }
        }

        /// <summary>
        /// Gets or sets List carries info about the hidden layers, the count of the list is the number of hidden layers, each element in each index, indicates the number of nodes in this layer
        /// </summary>
        public List<int> HiddenLayers
        {
            get { return this.hiddenLayers; }
            protected set { this.hiddenLayers = value; }
        }

        /// <summary>
        /// Gets or sets Random Variable
        /// </summary>
        protected Random Rnd
        {
            get { return this.rnd; }
            set { this.rnd = value; }
        }

        #endregion Properties

        public void SetValues(string myEta, string myMinError, decimal myEpochsNum, decimal myTestingNum)
        {
            this.eta = double.Parse(myEta);
            this.minError = double.Parse(myMinError);

            this.epochsNum = (int)myEpochsNum;
            this.testingNum = (int)myTestingNum;
        }

        #region Abstract Initializations

        /// <summary>
        /// Initialize the Training and Testing Lists
        /// </summary>
        protected abstract void Create_Samples_And_Results();

        #endregion Initializations
    }
}