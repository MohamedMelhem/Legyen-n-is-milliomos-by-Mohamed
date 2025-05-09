namespace Legyen_ön_is_milliomos
{
	internal class Program
	{


		static void Main(string[] args)
		{
			var sorkerdesek = Sorkerdes.BeolvasFajlbol("sorkerdes.txt");

			foreach (var kerdes in sorkerdesek)
			{
				kerdes.Kiir();
				Console.WriteLine();
			}

		}
	}
}
