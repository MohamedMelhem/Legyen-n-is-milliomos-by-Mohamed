using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legyen_ön_is_milliomos
{
	internal class Kerdesek
	{
		List<Kerdes> kerdesLista = new List<Kerdes>();
		List<Sorkerdes> sorkerdesLista = new List<Sorkerdes>();


		Random rand = new Random();

        public Kerdesek(string kerdesfajl, string sorkerdesfajl)
        {
            foreach (string sor  in File.ReadAllLines(sorkerdesfajl)) 
            {
                sorkerdesLista.Add(new Sorkerdes(sor));
            }
            foreach (string sor in File.ReadLines(kerdesfajl))
            {
                kerdesLista.Add(new Kerdes(sor));
            }
        }
               
        public Sorkerdes VeletlenSorkerdesKivalasztas()
        {
            int index = rand.Next(sorkerdesLista.Count);
            return sorkerdesLista[index];
        }
        public Kerdes VeletlenKerdesKivalasztas()
        {
            int index = rand.Next(kerdesLista.Count);
            return kerdesLista[index];
        }



    }
}
