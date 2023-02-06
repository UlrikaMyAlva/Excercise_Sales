using Inlämingsuppgift2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Pseudokod:

            // Skriv in antalet säljare.
            // Skriv in namn, personnummer, distrikt och antal sålda artiklar på varje säljare.
            // Sorterar antalet sålda artiklar från minst till störst.
            // Skapa en lista för varje nivå om hur säljare det är i varje nivå.
            // Skriv ut hur många säljare som har nått nivå 1-4 baserat på hur många artiklar varje säljare har sålt.
            // Skriv ut hur många säljare det är i varje nivå efter att alla säljare har presenterats i den nivån.
            // Skriv allt till en textfil.


            // 1. Be om antalet säljare som ska registreras.
            Console.WriteLine("Välkommen till Säljdata! Hur många säljare vill du registrera? ");
            int registrering = int.Parse(Console.ReadLine());
            Console.Clear();

            //Sätter storleken på Array class
            Säljdata[] säljarTeam = new Säljdata[registrering];


            //Ber om input
            // Registrerar namn, personnummer, distrikt och antal sålda artiklar.
            for (int i = 0; i < registrering; i++)
            {

                säljarTeam[i] = new Säljdata();

                Console.WriteLine("Säljare " + (1 + i));

                Console.WriteLine("Namn: ");
                säljarTeam[i].namn = Console.ReadLine();

                Console.WriteLine("Personnummer: ");
                säljarTeam[i].personnummer = double.Parse(Console.ReadLine());

                Console.WriteLine("Distrikt: ");
                säljarTeam[i].distrikt = Console.ReadLine();

                Console.WriteLine("Antal Sålda artiklar: ");
                säljarTeam[i].såldaArtiklar = int.Parse(Console.ReadLine());

                Console.Clear();

            }

            //Bubbelsort
            // Sorterar antalet sålda artiklar från minst antal sålda artiklar till mest antal sålda artiklar.

            for (int j = 0; j < registrering + 2; j++)
            {

                for (int i = 0; i < registrering - 1; i++)
                {
                    if (säljarTeam[i].såldaArtiklar > säljarTeam[i + 1].såldaArtiklar)
                    {
                        
                        string tempNamn = säljarTeam[i + 1].namn;
                        säljarTeam[i + 1].namn = säljarTeam[i].namn;
                        säljarTeam[i].namn = tempNamn;

                        double tempPersonnummer = säljarTeam[i + 1].personnummer;
                        säljarTeam[i + 1].personnummer = säljarTeam[i].personnummer;
                        säljarTeam[i].personnummer = tempPersonnummer;

                        string tempDistrikt = säljarTeam[i + 1].distrikt;
                        säljarTeam[i + 1].distrikt = säljarTeam[i].distrikt;
                        säljarTeam[i].distrikt = tempDistrikt;

                        int tempSåldaArtiklar = säljarTeam[i + 1].såldaArtiklar;
                        säljarTeam[i + 1].såldaArtiklar = säljarTeam[i].såldaArtiklar;
                        säljarTeam[i].såldaArtiklar = tempSåldaArtiklar;


                    }

                }

                j++;


            }



            // Listor, där antalet säljare i varje nivå registreras.
            List<int> listaNivå4 = new List<int>();
            List<int> listaNivå3 = new List<int>();
            List<int> listaNivå2 = new List<int>();
            List<int> listaNivå1 = new List<int>();


            for (int i = 0; i < registrering; i++)
            {
                if (säljarTeam[i].såldaArtiklar > 200)
                {
                    listaNivå4.Add(i);
                }
                else if (säljarTeam[i].såldaArtiklar > 100 && säljarTeam[i].såldaArtiklar < 199)
                {
                    listaNivå3.Add(i);
                }
                else if (säljarTeam[i].såldaArtiklar > 50 && säljarTeam[i].såldaArtiklar < 99)
                {
                    listaNivå2.Add(i);
                }
                else
                {
                    listaNivå1.Add(i);
                }
            }

            int nivå4 = 0;
            int nivå3 = 0;
            int nivå2 = 0;
            int nivå1 = 0;

            // Här skapas objektet som gör att man kan skriva programmet till en fil.
            StreamWriter tillFil = new StreamWriter("säljare.txt");


            Console.WriteLine(String.Format("{0,10} {1,18} {2,14} {3,22}\n", "Namn", "Personnummer", "Distrikt", "Antal Sålda Varor"));
            tillFil.WriteLine(String.Format("{0,10} {1,18} {2,14} {3,22}\n", "Namn", "Personnummer", "Distrikt", "Antal Sålda Varor"));
            Console.WriteLine("________________________________________________________________________");

            // Här skrivs säljarna som tilldelas nivå 1 till nivå 4.

            //NIVÅ 1
            for (int i = 0; i < registrering; i++)
            {
                if (säljarTeam[i].såldaArtiklar < 50)
                {

                    // Här skrivs nivå 1 till Console samt till en fil.

                    Console.WriteLine(String.Format("{0,10} {1,18} {2, 14} {3,22}\n", säljarTeam[i].namn, säljarTeam[i].personnummer, säljarTeam[i].distrikt, säljarTeam[i].såldaArtiklar));
                    tillFil.WriteLine(String.Format("{0,10} {1,18} {2, 14} {3,22}\n", säljarTeam[i].namn, säljarTeam[i].personnummer, säljarTeam[i].distrikt, säljarTeam[i].såldaArtiklar));


                    nivå1++;

                    // När alla säljare i denna nivå har skrivits ut skrivs också antalet säljare ut nedan.

                    if (listaNivå1.Count == nivå1)
                    {
                        Console.WriteLine("________________________________________________________________________\n");
                        Console.WriteLine("Så här många säljare har nått nivå 1: " + listaNivå1.Count());
                        Console.WriteLine("________________________________________________________________________");

                        tillFil.WriteLine("Så här många säljare har nått nivå 1: " + listaNivå1.Count());

                    }

                }
            }

            //NIVÅ 2
            for (int i = 0; i < registrering; i++)
            {
                if (säljarTeam[i].såldaArtiklar > 50 && säljarTeam[i].såldaArtiklar < 99)
                {

                    Console.WriteLine(String.Format("{0,10} {1,18} {2, 14} {3,22}\n", säljarTeam[i].namn, säljarTeam[i].personnummer, säljarTeam[i].distrikt, säljarTeam[i].såldaArtiklar));
                    tillFil.WriteLine(String.Format("{0,10} {1,18} {2, 14} {3,22}\n", säljarTeam[i].namn, säljarTeam[i].personnummer, säljarTeam[i].distrikt, säljarTeam[i].såldaArtiklar));

                    nivå2++;

                    if (listaNivå2.Count == nivå2)
                    {
                        Console.WriteLine("________________________________________________________________________\n");
                        Console.WriteLine("Så här många säljare har nått nivå 2: " + listaNivå2.Count());
                        Console.WriteLine("________________________________________________________________________");

                        tillFil.WriteLine("Så här många säljare har nått nivå 2: " + listaNivå2.Count());
                    }

                }
            }

            //NIVÅ 3
            for (int i = 0; i < registrering; i++)
            {
                if (säljarTeam[i].såldaArtiklar > 100 && säljarTeam[i].såldaArtiklar < 199)
                {

                    Console.WriteLine(String.Format("{0,10} {1,18} {2, 14} {3,22}\n", säljarTeam[i].namn, säljarTeam[i].personnummer, säljarTeam[i].distrikt, säljarTeam[i].såldaArtiklar));
                    tillFil.WriteLine(String.Format("{0,10} {1,18} {2, 14} {3,22}\n", säljarTeam[i].namn, säljarTeam[i].personnummer, säljarTeam[i].distrikt, säljarTeam[i].såldaArtiklar));

                    nivå3++;

                    if (listaNivå3.Count == nivå3)
                    {
                        Console.WriteLine("________________________________________________________________________\n");
                        Console.WriteLine("Så här många säljare har nått nivå 3: " + listaNivå3.Count());
                        Console.WriteLine("________________________________________________________________________");

                        tillFil.WriteLine("Så här många säljare har nått nivå 3: " + listaNivå3.Count());
                    }
                }
            }

            //NIVÅ 4
            for (int i = 0; i < registrering; i++)
            {
                if (säljarTeam[i].såldaArtiklar > 200)
                {

                    Console.WriteLine(String.Format("{0,10} {1,18} {2, 14} {3,22}\n", säljarTeam[i].namn, säljarTeam[i].personnummer, säljarTeam[i].distrikt, säljarTeam[i].såldaArtiklar));
                    tillFil.WriteLine(String.Format("{0,10} {1,18} {2, 14} {3,22}\n", säljarTeam[i].namn, säljarTeam[i].personnummer, säljarTeam[i].distrikt, säljarTeam[i].såldaArtiklar));

                    nivå4++;

                    if (listaNivå4.Count == nivå4)
                    {
                        Console.WriteLine("________________________________________________________________________\n");
                        Console.WriteLine("Så här många säljare har nått nivå 4: " + listaNivå4.Count());
                        Console.WriteLine("________________________________________________________________________");

                        tillFil.WriteLine("Så här många säljare har nått nivå 4: " + listaNivå4.Count());

                    }

                }
            }


            tillFil.Close();
            Console.ReadLine();

        }

    }
}

