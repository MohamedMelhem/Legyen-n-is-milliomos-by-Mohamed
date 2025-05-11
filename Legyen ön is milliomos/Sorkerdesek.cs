using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legyen_ön_is_milliomos
{


	public class Sorkerdes
	{
		string helyessorrend;
		string kerdes;
		List<string> valaszok;
		string kategoria;


        public Sorkerdes(string sor)
        {
			string[] elemek = sor.Split(';');
            kerdes = elemek[0];
            valaszok = new List<string>() { elemek[1], elemek[2], elemek[3], elemek[4] };
            helyessorrend = elemek[5];
            kategoria = elemek[6];


        }

        public override string? ToString()
        {
            return $"{kategoria} Kérdés: {Kerdes}\n" +
                $"A: {valaszok[0]}  B: {valaszok[1]}\n" +
                $"C: {valaszok[2]} D: {valaszok[3]}\n" +
                $"helyes valasz : {helyessorrend}";
        }

        public string Helyessorrend { get => helyessorrend; set => helyessorrend = value; }
        public string Kerdes { get => kerdes; set => kerdes = value; }

        public string Kategoria { get => kategoria; set => kategoria = value; }
        public List<string> Valaszok { get => valaszok; set => valaszok = value; }     
    }
}
