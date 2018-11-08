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
            List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();
            List<string> Persons = new List<string>();
            int index = 0;

            string geslacht = "";
            int leeftijd = 0;
            string naam = "";
            string bestedingen = "";
            string toestemming = "";
            double kleding = 0;
            double schoenen = 0;
            int jaarinkomen = 0;

            do
            {
                dataList.Add(new Dictionary<string, string>());
                index = dataList.Count - 1;
                Console.WriteLine("Beantwoordt de volgende 4 vragen:");

                naam = CheckName(dataList);
                Persons.Add(naam);

                geslacht = CheckGender(dataList);

                leeftijd = CheckAge(dataList);

                bestedingen = CheckPurchase(dataList);

            } while (NogEenVraag());

            for (int i = 0; i <= index; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Gegevens van {Persons[i]}:");
                Console.WriteLine($"|{"Data",-25}|{"Waarde",10}|");
                foreach (var item in dataList[i])
                Console.WriteLine($"|{item.Key,-25}|{item.Value,10}|");
            }
            Console.ReadLine();
        }

        private static string CheckName(List<Dictionary<string,string>> dataList)
        {
            string naam = "";
            int index = dataList.Count - 1;

            Console.WriteLine("Wat is uw naam? ");
            naam = Convert.ToString(Console.ReadLine().Trim());
            dataList[index]["naam"] = naam.ToString();
            return naam;
        }

        private static string CheckGender(List<Dictionary<string, string>> dataList)
        {
            string geslacht = "";
            bool isValidGender = false;
            int index = dataList.Count - 1;
            do
            {
                Console.WriteLine("Wat is uw geslacht? (M/V) ");
                geslacht = Convert.ToString(Console.ReadLine().ToLower().Trim());
                isValidGender = IsMaleOrFemale(geslacht);
                if (!isValidGender)
                {
                    Console.WriteLine("Het ingevoerde geslacht is geen man of vrouw (M/V)");
                }
                else
                {
                    dataList[index]["geslacht"] = geslacht;
                }
            } while (!isValidGender);
            return geslacht;
        }

        private static bool IsMaleOrFemale(string geslacht)
        {
            return geslacht.ToLower().Trim() == "m" || geslacht.ToLower().Trim() == "v";
        }

        private static int CheckAge(List<Dictionary<string, string>> dataList)
        {
            int index = dataList.Count - 1;
            int leeftijd = 0;
            bool isValidAge = false;
            bool permission = false;
            string toestemming = "";

            Console.WriteLine("Wat is uw leeftijd? ");
            leeftijd = Int32.Parse(Console.ReadLine().Trim());
            isValidAge = isRightAge(leeftijd);
            dataList[index]["leeftijd"] = leeftijd.ToString();
            if (isValidAge)
            {
                permission = AskPermission(leeftijd, toestemming);
                dataList[index]["toestemming"] = permission ? "j" : "n";
                if (permission)
                {
                    string bestedingen = CheckPurchase(dataList);
                }
            }
            return leeftijd;
        }

        private static bool isRightAge(int leeftijd)
        {
            if (leeftijd >= 12 && leeftijd <= 130)
            {
                if (leeftijd <= 16)
                    return true;
                    else return false;
            }
            else
            {
                Console.WriteLine("Bedankt voor uw deelname.");
                return false;
            }
        }

        private static bool AskPermission(int leeftijd, string toestemming)
        {
            while (leeftijd >= 12 && leeftijd <= 16)
            {
                bool isValidAnswer = false;

                do
                {
                    Console.WriteLine("Heeft u toestemming van uw ouders of voogd? (J/N) ");
                    toestemming = Convert.ToString(Console.ReadLine().Trim());
                    isValidAnswer = toestemming.ToLower().Trim() == "j" || toestemming.ToLower().Trim() == "n";
                    if (!isValidAnswer)
                    {
                        Console.WriteLine("Uw invoer is geen ja of nee (J/N)");
                        return false;
                    }
                    else
                    {
                        return toestemming == "n";
                    }
                } while (!isValidAnswer);
            }
            return true;
        }

        public static string CheckPurchase(List<Dictionary<string, string>> dataList)
        {
            string bestedingen = "";
            int index = dataList.Count - 1;
            bool isValidAnswer = false;
            do
            {
                Console.WriteLine("Heeft u vandaag bestedingen aan mode (kleding en/of schoenen) in het winkelcentrum gedaan? (J/N)");
                bestedingen = Console.ReadLine().ToLower().Trim();
                isValidAnswer = bestedingen.ToLower().Trim() == "j" || bestedingen.ToLower().Trim() == "n";
                if (isValidAnswer)
                {
                    if (bestedingen.ToLower().Trim() == "j")
                    {
                        DateTime DatumTijd = DateTime.Now;
                        var Datum = DatumTijd.ToShortDateString();
                        var Tijd = DatumTijd.ToShortTimeString();

                        Console.WriteLine($"Datum: {Datum}");
                        dataList[index]["Datum"] = Datum;
                        Console.WriteLine($"Tijd: {Tijd} uur");
                        dataList[index]["Tijd"] = Tijd;
                        dataList[index]["bestedingen"] = bestedingen.ToString();

                    }
                    if (bestedingen.ToLower().Trim() == "n")
                    {
                        Console.WriteLine("Bedankt voor uw deelname");
                        break;
                    }
                    else
                    {
                        double clothes = BuyCloths();
                        dataList[index]["bestedingen kleren"] = clothes.ToString();
                        double shoes = BuyShoes();
                        dataList[index]["bestedingen schoenen"] = shoes.ToString();
                    }
                }
                else
                {
                    Console.WriteLine("Uw invoer is geen ja of nee (J/N)");
                }
            } while (!isValidAnswer);
            return bestedingen;
        }
        public static double BuyCloths()
        {
            double kleding;
            Console.WriteLine("Hoeveel heeft u aan kleding uitbesteed?");
            kleding = double.Parse(Console.ReadLine());
            return kleding;
        }

        public static double BuyShoes()
        {
            double schoenen;
            Console.WriteLine("Hoeveel heeft u aan schoenen uitbesteed?");
            schoenen = double.Parse(Console.ReadLine());
            return schoenen;
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
                    GaanWeVerder = antwoord.ToLower().Trim() == "j";
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

//    public static void Main(string[] args)
//    {
//        Dictionary<string, string> data = new Dictionary<string, string>();
//        Dictionary<int, int> data2 = new Dictionary<int, int>();

//        string geslacht = "";
//        int leeftijd = 0;
//        string bestedingen = "";
//        string toestemming = "";
//        double kleding = 0;
//        double schoenen = 0;
//        int jaarinkomen = 0;

//        do
//        {
//            Console.WriteLine("Beantwoordt de volgende 4 vragen:");


//            do
//            {
//                Console.WriteLine("Wat is uw geslacht? (M/V) ");
//                geslacht = Convert.ToString(Console.ReadLine().Trim());
//                if (geslacht.ToLower().Trim() != "m" && geslacht.ToLower().Trim() != "v")
//                {
//                    Console.WriteLine("Het ingevoerde geslacht is geen man of vrouw (M/V)");
//                }
//            } while (geslacht.ToLower().Trim() != "m" && geslacht.ToLower().Trim() != "v");


//            Console.WriteLine("Wat is uw leeftijd? ");
//            leeftijd = Int32.Parse(Console.ReadLine().Trim());
//            data.Add("leeftijd", leeftijd.ToString());
//            if (leeftijd >= 12 && leeftijd <= 130)
//            {
//                toestemming = "j";
//                if (leeftijd <= 16)
//                {
//                    do
//                    {
//                        if (toestemming.ToLower().Trim() != "j" && toestemming.ToLower().Trim() != "n")
//                        {
//                            Console.WriteLine("Uw invoer is geen ja of nee (J/N)");
//                        }
//                        Console.WriteLine("Heeft u toestemming van uw ouders of voogd? (J/N) ");
//                        toestemming = Convert.ToString(Console.ReadLine().Trim());
//                    } while (toestemming.ToLower().Trim() != "j" && toestemming.ToLower().Trim() != "n");
//                }
//                if (toestemming.ToLower().Trim() == "n") continue;

//                do
//                {
//                    Console.WriteLine("Heeft u vandaag bestedingen aan mode (kleding en/of schoenen) in het winkelcentrum gedaan? (J/N)");
//                    bestedingen = Console.ReadLine().ToLower().Trim();

//                    if (bestedingen.ToLower().Trim() == "j")
//                    {
//                        DateTime datumTijd = DateTime.Now;
//                        Console.WriteLine($"Datum: {datumTijd.ToLongDateString()}");
//                        Console.WriteLine($"Tijd: {datumTijd.ToLongTimeString()} uur");

//                        Console.WriteLine("Hoeveel heeft u aan kleding uitbesteed?");
//                        kleding = double.Parse(Console.ReadLine());
//                        data.Add("kleding", kleding.ToString());

//                        Console.WriteLine("Hoeveel heeft u aan schoenen uitbesteed?");
//                        schoenen = double.Parse(Console.ReadLine());
//                        data.Add("schoenen", schoenen.ToString());
//                    }
//                    else if (bestedingen.ToLower().Trim() == "n")
//                    {
//                        Console.WriteLine("Bedankt voor uw deelname");
//                        continue;
//                    }
//                    else
//                    {
//                        Console.WriteLine("Uw invoer is geen ja of nee (J/N)");
//                    }
//                } while (bestedingen.ToLower().Trim() != "j" && bestedingen.ToLower().Trim() != "n");
//                if (bestedingen.ToLower().Trim() == "n") continue;


//                do
//                {
//                    Console.WriteLine("Wat is uw jaarinkomen?");
//                    jaarinkomen = Int32.Parse(Console.ReadLine().Trim());


//                    if (jaarinkomen >= 0)
//                    {
//                        continue;
//                    }
//                    else
//                    {
//                        Console.WriteLine("De jaarinkomen is niet correct ingevuld");
//                    }
//                } while (jaarinkomen < 0);
//            }

//            else
//            {
//                Console.WriteLine("De ingevoerde leeftijd komt niet in aanmerking voor de enquête");
//                continue;
//            }

//        } while (NogEenVraag());

//        Console.WriteLine(" ");
//        Console.WriteLine($"|{"Data",-25}|{"Waarde",10}|");
//        foreach (var item in data)

//            Console.WriteLine($"|{item.Key,-25}|{item.Value,10}");
//        Console.ReadLine();

//    }

//    private static string AchterhaalGeslacht(Dictionary<string, string> data)
//    {
//        string geslacht = "";
//        bool isValidGender = false;
//        do
//        {
//            Console.WriteLine("Wat is uw geslacht? (M/V) ");
//            geslacht = Convert.ToString(Console.ReadLine().ToLower().Trim());
//            isValidGender = IsMaleOrFemale(geslacht);
//            if (!isValidGender)
//            {
//                Console.WriteLine("Het ingevoerde geslacht is geen man of vrouw (M/V)");
//            }
//        } while (!isValidGender);
//        return geslacht;
//    }


//    public static bool NogEenVraag()
//    {
//        bool GaanWeVerder = false;
//        string antwoord = "";

//        do
//        {
//            Console.WriteLine("Wilt u nog een persoon invoeren? (J/N) ");
//            antwoord = Console.ReadLine();
//            if (antwoord.ToLower().Trim() == "j" || antwoord.ToLower().Trim() == "n")
//            {
//                if (antwoord.ToLower().Trim() == "n")
//                {
//                    GaanWeVerder = false;
//                    break;
//                }
//                GaanWeVerder = true;
//                break;
//            }
//            else
//            {
//                Console.WriteLine("Uw invoer is geen ja of nee (J/N)");
//            }
//        } while (antwoord.ToLower().Trim() != "j" && antwoord.ToLower().Trim() != "n");
//        return GaanWeVerder;
//    }
//}
