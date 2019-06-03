using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try // catch miss command-line parameter.
            {
                string file = args[0];
                var sr = new StreamReader(file);
                string firstline = sr.ReadLine();
                string secondline = sr.ReadLine();
                sr.Close();

                // print output
                Console.WriteLine("String X: " + firstline);
                Console.WriteLine("String Y: " + secondline);
                Console.Write("LCS: ");
                LCSlength(firstline, secondline);
                Console.WriteLine("");
            }
            catch
            {
                Console.WriteLine("You miss the command-line parameter.");
            }
        }


        public static void LCSlength(string A, string B)
        {
            int m = A.Length;
            int n = B.Length;
            string[,] arrows = new string[m+1, n+1];
            int[,] num = new int[m+1, n+1];

            
            for (int i = 1; i<m+1; i++)
            {
                num[i, 0] = 0; // fill the row with 0s
            }
            for(int j = 0; j<n+1; j++)
            {
                num[0, j] = 0; // fill the colunm with 0s.
            }
            for (int i = 1; i<m+1; i++)
            {
                for (int j = 1; j<n+1; j++)
                {
                    // comparision for two input strings.
                    if (A[i-1] == B[j-1]) // if the string is equal value, put ↖ in the arrows array in [i,j] position.
                    {
                        num[i, j] = num[i - 1, j - 1] + 1;
                        arrows[i, j] = "↖";
                    }
                    else if (num[i - 1, j] >= num[i, j - 1])
                    {
                        num[i, j] = num[i - 1, j];
                        arrows[i, j] = "↑";
                    }
                    else
                    {
                        num[i, j] = num[i, j - 1];
                        arrows[i, j] = "←";
                    }
                }
            }
            print_LCS(arrows, A, m, n);
        }

        public static void print_LCS(string[,] arrows, string A, int i, int j)
        {
            if (i==0 || j == 0)
            {
                return;
            }
            if (arrows[i,j] == "↖")
            {
                print_LCS(arrows, A, i - 1, j - 1);
                Console.Write(A[i-1]);
            }
            else if (arrows[i,j] == "↑")
            {
                print_LCS(arrows, A, i - 1, j);
            }
            else
            {
                print_LCS(arrows, A, i, j - 1);
            }

        }
    }
}
