using System.Globalization;

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

                if(operacja != 1)
                {
                    Console.WriteLine("Nie istnieje takiej operacji!");
                }

                switch (operacja)
                {
                    case 1:
                        {

                            Console.WriteLine("Wprowadz kwote do wplacenia: ");

                            string moneta = Console.ReadLine();

                            moneta = moneta.Replace(",", ".");

                            decimal.TryParse(moneta, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal kwota);

                            pusteKonto.Wplata(kwota);

                            break;
                        }
                }
            }
        }
    }
}
