using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FileProject_2._2;

namespace ConsoleApplication1
{
    class Program
    {
        //========================================================================================================================
                                                         static void Field_Controller()
        {
            char choice;
            while (true)
            {
                Console.WriteLine("================================================================================");
                Console.WriteLine("\t\t\t\tFields List\n");
                Console.WriteLine("Choose the type of sorting the (Fields) : ");
                Console.WriteLine("Type (F) for the Fixed Field");
                Console.WriteLine("Type (D) for the Delimiter");
                Console.WriteLine("Type (L) for the Length Indicator");
                Console.WriteLine("Type (K) for the Keyword = Value");
                Console.WriteLine("Type (X) To Exit");
                Console.WriteLine("Enter your choice : ");
                try { choice = char.Parse(Console.ReadLine()); }
                catch
                {
                    Console.WriteLine("You entered invalid choice!");
                    Console.WriteLine("Enter your choice : ");
                    choice = char.Parse(Console.ReadLine());
                }
                switch (choice)
                {
                    case 'f':
                    case 'F':
                        FixedLength_Field();
                        break;
                    case 'd':
                    case 'D':
                        Delimiter_Field();
                        break;
                    case 'l':
                    case 'L':
                        LengthIndicator_Field();
                        break;
                    case 'k':
                    case 'K':
                        Keyword_Value_Field();
                        break;
                    case 'x':
                    case 'X':
                        Console.WriteLine("\n\n\t\t\tHappy for your visit :) ");
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        continue;
                }//switch
            }//while
        }
        //                                     -----------------------------------------------------------
        static void FixedLength_Field()
        {
            char choice;
            string Str;
            bool check;

            Methods_For_Field_FixedLength Fixed_F = new Methods_For_Field_FixedLength();

            while (true)
            {
                Console.WriteLine("================================================================================");
                Console.WriteLine("\t\t\t\tFixed_Field\n\n");
                Console.WriteLine("Type (A) to add student");
                Console.WriteLine("Type (D) to Display all students");
                Console.WriteLine("Type (S) to Search");
                Console.WriteLine("Type (X) to back to List");
                Console.WriteLine("Enter your choice : ");
                try { choice = char.Parse(Console.ReadLine()); }
                catch
                {
                    Console.WriteLine("You entered invalid choice!");
                    Console.WriteLine("Enter your choice : ");
                    choice = char.Parse(Console.ReadLine());
                }
                switch (choice)
                {
                    case 'a':
                    case 'A':
                        Fixed_F.AddStudent();
                        break;
                    case 'd':
                    case 'D':
                        Fixed_F.ShowStudents();
                        break;
                    case 's':
                    case 'S':
                        Console.WriteLine("\nTo search by Name type (N)");
                        Console.WriteLine("To search by ID  type  (I)");
                        Console.WriteLine("To back (X) ");
                        Console.WriteLine("Enter your choice : ");
                        try { choice = char.Parse(Console.ReadLine()); }
                        catch
                        {
                            Console.WriteLine("You entered invalid input!");
                            Console.WriteLine("Enter your choice : ");
                            choice = char.Parse(Console.ReadLine());
                        }
                        switch (choice)
                        {
                            case 'n':
                            case 'N':
                                Console.WriteLine("Enter student Name : ");
                                try { Str = Console.ReadLine(); }
                                catch
                                {
                                    Console.WriteLine("You entered invalid input!");
                                    Console.WriteLine("Enter student Name : ");
                                    Str = Console.ReadLine();
                                }
                                check = Fixed_F.Sequential_Search_Name(Str);
                                if (!check)
                                    Console.WriteLine("\nStudent Name not found!\n");
                                break;
                            case 'i':
                            case 'I':
                                Console.WriteLine("Enter student ID : ");
                                try { Str = Console.ReadLine(); }
                                catch
                                {
                                    Console.WriteLine("You entered invalid input!");
                                    Console.WriteLine("Enter student ID : ");
                                    Str = Console.ReadLine();
                                }
                                check = Fixed_F.Sequential_Search_ID(Str);
                                if (!check)
                                    Console.WriteLine("\nStudent ID not found!\n");
                                break;
                            case 'x':
                            case 'X':
                                break;
                            default:
                                Console.WriteLine("Invalid input!");
                                break;
                        }
                        break;
                    case 'x':
                    case 'X':
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        continue;
                }//switch
            }//while
        }
        static void Delimiter_Field()
        {
            char choice;
            string Str;
            bool check;

            Methods_For_Field_Delimiter Delimiter_F = new Methods_For_Field_Delimiter();

            while (true)
            {
                Console.WriteLine("================================================================================");
                Console.WriteLine("\t\t\t\tDelimiter Field\n\n");
                Console.WriteLine("Type (A) to add student");
                Console.WriteLine("Type (D) to display students");
                Console.WriteLine("Type (S) to Sequential Search");
                Console.WriteLine("Type (B) to Binary Search");
                Console.WriteLine("Type (X) to back to the list");
                Console.WriteLine("Enter your choice : ");
                try { choice = char.Parse(Console.ReadLine()); }
                catch
                {
                    Console.WriteLine("You entered invalid choice!");
                    Console.WriteLine("Enter your choice : ");
                    choice = char.Parse(Console.ReadLine());
                }
                switch (choice)
                {
                    case 'a':
                    case 'A':
                        Delimiter_F.AddStudent();
                        break;
                    case 'd':
                    case 'D':
                        Delimiter_F.ShowStudents();
                        break;
                    case 's':
                    case 'S':
                        Console.WriteLine("To search by Name type (N)");
                        Console.WriteLine("To search by ID   type (I)");
                        Console.WriteLine("To back (X) ");
                        Console.WriteLine("Enter your choice : ");
                        try { choice = char.Parse(Console.ReadLine()); }
                        catch
                        {
                            Console.WriteLine("You entered invalid input!");
                            Console.WriteLine("Enter your choice : ");
                            choice = char.Parse(Console.ReadLine());
                        }
                        switch (choice)
                        {
                            case 'n':
                            case 'N':
                                Console.WriteLine("Enter Student Name : ");
                                try { Str = Console.ReadLine(); }
                                catch
                                {
                                    Console.WriteLine("You entered invalid input!");
                                    Console.WriteLine("Enter Student Name : ");
                                    Str = Console.ReadLine();
                                }
                                check = Delimiter_F.Sequential_Search_Name(Str);
                                if (!check)
                                    Console.WriteLine("\nStudent Name not found!\n");
                                break;
                            case 'i':
                            case 'I':
                                Console.WriteLine("Enter Student ID : ");
                                try { Str = Console.ReadLine(); }
                                catch
                                {
                                    Console.WriteLine("You entered invalid input!");
                                    Console.WriteLine("Enter Student ID : ");
                                    Str = Console.ReadLine();
                                }
                                check = Delimiter_F.Sequential_Search_ID(Str);
                                if (!check)
                                {
                                    Console.WriteLine("\nStudent ID not found!\n");
                                }
                                break;
                            case 'x':
                            case 'X':
                                break;
                            default:
                                Console.WriteLine("Invalid input!");
                                break;
                        }
                        break;
                    case 'b':
                    case 'B':
                        Console.WriteLine("To search by Name type (N)");
                        Console.WriteLine("To search by ID   type (I)");
                        Console.WriteLine("To back (X)");
                        Console.WriteLine("Enter your choice : ");
                        try{choice = char.Parse(Console.ReadLine());}
                        catch
                        {
                            Console.WriteLine("You entered invalid chioce!");
                            Console.WriteLine("Enter your choice : ");
                            choice = char.Parse(Console.ReadLine());
                        }
                        switch(choice)
                        {
                            case 'n':
                            case 'N':
                                Console.WriteLine("Enter Student Name : ");
                                try { Str = Console.ReadLine(); }
                                catch
                                {
                                    Console.WriteLine("You entered invalid choice!");
                                    Console.WriteLine("Enter Student Name : ");
                                    Str = Console.ReadLine();
                                }
                                Delimiter_F.Binary_Search_Name(Str);
                                break;
                            case 'i':
                            case 'I':
                                break;
                            case 'x':
                            case 'X':
                                break;
                            default:
                            Console.WriteLine("You enered invalid choice!");
                                break;
                        }
                        break;
                    case 'x':
                    case 'X':
                        return;
                    default:
                        Console.WriteLine("invalid input!");
                        continue;
                }//switch
            }//while
        }
        static void LengthIndicator_Field()
        {
            char choice;
            string Str;
            bool check;

            Methods_For_Field_LengthIndicator LengthIndicator_F = new Methods_For_Field_LengthIndicator();

            while (true)
            {
                Console.WriteLine("================================================================================");
                Console.WriteLine("\t\t\t\tLength Indicator Field");
                Console.WriteLine("Type (A) to add student");
                Console.WriteLine("Type (D) to display students");
                Console.WriteLine("Type (S) to search");
                Console.WriteLine("Type (X) to back to the list");
                Console.WriteLine("Enter your choice : ");
                try { choice = char.Parse(Console.ReadLine()); }
                catch
                {
                    Console.WriteLine("You entered invalid choice!");
                    Console.WriteLine("Enter your choice : ");
                    choice = char.Parse(Console.ReadLine());
                }
                switch (choice)
                {
                    case 'a':
                    case 'A':
                        LengthIndicator_F.AddStudent();
                        break;
                    case 'd':
                    case 'D':
                        LengthIndicator_F.ShowStudents();
                        break;
                    case 's':
                    case 'S':
                        Console.WriteLine("To search by Name type (N)");
                        Console.WriteLine("To search by ID   type (I)");
                        Console.WriteLine("To back (X) ");
                        Console.WriteLine("Enter your choice : ");
                        try { choice = char.Parse(Console.ReadLine()); }
                        catch
                        {
                            Console.WriteLine("You entered invalid input!");
                            Console.WriteLine("Enter your choice : ");
                            choice = char.Parse(Console.ReadLine());
                        }
                        switch (choice)
                        {
                            case 'n':
                            case 'N':
                                Console.WriteLine("Enter Student Name : ");
                                try { Str = Console.ReadLine(); }
                                catch
                                {
                                    Console.WriteLine("You entered invalid input!");
                                    Console.WriteLine("Enter Student Name : ");
                                    Str = Console.ReadLine();
                                }
                                check = LengthIndicator_F.Sequential_Search_Name(Str);
                                if (!check)
                                    Console.WriteLine("\nStudent Name not found!\n");
                                break;
                            case 'i':
                            case 'I':
                                Console.WriteLine("Enter Student ID : ");
                                try { Str = Console.ReadLine(); }
                                catch
                                {
                                    Console.WriteLine("You entered invalid input!");
                                    Console.WriteLine("Enter Student ID : ");
                                    Str = Console.ReadLine();
                                }
                               check = LengthIndicator_F.Sequential_Search_ID(Str);
                               if (!check)
                                   Console.WriteLine("\nStudent ID not found!\n");
                                break;
                            case 'x':
                            case 'X':
                                break;
                            default:
                                Console.WriteLine("Invalid input!");
                                break;
                        }
                        break;
                    case 'x':
                    case 'X':
                        return;
                    default:
                        Console.WriteLine("invalid input!");
                        continue;
                }//switch
            }//while
        }
        static void Keyword_Value_Field()
        {
            char choice;
            string Str;
            bool check;

            Methods_For_Keyword_Value Keyword_Value_F = new Methods_For_Keyword_Value();

            while (true)
            {
                Console.WriteLine("================================================================================");
                Console.WriteLine("\t\t\t\tKeyword = Value Field");
                Console.WriteLine("Type (A) to add student");
                Console.WriteLine("Type (D) to display students");
                Console.WriteLine("Type (S) to Search ");
                Console.WriteLine("Type (X) to back to List");
                Console.WriteLine("Enter your choice : ");
                try { choice = char.Parse(Console.ReadLine()); }
                catch
                {
                    Console.WriteLine("You entered invalid choice!");
                    Console.WriteLine("Enter your choice : ");
                    choice = char.Parse(Console.ReadLine());
                }
                switch (choice)
                {
                    case 'a':
                    case 'A':
                        Keyword_Value_F.AddStudent();
                        break;
                    case 'd':
                    case 'D':
                        Keyword_Value_F.ShowStudents();
                        break;
                    case 's':
                    case 'S':
                        Console.WriteLine("To search by Name type (N)");
                        Console.WriteLine("To search by ID   type (I)");
                        Console.WriteLine("To back (X) ");
                        Console.WriteLine("Enter your choice : ");
                        try { choice = char.Parse(Console.ReadLine()); }
                        catch
                        {
                            Console.WriteLine("You entered invalid input!");
                            Console.WriteLine("Enter your choice : ");
                            choice = char.Parse(Console.ReadLine());
                        }
                        switch (choice)
                        {
                            case 'n':
                            case 'N':
                                Console.WriteLine("Enter Student Name : ");
                                try { Str = Console.ReadLine(); }
                                catch
                                {
                                    Console.WriteLine("You entered invalid input!");
                                    Console.WriteLine("Enter Student Name : ");
                                    Str = Console.ReadLine();
                                }
                                check = Keyword_Value_F.Sequential_Search_Name(Str);
                                if (!check)
                                    Console.WriteLine("\nStudent Name not found!\n");
                                break;
                            case 'i':
                            case 'I':
                                Console.WriteLine("Enter Student ID : ");
                                try { Str = Console.ReadLine(); }
                                catch
                                {
                                    Console.WriteLine("You entered invalid input!");
                                    Console.WriteLine("Enter Student ID : ");
                                    Str = Console.ReadLine();
                                }
                                check = Keyword_Value_F.Sequential_Search_ID(Str);
                                if (!check)
                                    Console.WriteLine("\nStudent ID not found!\n");
                                break;
                            case 'x':
                            case 'X':
                                break;
                            default:
                                Console.WriteLine("Invalid input!");
                                break;
                        }
                        break;
                    case 'x':
                    case 'X':
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        continue;
                }//switch
            }//while
        }
        //========================================================================================================================
                                                        static void Record_Controller()
        { }
        //                                     -----------------------------------------------------------
        //========================================================================================================================
        //                                                     ----------------------------
        //                                            ----------------------------------------------
        //                                     -----------------------------------------------------------
                                                        static void Main(string[] args)
        {
            char choice;
            while (true)
            {
                Console.WriteLine("================================================================================");
                Console.WriteLine("\t\t\t\tMain List\n");
                Console.WriteLine("Type (F) for Fields  Project");
                Console.WriteLine("Type (R) for Records Project");
                Console.WriteLine("Type (X) To Exit");
                Console.WriteLine("Enter your choice : ");
                try { choice = char.Parse(Console.ReadLine()); }
                catch
                {
                    Console.WriteLine("You entered invalid choice!");
                    Console.WriteLine("Enter your choice : ");
                    choice = char.Parse(Console.ReadLine());
                }
                switch (choice)
                {
                    case 'f':
                    case 'F':
                        Field_Controller();
                        break;
                    case 'x':
                    case 'X':
                        Console.WriteLine("\n\n\t\t\tHappy for your visit :) ");
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        continue;
                }//switch
            }//while
        }//Main
        //                                     -----------------------------------------------------------
        //                                            ----------------------------------------------
        //                                                     ----------------------------
        //========================================================================================================================
    }//class
}//namespace