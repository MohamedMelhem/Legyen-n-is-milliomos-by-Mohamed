using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legyen_ön_is_milliomos
{
	internal class Kerdes
	{
		public int Szint { get; }
		public string Szoveg { get; }
		public List<string> Valaszok { get; }
		public string HelyesValasz { get; }
		public string Kategoria { get; }

		public Kerdes(string sor)
		{
			var elemek = sor.Split('|');
			Szint = int.Parse(elemek[0]);
			Szoveg = elemek[1];
			Valaszok = new List<string> { elemek[2], elemek[3], elemek[4], elemek[5] };
			HelyesValasz = elemek[6];
			Kategoria = elemek[7];
		}

		public void Kiir()
		{
			Console.WriteLine(Szoveg);
			foreach (var v in Valaszok)
				Console.WriteLine(v);
		}

		public bool Ellenoriz(string valasz)
		{
			return valasz.ToUpper() == HelyesValasz;
		}
	}
}
