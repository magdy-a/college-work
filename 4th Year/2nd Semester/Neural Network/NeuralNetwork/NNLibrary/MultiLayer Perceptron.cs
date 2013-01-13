namespace NNLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using NNLibrary.MLPProblems;

    /// <summary>
    /// Multilayer Perceptron Network class
    /// </summary>
    public class MultiLayerPerceptron
    {
        #region Static Members

        /// <summary>
        /// Random Variable
        /// </summary>
        private static Random rnd;

        #endregion Static Members

        #region Members

        #region Form

        TrainingData td = new TrainingData();

        DateTime before;

        #endregion Form

        #region Problem

        /// <summary>
        /// The Problem for this MLP Solver
        /// </summary>
        private MLPProblem problem;

        #endregion Problem

        #region Network Architecture

        /// <summary>
        /// The list of Nodes in my Network, list of inputLayer Nodes, and outputLayer Nodes
        /// </summary>
        private List<Node> nodes;

        /// <summary>
        /// All Layers list
        /// </summary>
        private List<List<Node>> layers;

        /// <summary>
        /// Normal NodesDirections for all Nodes
        /// </summary>
        private List<List<Node>> forwrdDir;

        /// <summary>
        /// FirstDerivative NodesDirections for all Nodes
        /// </summary>
        private List<List<Node>> bckwrdDir;

        /// <summary>
        /// The List that carries the weights for the Network
        /// </summary>
        private double[,] weights;

        /// <summary>
        /// The Bias Weights for all Nodes except the input layer nodes
        /// </summary>
        private double[] biasWeights;

        #endregion Network Architecture

        #region Errors And Epochs

        /// <summary>
        /// The number of epochs used
        /// </summary>
        private int epochsUsed;

        /// <summary>
        /// The global error per epoch
        /// </summary>
        private double[] errorPerEpoch;

        /// <summary>
        /// The Mean Square Error for each epoch
        /// </summary>
        private double[] meanSquareErrorPerEpoch;

        #endregion Errors And Epochs

        #endregion Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MultiLayerPerceptron class.
        /// </summary>
        /// <param name="myProblem">MLP Problem to solve</param>
        public MultiLayerPerceptron(MLPProblem myProblem)
        {
            this.problem = myProblem;

            rnd = new Random();

            // Apply All Initializations to the network
            this.DoAllInitializations(myProblem.InputElements, myProblem.OutputElements, myProblem.HiddenLayers);
        }

        #endregion Constructor

        #region Properties

        #region Problem

        /// <summary>
        /// Gets The Problem for this MLP Solver
        /// </summary>
        public MLPProblem Problem
        {
            get { return this.problem; }
        }

        #region Samples

        /// <summary>
        /// Gets the Samples for this problem
        /// </summary>
        public List<List<double>> Samples
        {
            get { return this.problem.Samples; }
        }

        /// <summary>
        /// Gets the Samples Results for this problem
        /// </summary>
        public List<List<double>> SamplesResults
        {
            get { return this.problem.SamplesResults; }
        }

        /// <summary>
        /// Gets the Samples Num for this problem
        /// </summary>
        public int SamplesNum
        {
            get { return this.problem.SamplesNum; }
        }

        /// <summary>
        /// Gets the Training Number for this problem
        /// </summary>
        public int TrainingNum
        {
            get { return this.problem.SamplesNum /** 75 / 100*/; }
        }

        /// <summary>
        /// Gets the Testing Number for this problem
        /// </summary>
        public int TestingNum
        {
            get { return this.problem.TestingNum; }
        }

        #endregion Samples

        #region Errors And Epochs

        /// <summary>
        /// Gets The Learning Rate
        /// </summary>
        public double Eta
        {
            get { return this.problem.Eta; }
        }

        /// <summary>
        /// Gets the min error we are targeting
        /// </summary>
        public double MinError
        {
            get { return this.problem.MinError; }
        }

        /// <summary>
        /// Gets The number of epochs used
        /// </summary>
        public int EpochsUsed
        {
            get { return this.epochsUsed; }
        }

        /// <summary>
        /// Gets The number max epochs
        /// </summary>
        public int EpochsNum
        {
            get { return this.problem.EpochsNum; }
        }

        /// <summary>
        /// The global error per epoch
        /// </summary>
        public double[] ErrorPerEpoch
        {
            get { return this.errorPerEpoch; }
        }

        /// <summary>
        /// The Mean Square Error for each epoch
        /// </summary>
        public double[] MeanSquareErrorPerEpoch
        {
            get { return this.meanSquareErrorPerEpoch; }
        }

        #endregion Errors And Epochs

        #endregion Problem

        #region Network Architecture

        /// <summary>
        /// Gets The list of Nodes in my Network, list of inputLayer Nodes, and outputLayer Nodes
        /// </summary>
        public List<Node> Nodes
        {
            get { return this.nodes; }
        }

        /// <summary>
        /// Gets All Layers List
        /// </summary>
        public List<List<Node>> Layers
        {
            get { return this.layers; }
        }

        /// <summary>
        /// Gets the input layer from all layers list
        /// </summary>
        public List<Node> InputLayer
        {
            get { return (this.layers.Count == 0 || this.layers == null) ? null : this.layers[0]; }
        }

        /// <summary>
        /// Gets the output layer from all layers list
        /// </summary>
        public List<Node> OutputLayer
        {
            get { return (this.layers.Count == 0 || this.layers == null) ? null : this.layers[this.layers.Count - 1]; }
        }

        /// <summary>
        /// Gets Normal NodesDirections for all Nodes
        /// </summary>
        public List<List<Node>> ForwrdDir
        {
            get { return this.forwrdDir; }
        }

        /// <summary>
        /// Gets FirstDerivative NodesDirections for all Nodes
        /// </summary>
        public List<List<Node>> BckwrdDir
        {
            get { return this.bckwrdDir; }
        }

        /// <summary>
        /// Gets The List that carries the weights for the Network
        /// </summary>
        public double[,] Weights
        {
            get { return this.weights; }
        }

        #endregion Network Architecture

        #endregion Properties

        #region Static Functions

        /// <summary>
        /// Create a new Random Weight Value
        /// </summary>
        /// <returns>Random Weight Value</returns>
        public static double GetRandomWeightValue()
        {
            return rnd.NextDouble() + -(1 * rnd.NextDouble());
        }

        #endregion Static Functions

        #region Main Functions

        /// <summary>
        /// Run the Training Process
        /// </summary>
        public void RunTraining()
        {
            this.epochsUsed = 0;

            this.errorPerEpoch = new double[this.EpochsNum];

            this.meanSquareErrorPerEpoch = new double[this.EpochsNum];

            //this.td.Show();

            this.before = DateTime.Now;

            do
            {
                for (int sampleIndex = 0; sampleIndex < this.TrainingNum; sampleIndex++)
                {
                    // Forward Pass
                    this.ForwardPass(sampleIndex);

                    // BP Calc_Normal Signal Error for all nodes
                    this.CalcSignalError(sampleIndex);

                    // Sum the signal error foreach node in the output layer
                    for (int i = 0; i < this.OutputLayer.Count; i++)
                    {
                        this.errorPerEpoch[this.epochsUsed] += this.OutputLayer[i].SignalError;
                        this.meanSquareErrorPerEpoch[this.epochsUsed] += 0.5 * Math.Pow(this.OutputLayer[i].SignalError, 2);
                    }

                    //if (sampleIndex % 20 == 0)
                    //{
                    //    this.td.UpdateData(this.epochsUsed, sampleIndex, this.errorPerEpoch[this.epochsUsed], DateTime.Now - before);
                    //}

                    // Update weights
                    this.UpdateWeights();
                }

                this.meanSquareErrorPerEpoch[this.epochsUsed] /= this.TrainingNum;

                this.epochsUsed++;
            }
            while (Math.Abs(this.errorPerEpoch[this.epochsUsed - 1]) > this.MinError && this.epochsUsed < this.EpochsNum);

            //this.td.Close();
        }

        /// <summary>
        /// Run Testing with the testing samples
        /// </summary>
        /// <returns>Percentage of accuracy</returns>
        public double RunTesting()
        {
            int hit = 0;

            List<int> testingIndicies = new List<int>();
            int tmpIndex;

            if (this.TestingNum == this.SamplesNum)
            {
                for (int i = 0; i < this.SamplesNum; i++)
                {
                    testingIndicies.Add(i);
                }
            }
            else
            {
                while (testingIndicies.Count < this.TestingNum)
                {
                    tmpIndex = rnd.Next(this.SamplesNum);

                    if (testingIndicies.FindAll(x => x.CompareTo(tmpIndex) == 0).Count == 0)
                    {
                        testingIndicies.Add(tmpIndex);
                    }
                }
            }

            for (int i = 0; i < testingIndicies.Count; i++)
            {
                this.ForwardPass(testingIndicies[i]);

                hit++;
                for (int j = 0; j < this.OutputLayer.Count; j++)
                {
                    if (this.SamplesResults[testingIndicies[i]][j] != Math.Round(this.OutputLayer[j].Z))
                    {
                        hit--;
                        break;
                    }
                }
            }

            return hit / (double)this.TestingNum * 100;
        }

        /// <summary>
        /// Forward pass for every Training sample
        /// </summary>
        /// <param name="sampleIndex">sample Index</param>
        public void ForwardPass(int sampleIndex)
        {
            // Set input Values, to each element in the input layer
            for (int inputNodeIndex = 0; inputNodeIndex < this.InputLayer.Count; inputNodeIndex++)
            {
                // Set current input layer node's value
                this.InputLayer[inputNodeIndex].Set_Initial_Value_To_InputLayer_Node(this.Samples[sampleIndex][inputNodeIndex]);

                // Send values through weights to next nodes
                this.Send_Value_Through_Weights_Forward(this.InputLayer[inputNodeIndex]);
            }

            // Foreach other layer, after the input layer
            for (int layerIndex = 1; layerIndex < this.layers.Count; layerIndex++)
            {
                // Foreach Node in this layer
                foreach (Node tmpNode in this.layers[layerIndex])
                {
                    // Add Bias value of this node to the net
                    tmpNode.Function.Add(tmpNode.Bias * this.biasWeights[tmpNode.ID]);

                    // Calculate Value, and set it
                    tmpNode.Z = tmpNode.Function.Calc_Normal();

                    // Send values through weights to next nodes
                    this.Send_Value_Through_Weights_Forward(tmpNode);
                }
            }
        }

        public bool CheckCurrentOutput(int sampleIndex)
        {
            bool result = true;

            for (int i = 0; i < this.OutputLayer.Count; i++)
            {
                if (this.SamplesResults[sampleIndex][i] != Math.Round(this.OutputLayer[i].Z))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Calculate the error for this result
        /// </summary>
        /// <param name="sampleIndex">Used Sample Index</param>
        private void CalcSignalError(int sampleIndex)
        {
            Node tmpNode, tmpNextNode;
            double tmp_Weights_Mul_SignalErrors;

            // foreach node in the output layer, calc Signal Error
            for (int i = 0; i < this.OutputLayer.Count; i++)
            {
                tmpNode = this.OutputLayer[i];

                // Calculate the signal error for this output layer node, using the last net value
                tmpNode.SignalError = (this.SamplesResults[sampleIndex][i] - tmpNode.Z) * tmpNode.Function.Calc_FirstDerivative(tmpNode.Z);
            }

            // foreach node all hidden layers, calc Signal Error
            for (int i = this.layers.Count - 2; i > 0; i--)
            {
                // foreach node in this hidden layer
                for (int j = 0; j < this.layers[i].Count; j++)
                {
                    // get current node
                    tmpNode = this.layers[i][j];

                    tmp_Weights_Mul_SignalErrors = 0;

                    // Foreach Weight, from me to the node in the forwardDir, sum the weight * nextNode's signal error
                    for (int k = 0; k < this.forwrdDir[tmpNode.ID].Count; k++)
                    {
                        // Get the current-forward node in the forward list
                        tmpNextNode = this.forwrdDir[tmpNode.ID][k];

                        tmp_Weights_Mul_SignalErrors += this.weights[tmpNode.ID, tmpNextNode.ID] * tmpNextNode.SignalError;
                    }

                    // Signal Error = FirstDerivative for this node, based on it's net value * Summation (Weight * ForwardNode_SignalErorrs)
                    tmpNode.SignalError = tmpNode.Function.Calc_FirstDerivative(tmpNode.Z) * tmp_Weights_Mul_SignalErrors;
                }
            }
        }

        /// <summary>
        /// Update all weights in the network
        /// </summary>
        private void UpdateWeights()
        {
            Node tmpNode, tmpPreviousNode;

            // foreach layer except the input layer, update backward weights and bias
            for (int i = 1; i < this.layers.Count; i++)
            {
                // foreach node in this layer
                for (int j = 0; j < this.layers[i].Count; j++)
                {
                    tmpNode = this.layers[i][j];

                    // Foreach Node in the backward Direction
                    for (int k = 0; k < this.bckwrdDir[tmpNode.ID].Count; k++)
                    {
                        tmpPreviousNode = this.bckwrdDir[tmpNode.ID][k];

                        this.weights[tmpPreviousNode.ID, tmpNode.ID] += -1 * this.Eta * tmpNode.SignalError * tmpPreviousNode.Z;

                        this.biasWeights[tmpNode.ID] += -1 * this.Eta * tmpNode.SignalError * tmpNode.Bias;
                    }
                }
            }
        }

        /// <summary>
        /// Send the value of the tmpNode to the forward nodes
        /// </summary>
        /// <param name="tmpNode">Node to send from</param>
        private void Send_Value_Through_Weights_Forward(Node tmpNode)
        {
            Node tmpNextNode;
            double tmpWeight;

            // Foreach direction for this node, add required value
            for (int k = 0; k < this.forwrdDir[tmpNode.ID].Count; k++)
            {
                // Get Next Node
                tmpNextNode = this.forwrdDir[tmpNode.ID][k];

                // Get Weight, forward:[nodeID,nextID] ... backward:[nextID,nodeID]
                tmpWeight = this.weights[tmpNode.ID, tmpNextNode.ID];

                // Add to Value, Check If I should add the bias
                tmpNextNode.Function.Add(tmpNode.Z * tmpWeight);
            }
        }

        #endregion Main Functions

        #region Helping Functions

        #endregion Helping Functions

        #region Initializations

        /// <summary>
        /// Makes all the Initializations Network, by defining all Nodes, and their static values, Layers, and forward Directions along with it's backward
        /// </summary>
        /// <param name="myInputElements">The number of input Elements in the network</param>
        /// <param name="myOutputElements">The number of output Elements in the network</param>
        /// <param name="myHiddenLayers">List carries the number of nodes in each layer</param>
        private void DoAllInitializations(int myInputElements, int myOutputElements, List<int> myHiddenLayers)
        {
            // Initialize the Node and Layers for the network
            this.Initialize_Nodes_Layers(myInputElements, myOutputElements, myHiddenLayers);

            // Set the forward directions, fully layers connected
            this.Initialize_forwrd_dir();

            // Calc FirstDerivative Direction from the Normal NodesDirections List
            this.Calc_bckwrd_dir();

            // Initialize Weights list by random values
            this.Initialize_Weights_List();
        }

        /// <summary>
        /// Initialize the Network, by defining all Nodes, and their static values, Layers, and forward Directions
        /// </summary>
        /// <param name="myInputElements">The number of input Elements in the network</param>
        /// <param name="myOutputElements">The number of output Elements in the network</param>
        /// <param name="myHiddenLayers">List carries the number of nodes in each layer</param>
        private void Initialize_Nodes_Layers(int myInputElements, int myOutputElements, List<int> myHiddenLayers)
        {
            int tmpID;
            Node tmpNode;
            List<Node> tmpLayer;

            int nodesCount = myInputElements + myOutputElements + myHiddenLayers.Sum();
            int layersCount = myHiddenLayers.Count + 2;

            // Create newList for nodes list
            this.nodes = new List<Node>(nodesCount);

            // Create the layers list
            this.layers = new List<List<Node>>((myHiddenLayers.Count + 2) * (int)myHiddenLayers.Average());

            // Create Layers and nodes
            tmpID = 0;
            for (int i = 0; i < layersCount; i++)
            {
                tmpLayer = new List<Node>();

                if (i == 0)
                {
                    for (int j = 0; j < myInputElements; j++)
                    {
                        // Create node here
                        tmpNode = new Node(tmpID++, NodeType.InputLayer);

                        this.nodes.Add(tmpNode);
                        tmpLayer.Add(tmpNode);
                    }
                }
                else if (i >= 1 && i <= layersCount - 2)
                {
                    for (int j = 0; j < myHiddenLayers[i - 1]; j++)
                    {
                        // Create node here
                        tmpNode = new Node(tmpID++, NodeType.HiddenLayer);

                        this.nodes.Add(tmpNode);
                        tmpLayer.Add(tmpNode);
                    }
                }
                else
                {
                    for (int j = 0; j < myOutputElements; j++)
                    {
                        // Create node here
                        tmpNode = new Node(tmpID++, NodeType.OutputLayer);

                        this.nodes.Add(tmpNode);
                        tmpLayer.Add(tmpNode);
                    }
                }

                this.layers.Add(tmpLayer);
            }
        }

        /// <summary>
        /// Initialize the Forward Directions List for all nodes
        /// </summary>
        private void Initialize_forwrd_dir()
        {
            // Create newList for forward Dir list
            this.forwrdDir = new List<List<Node>>(this.nodes.Count * 2);

            // Set forward direction based on the layers, for all layers except the output layer
            for (int i = 0; i < this.layers.Count - 1; i++)
            {
                // Foreach node in this layer
                for (int j = 0; j < this.layers[i].Count; j++)
                {
                    // Add the list of next Layer's nodes, to the forward direction list
                    this.forwrdDir.Add(this.layers[i + 1]);
                }
            }

            // Foreach node in the ouput layer, Add Empty List to the forward directions list
            for (int i = 0; i < this.OutputLayer.Count; i++)
            {
                this.forwrdDir.Add(new List<Node>());
            }
        }

        /// <summary>
        /// Calculate the backward direction for all nodes
        /// </summary>
        private void Calc_bckwrd_dir()
        {
            // Initialize the FirstDerivative List
            this.bckwrdDir = new List<List<Node>>(this.nodes.Count * this.nodes.Count);

            // Add empty List for the input layer
            this.bckwrdDir.Add(new List<Node>());

            // foreach layer
            for (int i = 0; i < this.layers.Count; i++)
            {
                // foreach node in this layer, add the nodes of the previous layer
                for (int j = 0; j < this.layers[i].Count; j++)
                {
                    // If input layer, add empty list
                    if (i == 0)
                    {
                        this.bckwrdDir.Add(new List<Node>());
                    }
                    else
                    {
                        this.bckwrdDir.Add(this.layers[i - 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the Weights List for all nodes
        /// </summary>
        private void Initialize_Weights_List()
        {
            Node tmpNode, tmpNextNode;

            // Initialize the 2D List for weights between nodes
            this.weights = new double[this.nodes.Count, this.nodes.Count];

            // Initialize weights for all nodes except the input layer nodes
            this.biasWeights = new double[this.nodes.Count];

            // foreach layer but the output layer
            for (int i = 0; i < this.layers.Count - 1; i++)
            {
                // foreach node in this layer
                for (int j = 0; j < this.layers[i].Count; j++)
                {
                    tmpNode = this.layers[i][j];

                    // Add Bias Weight, if this node isn't an input layer node
                    if (tmpNode.Type == NodeType.InputLayer)
                    {
                        this.biasWeights[tmpNode.ID] = 0;
                    }
                    else
                    {
                        this.biasWeights[tmpNode.ID] = GetRandomWeightValue();
                    }

                    // foreach node in the next layer, add random weight
                    for (int k = 0; k < this.layers[i + 1].Count; k++)
                    {
                        tmpNextNode = this.layers[i + 1][k];
                        this.weights[tmpNode.ID, tmpNextNode.ID] = GetRandomWeightValue();
                    }
                }
            }
        }

        #endregion Initializations
    }
}