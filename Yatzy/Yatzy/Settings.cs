using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    class Settings
    {
        public static bool snyd = false;
        public static bool bias;
        public static int snydeGrad;
        public static int antalForsøg = 3;

       public Settings ()
        {
            Setting();
            ShowSettings();
        }
   
        public void Setting()
        {
            Console.WriteLine("Hvor mange gange vil du kunne rulle med terningerne per runde ( imellem 2 - 10 gange?"); 
            string input = Console.ReadLine();
            int tal;
            Int32.TryParse(input, out tal);
            antalForsøg = tal;

            Console.WriteLine("Ønsker du at Snyde? J/N"); // convert to upper
            string SnydeSvar = Console.ReadLine();
            if (SnydeSvar == "J")
            {
                snyd = true;
            }
            else
            {
                snyd = false;
            }
            if (snyd == true)
            {
                Console.WriteLine("Skal dine terninger være positive eller negative biased? P/N");
                string PosNeg = Console.ReadLine(); // convert to upper
                if (PosNeg == "P")
                {
                    bias = true;
                }
                else
                {
                    bias = false;
                }

                Console.WriteLine("Hvor ofte ønsker du at snyde. Indsæt i procent:");
                string inputtet = Console.ReadLine();
                int number;
                Int32.TryParse(inputtet, out number);
                snydeGrad = number;
            }

         

        }

        public void ShowSettings()
        {
            Console.WriteLine("===================");
            Console.WriteLine("Antal forsøg per runde:" + antalForsøg);
            Console.WriteLine("Snyd:" + snyd);
            Console.WriteLine("Pos bias: " + bias);
            Console.WriteLine("Snydegrad: " + snydeGrad);
            Console.WriteLine("===================");
            Console.WriteLine("Dette er dine nuværende settings. Du kan ændre indstillingerne for terningen undervejs");
            Console.WriteLine("Tryk på en hvilken som helst knap for at starte spillet");
            Console.ReadLine();

        }
    }

}
