using System.IO;
namespace Files_Project{
    class Record_LengthIndicator{
        static public void FixedLengthField(char choice){
            string FilePass = "C:\\LengthIndicatorRecord_FixedLengthField.txt";
            string Record = "";
            Field_FixedLength FixedLength_F = new Field_FixedLength();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    FixedLength_F.AddStudent(FilePass, true);
                    break;
                case '2':
                    char[] arr = new char[2];
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Record = "";
                        arr[0] = (char)FS.ReadByte();
                        arr[1] = (char)FS.ReadByte();
                        for (int i = 0; i < Program.charArrToInt(arr); i++)
                            Record += (char)FS.ReadByte();
                        if (Record != "")
                            FixedLength_F.DisplayStudent(Record, false);}
                    FS.Close();
                    break;}}
        static public void DelimiterField(char choice){
            string FilePass = "C:\\LengthIndicatorRecord_DelimiterField.txt";
            string Record = "";
            Field_Delimiter Delimiter_F = new Field_Delimiter();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    Delimiter_F.AddStudent(FilePass, true);
                    break;
                case '2':
                    char[] arr = new char[2];
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Record = "";
                        arr[0] = (char)FS.ReadByte();
                        arr[1] = (char)FS.ReadByte();
                        for (int i = 0; i < Program.charArrToInt(arr); i++)
                            Record += (char)FS.ReadByte();
                        if (Record != "")
                            Delimiter_F.DisplayStudent(Record, false,0);}
                    FS.Close();
                    break;}}
        static public void KeywordValueField(char choice){
            string FilePass = "C:\\LengthIndicatorRecord_KeywordValueField.txt";
            string Record = "";
            Field_Keyword_Value KeywordValue_F = new Field_Keyword_Value();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    KeywordValue_F.AddStudent(FilePass, true);
                    break;
                case '2':
                    char[] arr = new char[2];
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Record = "";
                        arr[0] = (char)FS.ReadByte();
                        arr[1] = (char)FS.ReadByte();
                        for (int i = 0; i < Program.charArrToInt(arr); i++)
                            Record += (char)FS.ReadByte();
                        if (Record != "")
                            KeywordValue_F.DisplayStudent(Record, false);}
                    FS.Close();
                    break;}}
        static public void LengthIndicatorField(char choice){
            string FilePass = "C:\\LengthIndicatorRecord_LengthIndicatorField.txt";
            string Record = "";
            Field_LengthIndicator LengthIndicator_F = new Field_LengthIndicator();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    LengthIndicator_F.AddStudent(FilePass, true);
                    break;
                case '2':
                    char[] arr = new char[2];
                    FileStream FS = new FileStream(FilePass, FileMode.OpenOrCreate);
                    while (FS.Position != FS.Length){
                        Record = "";
                        arr[0] = (char)FS.ReadByte();
                        arr[1] = (char)FS.ReadByte();
                        for (int i = 0; i < Program.charArrToInt(arr); i++)
                            Record += (char)FS.ReadByte();
                        if (Record != "")
                            LengthIndicator_F.DisplayStudent(Record, false);}
                    FS.Close();
                    break;}}}}