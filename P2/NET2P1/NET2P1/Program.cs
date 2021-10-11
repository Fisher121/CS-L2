using System;
using System.IO;
using System.Text;


namespace NET2P1
{                                                                           
    class Program
    {
        static void Main(string[] args)
        {
            parser Parser = new parser("football.dat");
            double[,] matrix = Parser.parse();
            for (int z = 0; z < Parser.getRowCount(); z++)
            {
                for (int k = 0; k < Parser.getColumnCount(); k++)
                {
                    Console.Write(matrix[z, k]);
                    Console.Write(',');
                }

                Console.WriteLine();
            }

        }
    }
}
