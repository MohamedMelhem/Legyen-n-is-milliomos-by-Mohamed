using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legyen_ön_is_milliomos
{
	internal class Kerdesek
	{
		private List<Kerdes> osszes = new List<Kerdes>();

		public Kerdesek(string fajlNev)
		{
			foreach (var sor in File.ReadAllLines(fajlNev))
			{
				osszes.Add(new Kerdes(sor));
			}
		}

		public Kerdes GetKerdesSzintSzerint(int szint)
		{
			return osszes.FirstOrDefault(k => k.Szint == szint);
		}
	}
}
