using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET2P1
{                                                                           
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = File.Open("weather.dat", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader streamReader = new StreamReader(fs);
            String rows;
            String[] columns;
            rows = streamReader.ReadLine();
            int len = rows.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;
            int[] delimiters = new int[len+1];
            int delcount = len;
            delimiters[0] = 0;
            delimiters[delcount--] = rows.Length;
            int next = 0;
            double[,] matrix = new double[100,100];
            int j = 0,r=0;
            for (int i = rows.Length-1; i >= 0; i--)
            {
                if(rows[i] != ' ' && next == 1)
                {
                    delimiters[delcount] = i+1;
                    next = 0;
                    delcount--;
                }
                else
                {
                    if(rows[i] == ' ')
                    {
                        next = 1;
                    }
                }
            }
            rows = streamReader.ReadLine();
            do
            {
                rows = streamReader.ReadLine();
                
                if (rows != null)
                {
                    rows = rows.Replace('*', ' ');
                    StringBuilder stringBuilder = new StringBuilder(rows);
                    int count = 1;
                    int check = 0;
                    for(int i = 0; i <= rows.Length - 1; i++)
                    {
                       if(check == 0 && rows[i] !=' ')
                        {
                            check = 1;
                        } 
                        if (i == delimiters[count])
                        {
                            if (check == 0)
                            {
                                stringBuilder[delimiters[count]] = '1';
                                stringBuilder[delimiters[count]-1] = '-';
                            }
                            count++;
                            check = 0;
                        }
                    }
                    rows = stringBuilder.ToString();
                    
                    columns = rows.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                    r = 0;
                    foreach (String str in columns)
                    {
                        try
                        {
                            matrix[j, r] = Convert.ToDouble(str);
                            r++;
                        }
                        catch(Exception e)
                        {

                        }
                    }
                    j++;
                }
            }while (rows != null );

            for(int z = 0; z < j; z++)
            {
                for(int k = 0; k < r; k++)
                {
                    Console.Write(matrix[z,k]);
                    Console.Write(',');
                }
                
                Console.WriteLine();
            }
        }
    }
}
