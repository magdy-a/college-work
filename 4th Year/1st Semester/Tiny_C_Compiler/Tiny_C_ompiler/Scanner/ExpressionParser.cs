namespace Scanner
{
    /// <summary>
    /// Expression Parser, Handle Parsing An Expression, Creating the tree, and Calculating the result
    /// </summary>
    public class ExpressionParser
    {
        /// <summary>
        /// The Parsing Tree
        /// </summary>
        private Node tree;

        /// <summary>
        /// The Expression to Create the parsing tree from
        /// </summary>
        private string expression;

        /// <summary>
        /// Initializes a new instance of the ExpressionParser class
        /// </summary>
        public ExpressionParser()
        {
        }

        /// <summary>
        /// Gets The Parsing Tree
        /// </summary>
        public Node Tree
        {
            get { return this.tree; }
        }

        /// <summary>
        /// Gets The Expression to Create the parsing tree from
        /// </summary>
        public string Expression
        {
            get { return this.expression; }
        }

        /// <summary>
        /// Creates the Parse Tree of the Expression
        /// </summary>
        /// <param name="exp">The Expression to make the parse tree to</param>
        public void Parse(string exp)
        {
            this.expression = exp;
            this.tree = new Node();
        }
    }
}