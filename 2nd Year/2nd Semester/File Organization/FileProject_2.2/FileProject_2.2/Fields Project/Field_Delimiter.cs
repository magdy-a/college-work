using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileProject_2._2
{
    class Field_Delimiter
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
        public void Display_Student(int x)
        {
            Console.Write("Student Name (" + x + ") is : \t");
            Console.WriteLine(Name);
            Console.Write("Student ID   (" + x + ") is : \t");
            Console.WriteLine(ID);
            Console.WriteLine("-------------------------------------------------");
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
    class Methods_For_Field_Delimiter
    {
        public void AddStudent()//can't add same ID !
        {
            Field_Delimiter Delimiter_F = new Field_Delimiter();
            Delimiter_F.Set_Student();

            if (Sequential_Search_ID(Delimiter_F.ID))
            {
                Console.WriteLine("You cann't use that ID!\n");
                AddStudent();
                return;
            }


            FileStream Fs = new FileStream(@"D:\DelimiterField.txt", FileMode.Append);
            StreamWriter Sw = new StreamWriter(Fs);

            Sw.WriteLine(Delimiter_F.Name);
            Sw.WriteLine(Delimiter_F.ID);
            Sw.Close();
        }
        public void ShowStudents()
        {
            int counter = 0;
            FileStream Fs = new FileStream(@"D:\DelimiterField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);
            Field_Delimiter Delimiter_F = new Field_Delimiter();
            while (Sr.Peek() != -1)
            {
                counter++;
                Delimiter_F.Name = Sr.ReadLine();
                Delimiter_F.ID = Sr.ReadLine();
                Delimiter_F.Display_Student(counter);
            }
            Sr.Close();
        }
        public bool Sequential_Search_Name(string Name)//can search for all names if equal the name u send !
        {
            Field_Delimiter Delimiter_F = new Field_Delimiter();
            FileStream Fs = new FileStream(@"D:\DelimiterField.txt",FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            int counter = 0;
            bool found = false;

            while (Sr.Peek() != -1)
            {
                counter++;
                Delimiter_F.Name = Sr.ReadLine();
                if (Delimiter_F.Name == Name)
                {
                    found = true;
                    Console.WriteLine("\nStudent Name found!\n");
                    Delimiter_F.ID = Sr.ReadLine();
                    Console.Write("Student (" + counter + ") Name is : ");
                    Console.WriteLine(Delimiter_F.Name);
                    Console.Write("Student (" + counter + ") ID   is : ");
                    Console.WriteLine(Delimiter_F.ID);
                    Console.WriteLine();
                }
                else
                    Delimiter_F.ID = Sr.ReadLine();
            }
            Sr.Close();
            if (found)
                return true;
            else
                return false;
        }
        public bool Sequential_Search_ID(string ID)
        {
            Field_Delimiter Delimiter_F = new Field_Delimiter();
            FileStream Fs = new FileStream(@"D:\DelimiterField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            int counter = 0;

            while (Sr.Peek() != -1)
            {
                counter++;
                Delimiter_F.Name = Sr.ReadLine();
                Delimiter_F.ID = Sr.ReadLine();
                if (Delimiter_F.ID == ID)
                {
                    Console.WriteLine("\nStudent ID found!\n");
                    Console.Write("Student (" + counter + ") Name is : ");
                    Console.WriteLine(Delimiter_F.Name);
                    Console.Write("Student (" + counter + ") ID   is : ");
                    Console.WriteLine(Delimiter_F.ID);
                    Console.WriteLine();
                    Sr.Close();
                    return true;
                }
            }
            Sr.Close();
            return false;
        }
        public bool Binary_Search_Name(string Name)
        {
            int counter = -1;
            string[] Names = new string[100];
            string[] IDs = new string[100];


            FileStream Fs = new FileStream(@"D:\DelimiterField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            while (Sr.Peek() != -1)
            {
                counter++;
                Names[counter] = Sr.ReadLine();
                IDs[counter] = Sr.ReadLine();
            }
            Sr.Close();
            
            //see how u will compare here >>>> !!!!!

            //after sorting u should serch by ( Binary search  ) !
            return false;
        }
    }
}