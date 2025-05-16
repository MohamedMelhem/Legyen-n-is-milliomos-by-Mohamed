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
        int kerdesSzint = 0;


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
            while (kerdesSzint < 15)
            {
                Kerdes kerdes = kerdesek.VeletlenKerdesKivalasztas();
                bool valaszolva = false;
                List<char> megengedettValaszok = new List<char> { 'A', 'B', 'C', 'D' };

                while (!valaszolva)
                {
                    Console.WriteLine($"\n{kerdesSzint + 1}. kérdés - Nyeremény: {nyeremenyek[kerdesSzint + 1]}");
                    Console.WriteLine(kerdes);


                    string input = Console.ReadLine().Trim().ToUpper();



                    if (input.Length == 1 && megengedettValaszok.Contains(input[0]))
                    {
                        valaszolva = EllenorizValaszt(input, kerdes);
                        if (!valaszolva) return;
                    }
                    else
                    {
                        Console.WriteLine("Érvénytelen válasz. Kérjük, válasszon a megadott lehetőségek közül.");
                    }
                }
            }

            Console.WriteLine("\nGRATULÁLOK! Ön megnyerte a főnyereményt: 40 000 000 Ft!");
        }






    }
}
