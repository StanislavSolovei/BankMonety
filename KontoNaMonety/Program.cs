namespace KontoNaMonety
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Console.WriteLine("Wprowadz nowego wlasciciela: ");

            string wlasciciel = Console.ReadLine();

            KontoBankowe pusteKonto = new KontoBankowe(wlasciciel, 0);

            while (true)
            {
                Console.WriteLine("Wybierz operacje, 1 - Wplata");

                int operacja = int.Parse(Console.ReadLine());

                switch (operacja)
                {
                    case 1:
                        {
                            Console.WriteLine("Wprowadz kwote do wplacenia: ");

                            decimal kwota = decimal.Parse(Console.ReadLine());

                            pusteKonto.Wplata(kwota);

                            break;
                        }
                }
            }
        }
    }
}
