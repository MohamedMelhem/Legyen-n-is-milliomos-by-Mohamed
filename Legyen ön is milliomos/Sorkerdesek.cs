using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legyen_ön_is_milliomos
{
	using System;
	using System.Collections.Generic;
	using System.IO;

	public class Sorkerdes
	{
		public string KerdesSzoveg { get; set; }
		public List<string> Valaszok { get; set; }
		public string HelyesSorrend { get; set; }

		public Sorkerdes(string sor)
		{

			var reszek = sor.Split(';');
			KerdesSzoveg = reszek[0];
			Valaszok = new List<string> { reszek[1], reszek[2], reszek[3], reszek[4] };
			HelyesSorrend = reszek[5];
		}

		public static List<Sorkerdes> BeolvasFajlbol(string fajlNev)
		{
			var sorkerdesek = new List<Sorkerdes>();

			if (File.Exists(fajlNev))
			{
				foreach (var sor in File.ReadAllLines(fajlNev))
				{
					if (!string.IsNullOrWhiteSpace(sor))
					{
						sorkerdesek.Add(new Sorkerdes(sor));
					}
				}
			}
			else
			{
				Console.WriteLine("A fájl nem található: " + fajlNev);
			}

			return sorkerdesek;
		}

		public void Kiir()
		{
			Console.WriteLine(KerdesSzoveg);
			foreach (var valasz in Valaszok)
			{
				Console.WriteLine(valasz);
			}
		}
	}
}
