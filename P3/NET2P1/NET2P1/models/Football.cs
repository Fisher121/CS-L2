using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET2P1
{
    class Football
    {
        public List<Football> teamList = new List<Football>();
        public List<double> goalsForList = new List<double>();
        public List<double> goalsAgainstList = new List<double>();

        public int id { get; set; }
        public double team { get; set; }
        public int playedMatch {get; set; }
        public int win { get; set; }
        public int lost { get; set; }
        public int draw { get; set; }
        public int goalFor { get; set; }
        public int goalAgainst { get; set; }

        public int points { get; set; }

        public List<Football> getDataToProperties(parser Parser, data Data)
        {

            for (int z = 1; z < Parser.getRowCount(); z++)
            {
                Football football = new Football();
                football.id = (int)Data.matrix[z, 0];
                football.team = Data.matrix[z, 1];
                football.playedMatch = (int)Data.matrix[z, 2];
                football.win = (int)Data.matrix[z, 3];
                football.lost = (int)Data.matrix[z, 4];
                football.draw = (int)Data.matrix[z, 5];
                football.goalFor = (int)Data.matrix[z, 6];
                football.goalAgainst = (int)Data.matrix[z, 7];
                football.points = (int)Data.matrix[z, 8];
                teamList.Add(football);
            }
            return teamList;
        }
        public List<double> getGoalForList(parser Parser, data Data)
        {
            for (int i = 0; i < Parser.getRowCount(); i++)
            {
                if(Data.matrix[i, 6] != 0)
                {
                    goalsForList.Add(Data.matrix[i, 6]);
                }
                
            }

            return goalsForList;
        }
        public List<double> getGoalAgainstList(parser Parser,data Data)
        {
            for (int i = 0; i < Parser.getRowCount(); i++)
            {
                if (Data.matrix[i, 7] != 0)
                {
                    goalsAgainstList.Add(Data.matrix[i, 7]);
                }
            }

            return goalsAgainstList;
        }
    }
}
