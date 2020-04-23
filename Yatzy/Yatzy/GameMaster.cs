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
        public BægerPos _bægerpos { get; private set; } = new BægerPos();
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
                    Console.WriteLine("You have now thrown the dices 3 times. Your last throw:");
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
                    Console.WriteLine("3.) for quitting the game");
                }
                if (!_hand.FirstRound && hasRemainingTries())
                {
                    Console.WriteLine("4.) Chose the dices you want to reroll with ',' symbol between");
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
                            if (Settings.snyd == true)
                            {
                                _bægerpos.RerollAll();
                                tries--;
                            }
                            else
                            {
                                _hand.RerollAll();
                                tries--;
                            }
                            break;

                        case 2:
                            Console.Clear();
                             new Settings();
                          
                            break;

                        case 3:
                            GameRunning = false;
                            Console.WriteLine("Thx for playing byebye - enter to quit");
                            break;

                        case 4:
                            tries--;
                            _hand.KeepDices(AskUserForDices());
                            break;


                        default:
                            break;
                    }


                }



            }

            Console.ReadLine();



        }

        private int[] AskUserForDices()
        {
            Console.WriteLine("What dices you want to keep?\nPlease seperate it with a comma like so 0,0,0 (for example)");
            if (Settings.snyd == true)
            {
                _bægerpos.ShowDices();
            }
            else
            {
                _hand.ShowDices();
            }
            
            string userInput = Console.ReadLine();

            string[] chosenDices = userInput.Split(',');

            int[] toReroll = new int[chosenDices.Length];


            for (int i = 0; i < chosenDices.Length; i++)
            {
                toReroll[i] = int.Parse(chosenDices[i]);
            }

            foreach (int value in toReroll)
            {
                Console.Write(value);
            }

            return toReroll;

        }

        private bool hasRemainingTries()
        {
            return tries > 0;

        }
    }
}