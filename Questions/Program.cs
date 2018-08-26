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

        public static void Main(string[] args)
        {
            string geslacht;
            int leeftijd;
            int bestedingen;
            string toestemming;
            do
            {
                Console.WriteLine("Beantwoordt de volgende 3 vragen:");
                do
                {
                    Console.Write("Wat is uw geslacht? (m/v) ");
                    geslacht = Convert.ToString(Console.ReadLine());
                } while (geslacht.ToLower() != "m" && geslacht.ToLower() != "v");
                do
                {
                    Console.Write("Wat is uw leeftijd? ");
                    leeftijd = Int32.Parse(Console.ReadLine());
                    if (leeftijd > 12 && leeftijd < 16)
                    {
                        Console.WriteLine("Hebt u toestemming van uw ouders of voogd? (J/N)");
                    }
                    else if (leeftijd <= 12 || leeftijd >= 130)
                    {
                        Console.WriteLine("Uw ingevoerde leeftijd komt niet in aanmerking voor de enquête");
                        continue;
                    }
                    toestemming = Convert.ToString(Console.ReadLine());
                } while (toestemming != "j");
                Console.Write("Wat heeft u vandaag besteed? ");
                bestedingen = Int32.Parse(Console.ReadLine());
            } while (NogEenVraag());
        }

        public static bool NogEenVraag()
        {
            Console.WriteLine("Wilt u nog een persoon invoeren? (J/N) ");
            bool result = Console.ReadLine().ToLower() == "j";
            return result;
        }
    }
}
