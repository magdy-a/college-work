namespace NNLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NNLibrary.ActivationFunctions;

    #region Enumerators

    /// <summary>
    /// Enumerator for NodeType
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// The Layer the takes input from the training or testing
        /// </summary>
        InputLayer,

        /// <summary>
        /// Any Layer between input and output layer
        /// </summary>
        HiddenLayer,

        /// <summary>
        /// The Layer the generates the output for this network
        /// </summary>
        OutputLayer
    }

    #endregion Enumerators

    /// <summary>
    /// Multilayer Perceptron Node
    /// </summary>
    public class Node
    {
        #region Static Members

        /// <summary>
        /// Random Var to be used
        /// </summary>
        private static Random rnd = new Random();

        #endregion Static Members

        #region Members

        /// <summary>
        /// ID for this node
        /// </summary>
        private int id;

        /// <summary>
        /// Type of this node
        /// </summary>
        private NodeType type;

        /// <summary>
        /// Value of this Node
        /// </summary>
        private double z;

        /// <summary>
        /// Signal Error for this node
        /// </summary>
        private double signalError;

        /// <summary>
        /// Bias for this node
        /// </summary>
        private double bias;

        /// <summary>
        /// Activation function for this node
        /// </summary>
        private ActivationFunction function;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        /// <param name="myId">ID for this node</param>
        /// <param name="myType">Type of this node</param>
        public Node(int myId, NodeType myType)
        {
            this.id = myId;
            this.type = myType;
            this.bias = GetBiasValue();
            this.z = 0;
            this.function = new SigmoidFn();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets ID for this node
        /// </summary>
        public int ID
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets Type of this node
        /// </summary>
        public NodeType Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// Gets or sets Value of this Node
        /// </summary>
        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        /// <summary>
        /// Gets or sets Signal Error for this node
        /// </summary>
        public double SignalError
        {
            get { return this.signalError; }
            set { this.signalError = value; }
        }

        /// <summary>
        /// Gets Bias for this node
        /// </summary>
        public double Bias
        {
            get { return this.bias; }
        }

        /// <summary>
        /// Gets Activation function for this node
        /// </summary>
        public ActivationFunction Function
        {
            get { return this.function; }
        }

        #endregion Properties

        #region Static Functions

        /// <summary>
        /// Create a new Random Bias Value
        /// </summary>
        /// <returns>Random Bias Value</returns>
        public static double GetBiasValue()
        {
            ////return rnd.NextDouble() + (-1 * rnd.NextDouble());
            return 1;
        }

        #endregion Static Functions

        #region Functions

        /// <summary>
        /// Set the initial value from samples to the input layer node
        /// </summary>
        /// <param name="myValue">The value to set</param>
        public void Set_Initial_Value_To_InputLayer_Node(double myValue)
        {
            if (this.type == NodeType.InputLayer)
            {
                this.z = myValue;
            }
        }

        #endregion Functions

        #region Overrided Functions

        /// <summary>
        /// The string representation for the node
        /// </summary>
        /// <returns>String Representation</returns>
        public override string ToString()
        {
            return string.Format("ID: {0}, Type: {1}, Value: {2}, Net: {3}, SignalError: {4}", this.id, this.type.ToString(), this.z, this.function.Net, this.signalError);
        }

        #endregion Overrided Functions
    }
}