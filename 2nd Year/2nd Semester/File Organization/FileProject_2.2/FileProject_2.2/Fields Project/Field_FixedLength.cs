using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileProject_2._2
{
    class Field_FixedLength
    {
        //Data
        public char[] Name;
        public char[] ID;
        public int Name_Len;
        public int ID_Len;

        //Methods
        public Field_FixedLength()
        {
            Name_Len = 20;
            ID_Len = 5;
            Name = new char[Name_Len];
            ID = new char[ID_Len];
        }
        public void Set_Student()
        {
            Set_StudentName();
            Set_StudentID();
        }
        public void Display_Student(int x)
        {
            Console.Write("Student Name (" + x + ") is : \t");
            for (int i = 0; i < Name_Len; i++)
            {
                if (Name[i] != '\0')
                    Console.Write(Name[i]);
                else
                    break;
            }
            Console.WriteLine();
            Console.Write("Student ID   (" + x + ") is : \t");
            for (int i = 0; i < ID_Len; i++)
            {
                if (ID[i] != '\0')
                    Console.Write(ID[i]);
                else
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
        }

        //Helping methods
        private void Set_StudentName()
        {
            string Str;
            try
            {
                Console.WriteLine("Enter Student Name : ");
                Str = Console.ReadLine();
                if (Str.Length <= Name_Len)
                    Str.CopyTo(0, Name, 0, Str.Length);
                else
                {
                    Console.WriteLine("You entered very long name, you can only enter 20 characters");
                    Set_StudentName();
                }
                for (int i = Str.Length; i < Name_Len; i++)
                    Name[i] = '\0';
            }
            catch {
                Console.WriteLine("You entered a valid input!");
                Set_StudentName();
            }
        }
        private void Set_StudentID()
        {
            string Str;
            try
            {
                Console.WriteLine("Enter Student ID : ");
                Str = Console.ReadLine();
                if (Str.Length <= ID_Len)
                {
                    Str.CopyTo(0, ID, 0, Str.Length);
                }
                else
                {
                    Console.WriteLine("You Entered very long ID, you can enter only 5 characters");
                    Set_StudentID();
                }
                for (int i = Str.Length; i < ID_Len; i++)
                    ID[i] = '\0';
            }
            catch {
                Console.WriteLine("You entered a valid input!");
                Set_StudentID();
            }
        }
    }
    class Methods_For_Field_FixedLength
    {
        public void AddStudent()//search if same Name and ID exists*********************** or just make it by ID and make the (search) can search all the names not the first come !!
        {
            Field_FixedLength Fixed_F = new Field_FixedLength();

            Fixed_F.Set_Student();

            if (Sequential_Search_ID(Fixed_F.ID))
            {
                Console.WriteLine("You can't use this ID!\n");
                
                AddStudent();
                return;
            }

            FileStream Fs = new FileStream(@"D:\FixedField.txt", FileMode.Append);
            StreamWriter Sw = new StreamWriter(Fs);

            Sw.Write(Fixed_F.Name, 0, Fixed_F.Name_Len);
            Sw.Write(Fixed_F.ID, 0, Fixed_F.ID_Len);

            Sw.Close();
        }
        public void ShowStudents()
        {
            int counter = 0;
            Field_FixedLength Fixed_F = new Field_FixedLength();
            FileStream Fs = new FileStream(@"D:\FixedField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);
            while (Sr.Peek() != -1)
            {
                counter++;
                Sr.Read(Fixed_F.Name, 0, Fixed_F.Name_Len);
                Sr.Read(Fixed_F.ID, 0, Fixed_F.ID_Len);
                Fixed_F.Display_Student(counter);
            }
            Sr.Close();
        }
        public bool Sequential_Search_Name(string Name)
        {
            FileStream Fs = new FileStream(@"D:\FixedField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            Field_FixedLength Fixed_F = new Field_FixedLength();

            bool check = true;
            bool found = false;
            int counter = 0;

            while (Sr.Peek() != -1)
            {
                check = true;
                counter++;
                Sr.Read(Fixed_F.Name, 0, Fixed_F.Name_Len);
                for (int i = Name.Length; i < Fixed_F.Name_Len; i++)
                {
                    Name += '\0';
                }
                for (int i = 0; i < Name.Length; i++)
                    if (Fixed_F.Name[i] != Name[i])
                    {
                        check = false;
                        break;
                    }

                if (check)
                {
                    found = true;
                    Console.WriteLine("\nName found!\n");
                    Console.Write("Student (" + counter + ") Name is : ");
                    Console.WriteLine(Name);
                    Console.Write("Student (" + counter + ") ID   is : ");
                    Sr.Read(Fixed_F.ID,0,Fixed_F.ID_Len);
                    for(int i=0;i<Fixed_F.ID_Len;i++)
                        Console.Write(Fixed_F.ID[i]);
                    Console.WriteLine("\n");
                    continue;
                }
                Sr.Read(Fixed_F.ID, 0, Fixed_F.ID_Len);
            }
            Sr.Close();
            if (found)
                return true;
            else
                return false;
        }
        public bool Sequential_Search_ID(char[] ID)//array of chars // it is a helping function for the AddStudent() !
        {
            Field_FixedLength Fixed_F = new Field_FixedLength();
            FileStream Fs = new FileStream(@"D:\FixedField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            bool check = true;
            int counter = 0;

            while (Sr.Peek() != -1)
            {
                Sr.Read(Fixed_F.Name, 0, Fixed_F.Name_Len);

                counter++;
                check = true;

                Sr.Read(Fixed_F.ID, 0, Fixed_F.ID_Len);

                for (int i = 0; i < ID.Length; i++)
                    if (Fixed_F.ID[i] != ID[i])
                    {
                        check = false;
                        break;
                    }
                if (check == true && Fixed_F.ID_Len > ID.Length)
                    check = false;
                if (check)
                {
                    Console.WriteLine("\nStudent ID found!\n");
                    Console.Write("Student (" + counter + ") Name is : ");
                    for (int i = 0; i < Fixed_F.Name_Len; i++)
                        if (Fixed_F.Name[i] == '\0')
                            break;
                        else
                            Console.Write(Fixed_F.Name[i]);
                    Console.WriteLine();
                    Console.Write("Student (" + counter + ") ID   is : ");
                    for (int i = 0; i < Fixed_F.ID_Len; i++)
                        if (Fixed_F.ID[i] == '\0')
                            break;
                        else
                            Console.Write(Fixed_F.ID[i]);
                    Console.WriteLine("\n");
                    Sr.Close();
                    return true;
                }
            }
            Sr.Close();
            return false;
        }
        public bool Sequential_Search_ID(string ID)//string  // for the search function
        {
            Field_FixedLength Fixed_F = new Field_FixedLength();
            FileStream Fs = new FileStream(@"D:\FixedField.txt", FileMode.Open);
            StreamReader Sr = new StreamReader(Fs);

            bool check = true;
            int counter = 0;

            while (Sr.Peek() != -1)
            {
                Sr.Read(Fixed_F.Name, 0, Fixed_F.Name_Len);

                counter++;
                check = true;

                Sr.Read(Fixed_F.ID, 0, Fixed_F.ID_Len);

                for (int i = ID.Length; i < Fixed_F.ID_Len; i++)
                {
                    ID += '\0';
                }

                for (int i = 0; i < ID.Length; i++)
                    if (Fixed_F.ID[i] != ID[i])
                    {
                        check = false;
                        break;
                    }
                //if (check = true && Fixed_F.ID_Len > ID.Length)//5od balak men en law enta 3andak fe el file kelmak 2a2al men 5 chars fa el ba2y haykon '\0' null we dah bey5ale mesa7et el string dah atwal men el ID ele hoa bedawar 3aleh >> fa e3mel el for loop l3'ayet el Fixed_F.ID_Len we etla3 men el for loop lma el Fixed_F.ID[i] = '\0' we sheel el if condition beta3et el akbar men !!!!
                //    check = false;
                if (check)
                {
                    Console.WriteLine("\nStudent ID found!\n");
                    Console.Write("Student (" + counter + ") Name is : ");
                    for (int i = 0; i < Fixed_F.Name_Len; i++)
                        if (Fixed_F.Name[i] == '\0')
                            break;
                        else
                            Console.Write(Fixed_F.Name[i]);
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