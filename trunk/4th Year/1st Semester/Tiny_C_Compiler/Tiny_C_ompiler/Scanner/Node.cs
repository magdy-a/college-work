namespace Scanner
{
    /// <summary>
    /// Contains the Types the Node could be
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// Number, to the numbering system of the language
        /// </summary>
        Num,

        /// <summary>
        /// Plus Operator
        /// </summary>
        Plus,

        /// <summary>
        /// Minus Operator
        /// </summary>
        Minus,

        /// <summary>
        /// Multiply Operator
        /// </summary>
        Times,

        /// <summary>
        /// Divide Operator
        /// </summary>
        Divide,
    }

    /// <summary>
    /// The Node Class, Will be the Point in the Parsing Tree
    /// </summary>
    public class Node
    {
        #region Attributes

        /// <summary>
        /// Node's Left Node
        /// </summary>
        private Node left;

        /// <summary>
        /// Node's Value
        /// </summary>
        private int value;

        /// <summary>
        /// Node's Type
        /// </summary>
        private NodeType type;

        /// <summary>
        /// Node's Right Node
        /// </summary>
        private Node right;

        #endregion Attributes

        /// <summary>
        /// Initializes a new instance of the Node class
        /// </summary>
        public Node()
        {
            this.left = null;
            this.right = null;
            this.type = NodeType.Num;
            this.value = 0;
        }

        /// <summary>
        /// Initializes a new instance of the Node class
        /// </summary>
        /// <param name="ty">Initial Node Type</param>
        public Node(NodeType ty)
        {
            this.left = null;
            this.right = null;
            this.type = ty;
        }

        #region Properties

        /// <summary>
        /// Gets Node's Left Node
        /// </summary>
        public Node Left
        {
            get { return this.left; }
        }

        /// <summary>
        /// Gets Node's Value
        /// </summary>
        public int Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// Gets Node's Type
        /// </summary>
        public NodeType Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// Gets Node's Right Node
        /// </summary>
        public Node Right
        {
            get { return this.right; }
        }

        #endregion Properties
    }
}