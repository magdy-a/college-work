using System.IO;
namespace Files_Project{
    class Record_FixedLength{
        static public void FixedLengthField(char choice){
            string FilePass = "C:\\FixedLengthRecord_FixedLengthField.txt";
            string Record = "";
            Field_FixedLength FixedLength_F = new Field_FixedLength();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    FixedLength_F.AddStudent(FilePass, false);
                    break;
                case '2':
                    byte[] ByteRecord = new byte[50];
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Record = "";
                        FS.Read(ByteRecord, 0, 50);
                        for (int i = 0; i < 50; i++)
                            Record += (char)ByteRecord[i];
                        if (Record != "")
                            FixedLength_F.DisplayStudent(Record, false);}
                    FS.Close();
                    break;}}
        static public void DelimiterField(char choice){
            string FilePass = "C:\\FixedLengthRecord_DelimiterField.txt";
            string Record = "";
            Field_Delimiter Delimiter_F = new Field_Delimiter();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    int Length;
                    Length = Delimiter_F.AddStudent(FilePass, false);
                    FileStream Fs = new FileStream(FilePass, FileMode.Append);
                    byte One = (byte)'\0';
                    for (int i = Length; i < 50; i++)
                        Fs.WriteByte(One);
                    Fs.Close();
                    break;
                case '2':
                    int Position = 0;
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Record += (char)FS.ReadByte();
                        Position++;
                        if (Position % 50 == 0 && Position != 0){
                            for (int i = 0; i < Record.Length; i++)
                                if (Record[i] == '\0'){
                                    Record.Remove(i);
                                    break;}
                            if (Record != "")
                                Delimiter_F.DisplayStudent(Record, false,0);
                            Record = "";
                            Position = 0;
                            continue;}}
                    FS.Close();
                    break;}}
        static public void KeywordValueField(char choice){
            string FilePass = "C:\\FixedLengthRecord_KeywordValueField.txt";
            string Record = "";
            Field_Keyword_Value KeywordValue_F = new Field_Keyword_Value();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    int Length;
                    Length = KeywordValue_F.AddStudent(FilePass, false);
                    FileStream Fs = new FileStream(FilePass, FileMode.Append);
                    byte One = (byte)'\0';
                    for (int i = Length; i < 50; i++)
                        Fs.WriteByte(One);
                    Fs.Close();
                    break;
                case '2':
                    int Position = 0;
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Record += (char)FS.ReadByte();
                        Position++;
                        if (Position % 50 == 0 && Position != 0){
                            for (int i = 0; i < Record.Length; i++)
                                if (Record[i] == '\0'){
                                    Record.Remove(i);
                                    break;}
                            if (Record != "")
                                KeywordValue_F.DisplayStudent(Record, false);
                            Record = "";
                            Position = 0;
                            continue;}}
                    FS.Close();
                    break;
            }}
        static public void LengthIndicatorField(char choice){
            string FilePass = "C:\\FixedLengthRecord_LengthIndicatorField.txt";
            string Record = "";
            Field_LengthIndicator LengthIndicator_F = new Field_LengthIndicator();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    int Length;
                    Length = LengthIndicator_F.AddStudent(FilePass, false);
                    FileStream Fs = new FileStream(FilePass, FileMode.Append);
                    byte One = (byte)'\0';
                    for (int i = Length; i < 50; i++)
                        Fs.WriteByte(One);
                    Fs.Close();
                    break;
                case '2':
                    int Position = 0;
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Record += (char)FS.ReadByte();
                        Position++;
                        if (Position % 50 == 0){
                            for (int i = 0; i < Record.Length; i++)
                                if (Record[i] == '\0'){
                                    Record.Remove(i);
                                    break;}
                            if (Record != "")
                                LengthIndicator_F.DisplayStudent(Record, false);
                            Record = "";
                            Position = 0;
                            continue;}}
                    FS.Close();
                    break;}}}}