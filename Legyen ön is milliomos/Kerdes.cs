using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legyen_ön_is_milliomos
{
	internal class Kerdes
	{
		int id;
		string helyesvalasz;
		string kategoria;
		List<string> valaszok;
		string kerdesszoveg;

        public Kerdes(string sor)
        {
            string[] elemek = sor.Split(';');
            id = int.Parse(elemek[0]);
            kerdesszoveg = elemek[1];
            valaszok = new List<string>() { elemek[2] , elemek[3], elemek[4], elemek[5] };
            helyesvalasz = elemek[6];
            kategoria = elemek[7];

        }

        public override string? ToString()
        {
            return $"({kategoria}) Kérdés: {kerdesszoveg}\n" +
                $"Válaszok: A: {valaszok[0]}  B: {valaszok[1]}\n" +
                $"C: {valaszok[2]}  D: {valaszok[3]}\n" +
                $"helyes valasz : {helyesvalasz}";
        }

        public int Id { get => id; set => id = value; }
        public string Helyesvalasz { get => helyesvalasz; set => helyesvalasz = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
        public List<string> Valaszok { get => valaszok; set => valaszok = value; }
        public string Kerdesszoveg { get => kerdesszoveg; set => kerdesszoveg = value; }
    }
}
