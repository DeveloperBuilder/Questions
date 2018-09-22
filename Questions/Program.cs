using System;
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
            string geslacht = "";
            int leeftijd = 0;
            double bestedingen = 0;
            string toestemming = "";

            do
            {
                Console.WriteLine("Beantwoord de volgende 3 vragen:");
                do
                {
                    Console.WriteLine("Wat is uw geslacht? (M/V) ");
                    geslacht = Convert.ToString(Console.ReadLine().Trim());
                    if (geslacht.ToLower().Trim() != "m" && geslacht.ToLower().Trim() != "v")
                    {
                        Console.WriteLine("Uw ingevoerde geslacht is geen man of vrouw (M/V)");
                    }
                } while (geslacht.ToLower().Trim() != "m" && geslacht.ToLower().Trim() != "v");

                Console.WriteLine("Wat is uw leeftijd? ");
                leeftijd = Int32.Parse(Console.ReadLine().Trim());
                if (leeftijd >= 12 && leeftijd <= 130)
                {
                    toestemming = "j";
                    if (leeftijd <= 16)
                    {
                        do
                        {
                            if (toestemming.ToLower().Trim() != "j" && toestemming.ToLower().Trim() != "n")
                            {
                                Console.WriteLine("Uw invoer is geen ja of nee (J/N)");
                            }
                            Console.WriteLine("Hebt u toestemming van uw ouders of voogd? (J/N) ");
                            toestemming = Convert.ToString(Console.ReadLine().Trim());
                        } while (toestemming.ToLower().Trim() != "j" && toestemming.ToLower().Trim() != "n");
                    }
                    if (toestemming.ToLower().Trim() == "n") continue;

                    Console.WriteLine("Wat heeft u vandaag besteed? (minstens 5 euro)");
                    bestedingen = Double.Parse(Console.ReadLine().Trim());
                    if (bestedingen > 0)
                    {
                        if (bestedingen > 5)
                        {
                            Console.WriteLine($"Uw ingevoerde bedrag wordt afgerond naar: {Math.Round(bestedingen / 5) * 5} euro");

                            DateTime datumTijd = DateTime.Now;
                            Console.WriteLine($"Datum: {datumTijd.ToLongDateString()}");
                            Console.WriteLine($"Tijd: {datumTijd.ToLongTimeString()} uur");
                        }
                        else
                        {
                            Console.WriteLine("Uw bedrag is kleiner dan 5 euro");
                            continue;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Uw ingevoerde leeftijd komt niet in aanmerking voor de enquête");
                    continue;
                }

            } while (NogEenVraag());
        }

            public static bool NogEenVraag()
            {
                bool GaanWeVerder = false;
                string antwoord = "";

            do
            {
                Console.WriteLine("Wilt u nog een persoon invoeren? (J/N) ");
                antwoord = Console.ReadLine();
                if (antwoord.ToLower().Trim() == "j" || antwoord.ToLower().Trim() == "n")
                {
                    if (antwoord.ToLower().Trim() == "n")
                    {
                        GaanWeVerder = false;
                        break;
                    }
                    GaanWeVerder = true;
                    break;
                }
                else
                {
                    Console.WriteLine("De invoer is geen ja of nee (J/N)");
                }
            } while (antwoord.ToLower().Trim() != "j" && antwoord.ToLower().Trim() != "n");
            return GaanWeVerder;
            }
    }
}