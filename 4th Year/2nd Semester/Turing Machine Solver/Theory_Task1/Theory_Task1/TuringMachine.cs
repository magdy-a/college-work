using System;
using System.Collections.Generic;

namespace Theory_Task1
{
    /// <summary>
    /// Turing Machine Class, carries the data for a standard TM, and generates tape
    /// </summary>
    public class TuringMachine
    {
        #region Members

        /// <summary>
        /// The separators between the input states and alphabet
        /// </summary>
        private const string separators = ",";

        public const char Left = 'L', Right = 'R', Stop = 'S', Fai = '∅';

        private List<int> states, finalStates;

        private int startState;

        private List<char> tapeAlphabet, inputAlphabet, tape;

        private string input;

        private List<Transition> trans;

        private List<List<List<Transition>>> table;

        #endregion Members

        public TuringMachine()
        {
            states = new List<int>();
            tapeAlphabet = new List<char>();
            inputAlphabet = new List<char>();
            startState = 0;
            finalStates = new List<int>();
            input = string.Empty;
            trans = new List<Transition>();

            // 2D array each element is an array, so total is 3D
            // First List will be the states
            // Second List will be the tapeAlphabet
            // Third List will be all transitions from this combination
            table = new List<List<List<Transition>>>();
        }

        #region Properties

        public List<int> States
        {
            get { return this.states; }
        }

        public List<char> InputAlphabet
        {
            get { return this.inputAlphabet; }
        }

        public List<char> TapeAlphabet
        {
            get { return this.tapeAlphabet; }
        }

        public List<int> FinalStates
        {
            get { return finalStates; }
            set { this.finalStates = value; }
        }

        public int StartState
        {
            get { return this.startState; }
            set { this.startState = value; }
        }

        public List<Transition> Trans
        {
            get { return trans; }
            set { trans = value; }
        }

        public List<char> Tape
        {
            get { return this.tape; }
        }

        public string Input
        {
            get { return this.input; }
            set { this.input = value; }
        }

        #endregion Properties

        #region Functions

        /// <summary>
        /// Sets the main values of the TuringMachine
        /// </summary>
        /// <param name="_states">States in this TM, separated by commas</param>
        /// <param name="_tapeAlphabet">tapeAlphabet in this TM, separated by commas</param>
        /// <param name="_inputAlphabet">inputAlphabet in this TM, separated by commas</param>
        public void Set_States_Alphabet(string _states, string _tapeAlphabet, string _inputAlphabet)
        {
            // Set States
            int tryInt = 0;
            foreach (string c in _states.Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                // TODO Check for duplicated numbers
                if (int.TryParse(c, out tryInt))
                {
                    this.states.Add(tryInt);
                }
            }

            // Set TapeAlphabet
            this.tapeAlphabet = new List<char>(_tapeAlphabet.ToCharArray());
            this.tapeAlphabet.RemoveAll(x => separators.CompareTo(x.ToString()) == 0);
            this.tapeAlphabet.Add(TuringMachine.Fai);
            // TODO Check for duplicated chars

            // Set InputAlphabet
            this.inputAlphabet = new List<char>(_inputAlphabet.ToCharArray());
            this.inputAlphabet.RemoveAll(x => separators.CompareTo(x.ToString()) == 0);
            // TODO Check for duplicated chars
            // TODO Check for any char that doesn't exist in the tapeAlphabet

            // Wrong Command !!!, but I need to know how it operates behind the scence, was going to remove duplicated chars
            //this.tapeAlphabet.RemoveAll(x => this.tapeAlphabet.FindAll(y => x.CompareTo(y) == 0).Count > 1);
        }

        /// <summary>
        /// Initializes the table of the transition with the alphabet
        /// </summary>
        public void CreateTable()
        {
            // Create Table
            foreach (int i in states)
            {
                this.table.Add(new List<List<Transition>>());
                foreach (char c in tapeAlphabet)
                {
                    this.table[this.table.Count - 1].Add(this.trans.FindAll(x => x.From.CompareTo(i) == 0 && x.Input.CompareTo(c) == 0));
                }
            }
        }

        /// <summary>
        ///  Solves the input, generates the tape
        /// </summary>
        /// <returns>boolean indicates whether if the input is isAccepted or not</returns>
        public bool Solve()
        {
            bool isAccepted = false;
            this.tape = new List<char>(this.input.ToCharArray());

            //if (this.tape.Count == 0)
            //{
            //    return isAccepted;
            //}

            int currentState = this.startState;

            // TODO If cursor reads and outOfIndex, u should make it empty char (' ')
            // TODO also if was removeing a char that was outOfIndex, don't do anything

            // My Stack
            List<Transition> options = new List<Transition>();

            // Just BullShit :(
            //while (!isAccepted && options != null && options.Count > 0)
            //{
            //}

            // Another BullShit :(:(
            //foreach (char c in tape)
            //{
            //    // Insert all the possible routes to the list of options
            //    options.InsertRange(0, this.table[currentState][this.GetCharIndex(c)]);

            //    if (options.Count > 0)
            //    {
            //        options.RemoveAt(0);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            options.InsertRange(0, this.table[currentState][this.GetCharIndex(tape[0])]);
            foreach (Transition t in options)
            {
                isAccepted = SolveRoute(tape, 0, t);

                if (isAccepted)
                {
                    break;
                }
            }

            return isAccepted;
        }

        private bool SolveRoute(List<char> _tape, int _tapeIndex, Transition _route)
        {
            bool IsAccepted = false;
            int _state;

            // I set them in new vars, cause in NonDeterministic, there may be more than one route, so I don't want to mess up the data
            List<char> newTape = new List<char>(_tape);
            int newTapeIndex = (_route.Cursor == TuringMachine.Left) ? _tapeIndex - 1 : (_route.Cursor == TuringMachine.Right) ? _tapeIndex + 1 : _tapeIndex;

            _state = _route.To;

            // If I am standing on a FinalState ... Done
            if (this.IsFinalState(_state))
            {
                IsAccepted = true;
                return IsAccepted;
            }

            if (_tapeIndex < 0 || _tapeIndex >= newTape.Count)
            {
            }
            newTape.RemoveAt(_tapeIndex);
            newTape.InsertRange(_tapeIndex, _route.Output.ToCharArray());

            List<Transition> _options = this.table[this.GetCharIndex(_route.Input)][this.GetStateIndex(_route.From)];

            foreach (Transition t in _options)
            {
                IsAccepted = SolveRoute(newTape, newTapeIndex, t);

                if (IsAccepted)
                {
                    break;
                }
            }

            return IsAccepted;
        }

        private char GetCharOnCursor(List<char> _tape, int _tapeIndex)
        {
            char c = '\0';

            if (_tapeIndex < 0 || _tapeIndex >= _tape.Count)
            {
                c = TuringMachine.Fai;
            }

            c = _tape[_tapeIndex];

            return c;
        }

        /// <summary>
        /// Check certain state if StartState or not
        /// </summary>
        /// <param name="_state">State num</param>
        /// <returns>boolean indicates whether this state is StartState or not</returns>
        private bool IsStartState(int _state)
        {
            bool returnValue = false;

            if (this.startState.CompareTo(_state) == 0)
            {
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Check certain state if FinalState or not
        /// </summary>
        /// <param name="_state">State num</param>
        /// <returns>boolean indicates whether this state is FinalState or not</returns>
        private bool IsFinalState(int _state)
        {
            bool returnValue = false;

            if (this.finalStates.Contains(_state))
            {
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Searches the list of states for the index of this state
        /// </summary>
        /// <param name="_state">State num</param>
        /// <returns>The index of this state, (-1) if doesn't exist</returns>
        private int GetStateIndex(int _state)
        {
            return this.states.IndexOf(_state);
        }

        /// <summary>
        /// Searches the list of tapeAlphabet for the index of the char
        /// </summary>
        /// <param name="_char">char I am looking for</param>
        /// <returns>The index of this char, (-1) if doesn't exist</returns>
        private int GetCharIndex(char _char)
        {
            return this.tapeAlphabet.IndexOf(_char);
        }

        #endregion Functions
    }
}