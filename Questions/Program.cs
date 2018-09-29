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
        •	Er wordt een vraag gesteld: Wat is uw geslacht? (M/V)? 
        •	Antwoord wordt ingelezen en bewaard 
        •	Er wordt een vraag gesteld: Wat is uw leeftijd? 
        •	Antwoord wordt ingelezen en bewaard 
        •	Er wordt een vraag gesteld: Wat heeft u vandaag in het winkelcentrum besteed aan mode? (minstens 5 euro)? 
        •	Antwoord wordt ingelezen en bewaard 
        •	Er wordt een vraag gesteld: Wat is uw jaarinkomen?
        •	Antwoord wordt ingelezen en bewaard
        •	Enzovoort

        Als men voor “J” kiest, dan vraagt de applicatie opnieuw de vier vragen. Indien men voor “N” koos, dan stop de applicatie en toont de volgende gegevens in een staafdiagram en een tabel.
        De doeleinde van de enquête is:
        a.	Gemiddelde bestedingen van de man en vrouw 
        b.	Mediaan bestedingen van de man en vrouw 
        c.	Alle gegevens weergeven van de hoogste bestedingen van de man en vrouw 
        d.  De aantal deelnemers moeten in de tabel voorkomen
        e.  De nul bedragen, geen toestemming en geen bestedingen moeten uitgefilterd worden
        e.  Sorteer gemiddelde, mediaan, bestedingen op leeftijd, categorie, jaarinkomen
            Belastingschijf 	Loon (jaarbasis) 	
            schijf 1 	        Vanaf € 0 t/m € 20.142 	
            schijf 2 	        Vanaf € 20.143 t/m € 34.404 	
            schijf 3 	        Vanaf € 34.405 t/m € 68.507 	
            schijf 4 	        Meer dan € 68.507

        Er moeten rekening gehouden met de volgende punten.
        •	Geen namen in Arabisch, Chinese karakters, etc 
        •	Geen negatieve leeftijd en leeftijd tussen 12 jaar en 130 jaar 
        •	Leeftijd onder 16 jaar moeten toestemming krijgen van ouders of voogd doormiddel van een pop-up 
        •	Geslacht kan alleen man of vrouw zijn, geen gender neutraal 
        •	Bestedingen zijn in euro’s, vanaf 0 euro met bedragen twee decimalen achter de komma's
        •	Bestedingen moeten van vandaag zijn 
        •   Mode onderverdelen in kleding en schoenen
        •   Jaarinkomen in hele getallen en verdeeld in diagram en tabel */

        public static void Main(string[] args)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string geslacht = "";
            int leeftijd = 0;
            string bestedingen = "";
            string toestemming = "";
            double kleding = 0;
            double schoenen = 0;
            int jaarinkomen = 0;

            do
            {
                Console.WriteLine("Beantwoordt de volgende 4 vragen:");

                geslacht = AchterhaalGeslacht(data);
                //do
                //{
                //    Console.WriteLine("Wat is uw geslacht? (M/V) ");
                //    geslacht = Convert.ToString(Console.ReadLine().Trim());
                //    if (geslacht.ToLower().Trim() != "m" && geslacht.ToLower().Trim() != "v")
                //    {
                //        Console.WriteLine("Het ingevoerde geslacht is geen man of vrouw (M/V)");
                //    }
                //} while (geslacht.ToLower().Trim() != "m" && geslacht.ToLower().Trim() != "v");
                //Data.Add("geslacht", geslacht);

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
                            Console.WriteLine("Heeft u toestemming van uw ouders of voogd? (J/N) ");
                            toestemming = Convert.ToString(Console.ReadLine().Trim());
                        } while (toestemming.ToLower().Trim() != "j" && toestemming.ToLower().Trim() != "n");
                    }
                    if (toestemming.ToLower().Trim() == "n") continue;
                    
                    do
                    {
                        Console.WriteLine("Heeft u vandaag bestedingen aan mode (kleding en/of schoenen) in het winkelcentrum gedaan? (J/N)");
                        bestedingen = Console.ReadLine().ToLower().Trim();

                        if (bestedingen.ToLower().Trim() == "j")
                        {
                            DateTime datumTijd = DateTime.Now;
                            Console.WriteLine($"Datum: {datumTijd.ToLongDateString()}");
                            Console.WriteLine($"Tijd: {datumTijd.ToLongTimeString()} uur");

                            Console.WriteLine("Hoeveel heeft u aan kleding uitbesteed?");
                            kleding = double.Parse(Console.ReadLine());
                            Data.Add("kleding", kleding.ToString());

                            Console.WriteLine("Hoeveel heeft u aan schoenen uitbesteed?");
                            schoenen = double.Parse(Console.ReadLine());
                            Data.Add("schoenen", schoenen.ToString());
                        }
                        else if (bestedingen.ToLower().Trim() == "n")
                        {
                            Console.WriteLine("Bedankt voor uw deelname");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Uw invoer is geen ja of nee (J/N)");
                        }
                    } while (bestedingen.ToLower().Trim() != "j" && bestedingen.ToLower().Trim() != "n");
                    if (bestedingen.ToLower().Trim() == "n") continue;
                    

                    do
                    {
                        Console.WriteLine("Wat is uw jaarinkomen?");
                        jaarinkomen = Int32.Parse(Console.ReadLine().Trim());
                        

                        if (jaarinkomen >= 0)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("De jaarinkomen is niet correct ingevuld");
                        }
                    } while (jaarinkomen < 0);
                }

                else
                {
                    Console.WriteLine("De ingevoerde leeftijd komt niet in aanmerking voor de enquête");
                    continue;
                }

            } while (NogEenVraag());

            Console.WriteLine(" ");
            Console.WriteLine($"|{"Data",-25}|{"Waarde",10}|");
            foreach (var item in Data)
            
                Console.WriteLine($"|{item.Key,-25}|{item.Value,10}");
                Console.ReadLine();
            
        }

            private static string AchterhaalGeslacht(Dictionary<string, string> data)
        {
            string geslacht = "";
            bool isValidGender = false;
            do
            {
                Console.WriteLine("Wat is uw geslacht? (M/V) ");
                geslacht = Convert.ToString(Console.ReadLine().Trim());
                isValidGender = IsMaleOrFemale(geslacht);
                if (!isValidGender)
                {
                    Console.WriteLine("Het ingevoerde geslacht is geen man of vrouw (M/V)");
                }
            } while (!isValidGender);
            return geslacht;
        }

        private static bool IsMaleOrFemale(string geslacht)
        {
            if (geslacht.Contains("m"))
            {
                return true;
            }

            if (geslacht.Contains("v"))
            {
                return true;
            }
            return false;
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
                    Console.WriteLine("Uw invoer is geen ja of nee (J/N)");
                }
            } while (antwoord.ToLower().Trim() != "j" && antwoord.ToLower().Trim() != "n");
            return GaanWeVerder;
            }
    }
}