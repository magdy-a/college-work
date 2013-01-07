using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileProject_2._2
{
    class Field_Keyword_Value
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
    class Methods_For_Keyword_Value
    {
        public void AddStudent()//search if same Name and ID exists
        {
            string Str;
            Field_Keyword_Value Keyword_Value_F = new Field_Keyword_Value();

            Keyword_Value_F.Set_Student();

            if (Sequential_Search_ID(Keyword_Value_F.ID))
            {
                Console.WriteLine("You cann't use this ID!\n");
                AddStudent();
                return;
            }

            FileStream Fs = new FileStream(@"D:\Keyword_valueField.txt", FileMode.Append);
            StreamWriter Sw = new StreamWriter(Fs);

            Str = "Name=";
            Sw.WriteLine(Str + Keyword_Value_F.Name);
            Str = "ID=";
            Sw.WriteLine(Str + Keyword_Value_F.ID);
            Sw.Close();
        }
        public void ShowStudents()
        {
            FileStream Fs = new FileStream(@"D:\Keyword_ValueField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            Field_Keyword_Value Keyword_Value_F = new Field_Keyword_Value();

            int counter = 0;
            string str;

            while (Sr.Peek() != -1)
            {
                counter++;
                str = Sr.ReadLine();
                Console.Write("Student Name (" + counter + ") is : ");
                for(int i=5;i<str.Length;i++)
                    Console.Write(str[i]);
                Console.WriteLine();
                str = Sr.ReadLine();
                Console.Write("Student ID   (" + counter + ") is : ");
                for(int i=3;i<str.Length;i++)
                    Console.Write(str[i]);
                Console.WriteLine("\n-------------------------------------------------");
            }
            Sr.Close();
        }
        public bool Sequential_Search_Name(string Name)
        {
            FileStream Fs = new FileStream(@"D:\Keyword_ValueField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            string Str;

            int counter = 0;

            bool check = true;//for checking if the name exists
            bool found = false;

            while (Sr.Peek() != -1)
            {
                check = true;
                counter++;//for counting student order
                Str = Sr.ReadLine();
                for (int i = 0; i < Name.Length; i++)//checking if Equal
                    if (Str[i + 5] != Name[i])
                    {
                        check = false;
                        break;
                    }
                if (check == true && Str.Length > (Name.Length + 5/*+5 with counting "Name=" in Str*/))//for special cases : if i have word like helloworld and iam checking for word like hello >> for loop will consider it true but it isn't
                    check = false;
                if (check)
                {
                    found = true;
                    Console.WriteLine("\nName found!\n");
                    Console.Write("Student (" + counter + ") Name is : ");
                    Console.WriteLine(Name);
                    Str = Sr.ReadLine();
                    Console.Write("Student (" + counter + ") ID   is : ");
                    for (int i = 3; i < Str.Length; i++)
                        Console.Write(Str[i]);
                    Console.WriteLine("\n");
                    continue;
                }
                else
                    Sr.ReadLine();
            }
            Sr.Close();
            if (found)
                return true;
            else
                return false;
        }
        public bool Sequential_Search_ID(string ID)
        {
            FileStream Fs = new FileStream(@"D:\Keyword_ValueField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            Field_Keyword_Value Keyword_Value_F = new Field_Keyword_Value();

            string Str;
            string Name = "Name";

            int Specifier = 1;// for checking only IDs 
            int counter = 0;// for counting student order

            bool check = true;

            while (Sr.Peek() != -1)
            {
                check = true;
                Specifier++;
                counter++;

                if (Specifier % 2 == 0)
                {
                    counter--;
                    Name = Sr.ReadLine();//for saving student name to show the student full information
                    continue;
                }
                Str = Sr.ReadLine();
                for (int i=0;i<ID.Length ; i++)
                {
                    if(Str[i+3] != ID[i])
                    {
                        check = false;
                        break;
                    }
                }
                if (check == true && Str.Length > (ID.Length + 3))
                {
                    check = false;
                }
                if (check)
                {
                    Console.WriteLine("\nID found!\n");
                    Console.WriteLine();
                    Console.Write("Student (" + counter + ") Name is : ");
                    for (int i = 5; i < Name.Length; i++)
                        Console.Write(Name[i]);
                    Console.WriteLine();
                    Console.Write("Student (" + counter + ") ID   is : ");
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