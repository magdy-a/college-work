namespace Scanner
{
    using System.Collections.Generic;

    /// <summary>
    /// The Language Tokens
    /// </summary>
    public enum TokenType
    {
        #region Reserved Words

        /// <summary>
        /// If Condition, for conditional parts in the code
        /// </summary>
        If,

        /// <summary>
        /// Then (Just after the If Expression)
        /// </summary>
        Then,

        /// <summary>
        /// Else, May be attached to an If Condition, for the opposite Expression
        /// </summary>
        Else,

        /// <summary>
        /// Ends the If Codition's Code
        /// </summary>
        End,

        /// <summary>
        /// Repeat, to Repeat some statments
        /// </summary>
        Repeat,

        /// <summary>
        /// Limits the Repeat times in Repeat statment for a certain condition
        /// </summary>
        Until,

        /// <summary>
        /// Read, to Get an input from the User, in run time
        /// </summary>
        Read,

        /// <summary>
        /// Write, to Write Some: Expression or Identifier, Num, String, Or combination to the User, in run time
        /// </summary>
        Write,

        #endregion Reserved Words

        #region Special Symbols

        #region MultiChar Symbols

        /// <summary>
        /// Assign Operator, to set an Identifiers value
        /// </summary>
        Assign,

        /// <summary>
        /// Increment Operator, to Increment a Numbers's value
        /// </summary>
        Increment,

        /// <summary>
        /// Decrement Operator, to Decrement a Numbers's value
        /// </summary>
        Decrement,

        /// <summary>
        /// SelfMultiplication, Multiplies a Number's Values by another
        /// </summary>
        SelfMultiplication,

        /// <summary>
        /// SelfDivision, Divides a Number's Values by another
        /// </summary>
        SelfDivision,

        /// <summary>
        /// SelfAddition, Adds a Number's Values by another
        /// </summary>
        SelfAddition,

        /// <summary>
        /// SelfSubtraction, Subtracts a Number's Values by another
        /// </summary>
        SelfSubtraction,

        /// <summary>
        /// Less than Or Equal, ex: Conditional statements
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// Greater than Or Equal, ex: Conditional statements
        /// </summary>
        GreaterThanOrEqual,

        #endregion MultiChar Symbols

        #region Ambiguous Symbols

        /// <summary>
        /// Equality Condition, ex: Condition statements
        /// </summary>
        Equal,

        /// <summary>
        /// Less than, ex: Conditional statements
        /// </summary>
        LessThan,

        /// <summary>
        /// Greater than, ex: Conditional statements
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Plus Operator, ex: Expression generator
        /// </summary>
        Plus,

        /// <summary>
        /// Minus Operator, ex: Expression generator
        /// </summary>
        Minus,

        /// <summary>
        /// Multiplier Operator, ex: Expression generator
        /// </summary>
        Times,

        /// <summary>
        /// Multiplier Operator, ex: Expression generator
        /// </summary>
        Divide,

        #endregion Ambiguous Symbols

        #region Single Symbols

        /// <summary>
        /// Left Parentheses "(", to specify precedence end, ex: Expression generator
        /// </summary>
        LeftParentheses,

        /// <summary>
        /// Right Parentheses ")", to specify precedence end, ex: Expression generator
        /// </summary>
        RightParentheses,

        /// <summary>
        /// Semi Colon, to end most of the statements in the Language, except some Like (If & Repeat statements)
        /// </summary>
        SemiColon,

        #endregion Single Symbols

        #endregion Special Symbols

        #region Other

        /// <summary>
        /// Identifier, A Variable
        /// </summary>
        ID,

        /// <summary>
        /// Number, according to the number system
        /// </summary>
        Num,

        /// <summary>
        /// Comments on Code
        /// </summary>
        Comment,

        /// <summary>
        /// End Of File
        /// </summary>
        EndFile,

        #endregion Other

        #region Unknown

        /// <summary>
        /// A Token that the System don't Accept, or can't recogize
        /// </summary>
        Error,

        #endregion Unknown
    }

    /// <summary>
    /// The Categories the token can be included in
    /// </summary>
    public enum TokenCategory
    {
        /// <summary>
        /// Reserved Words, Like (While, If, ... etc)
        /// </summary>
        ReservedWord,

        /// <summary>
        /// Special Symbols, Like (Equal, Plu, ... etc)
        /// </summary>
        SpecialSymbol,

        /// <summary>
        /// Other Tokens, Like (Identifier, Number, Comment)
        /// </summary>
        Other,

        /// <summary>
        /// Unknown Token, Not in any of the other Category Types, Like if, it may be any token that is written wrong, or an illegal Identifier Name, or a Token the Language doesn't support.
        /// </summary>
        Unknown,
    }

    /// <summary>
    /// Token Values Class, the way you'll represent a Token from now, to the next task
    /// </summary>
    public class Token
    {
        // TODO Why not to take the Language's Tokens from an XML File, so when I want to Add a new Token I just add it the XML file
        //// Steps to Add a new Token
        //// 1- Add it the the TokenType Enum
        //// 2- Add it the Get Category Function to specify Category
        //// 3- Add it to it's String list in whether ReservedWords || SingleCharSpecialSymbols
        //// 4- Add it to the GetTokens() Functions, to Add an object from it in program startup

        #region Attributes

        /// <summary>
        /// Array contains the reserved Words
        /// </summary>
        private static List<string> reservedWords = new List<string>(new string[] { "if", "then", "else", "end", "repeat", "until", "read", "write" });

        /// <summary>
        /// Array contains the Always SingleSpecial Symbols
        /// </summary>
        private static List<string> alwaysSingleCharSpecialSymbols = new List<string>(new string[] { "(", ")", ";" });

        /// <summary>
        /// Array contains the Ambiguous SingleSpecial Symbols
        /// </summary>
        private static List<string> ambiguousSingleCharSpecialSymbols = new List<string>(new string[] { "+", "-", "*", "/", "=", "<", ">" });

        /// <summary>
        /// Array contains the MultiSpecial Symbols
        /// </summary>
        private static List<string> multiChatSpecialSymbols = new List<string>(new string[] { ":=", "++", "--", "*=", "/=", "+=", "-=", "<=", ">=" });

        /// <summary>
        /// Token Value List
        /// </summary>
        private static List<Token> tokens = GetToknes();

        /// <summary>
        /// The Token it self
        /// </summary>
        private string tokenRepresentation;

        /// <summary>
        /// Token name, like representation and stuff
        /// </summary>
        private TokenType name;

        /// <summary>
        /// Token Category
        /// </summary>
        private TokenCategory category;

        #endregion Attributes

        /// <summary>
        /// Initializes a new instance of the Token class
        /// </summary>
        /// <param name="representation">The String of the Token</param>
        /// <param name="type">The Type of it</param>
        public Token(string representation, TokenType type)
        {
            // Assign Values
            this.tokenRepresentation = representation;
            this.name = type;

            // Get Category
            this.category = GetCategory(type);
        }

        /// <summary>
        /// Initializes a new instance of the Token class
        /// </summary>
        /// <param name="representation">The String of the Token</param>
        /// <param name="type">The Type of The Token</param>
        /// <param name="cate">The Category of the Token</param>
        public Token(string representation, TokenType type, TokenCategory cate)
        {
            // Assign Values
            this.tokenRepresentation = representation;
            this.name = type;
            this.category = cate;
        }

        #region Properties

        /// <summary>
        /// Gets the List of Tokens after being filled
        /// </summary>
        public static List<Token> Tokens
        {
            get { return tokens; }
        }

        /// <summary>
        /// Gets the Array that contains the reserved Words
        /// </summary>
        public static List<string> ReservedWord
        {
            get { return Token.reservedWords; }
        }

        /// <summary>
        /// Gets Array contains the Always SingleSpecial Symbols
        /// </summary>
        public static List<string> AlwaysSingleCharSpecialSymbols
        {
            get { return Token.alwaysSingleCharSpecialSymbols; }
        }

        /// <summary>
        /// Gets Array contains the Ambiguous SingleSpecial Symbols
        /// </summary>
        public static List<string> AmbigousSingleCharSpecialSymbols
        {
            get { return Token.ambiguousSingleCharSpecialSymbols; }
        }

        /// <summary>
        /// Gets Array contains the MultiSpecial Symbols
        /// </summary>
        public static List<string> MultiChatSpecialSymbols
        {
            get { return Token.multiChatSpecialSymbols; }
        }

        /// <summary>
        /// Gets or sets The Token it self
        /// </summary>
        public string TokenRepresenation
        {
            get { return this.tokenRepresentation; }
            set { this.tokenRepresentation = value; }
        }

        /// <summary>
        /// Gets or sets Token name, like representation and stuff
        /// </summary>
        public TokenType Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets Token Category
        /// </summary>
        public TokenCategory Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        #endregion Properties

        /// <summary>
        /// Identify certain Token
        /// </summary>
        /// <param name="tok">Token String</param>
        /// <returns>Token as Identified or Not</returns>
        public static Token Identify(string tok)
        {
            Token tmpToken;
            if (reservedWords.Contains(tok.ToLower()) == true)
            {
                // Reserved Words
                tmpToken = GetToken(tok);
                tmpToken.tokenRepresentation.ToUpper();
                return tmpToken;
            }
            else if (alwaysSingleCharSpecialSymbols.Contains(tok) == true || ambiguousSingleCharSpecialSymbols.Contains(tok) == true || multiChatSpecialSymbols.Contains(tok) == true)
            {
                // Special Symbols
                return GetToken(tok);
            }
            else if (CheckIfNumber(tok) == true)
            {
                // Other ... Number
                return new Token(tok, TokenType.Num, TokenCategory.Other);
            }
            else if (CheckIfIdentifier(tok) == true)
            {
                // Other ... Number
                return new Token(tok, TokenType.ID, TokenCategory.Other);
            }
            else
            {
                // Unknown
                return new Token(tok, TokenType.Error, TokenCategory.Unknown);
            }

            // TODO Check for User's Comments
        }

        /// <summary>
        /// Searches the Tokens for the Specified String, in a Specified Category
        /// </summary>
        /// <param name="tok">String of a Token</param>
        /// <returns>Type of Token</returns>
        public static Token GetToken(string tok)
        {
            foreach (Token element in tokens)
            {
                if (element.tokenRepresentation.ToLower().CompareTo(tok.ToLower()) == 0)
                {
                    return element;
                }
            }

            return new Token("Can't be found", TokenType.Error);
        }

        /// <summary>
        /// Searches the Tokens for the Specified String, in a Specified Category
        /// </summary>
        /// <param name="type">The Type of the Token</param>
        /// <returns>Type of Token</returns>
        public static Token GetToken(TokenType type)
        {
            foreach (Token element in tokens)
            {
                if (element.name == type)
                {
                    return element;
                }
            }

            return new Token("UnIdentified", TokenType.Error);
        }

        #region Private Static Functions

        /// <summary>
        /// Gets the Tokens of the Language
        /// </summary>
        /// <returns>The List of Tokens</returns>
        private static List<Token> GetToknes()
        {
            // Create a List
            List<Token> tinyCTokens = new List<Token>();

            // Reserved Words
            tinyCTokens.Add(new Token("If", TokenType.If));
            tinyCTokens.Add(new Token("Then", TokenType.Then));
            tinyCTokens.Add(new Token("Else", TokenType.Else));
            tinyCTokens.Add(new Token("End", TokenType.End));
            tinyCTokens.Add(new Token("Repeat", TokenType.Repeat));
            tinyCTokens.Add(new Token("Until", TokenType.Until));
            tinyCTokens.Add(new Token("Read", TokenType.Read));
            tinyCTokens.Add(new Token("Write", TokenType.Write));

            // Specials
            // MultiChar Symbols
            tinyCTokens.Add(new Token(":=", TokenType.Assign));
            tinyCTokens.Add(new Token("++", TokenType.Increment));
            tinyCTokens.Add(new Token("--", TokenType.Decrement));
            tinyCTokens.Add(new Token("*=", TokenType.SelfMultiplication));
            tinyCTokens.Add(new Token("/=", TokenType.SelfDivision));
            tinyCTokens.Add(new Token("+=", TokenType.SelfAddition));
            tinyCTokens.Add(new Token("-=", TokenType.SelfSubtraction));
            tinyCTokens.Add(new Token("<=", TokenType.LessThanOrEqual));
            tinyCTokens.Add(new Token(">=", TokenType.GreaterThanOrEqual));

            // Ambiguous Symbols
            tinyCTokens.Add(new Token("+", TokenType.Plus));
            tinyCTokens.Add(new Token("-", TokenType.Minus));
            tinyCTokens.Add(new Token("*", TokenType.Times));
            tinyCTokens.Add(new Token("/", TokenType.Divide));
            tinyCTokens.Add(new Token("=", TokenType.Equal));
            tinyCTokens.Add(new Token("<", TokenType.LessThan));
            tinyCTokens.Add(new Token(">", TokenType.GreaterThan));

            // Single Symbols
            tinyCTokens.Add(new Token("(", TokenType.LeftParentheses));
            tinyCTokens.Add(new Token(")", TokenType.RightParentheses));
            tinyCTokens.Add(new Token(";", TokenType.SemiColon));

            // Others
            tinyCTokens.Add(new Token(string.Empty, TokenType.Num));
            tinyCTokens.Add(new Token(string.Empty, TokenType.ID));
            tinyCTokens.Add(new Token(string.Empty, TokenType.Comment));
            tinyCTokens.Add(new Token("End_Of_File", TokenType.EndFile, TokenCategory.Other));

            // Return Data
            return tinyCTokens;
        }

        /// <summary>
        /// Check if a given string is a number or Not
        /// </summary>
        /// <param name="tok">String to Check</param>
        /// <returns>Boolean indication of being a number</returns>
        private static bool CheckIfNumber(string tok)
        {
            // TODO Why not to accept Floats ??
            int dummy;

            return int.TryParse(tok, out dummy);
        }

        /// <summary>
        /// Check if a Given string is a valid Identifier
        /// </summary>
        /// <param name="tok">String to Check</param>
        /// <returns>Boolean indication of being a valid Identifier or not</returns>
        private static bool CheckIfIdentifier(string tok)
        {
            // Check for First Char (Normal State Only) from a:z & A:Z & _
            if ((tok[0] >= 'a' && tok[0] <= 'z') || (tok[0] >= 'A' && tok[0] <= 'Z') || tok[0] == '_')
            {
                // I Did Pass the First Phase

                // Check for All the Chars, I am sure that first char is good, must contain the legal chars
                foreach (char c in tok)
                {
                    // Check for all next chars, (Normal State + Numbers) from a:z & A:Z & _ & 0:9
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_' || (c >= '0' && c <= '9'))
                    {
                        // Char Accepted, and continue to the next char
                    }
                    else
                    {
                        // Char Rejected, char violation error
                        return false;
                    }
                }

                // If Passes Successfully, you made it through Second Phase
                return true;
            }
            else
            {
                // If Didn't Pass First Phase
                return false;
            }
        }

        /// <summary>
        /// Get the Category of certain TokenType
        /// </summary>
        /// <param name="type">Token Type</param>
        /// <returns>It Category</returns>
        private static TokenCategory GetCategory(TokenType type)
        {
            switch (type)
            {
                // Reserved Words
                case TokenType.If:
                case TokenType.Then:
                case TokenType.Else:
                case TokenType.End:
                case TokenType.Repeat:
                case TokenType.Until:
                case TokenType.Read:
                case TokenType.Write:
                    return TokenCategory.ReservedWord;

                // Special Symbols
                // MultiChar Symbols
                case TokenType.Assign:
                case TokenType.Increment:
                case TokenType.Decrement:
                case TokenType.SelfMultiplication:
                case TokenType.SelfDivision:
                case TokenType.SelfAddition:
                case TokenType.SelfSubtraction:
                case TokenType.LessThanOrEqual:
                case TokenType.GreaterThanOrEqual:

                // Ambiguous Symbols
                case TokenType.Plus:
                case TokenType.Minus:
                case TokenType.Times:
                case TokenType.Divide:
                case TokenType.Equal:
                case TokenType.LessThan:
                case TokenType.GreaterThan:

                // Single Symbols
                case TokenType.LeftParentheses:
                case TokenType.RightParentheses:
                case TokenType.SemiColon:
                    return TokenCategory.SpecialSymbol;

                // Other
                case TokenType.Num:
                case TokenType.ID:
                case TokenType.Comment:
                case TokenType.EndFile:
                    return TokenCategory.Other;

                default:
                    // TODO Check Again
                    // Includes
                    // case TokenType.Error:
                    return TokenCategory.Unknown;
            }
        }

        #endregion Private Static Functions

        // TODO Make the HighLighting in the Code Box activeColor, so that you highlight the equivilant List View
        // TODO Resize the Columns of the ListView as you Resize the Form
        // TODO Use shortcuts like (ctrl + (O Open, S Save), Alt + (Enter FullScreen))
        // TODO Make the Indicies of the Tokens a list in the scanner, so that you can acess them easier, and it would be better for the performance
        // TODO Create a Status bar, It will make the form more professional
    }
}