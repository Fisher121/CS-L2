using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace NET2P1
{                                                                           
    class Program
    {
        static void Main(string[] args)
        {
            
            parser Parser = new parser("weather.dat");
            data matrix = Parser.parse();

            Weather weather = new Weather();
            var listForMaxTemperature = weather.getMaxTemperature(Parser, matrix);
            var listForMinTemperature = weather.getMinimumTemperature(Parser, matrix);
            Console.WriteLine("Ziua in care diferenta de temperatura este minima este: " + matrix.matrix[Parser.getMinimumDifference(listForMaxTemperature, listForMinTemperature)+1,0]);

            /*            Football football = new Football();
                        var listGoalFor = football.getGoalForList(Parser, matrix);
                        var listGoalAgainst = football.getGoalAgainstList(Parser, matrix);
                        Console.WriteLine(matrix.stringValues[Parser.getMinimumDifference(listGoalFor, listGoalAgainst)]);*/

        }
    }
}
