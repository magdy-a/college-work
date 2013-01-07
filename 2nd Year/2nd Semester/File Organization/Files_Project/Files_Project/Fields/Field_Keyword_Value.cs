using System.IO;
using System.Windows.Forms;
namespace Files_Project{
    class Field_Keyword_Value{
        string ID, Name, Add;
        public int AddStudent(string FilePass, bool LengthIndicator){
            string Str = "ID=";
            ID = Str + Program.myForm.txtID.Text + '@';
            Str = "Name=";
            Name = Str + Program.myForm.txtName.Text + '@';
            Str = "Add=";
            Add = Str + Program.myForm.txtAdd.Text;
            Str = ID + Name + Add;
            if (LengthIndicator){
                string Indicator = "";
                Indicator += Program.intToString(Str.Length);
                Indicator += Str;
                Str = Indicator;}
            FileStream FS = new FileStream(FilePass, FileMode.Append);
            for (int i = 0; i < Str.Length; i++)
                FS.WriteByte((byte)Str[i]);
            FS.Close();
            Program.myForm.txtID.Clear();
            Program.myForm.txtName.Clear();
            Program.myForm.txtAdd.Clear();
            return Str.Length;}
        public void DisplayStudent(string Record, bool FixedFields){
            ID = "";
            Name = "";
            Add = "";
            if (!FixedFields){
                string[] Split = new string[3];
                Split = Record.Split('@');
                ID = Split[0].Remove(0, 3);
                Name = Split[1].Remove(0, 5);
                Add = Split[2].Remove(0, 4);
                ListViewItem L = new ListViewItem(ID);
                L.SubItems.Add(Name);
                L.SubItems.Add(Add);
                Program.myForm.listView1.Items.Add(L);
                return;}
            else{
                string Str = "";
                for (int i = 0; i < Record.Length; i++){
                    if (Record[i] != '@')
                        ID += Record[i];
                    else{
                        for (int j = i + 1; j < Record.Length; j++){
                            if (Record[j] != '@')
                                Name += Record[j];
                            else{
                                for (int k = j + 1; k < Record.Length; k++){
                                    if (Record[k] != '@')
                                        Add += Record[k];
                                    else{
                                        string newRecord = "";
                                        for (int f = k + 1; f < Record.Length; f++)
                                            newRecord += Record[f];
                                        for (int a = 3; a < ID.Length; a++)
                                            Str += ID[a];
                                        ListViewItem L = new ListViewItem(Str);
                                        Str = "";
                                        for (int b = 5; b < Name.Length; b++)
                                            Str += Name[b];
                                        L.SubItems.Add(Str);
                                        Str = "";
                                        for (int c = 4; c < Add.Length; c++)
                                            Str += Add[c];
                                        L.SubItems.Add(Str);
                                        Program.myForm.listView1.Items.Add(L);
                                        DisplayStudent(newRecord, FixedFields);
                                        return;}}}}}}}}}}