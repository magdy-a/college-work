using System.IO;
namespace Files_Project{
    class Record_Delimiter{
        static public void FixedLengthField(char choice){
            string FilePass = "C:\\DelimiterRecord_FixedLengthField.txt";
            string Record = "";
            Field_FixedLength FixedLength_F = new Field_FixedLength();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    byte Delimiter = (byte)'#';
                    FixedLength_F.AddStudent(FilePass, false);
                    FileStream Fs = new FileStream(FilePass, FileMode.Append);
                    Fs.WriteByte(Delimiter);
                    Fs.Close();
                    break;
                case '2':
                    int Position = 0;
                    char Character;
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Character = (char)FS.ReadByte();
                        if (Character == '#'){
                            if (Record != "")
                                FixedLength_F.DisplayStudent(Record, false);
                            Record = "";
                            Position = 0;
                            continue;}
                        Record += Character;
                        Position++;}
                    FS.Close();
                    break;}}
        static public void DelimiterField(char choice){
            string FilePass = "C:\\DelimiterRecord_DelimiterField.txt";
            string Record = "";
            Field_Delimiter Delimiter_F = new Field_Delimiter();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    byte Delimiter = (byte)'#';
                    Delimiter_F.AddStudent(FilePass, false);
                    FileStream Fs = new FileStream(FilePass, FileMode.Append);
                    Fs.WriteByte(Delimiter);
                    Fs.Close();
                    break;
                case '2':
                    int Position = 0;
                    char Character;
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Character = (char)FS.ReadByte();
                        if (Character == '#'){
                            if (Record != "")
                                Delimiter_F.DisplayStudent(Record, false,0);
                            Record = "";
                            Position = 0;
                            continue;}
                        Record += Character;
                        Position++;}
                    FS.Close();
                    break;}}
        static public void KeywordValueField(char choice){
            string FilePass = "C:\\DelimiterRecord_KeywordValueField.txt";
            string Record = "";
            Field_Keyword_Value KeywordValue_F = new Field_Keyword_Value();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    byte Delimiter = (byte)'#';
                    KeywordValue_F.AddStudent(FilePass, false);
                    FileStream Fs = new FileStream(FilePass, FileMode.Append);
                    Fs.WriteByte(Delimiter);
                    Fs.Close();
                    break;
                case '2':
                    int Position = 0;
                    char Character;
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Character = (char)FS.ReadByte();
                        if (Character == '#'){
                            if (Record != "")
                                KeywordValue_F.DisplayStudent(Record, false);
                            Record = "";
                            Position = 0;
                            continue;}
                        Record += Character;
                        Position++;}
                    FS.Close();
                    break;}}
        static public void LengthIndicatorField(char choice){
            string FilePass = "C:\\DelimiterRecord_LengthIndicatorField.txt";
            string Record = "";
            Field_LengthIndicator LengthIndicator_F = new Field_LengthIndicator();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    byte Delimiter = (byte)'#';
                    LengthIndicator_F.AddStudent(FilePass, false);
                    FileStream Fs = new FileStream(FilePass, FileMode.Append);
                    Fs.WriteByte(Delimiter);
                    Fs.Close();
                    break;
                case '2':
                    int Position = 0;
                    char Character;
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Character = (char)FS.ReadByte();
                        if (Character == '#'){
                            if (Record != "")
                                LengthIndicator_F.DisplayStudent(Record, false);
                            Record = "";
                            Position = 0;
                            continue;}
                        Record += Character;
                        Position++;}
                    FS.Close();
                    break;}}}}