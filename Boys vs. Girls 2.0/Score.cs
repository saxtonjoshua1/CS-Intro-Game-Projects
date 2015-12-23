using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Boys_vs.Girls
{
    [Serializable] 
    public class Score
    {
        private List<Player> playerList;
        private string name;
        private int score;
        public StreamReader sr;
        public StreamWriter sw;

        public Score(Player p)
        {
            name = p.Name;
            score = p.Score;
        }

        private string FileFormat()
        {
            return name + " " + score;
        }

        public static void SaveHighScore(List<Player> playerList, string filename)
        {
            StreamWriter sw;
            Stream filestream;
            try
            {
                sw = new StreamWriter(filename);
                //Open the file, read contents 
            }
            //If file dosen't exist create it. 
            catch
            {
                filestream = File.Open(filename, FileMode.Create);
                filestream.Close();
                sw = new StreamWriter(filename);
            }
            sw.WriteLine(playerList.FileFormat());
            sw.Close();
        }





    }
}
