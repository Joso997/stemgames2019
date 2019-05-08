using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        public static int Calculate(string source1, string source2) //O(n*m)
        {
            var source1Length = source1.Length;
            var source2Length = source2.Length;

            var matrix = new int[source1Length + 1, source2Length + 1];

            // First calculation, if one entry is empty return full length
            if (source1Length == 0)
                return source2Length;

            if (source2Length == 0)
                return source1Length;

            // Initialization of matrix with row size source1Length and columns size source2Length
            for (var i = 0; i <= source1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= source2Length; matrix[0, j] = j++) { }

            // Calculate rows and collumns distances
            for (var i = 1; i <= source1Length; i++)
            {
                for (var j = 1; j <= source2Length; j++)
                {
                    var cost = (source2[j - 1] == source1[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            // return result
            return matrix[source1Length, source2Length];
        }

        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Developer\Downloads\keys\keys\test_cases\keys_9.in");

            string[] temp = text.Split();
            string[] test = temp.Skip(2).ToArray();
            int[] counter = new int[test.Length];
            Parallel.For(0, test.Length, i =>
            {
                counter[i] = Calculate(temp[1], test[i]);
            });


            for (int i=0; i < int.Parse(temp[0]); ++i){
                
            }

            int max = counter[0], index=0;

            for (int i=0; i < counter.Length; ++i)
            {
                if (max > counter[i]) {
                    max = counter[i];
                    index = i;
                }                
            }

            //Console.WriteLine(index);
            Console.WriteLine(index);
        }
    }    
}

/*
0: 5
1: 3
2: 0
3: 17
4: 7
5: 30
6: 9
7: 108
8: 415
9: 118
*/
