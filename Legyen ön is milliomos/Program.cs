namespace Legyen_ön_is_milliomos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kerdesek kerdesek = new Kerdesek("kerdes.txt","sorkerdes.txt");
            Jatek jatek = new Jatek(kerdesek);
            jatek.Inditas();
        }
    }
}
