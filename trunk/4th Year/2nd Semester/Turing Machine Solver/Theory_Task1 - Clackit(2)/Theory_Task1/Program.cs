using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Theory_Task1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            getEqualSumString("986561517416921217551395112859219257312");

            Application.Run(new TheoryTask1());
        }

        private static int getEqualSumString(string s)
        {
            int i, j, k, leftSum, rightSum, result;

            // Convert to List<char>
            List<char> tmpArr = new List<char>(s.ToCharArray());

            // Initialize List<int>
            List<int> arr = new List<int>(s.Length);

            // Set values from List<char> to the List<int>
            tmpArr.ForEach(element => arr.Add(element - 48));

            // Initialize result
            result = 0;

            // Check length of the input
            if (s.Length == result)
            {
                return result;
            }

            // Foreach int
            for (i = 0; i < s.Length - 1; i++)
            {
                // From the next int to the end
                for (j = i + 1; j < s.Length; j += 2)
                {
                    leftSum = rightSum = 0;

                    // Get Left & Right Sum, from my int to the current
                    for (k = i; k <= j; k++)
                    {
                        if (k <= (j + i) / 2)
                        {
                            leftSum += arr[k];
                        }
                        else
                        {
                            rightSum += arr[k];
                        }
                    }

                    if ((leftSum == rightSum) && (j - i + 1) > result)
                    {
                        result = (j - i + 1);
                    }
                }
            }

            //Console.WriteLine(result);
            return result;
        }
    }
}