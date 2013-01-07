using System.IO;
namespace Files_Project{
    class Record_FixedFields{
        static public void FixedLengthField(char choice){
            string FilePass = "C:\\FixedFieldsRecord_FixedLengthField.txt";
            string Record = "";
            Field_FixedLength FixedLength_F = new Field_FixedLength();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    FixedLength_F.AddStudent(FilePass, false);
                    break;
                case '2':
                    Record = "";
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    for (int i = 0; i < FS.Length; i++)
                        Record += (char)FS.ReadByte();
                    if (Record != "")
                        FixedLength_F.DisplayStudent(Record, true);
                    FS.Close();
                    break;}}
        static public void DelimiterField(char choice){
            string FilePass = "C:\\FixedFieldsRecord_DelimiterField.txt";
            string Record = "";
            Field_Delimiter Delimiter_F = new Field_Delimiter();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    Delimiter_F.AddStudent(FilePass, false);
                    FileStream Fs = new FileStream(FilePass, FileMode.Append);
                    Fs.WriteByte((byte)'@');
                    Fs.Close();
                    break;
                case '2':
                    Record = "";
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    for (int i = 0; i < FS.Length; i++)
                        Record += (char)FS.ReadByte();
                    if (Record != "")
                        Delimiter_F.DisplayStudent(Record, true,0);
                    FS.Close();
                    break;}}
        static public void KeywordValueField(char choice){
            string FilePass = "C:\\FixedFieldsRecord_KeywordValueField.txt";
            string Record = "";
            Field_Keyword_Value KeywordValue_F = new Field_Keyword_Value();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    KeywordValue_F.AddStudent(FilePass, false);
                    FileStream Fs = new FileStream(FilePass, FileMode.Append);
                    Fs.WriteByte((byte)'@');
                    Fs.Close();
                    break;
                case '2':
                    Record = "";
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    for (int i = 0; i < FS.Length; i++)
                        Record += (char)FS.ReadByte();
                    if (Record != "")
                        KeywordValue_F.DisplayStudent(Record, true);
                    FS.Close();
                    break;}}
        static public void LengthIndicatorField(char choice){
            string FilePass = "C:\\FixedFieldsRecord_LengthIndicatorField.txt";
            string Record = "";
            Field_LengthIndicator LengthIndicator_F = new Field_LengthIndicator();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    LengthIndicator_F.AddStudent(FilePass, false);
                    break;
                case '2':
                    Record = "";
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    for (int i = 0; i < FS.Length; i++)
                        Record += (char)FS.ReadByte();
                    if (Record != "")
                        LengthIndicator_F.DisplayStudent(Record, true);
                    FS.Close();
                    break;}}}}