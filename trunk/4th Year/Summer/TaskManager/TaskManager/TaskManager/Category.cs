using System;
using System.Collections.Generic;
namespace TaskManager
{
    /// <summary>
    /// Category of the Task
    /// </summary>
    public class Category
    {
        private static List<Category> categories = new List<Category>();

        private int id;

        private string name;

        public static List<Category> Categories
        {
            get { return Category.categories; }
            set { Category.categories = value; }
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public static Category GetCategoryByID(int catID)
        {
            return Category.categories.Find(cat => cat.id == catID);
        }

        public static Category GetCategoryWithName(string catName)
        {
            return Category.Categories.Find(cat => cat.Name == catName);
        }

        public static string[] GetListOfNames()
        {
            List<string> arr = new List<string>();
            Category.Categories.ForEach(cat => arr.Add(cat.name));
            return arr.ToArray();
        }

        public override string ToString()
        {
            return "ID = " + this.id + "\tName = " + this.name + Environment.NewLine;
        }
    }
}
