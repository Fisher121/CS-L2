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
                        Console.WriteLine("Echipa care are golaverajul cel mai mic este: " + matrix.stringValues[Parser.getMinimumDifference(listGoalFor, listGoalAgainst)]);*/

        }
    }
}
/*
 *  Intrebarea 1:
 *  Aspectele de design luate initial ne-au ajutat deoarece am avut un model general dupa care sa proiectam programul final
 *  
 *  Intrebarea 2:
 *  Da, deoarece am inceput tranzitia spre un program care poate citi fisiere asemanatoare inca din partea a 2 a
 *  
 *  Intrebarea 3:
 *  Factorizarea programului in asa fel incat sa avem cat mai putin cod este, in general, un lucru bun atat din punct de vedere al eficientei cat si al
 *  lizibilitatii codului. Insa, uneori acest lucru poate complica intelegerea codului de catre alti programatori. In cazul nostru, consideram ca am reusit
 *  sa creem un cod lizibil. Programul ar trebui sa functioneze si pentru fisiere diferite, dar care au aceeasi structura de baza, cu conditia de a creea
 *  un model nou.
 */
