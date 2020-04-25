﻿using System;
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
        public Scoreboard Scoreboard { get; set; } = new Scoreboard();
        public Roll Roll { get; set; }

        private int UserChoice;
        private bool GameRunning = true;
        private int tries = Settings.antalForsøg;

        // this is the master which asks all the questions and keeps track of the answers and decides what to do with it
        public void Game()
        {

            Console.WriteLine("---------- Welcome to Yatzy ----------");

            while (GameRunning)
            {

                if (hasRemainingTries() == false)
                {
                    Console.WriteLine("You have now thrown the dice 3 times. Your last throw:");
                    _hand.ShowDices();

                    Console.WriteLine("Click Enter for a new round");
                    tries = Settings.antalForsøg;
                    continue;
                }
                else
                {

                    Console.WriteLine("Please chose an option: ");
                    Console.WriteLine("1.) for Rolling all 6 dices");
                    Console.WriteLine("2.) for settings");
                    Console.WriteLine("3.) for scoreboard");
                    Console.WriteLine("4.) for quitting the game");
                }
                if (!_hand.FirstRound && hasRemainingTries())
                {
                    Console.WriteLine("5.) Chose the dices you want to reroll with ',' symbol between");
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
                            _hand.RerollAll();
                            PrintOutcomes();

                            break;

                        case 2:
                            Console.Clear();
                            new Settings();
                            _hand.CreateDice();
                          
                            break;

                        case 3:
                            Console.WriteLine("===============");
                            Scoreboard.Print();
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
                            Console.WriteLine("Which outcome to choose?");

                            var outcomeIndex = Console.ReadLine()[0] - 'a';
                            if (outcomeIndex >= 0 && outcomeIndex < Roll.Outcomes.Count)
                            {
                                Roll.UseOutcome(outcomeIndex);
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
            Roll = new Roll(Scoreboard, _hand.Terninger);
            Roll.Print();
            Console.WriteLine();
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