using MastermindConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MastermindConsoleApp.Models
{
    class Game
    {
        public List<CodePeg> codePegsPlayer1 { get; set; }
        public List<CodePeg> copiedCodePegsPlayer1 { get; set; }
        public List<CodePeg> codePegsPlayer2 { get; set; }

        public Game()
        {
            codePegsPlayer1 = GenerateCodePegsPlayer1();
            //copiedCodePegsPlayer1 = codePegsPlayer1;
            codePegsPlayer2 = new List<CodePeg>();
        }

        public List<CodePeg> GenerateCodePegsPlayer1()
        {
            return new List<CodePeg> { GetRandomCodePeg(), GetRandomCodePeg(), GetRandomCodePeg(), GetRandomCodePeg() };
        }

        public CodePeg GetRandomCodePeg()
        {
            Random rnd = new Random();
            int mIndex = rnd.Next(Enum.GetNames(typeof(CodePeg)).Length);
            CodePeg codePeg = (CodePeg)mIndex;
            return codePeg;
        }

        public void PlayTheGame()
        {
            List<CodePeg> copiedCodePegsPlayer1 = new List<CodePeg>(codePegsPlayer1);
            string letterCodedCodePegsPlayer2 = "";
            Console.WriteLine("Enter four-color guess; R for Red, G for Green, C for Cyan, Y for Yellow, B for Black, W for White)\n" +
                   "eg. RCRW ");

            while (true)
            {
                copiedCodePegsPlayer1.Clear();
                copiedCodePegsPlayer1 = codePegsPlayer1.ToList();

                Console.WriteLine("Your last guess was: " + letterCodedCodePegsPlayer2);
                codePegsPlayer2.Clear();                             
            
                letterCodedCodePegsPlayer2 = Console.ReadLine();
                List<string> stringlist = new List<string>(letterCodedCodePegsPlayer2.Select(c => c.ToString()));

                foreach (string str in stringlist)
                {
                    CodePeg singleCodePeg = new CodePeg();
                    Enum.TryParse(str, out singleCodePeg);
                    codePegsPlayer2.Add(singleCodePeg);
                }

                var gameRound = new GameRound(copiedCodePegsPlayer1, codePegsPlayer2);
                gameRound.PrintTheAssessmentResult();
            }
        }
    }
}

