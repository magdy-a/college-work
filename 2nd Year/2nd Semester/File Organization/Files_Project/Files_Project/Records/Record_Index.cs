using System.IO;
namespace Files_Project{
    class Record_Index{
        static public void FixedLengthField(char choice){
            string FilePass = "C:\\IndexRecord_FixedLengthField.txt";
            string IndexPass = "C:\\IndexRecord_FixedLengthField_Index.txt";
            string Record = "";
            Field_FixedLength FixedLength_F = new Field_FixedLength();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    FileStream Data = new FileStream(FilePass, FileMode.Append);
                    FileStream Index = new FileStream(IndexPass, FileMode.Append);
                    Index.WriteByte((byte)Data.Length);
                    Data.Close();
                    Index.Close();
                    FixedLength_F.AddStudent(FilePass, false);
                    break;
                case '2':
                    FileStream IndexTxt = new FileStream(IndexPass, FileMode.OpenOrCreate);
                    FileStream DataTxt = new FileStream(FilePass, FileMode.OpenOrCreate);
                    long[] Positions = new long[100];
                    int x = 0;
                    while (IndexTxt.Position != IndexTxt.Length)
                        Positions[x++] = IndexTxt.ReadByte();
                    for (int i = 0; i < IndexTxt.Length - 1; i++){
                        Record = "";
                        for (int j = 0; j < (Positions[i + 1] - Positions[i]); j++)
                            Record += (char)DataTxt.ReadByte();
                        if(Record != "")
                            FixedLength_F.DisplayStudent(Record, false);}
                    Record = "";
                    while (DataTxt.Position != DataTxt.Length)
                        Record += (char)DataTxt.ReadByte();
                    if(Record != "")
                        FixedLength_F.DisplayStudent(Record, false);

                    IndexTxt.Close();
                    DataTxt.Close();
                    break;}}
        static public void DelimiterField(char choice){
            string FilePass = "C:\\IndexRecord_DelimiterhField.txt";
            string IndexPass = "C:\\IndexRecord_DelimiterField_Index.txt";
            string Record = "";
            Field_Delimiter Delimiter_F = new Field_Delimiter();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    FileStream Data = new FileStream(FilePass, FileMode.Append);
                    FileStream Index = new FileStream(IndexPass, FileMode.Append);
                    Index.WriteByte((byte)Data.Length);
                    Data.Close();
                    Index.Close();
                    Delimiter_F.AddStudent(FilePass, false);
                    break;
                case '2':
                    FileStream IndexTxt = new FileStream(IndexPass, FileMode.OpenOrCreate);
                    FileStream DataTxt = new FileStream(FilePass, FileMode.OpenOrCreate);

                    long[] Positions = new long[100];
                    int x = 0;
                    while (IndexTxt.Position != IndexTxt.Length)
                        Positions[x++] = IndexTxt.ReadByte();
                    for (int i = 0; i < IndexTxt.Length - 1; i++){
                        Record = "";
                        for (int j = 0; j < (Positions[i + 1] - Positions[i]); j++)
                            Record += (char)DataTxt.ReadByte();
                        if(Record != "")
                            Delimiter_F.DisplayStudent(Record, false,0);}
                    Record = "";
                    while (DataTxt.Position != DataTxt.Length)
                        Record += (char)DataTxt.ReadByte();
                    if (Record != "")
                        Delimiter_F.DisplayStudent(Record, false,0);
                    IndexTxt.Close();
                    DataTxt.Close();
                    break;}}
        static public void KeywordValueField(char choice){
            string FilePass = "C:\\IndexRecord_KeywordValueField.txt";
            string IndexPass = "C:\\IndexRecord_KeywordValueField_Index.txt";
            string Record = "";
            Field_Keyword_Value KeywordValue_F = new Field_Keyword_Value();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    FileStream Data = new FileStream(FilePass, FileMode.Append);
                    FileStream Index = new FileStream(IndexPass, FileMode.Append);
                    Index.WriteByte((byte)Data.Length);
                    Data.Close();
                    Index.Close();
                    KeywordValue_F.AddStudent(FilePass, false);
                    break;
                case '2':
                    FileStream IndexTxt = new FileStream(IndexPass, FileMode.OpenOrCreate);
                    FileStream DataTxt = new FileStream(FilePass, FileMode.OpenOrCreate);
                    long[] Positions = new long[100];
                    int x = 0;
                    while (IndexTxt.Position != IndexTxt.Length)
                        Positions[x++] = IndexTxt.ReadByte();
                    for (int i = 0; i < IndexTxt.Length - 1; i++){
                        Record = "";
                        for (int j = 0; j < (Positions[i + 1] - Positions[i]); j++)
                            Record += (char)DataTxt.ReadByte();
                        if (Record != "")
                            KeywordValue_F.DisplayStudent(Record, false);}
                    Record = "";
                    while (DataTxt.Position != DataTxt.Length)
                        Record += (char)DataTxt.ReadByte();
                    if (Record != "")
                        KeywordValue_F.DisplayStudent(Record, false);
                    IndexTxt.Close();
                    DataTxt.Close();
                    break;}}
        static public void LengthIndicatorField(char choice){
            string FilePass = "C:\\IndexRecord_LengthIndicatorField.txt";
            string IndexPass = "C:\\IndexRecord_LengthIndicatorField_Index.txt";
            string Record = "";
            Field_LengthIndicator LengthIndicator_F = new Field_LengthIndicator();
            switch (choice){
                case '1':
                    if (Program.myForm.txtID.Text == "" || Program.myForm.txtName.Text.Equals("") || Program.myForm.txtAdd.Text.Equals(""))
                        break;
                    FileStream Data = new FileStream(FilePass, FileMode.Append);
                    FileStream Index = new FileStream(IndexPass, FileMode.Append);
                    Index.WriteByte((byte)Data.Length);
                    Data.Close();
                    Index.Close();
                    LengthIndicator_F.AddStudent(FilePass, false);
                    break;
                case '2':
                    FileStream IndexTxt = new FileStream(IndexPass, FileMode.OpenOrCreate);
                    FileStream DataTxt = new FileStream(FilePass, FileMode.OpenOrCreate);
                    long[] Positions = new long[100];
                    int x = 0;
                    while (IndexTxt.Position != IndexTxt.Length)
                        Positions[x++] = IndexTxt.ReadByte();
                    for (int i = 0; i < IndexTxt.Length - 1; i++){
                        Record = "";
                        for (int j = 0; j < (Positions[i + 1] - Positions[i]); j++)
                            Record += (char)DataTxt.ReadByte();
                        LengthIndicator_F.DisplayStudent(Record, false);}
                    Record = "";
                    while (DataTxt.Position != DataTxt.Length)
                        Record += (char)DataTxt.ReadByte();
                    if (Record != "")
                        LengthIndicator_F.DisplayStudent(Record, false);
                    IndexTxt.Close();
                    DataTxt.Close();
                    break;}}}}