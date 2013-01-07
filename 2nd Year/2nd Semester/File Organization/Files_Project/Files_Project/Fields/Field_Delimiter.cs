using System.IO;
using System.Windows.Forms;
namespace Files_Project{
    class Field_Delimiter{
        string ID = "", Name = "", Add = "";
        public int AddStudent(string FilePass, bool LengthIndicator){
            string Record = "";
            ID = Program.myForm.txtID.Text;
            Name = Program.myForm.txtName.Text;
            Add = Program.myForm.txtAdd.Text;
            Record += ID + '@' + Name + '@' + Add;
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
        public string DisplayStudent(string Record, bool FixedFields,int Return){
            if (!FixedFields){
                string[] Split = new string[3];
                Split = Record.Split('@');
                ID = Split[0];
                Name = Split[1];
                Add = Split[2];
                string Str = "";
                for (int i = 0; i < Add.Length; i++)
                    if (Add[i] != '\0')
                        Str += Add[i];
                    else
                        break;
                Add = Str;
                ListViewItem L = new ListViewItem(ID);
                L.SubItems.Add(Name);
                L.SubItems.Add(Add);
                Program.myForm.listView1.Items.Add(L);
                return Split[Return];}
            else{
                ID = "";
                Name = "";
                Add = "";
                string[] Split = new string[3];
                for (int i = 0; i < Record.Length; i++){
                    if (Record[i] != '@'){
                        ID += Record[i];
                        Split[0] = ID;}
                    else{
                        for (int j = i + 1; j < Record.Length; j++){
                            if (Record[j] != '@'){
                                Name += Record[j];
                                Split[1] = Name;}
                            else{
                                for (int k = j + 1; k < Record.Length; k++){
                                    if (Record[k] != '@'){
                                        Add += Record[k];
                                        Split[2] = Add;}
                                    else{
                                        string newRecord = "";
                                        for (int f = k + 1; f < Record.Length; f++)
                                            newRecord += Record[f];
                                        ListViewItem L = new ListViewItem(ID);
                                        L.SubItems.Add(Name);
                                        L.SubItems.Add(Add);
                                        Program.myForm.listView1.Items.Add(L);
                                        DisplayStudent(newRecord, FixedFields, Return);
                                        return Split[Return];}}}}}}}return "";}}}