using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MST
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filename = args[0];
                var sr = new StreamReader(filename);
                string alphabet = sr.ReadLine();
                List<Edges> edge = new List<Edges>();
                List<int> parent = new List<int>();
                Hashtable root = new Hashtable();
                List<Edges> visited = new List<Edges>();

                // make set
                for (int i = 0; i < alphabet.Length; i++)
                {
                    root[alphabet[i]] = alphabet[i];
                }

                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    Edges ed = new Edges(temp);
                    edge.Add(ed);
                }
                sr.Close();

                bubble_sort(edge); // sort

                int count = 0;

                // kruskal 
                foreach (Edges e in edge)
                {
                    if (find(e.x) != find(e.y))
                    {
                        visited.Add(e);
                        union(e.x, e.y);
                        count += e.weight;
                    }
                }
                Console.WriteLine("MST has a weight of " + count + " and consists of these edges:");

                foreach (Edges e in visited)
                {
                    Console.WriteLine(e.sss);
                }

                // find
                int find(char x)
                {
                    if ((char)root[x] == x)
                    {
                        return x;
                    }
                    else
                    {
                        return find((char)root[x]);
                    }
                }

                // union
                void union(char x, char y)
                {
                    x = (char)find(x);
                    y = (char)find(y);
                    root[y] = x;
                }

                void bubble_sort(List<Edges> A)
                {
                    Edges backup;
                    // check the last index's value and index-1, and compare the weight and exchanges.
                    for (int i = 0; i < A.Count; i++)
                    {
                        for (int j = A.Count - 1; j > i; j--)
                        {
                            if (A[j].weight < A[j - 1].weight)
                            {
                                backup = A[j];
                                A[j] = A[j - 1];
                                A[j - 1] = backup;
                            }
                        }
                    }
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File required.");
            }
        }      
    }

    class Edges
    {
        public char x;
        public char y;
        public int weight;
        public string sss;
        public Edges(string data)
        {
            string[] fields = data.Split();
            x = fields[0][0];
            y = fields[1][0];
            weight = int.Parse(fields[2]);
            sss = x + " - " + y;
        }
    }   
}
