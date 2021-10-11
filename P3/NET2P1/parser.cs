using System;
using System.IO;
using System.Text;
public class parser
{
	public FileStream fs;
	public StreamReader streamReader;
	public String rows;
	public String[] columns;
	public int len;
	public int[] delimiters;
	public int delcount;
	public int next = 0;
	double[,] matrix;
	public int j = 0, r = 0;

	public parser(String filename)
    {
		init(filename);
    }

	private void init(String filename)
    {
        Console.WriteLine(filename);
        fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None);
		streamReader = new StreamReader(fs);
		rows = streamReader.ReadLine();
		len = rows.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;
		delimiters = new int[len + 1];
		delcount = len;
		delimiters[0] = 0;
		delimiters[delcount--] = rows.Length;
		next = 0;
		matrix = new double[100, 100];
		j = 0;
		r = 0;
		setDelimiters();
	}

	private void setDelimiters()
    {
		for (int i = rows.Length - 1; i >= 0; i--)
		{
			if (rows[i] != ' ' && next == 1)
			{
				delimiters[delcount] = i + 1;
				next = 0;
				delcount--;
			}
			else
			{
				if (rows[i] == ' ')
				{
					next = 1;
				}
			}
		}
	} 
    public int getRowCount()
    {
        return j;
    }
    public int getColumnCount()
    {
        return r;
    }

    public double[,] parse()
    {
        do
        {
            rows = streamReader.ReadLine();

            if (rows != null)
            {
                rows = rows.Replace('*', ' ');
                StringBuilder stringBuilder = new StringBuilder(rows);
                int count = 1;
                int check = 0;
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    if (check == 0 && rows[i] != ' ')
                    {
                        check = 1;
                    }
                    if (i == delimiters[count])
                    {
                        if (check == 0)
                        {
                            stringBuilder[delimiters[count]] = '1';
                            stringBuilder[delimiters[count] - 1] = '-';
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
                    catch (Exception e)
                    {

                    }
                }
                j++;
            }
        } while (rows != null);

    }
    return matrix;
}
