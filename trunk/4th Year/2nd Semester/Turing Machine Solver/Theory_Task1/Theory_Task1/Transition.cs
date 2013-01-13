using System.Windows.Forms;

namespace Theory_Task1
{
    /// <summary>
    /// Transition State : defines the parameters for a transition state
    /// </summary>
    public class Transition
    {
        #region Members

        private int from, to;

        private char input, cursor;

        private string output;

        #endregion Members

        public Transition()
        {
            from = to = 0;
            input = cursor = '\0';
            output = string.Empty;
        }

        public Transition(int _from, int _to, char _input, char _cursor, string _output)
        {
            this.SetTransition(_from, _to, _input, _cursor, _output);
        }

        #region Properties

        public int To
        {
            get { return to; }
            set { to = value; }
        }

        public int From
        {
            get { return from; }
            set { from = value; }
        }

        public char Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }

        public char Input
        {
            get { return input; }
            set { input = value; }
        }

        public string Output
        {
            get { return output; }
            set { output = value; }
        }

        #endregion Properties

        public void SetTransition(int _from, int _to, char _input, char _cursor, string _output)
        {
            this.from = _from;
            this.to = _to;
            this.input = _input;
            this.cursor = _cursor;
            this.output = _output;
        }

        public override bool Equals(object obj)
        {
            Transition other = (Transition)obj;
            bool returnValue = false;
            if (this.from == other.from &&
                this.to == other.to &&
                this.input.CompareTo(other.input) == 0 &&
                this.cursor.CompareTo(other.cursor) == 0 &&
                this.output.CompareTo(other.output) == 0
                )
            {
                returnValue = true;
            }

            return returnValue;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            //return string.Format("σ(q{0}, {1}) ==> σ(q{2}, {3}, {4})", this.from, (this.input.CompareTo(TuringMachine.Space) == 0) ? TuringMachine.Fai : this.input, this.to, this.output.Replace(TuringMachine.Space, '∅'), this.cursor);
            return string.Format("σ(q{0}, {1}) ==> σ(q{2}, {3}, {4})", this.from, this.input, this.to, this.output, this.cursor);
        }

        public ListViewItem ToListViewItem()
        {
            ListViewItem item = new ListViewItem(this.from.ToString());
            item.SubItems.AddRange(new string[] { this.input.ToString(), this.to.ToString(), this.output, this.cursor.ToString() });
            return item;
        }
    }
}