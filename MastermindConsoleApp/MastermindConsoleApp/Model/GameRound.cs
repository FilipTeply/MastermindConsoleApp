using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastermindConsoleApp.Model
{
    public class GameRound
    {
        public List<CodePeg> codePegsPlayer1ForGameRound { get; set; }
        public List<CodePeg> codePegsPlayer2ForGameRound { get; set; }

        public GameRound(List<CodePeg> codePegsPlayer1ForGameRound, List<CodePeg> codePegsPlayer2ForGameRound)
        {
            this.codePegsPlayer1ForGameRound = codePegsPlayer1ForGameRound;
            this.codePegsPlayer2ForGameRound = codePegsPlayer2ForGameRound;
        }

        public void PrintTheAssessmentResult()
        {
            var result = AssessGameRound(codePegsPlayer1ForGameRound, codePegsPlayer2ForGameRound);
            Console.WriteLine("Round Assessment: /n red key: " + result[0] + "x" + "/n white key: " + result[1] + "x");

        }

        public int[] AssessGameRound(List<CodePeg> codePegsPlayer1ForGameRound, List<CodePeg> codePegsPlayer2ForGameRound)
        {
            var copiedCodePegsPlayer1 = codePegsPlayer1ForGameRound;
            var copiedCodePegsPlayer2 = codePegsPlayer2ForGameRound;

            int[] result = new int[2];

            for (int i = 0; i < copiedCodePegsPlayer1.Count();)
            {
                if (copiedCodePegsPlayer1[i] == copiedCodePegsPlayer2[i])
                {
                    result[0]++;
                    copiedCodePegsPlayer1.Remove(copiedCodePegsPlayer1[i]);
                    copiedCodePegsPlayer2.Remove(copiedCodePegsPlayer2[i]);
                }
                else
                {
                    i++;
                }
            }

            for (int i = 0; i < copiedCodePegsPlayer1.Count();)
            {
                if (copiedCodePegsPlayer1.Contains(copiedCodePegsPlayer2[i]))
                {
                    result[1]++;
                    copiedCodePegsPlayer1.Remove(copiedCodePegsPlayer2[i]);
                    copiedCodePegsPlayer2.Remove(copiedCodePegsPlayer2[i]);
                }
                else
                {
                    i++;
                }
            }
            return result;
        }
    }
}
