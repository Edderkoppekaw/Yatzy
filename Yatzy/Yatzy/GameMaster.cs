using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    class GameMaster
    {

        //TODO: Refactoring that code to make it a bit better too read
        // TODO: Maybe add a counter where you see how much life you have left
        // TODO: Better Format the output text from the console. Make it prettier overall.

        public Hand _hand { get; private set; } = new Hand();
        public LowerScoreboard Scoreboard { get; set; } = new LowerScoreboard();
        public Roll Roll { get; set; }

        public UpperScoreboard UpScoreboard { get; set; } = new UpperScoreboard();

        private int UserChoice;
        private bool GameRunning = true;
        private int tries = Settings.attemptsLeft;
        private int Totalscore = 0;
        private int totaltriesmain = Settings.totaltries;

        // this is the master which asks all the questions and keeps track of the answers and decides what to do with it
        public void Game()
        {

            Console.WriteLine("---------- Welcome to Yatzy ----------");

            while (GameRunning)
            {

                if (hasRemainingTries() == false)
                {
                    Console.WriteLine("Which outcome to choose?");

                    var outcomeIndex = Console.ReadLine()[0] - 'a';
                    if (outcomeIndex >= 0 && outcomeIndex < Roll.Outcomes.Count)
                    {
                        Roll.UseOutcome(outcomeIndex);
                        tries = totaltriesmain;
                    }
                    Console.Clear();
                    continue;
                }
                else
                {

                    Console.WriteLine("Please choose an option: ");
                    Console.WriteLine("1.) for Rolling all 6 dices");
                    Console.WriteLine("2.) for settings");
                    Console.WriteLine("3.) for scoreboard");
                    Console.WriteLine("4.) for quitting the game");
                }
                if (!_hand.FirstRound && tries != totaltriesmain)
                {
                    Console.WriteLine("5.) Choose the dices you want to reroll with ',' symbol between");
                    Console.WriteLine("6.) End turn");
                }


                if (!int.TryParse(Console.ReadLine(), out UserChoice))
                {
                    Console.WriteLine("Sorry that was not a valid input. Try again");
                    continue;
                }
                else
                {
                    switch (UserChoice)
                    {
                        case 1:
                            tries--;
                            Console.Clear();
                            Console.WriteLine("You rolled:");
                            _hand.RerollAll();
                            PrintOutcomes();
                            Console.WriteLine("Remaining rolls: " + tries);
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.Clear();
                            new Settings();
                            _hand.CreateDice();

                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Scoreboard: ");
                            Console.WriteLine("===============");
                            if (UpScoreboard.Rules.All(r => r.Used))
                            {
                                
                                Scoreboard.Print();
                                Totalscore = UpScoreboard.Sum() + Scoreboard.Sum();
                                Console.WriteLine("Total score:" + Totalscore);
                                if (UpScoreboard.Sum() >= 63)
                                    Totalscore = UpScoreboard.Sum() + Scoreboard.Sum() + 50;
                            }
                            else
                                UpScoreboard.Print();
                            Console.WriteLine("===============");
                            break;

                        case 4:
                            GameRunning = false;
                            Console.WriteLine("Thx for playing byebye - enter to quit");
                            break;

                        case 5:
                            tries--;
                            _hand.RerollDices(AskUserForDices());
                            PrintOutcomes();

                            break;

                        case 6:
                            if (tries != totaltriesmain)
                            {
                                tries = 0;
                            }
                            break;
                        default:
                            break;
                    }


                }



            }

            Console.ReadLine();



        }

        private void PrintOutcomes()
        {
            if (UpScoreboard.Rules.All(r => r.Used))
            {
                Roll = new Roll(Scoreboard, _hand.Terninger);
                Roll.Print();
                Console.WriteLine();
            }
            else
            {
                Roll = new Roll(UpScoreboard, _hand.Terninger);
                Roll.Print();
                Console.WriteLine();
            }
        }

        private int[] AskUserForDices()
        {
            Console.WriteLine("What dices you want to reroll? Please seperate it with a comma like so 0,0,0 (for example)");
            _hand.ShowDices();

            string userInput = Console.ReadLine();

            string[] chosenDices = userInput.Split(',');

            int[] toReroll = new int[chosenDices.Length];

            for (int i = 0; i < chosenDices.Length; i++)
            {
                toReroll[i] = int.Parse(chosenDices[i]) - 1;
            }

            return toReroll;
        }

        private bool hasRemainingTries()
        {
            return tries > 0;

        }
    }
}