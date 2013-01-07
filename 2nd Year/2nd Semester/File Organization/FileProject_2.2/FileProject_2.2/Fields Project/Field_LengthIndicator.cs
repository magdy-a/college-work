using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileProject_2._2
{
    class Field_LengthIndicator
    {
        //Data
        public string Name;
        public string ID;

        //Methods
        public void Set_Student()
        {
            Set_Student_Name();
            Set_Student_ID();
        }

        //Helping Methods
        private void Set_Student_Name()
        {
            try
            {
                Console.WriteLine("Enter Student Name : ");
                Name = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("You entered invalid input!");
                Set_Student_Name();
            }
        }
        private void Set_Student_ID()
        {
            try
            {
                Console.WriteLine("Enter Student ID : ");
                ID = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("You entered invalid input!");
                Set_Student_ID();
            }
        }
    }
    class Methods_For_Field_LengthIndicator
    {
        public void AddStudent()//search if same Name and ID exists
        {
            Field_LengthIndicator LengthIndicator_F = new Field_LengthIndicator();

            LengthIndicator_F.Set_Student();

            if (Sequential_Search_ID(LengthIndicator_F.ID))
            {
                Console.WriteLine("You cann't use this ID!\n");
                AddStudent();
                return;
            }

            FileStream Fs = new FileStream(@"D:\LengthIndicatorField.txt", FileMode.Append);
            StreamWriter Sw = new StreamWriter(Fs);

            if (LengthIndicator_F.Name.Length / 10 == 0)
            {
                Sw.Write(0);
                Sw.Write(LengthIndicator_F.Name.Length + LengthIndicator_F.Name);
                if (LengthIndicator_F.ID.Length / 10 == 0)
                {
                    Sw.Write(0);
                    Sw.Write(LengthIndicator_F.ID.Length + LengthIndicator_F.ID);
                }
                else
                    Sw.Write(LengthIndicator_F.ID.Length + LengthIndicator_F.ID);
            }
            else
            {
                Sw.Write(LengthIndicator_F.Name.Length + LengthIndicator_F.Name);
                if (LengthIndicator_F.ID.Length / 10 == 0)
                {
                    Sw.Write(0);
                    Sw.Write(LengthIndicator_F.ID.Length + LengthIndicator_F.ID);
                }
                else
                    Sw.Write(LengthIndicator_F.ID.Length + LengthIndicator_F.ID);
            }
            Sw.Close();
        }
        public void ShowStudents()
        {
            int Length;
            int counter = 0;
            char[] Str = new char[100];
            char[] Number = new char[2];
            FileStream Fs = new FileStream(@"D:\LengthIndicatorField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);
            Field_LengthIndicator LengthIndicator_F = new Field_LengthIndicator();
            while (Sr.Peek() != -1)
            {
                counter++;
                //Name Length/////////////////////////////////
                Sr.Read(Number,0,2);
                Length  = Number[0] - 48;
                Length *= 10;
                Length += Number[1] - 48;

                //Name/////////////////////////////////////////
                Sr.Read(Str, 0, Length);

                Console.Write("Student Name ("+counter+") is : ");
                for (int i = 0; i < Str.Length; i++)
                {
                    Console.Write(Str[i]);
                    Str[i] = '\0';
                }
                Console.WriteLine();
                //ID Length////////////////////////////////////
                Sr.Read(Number, 0, 2);
                Length  = Number[0] - 48;
                Length *= 10;
                Length += Number[1] - 48;

                //ID///////////////////////////////////////////
                Sr.Read(Str, 0, Length);

                Console.Write("Student ID   (" + counter + ") is : ");
                for (int i = 0; i < Str.Length; i++)
                {
                    Console.Write(Str[i]);
                    Str[i] = '\0';
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------");
            }
            Sr.Close();
        }
        public bool Sequential_Search_Name(string Name)
        {
            Field_Delimiter LengthIndicator_F = new Field_Delimiter();
            FileStream Fs = new FileStream(@"D:\LengthIndicatorField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            int LengthName;
            int LengthID;

            int counter = 0;

            bool check = true;
            bool found = false;

            char[] StrName = new char[100];
            char[] StrID = new char[100];
            char[] Number = new char[2];

            while (Sr.Peek() != -1)
            {
                counter++;
                check = true;

                //Name Length/////////////////////////////////
                Sr.Read(Number, 0, 2);
                LengthName = Number[0] - 48;
                LengthName *= 10;
                LengthName += Number[1] - 48;

                //Name/////////////////////////////////////////
                Sr.Read(StrName, 0, LengthName);
                for (int i = 0; i < Name.Length; i++)
                    if (StrName[i] != Name[i])
                    {
                        check = false;
                        break;
                    }

                //ID Length////////////////////////////////////
                Sr.Read(Number, 0, 2);
                LengthID = Number[0] - 48;
                LengthID *= 10;
                LengthID += Number[1] - 48;

                //ID///////////////////////////////////////////
                Sr.Read(StrID, 0, LengthID);


                if (check)
                {
                    found = true;
                    Console.WriteLine("\nStudent Name found!\n");
                    Console.Write("Student (" + counter + ") Name is : ");
                    Console.WriteLine(Name);
                    Console.Write("Student (" + counter + ") ID is   : ");
                    for(int i=0;i<LengthID;i++)
                        Console.Write(StrID[i]);
                    Console.WriteLine("\n");
                }
            }
            Sr.Close();
            if (found)
                return true;
            else
                return false;
        }
        public bool Sequential_Search_ID(string ID)
        {
            Field_Delimiter LengthIndicator_F = new Field_Delimiter();
            FileStream Fs = new FileStream(@"D:\LengthIndicatorField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            int LengthName;
            int LengthID;
            int counter = 0;
            bool check = true;
            char[] StrName = new char[100];
            char[] StrID = new char[100];
            char[] Number = new char[2];

            while (Sr.Peek() != -1)
            {
                counter++;
                check = true;

                //Name Length/////////////////////////////////
                Sr.Read(Number, 0, 2);
                LengthName = Number[0] - 48;
                LengthName *= 10;
                LengthName += Number[1] - 48;

                //Name/////////////////////////////////////////
                Sr.Read(StrName, 0, LengthName);

                //ID Length////////////////////////////////////
                Sr.Read(Number, 0, 2);
                LengthID = Number[0] - 48;
                LengthID *= 10;
                LengthID += Number[1] - 48;

                //ID///////////////////////////////////////////
                Sr.Read(StrID, 0, LengthID);


                for (int i = 0; i < ID.Length; i++)
                    if (StrID[i] != ID[i])
                    {
                        check = false;
                        break;
                    }


                if (check)
                {
                    Console.WriteLine("\nStudent ID found!\n");
                    Console.Write("Student (" + counter + ") Name is : ");
                    for (int i = 0; i < LengthName; i++)
                        Console.Write(StrName[i]);
                    Console.WriteLine();
                    Console.Write("Student (" + counter + ") ID is   : ");
                    Console.WriteLine(ID);
                    Console.WriteLine();
                    Sr.Close();
                    return true;
                }
            }
            Sr.Close();
            return false;
        }
    }
}