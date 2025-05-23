using System;
using System.Collections.Generic;
using System.Linq;

namespace Legyen_ön_is_milliomos
{
	internal class Jatek
	{
		Kerdesek kerdesek;
		int kerdesSzint = 1;
		int felezoindex = 0;
		int kozonsegindex = 0;
		bool felezosHasznalt = false; 
		bool kozonsegiKerdesHasznalt = false; 

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
                Console.WriteLine($"                             5000 ft\n                         10 000 Ft 25 000ft 50 000ft \n        100 000 ft 200 000ft 300 000ft 500 000ft 800 000ft\n  1 500 000ft 3 000 000 5 000 000 10 000 000 20 000 000 40 000 000");
                Console.WriteLine();
                JatekInditasa();
			}
			else
			{
				Console.WriteLine($"Sajnálom, rossz válasz. Nem indulhat a játék.\n" +
					$"Helyes válasz: {sorkerdes.Helyessorrend}");
			}
		}

		private void Nyerenyemek() { 
		
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

                    Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"\n{kerdesSzint}. kérdés - Nyeremény: {nyeremenyek[kerdesSzint]}");
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine(kerdes);

		
					Console.WriteLine("\nSegítségek:");
					Console.WriteLine("1. Felezős segítség (F)");
					Console.WriteLine("2. Közönségi kérdés (K)"); 
					Console.WriteLine("3. Válasz: A/B/C/D");

					Console.Write("Adja meg a válaszát vagy segítség kérését: ");
					string input = Console.ReadLine().Trim().ToUpper();

					if (input == "F" && felezoindex < 0)
					{
						felezoindex ++;
						FelezosSegitseg(kerdes);
						felezosHasznalt = true;
						continue;
					}
					if (input == "K" && kozonsegindex < 0)
					{
						kozonsegindex ++;
						KozoensegiKerdest(kerdes);
						kozonsegiKerdesHasznalt = true;
						continue;
					}
					else
					{
						Console.WriteLine("Érvénytelen válasz. Ön már felhasználta ezt.");
					}

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
				Console.WriteLine("Szeretne-e megállni? (i: igen / n: nem)");
				Console.Write("Adja meg a válaszát: ");
				valasz = Console.ReadLine();
				if (valasz == "i")
				{
					Console.WriteLine($"Megállt a játékban. Köszönjük a részvételt.\n" +
						$"Nyereménye: {nyeremenyek[kerdesSzint - 1]}");
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

			Console.WriteLine($"Sajnos hibás választ adott meg.\n" +
				$"Viszont garantált nyereménye: {nyeremenyek[index]}");
		}

		private bool EllenorizValaszt(string input, Kerdes kerdes)
		{
			if (input[0] == kerdes.Helyesvalasz[0])
			{
				kerdesSzint++;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nHelyes válasz!");
				Console.ForegroundColor = ConsoleColor.White;
				return true;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"\nRossz válasz! A helyes válasz: {kerdes.Helyesvalasz}");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"Ön nyert: {nyeremenyek[Math.Min(kerdesSzint, 5)]}");
				return false;
			}
		}

		private void FelezosSegitseg(Kerdes kerdes)
		{
			var helyesValasz = kerdes.Helyesvalasz;
			var helytelenValaszok = kerdes.Valaszok.Where(v => v != helyesValasz).ToList();
			var valaszok = new List<string> { helyesValasz, helytelenValaszok[0] };

			var random = new Random();
			valaszok = valaszok.OrderBy(x => random.Next()).ToList();
			Console.WriteLine($"\nFelezős segítség: Az alábbi két válasz közül választhat:");
			Console.WriteLine($"A: {valaszok[0]}");
			Console.WriteLine($"B: {valaszok[1]}");
		}

		private void KozoensegiKerdest(Kerdes kerdes)
		{
			var helyesValasz = kerdes.Helyesvalasz;
			var helytelenValaszok = kerdes.Valaszok.Where(v => v != helyesValasz).ToList();
			var random = new Random();

			// Képzeljük el, hogy a közönség válaszai
			var kozonsegiValasz = new List<string> { helyesValasz };
			while (kozonsegiValasz.Count < 4)
			{
				var randomValasz = helytelenValaszok[random.Next(helytelenValaszok.Count)];
				if (!kozonsegiValasz.Contains(randomValasz))
					kozonsegiValasz.Add(randomValasz);
			}

			kozonsegiValasz = kozonsegiValasz.OrderBy(x => random.Next()).ToList(); 

			Console.WriteLine("\nKözönség válaszai:");
			foreach (var valasz in kozonsegiValasz)
			{
				Console.WriteLine(valasz);
			}
			Console.WriteLine("\nA közönség véleménye alapján válasszon egy választ!");
		}
	}
}
