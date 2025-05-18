using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legyen_ön_is_milliomos
{
	internal class Jatek
	{
        Kerdesek kerdesek;
        int kerdesSzint = 1;


        string[] nyeremenyek = {
        "0 Ft", "5 000 Ft", "10 000 Ft", "25 000 Ft", "50 000 Ft", "100 000 Ft",
        "200 000 Ft", "300 000 Ft", "500 000 Ft", "800 000 Ft", "1 500 000 Ft",
        "3 000 000 Ft", "5 000 000 Ft", "10 000 000 Ft", "20 000 000 Ft", "40 000 000 Ft" };

        public Jatek(Kerdesek kerdesek)
        {
            this.kerdesek = kerdesek;
        }



        public void Inditas()
        {
            Console.WriteLine("Üdvözlöm a Legyen Ön is milliomos játékban!");
            Console.WriteLine("\nElőször jön egy SORKÉRDÉS. Ha ezt jól oldja meg, indulhat a játék!\n");

            Sorkerdes sorkerdes = kerdesek.VeletlenSorkerdesKivalasztas();
            Console.WriteLine(sorkerdes);

            Console.Write("\nÍrja be a sorrendet (pl. ACBD): ");
            string valasz = Console.ReadLine().Trim().ToUpper();

            if (valasz == sorkerdes.Helyessorrend)
            {
                Console.WriteLine("\nHelyes sorrend! Kezdődik a játék!");
                JatekInditasa();
            }
            else
            {
                Console.WriteLine($"Sajnálom, rossz válasz. Nem indulhat a játék.\n" +
                    $"Helyes válasz: {sorkerdes.Helyessorrend}");
            }
        }
        private void JatekInditasa()
        {
            while (kerdesSzint < 16)
            {
                Kerdes kerdes = kerdesek.VeletlenKerdesKivalasztas(kerdesSzint);
                bool valaszolva = false;
                List<char> megengedettValaszok = new List<char> { 'A', 'B', 'C', 'D' };

                while (!valaszolva)
                {
                    Console.WriteLine($"\n{kerdesSzint}. kérdés - Nyeremény: {nyeremenyek[kerdesSzint]}");
                    Console.WriteLine(kerdes);


                    string input = Console.ReadLine().Trim().ToUpper();



                    if (input.Length == 1 && megengedettValaszok.Contains(input[0]))
                    {
                        valaszolva = EllenorizValaszt(input, kerdes);
                        if (!valaszolva) 
                        {
                            GarantaltNyeremeny();
                            return;
                        }
                        

                        if (Megalle())
                        {
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Érvénytelen válasz. Kérjük, válasszon a megadott lehetőségek közül.");
                    }
                    
                }
            }

            Console.WriteLine("\nGRATULÁLOK! Ön megnyerte a főnyereményt: 40 000 000 Ft!");
        }

        private bool Megalle()
        {
            string valasz;
            if (kerdesSzint != 1 && kerdesSzint != 5 && kerdesSzint != 10)
            {
                Console.WriteLine("Szeretne e megállni?(i:igen / n: nem");
                valasz =  Console.ReadLine();
                if (valasz == "i")
                {
                    Console.WriteLine($"Megállt a játékba, Köszönjük résztvételét\n" +
                        $"Nyereménye: {nyeremenyek[kerdesSzint]}");

                    return true;
                }
            }
            return false;
          

        }

        private void GarantaltNyeremeny()
        {
            int index = 0;
            if (kerdesSzint > 5)
            {
                index = 5;
            }
            if (kerdesSzint > 10)
            {
                index = 10;
            }

            Console.WriteLine($"Sajnos Hibás Választ adott meg.\n" +
                $" Viszont garantált nyereméyne : {nyeremenyek[index]}");
        }
                                              
        private bool EllenorizValaszt(string input, Kerdes kerdes)
        {
            if (input[0] == kerdes.Helyesvalasz[0])
            {  
                kerdesSzint++;
                Console.WriteLine("\nHelyes válasz!");
                return true;
            }
            else
            {
                Console.WriteLine($"\nRossz válasz! A helyes válasz: {kerdes.Helyesvalasz}");
                Console.WriteLine($"Ön nyert: {nyeremenyek[Math.Min(kerdesSzint, 5)]}");
                return false;
            }
        }
             




    }
}
