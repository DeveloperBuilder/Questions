﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    class Program
    {
        /*•	De applicatie start op 
        •	Er wordt een vraag gesteld: Wat is uw geslacht? 
        •	Antwoord wordt ingelezen en bewaard 
        •	Er wordt een vraag gesteld: Wat is uw leeftijd? 
        •	Antwoord wordt ingelezen en bewaard 
        •	Er wordt een vraag gesteld: Wat heeft u vandaag besteed? 
        •	Antwoord wordt ingelezen en bewaard 

        Als men voor “J” kiest, dan vraagt de applicatie opnieuw de drie vragen. Indien men voor “N” koos, dan stop de applicatie en toont de volgende gegevens in 3 tabellen.
        De doeleinde van de enquête is:
        a.	Gemiddelde bestedingen van de man en vrouw 
        b.	Mediaan bestedingen van de man en vrouw 
        c.	Alle gegevens weergeven van de hoogste bestedingen van de man en vrouw 
        Er moeten rekening gehouden met de volgende punten.
        •	Geen namen in Arabisch, Chinese karakters, etc 
        •	Geen negatieve leeftijd en leeftijd tussen 12 jaar en 130 jaar 
        •	Leeftijd onder 16 jaar moeten toestemming krijgen van ouders of voogd doormiddel van een pop-up 
        •	Geslacht kan alleen man of vrouw zijn, geen gender neutraal 
        •	Bestedingen zijn in euro’s, met minimaal een sprong van 5 euro (dus 5, 10, 15, etc) 
        •	Bestedingen moeten van vandaag zijn */

        static void Main(string[] args)
        {
            string geslacht;
            int leeftijd;
            int bestedingen;
            string antwoord;
            do
            {
                Console.WriteLine("Beantwoordt de volgende 3 vragen:");
                Console.Write("Wat is uw geslacht? (m/v) ");
                geslacht = Convert.ToString(Console.ReadLine());
                while (geslacht == "m")
                {
                    while (geslacht == "v")
                    {
                        Console.WriteLine(geslacht);
                    }
                }
                if (geslacht == "m")
                {
                    if (geslacht == "v")
                    {

                    }
                }
                else
                {
                    Console.WriteLine("Kies m of v");
                }
                Console.Write("Wat is uw leeftijd? ");
                leeftijd = Int32.Parse(Console.ReadLine());
                Console.Write("Wat heeft u vandaag besteed? ");
                bestedingen = Int32.Parse(Console.ReadLine());
                Console.Write("Wilt u nog een persoon invoeren? (J/N) ");
                antwoord = Console.ReadLine();
            } while (true);
        }
    }
}
