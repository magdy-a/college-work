namespace Scanner
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Scanner Class, it scans the Tokens in the fileCode, checks if it available
    /// </summary>
    public class Scanner
    {
        #region Static Members

        /// <summary>
        /// Separators which they are: Space, newLine, with the (maybe \r), and Tab \t
        /// </summary>
        private static List<char> separators = new List<char>(new char[] { ' ', '\r', '\n', '\t' });

        /// <summary>
        /// The Splitter I use to split MutliCharSymbols
        /// </summary>
        private static string multiCharSymbolSplitter = "___";

        #endregion Static Members

        #region Members

        /// <summary>
        /// The Code to Scan, User Input
        /// </summary>
        private string fileCode;

        /// <summary>
        /// Generated Token List, from Code
        /// </summary>
        private List<Token> generatedTokens;

        #endregion Members

        /// <summary>
        /// Initializes a new instance of the Scanner class
        /// </summary>
        public Scanner()
        {
            // Create an instance of generatedTokens List
            this.generatedTokens = new List<Token>();
        }

        #region Properties

        /// <summary>
        /// Gets Separators which they are: Space, newLine, with the (maybe \r), and Tab \t
        /// </summary>
        public static List<char> Separators
        {
            get { return Scanner.separators; }
        }

        /// <summary>
        /// Gets or sets Tiny C Code
        /// </summary>
        public string FileCode
        {
            get { return this.fileCode; }
            set { this.fileCode = value; }
        }

        /// <summary>
        /// Gets Generated Token List, from Code
        /// </summary>
        public List<Token> GeneratedTokens
        {
            get { return this.generatedTokens; }
        }

        #endregion Properties

        /// <summary>
        /// RunEvents the Scanner through the code
        /// </summary>
        public void Run()
        {
            // Create string Array for the GeneratedTokens
            string[] strTokens;

            // Create a tmp File Code
            string tmpFileCode = this.fileCode;

            // Clear the generatedTokens List
            this.generatedTokens.Clear();

            // If Code was Empty, return
            if (tmpFileCode == string.Empty)
            {
                return;
            }

            // Loop for Multi Char Symbols first, to Set Special Case is MutliChar Found
            foreach (string s in Token.MultiChatSpecialSymbols)
            {
                tmpFileCode = tmpFileCode.Replace(s, s[0] + multiCharSymbolSplitter + s[1]);
            }

            // Loop Always Single Symbols, to be splitted
            foreach (string s in Token.AlwaysSingleCharSpecialSymbols)
            {
                tmpFileCode = tmpFileCode.Replace(s, ' ' + s + ' ');
            }

            // Loop Ambiguous Single Char Symbols to be splitted
            foreach (string s in Token.AmbigousSingleCharSpecialSymbols)
            {
                tmpFileCode = tmpFileCode.Replace(s, ' ' + s + ' ');
            }

            // Set MultiChat with Spaces on both Side to empty
            tmpFileCode = tmpFileCode.Replace(" " + multiCharSymbolSplitter + " ", string.Empty);

            // Then do the same with the Right (Or Left, doesn't really matter now) Splitter Space
            tmpFileCode = tmpFileCode.Replace(multiCharSymbolSplitter + " ", string.Empty);

            // Now to the Left Splitter Space
            tmpFileCode = tmpFileCode.Replace(" " + multiCharSymbolSplitter, string.Empty);

            // Get All Tokens
            strTokens = tmpFileCode.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            // If there was no Tokens, return
            if (strTokens.Length == 0)
            {
                return;
            }

            // Loop Tokens
            foreach (string tok in strTokens)
            {
                // Identify Each of them
                this.generatedTokens.Add(Token.Identify(tok));
            }

            // TODO I'll But the EndFile here as temp solution, Alaa Knows it :)
            // this.generatedTokens.Add(Token.GetToken(TokenType.EndFile));
        }
    }
}