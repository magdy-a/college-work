using System.IO;
using System.Windows.Forms;
namespace Files_Project{
    class Field_FixedLength{
        string ID, Name, Add;
        int ID_Len = 5;
        int Name_Len = 20;
        int Add_Len = 25;
        public int AddStudent(string FilePass, bool LengthIndicator){
            string Record = "";
            if (LengthIndicator)
                Record += Program.intToString(50);
            Record += Program.myForm.txtID.Text.PadRight(ID_Len);
            Record += Program.myForm.txtName.Text.PadRight(Name_Len);
            Record += Program.myForm.txtAdd.Text.PadRight(Add_Len);
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
            for (int i = 0; i < 5; i++)
                if (Record[i] != '\0')
                    ID += Record[i];
                else
                    break;
            for (int i = 5; i < 25; i++)
                if (Record[i] != '\0')
                    Name += Record[i];
                else
                    break;
            for (int i = 25; i < 50; i++)
                if (Record[i] != '\0')
                    Add += Record[i];
                else
                    break;
            ListViewItem L = new ListViewItem(ID);
            L.SubItems.Add(Name);
            L.SubItems.Add(Add);
            Program.myForm.listView1.Items.Add(L);
            string newRecord = "";
            for (int i = 50; i < Record.Length; i++)
                newRecord += Record[i];
            if (FixedFields && newRecord.Length > 0)
                DisplayStudent(newRecord, FixedFields);}}}