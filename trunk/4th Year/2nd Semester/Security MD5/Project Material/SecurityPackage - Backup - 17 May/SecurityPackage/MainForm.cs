namespace SecurityPackage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using SecurityLibrary;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            //this.txtPlain.Text = "abcxyz";
            //this.txtCipher.Text = "abcxyz";
            //this.txtKey.Text = "3";

            //this.txtPlain.Text = Convertors.FromInt32ToBinary(2147483647);

            //this.txtPlain.Text = Convertors.FromIntToBinary(5, 8);

            //this.txtPlain.Text = Convertors.FromIntToBinary(5, 32);
            //this.txtCipher.Text = Convertors.FromIntToBinary(5, 64);
            //this.txtKey.Text = this.txtPlain.TextLength.ToString() + "\t" + this.txtCipher.TextLength.ToString();

            //this.txtPlain.Text = MD5.CalcPaddingLength(447).ToString() + " " + MD5.CalcPaddingLength(448).ToString() + " " + MD5.CalcPaddingLength(449).ToString() + " " + MD5.CalcPaddingLength(512).ToString();

            //int _b = 5;
            //string binary = Convertors.FromIntToBinary(_b, 32);
            //byte[] _c = BitConverter.GetBytes(_b);
            //List<byte> _d = new List<byte>();
            //foreach (char c in Convertors.FromBinaryToText(binary).ToCharArray())
            //{
            //    _d.Add((byte)c);
            //}
            //_d.Reverse();
            //_b = BitConverter.ToInt32(_d.ToArray(), 0);

            //MD5 _b = new MD5();
            //for (int i = 0; i < 56; i++)
            //{
            //    _b.PlainText += 's';
            //}
            //_b.Encrypt();
            //this.txtKey.Text = _b.PlainText;
            //this.txtCipher.Text = _b.PlainText.Length.ToString();

            //MD5 _b = new MD5();
            //_b.Display_Registers();
            //_b.Display_T_Values();

            //MessageBox.Show(((int)16 / 16).ToString() + " " + ((int)64 / 16).ToString());

            //uint x = 4;
            //uint _b = 3252435;
            //uint _c, yy;
            //_c = MD5.CircularShift(_b, 4, LeftRightAlignment.Left);
            //yy = MD5.CircularShift(_b, 4, LeftRightAlignment.Right);
            //MessageBox.Show(Convertors.FromIntToBinary(_b) + '\n' + Convertors.FromIntToBinary(_b << 6));
            //MessageBox.Show(Convertors.FromIntToBinary(x) + '\n' + Convertors.FromIntToBinary(x << 4) + '\n' + Convertors.FromIntToBinary(MD5.CircularShift(x, 4, LeftRightAlignment.Left)) + '\n' + Convertors.FromIntToBinary(MD5.CircularShift(x, 6, LeftRightAlignment.Right)) + '\n' + Convertors.FromIntToBinary(x >> 6));
            //MessageBox.Show(string.Format("{0:_b}", (int)5));
            //MessageBox.Show(Convertors.FromIntToBinary((int)_b) + '\n' + Convertors.FromIntToBinary((int)_c) + '\n' + Convertors.FromIntToBinary((int)yy));
            //MessageBox.Show(string.Format("{0:b}", _b));

            //MD5 myMD5 = new MD5();

            //string y = string.Empty;
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 16; j++)
            //    {
            //        //y += MD5.Get_XArr_Index(i, j).ToString() + '\t'; // Test X[k] index
            //        //y += ((i * 16) + j).ToString() + '\t'; // Test T[i] index
            //        //y += myMD5.S[i, j % 4].ToString() + '\t'; // Test #shifts
            //    }
            //}

            //MessageBox.Show(y);

            //int a = 5, b = 6;
            //MessageBox.Show(string.Format("{0}", a ^ b) + '\n' + string.Format("{0}", (a & ~b) | (~a & b)));

            //uint a = uint.MaxValue;
            //uint b = uint.MaxValue;

            //uint c = a & ~b;
            //c = a | b;
            //c = ~a;
            //c = a & b;
            //c = a ^ b;

            //a = uint.MaxValue - 1;
            //b = MD5.CircularShift(a, 1, LeftRightAlignment.Right);
            //string str = Convertors.FromIntToBinary(b);

            //string a, b;
            //uint value = 0x01ABCDEF;
            //a = string.Format("{0:x}", value);
            //value = Convertors.ToLittleEndian(value);
            //b = string.Format("{0:x}", value);
            //MessageBox.Show(a + "\n" + b);

            //string binarystring = Convertors.FromIntToBinary(16, 64);

            //List<byte> myList = new List<byte>(8);

            //for (int i = 0; i < 8; i++)
            //{
            //    myList.Add(Convertors.FromBinaryToByte(binarystring.Substring(i * 8, 8)));
            //}

            //string test = Convertors.ToLittleEndian(binarystring);

            //Int64 bla = BitConverter.ToInt64(myList.ToArray(), 0);

            //string x = string.Format("{0:x}", bla);
            //myList.Reverse();
            //bla = BitConverter.ToInt64(myList.ToArray(), 0);
            //string y = string.Format("{0:x}", bla);

            //Application.Exit();
        }

        private void BtnEncrypt_Click(object sender, System.EventArgs e)
        {
            //CeaserCipher algorithm = new CeaserCipher();
            //algorithm.PlainText = this.txtPlain.Text;

            //try
            //{
            //    algorithm.Key = int.Parse(this.txtKey.Text);
            //}
            //catch
            //{
            //    algorithm.Key = 0;
            //}

            MD5 algorithm = new MD5();

            algorithm.PlainText = this.txtPlain.Text;

            algorithm.Encrypt();

            this.txtCipher.Text = algorithm.CipherText;

            System.Security.Cryptography.MD5 algo = System.Security.Cryptography.MD5.Create();

            algo.Initialize();

            //List<byte> arr = new List<byte>(algo.ComputeHash(Encoding.ASCII.GetBytes(algorithm.PlainText)));
            List<byte> arr = new List<byte>(algo.ComputeHash(Encoding.ASCII.GetBytes(this.txtPlain.Text)));

            //arr.Reverse();

            List<byte> newArr = new List<byte>(4);

            string output = string.Empty;

            for (int i = 0; i < 16; i++)
            {
                output += string.Format("{0:x}", arr[i]);
            }
            output += "\t\t" + output.Length;

            //for (int i = 0; i < arr.Count; i++)
            //{
            //    output += Convertors.FromIntToBinary(arr[i], 8);
            //}

            //List<char> myList = new List<char>();
            //for (int i = 1; i <= 128; i++)
            //{
            //    myList.Add(output[i - 1]);
            //    if (i % 4 == 0)
            //    {
            //        if (i % 32 == 0)
            //        {
            //            if (i != 128)
            //                myList.AddRange(" == ".ToCharArray());
            //        }
            //        else
            //        {
            //            myList.AddRange("  ".ToCharArray());
            //        }
            //    }
            //}
            //output = new string(myList.ToArray());

            this.txtKey.Text = output;

            //MessageBox.Show(output);
        }

        private void btnDecrypt_Click(object sender, System.EventArgs e)
        {
            CeaserCipher algorithm = new CeaserCipher();
            algorithm.CipherText = this.txtCipher.Text;

            try
            {
                algorithm.Key = int.Parse(this.txtKey.Text);
            }
            catch
            {
                algorithm.Key = 0;
            }

            algorithm.Decrypt();

            this.txtPlain.Text = algorithm.PlainText;
        }
    }
}