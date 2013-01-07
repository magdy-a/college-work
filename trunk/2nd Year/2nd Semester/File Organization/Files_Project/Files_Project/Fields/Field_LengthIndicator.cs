using System.IO;
using System.Windows.Forms;
namespace Files_Project{
    class Field_LengthIndicator{
        string ID, Name, Add;
        public int AddStudent(string FilePass, bool LengthIndicator){
            string Record = "";
            ID = Program.myForm.txtID.Text;
            Name = Program.myForm.txtName.Text;
            Add = Program.myForm.txtAdd.Text;
            Record += Program.intToString(ID.Length);
            Record += ID;
            Record += Program.intToString(Name.Length);
            Record += Name;
            Record += Program.intToString(Add.Length);
            Record += Add;
            if (LengthIndicator){
                string Indicator = "";
                Indicator += Program.intToString(Record.Length);
                Indicator += Record;
                Record = Indicator;}
            FileStream FS = new FileStream(FilePass, FileMode.Append);
            for (int i = 0; i < Record.Length; i++)
                FS.WriteByte((byte)Record[i]);
            FS.Close();
            Program.myForm.txtID.Clear();
            Program.myForm.txtName.Clear();
            Program.myForm.txtAdd.Clear();
            return Record.Length;}
        public void DisplayStudent(string Record, bool FixedFields){
            ID = "";
            Name = "";
            Add = "";
            char[] arr = new char[2];
            int Position = 0;
            int Length = 0;
            arr[0] = Record[Position++];
            arr[1] = Record[Position++];
            Length = Program.charArrToInt(arr);
            for (int i = Position; i < (Position + Length); i++)
                ID += Record[i];
            Position += Length;
            arr[0] = Record[Position++];
            arr[1] = Record[Position++];
            Length = Program.charArrToInt(arr);
            for (int i = Position; i < (Position + Length); i++)
                Name += Record[i];
            Position += Length;
            arr[0] = Record[Position++];
            arr[1] = Record[Position++];
            Length = Program.charArrToInt(arr);
            for (int i = Position; i < (Position + Length); i++)
                Add += Record[i];
            ListViewItem L = new ListViewItem(ID);
            L.SubItems.Add(Name);
            L.SubItems.Add(Add);
            Program.myForm.listView1.Items.Add(L);
            string newRecord = "";
            for (int i = Position + Length; i < Record.Length; i++)
                newRecord += Record[i];
            if (FixedFields && newRecord.Length > 0)
                DisplayStudent(newRecord, FixedFields);}}}