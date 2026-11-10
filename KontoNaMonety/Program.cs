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
                Console.WriteLine("Wybierz operacje: 1 - Wplata || 2 - Wyświetl informacje || 3 - Wyświetl historię || 4 - Wlożyć wielu monet");

                int operacja = int.Parse(Console.ReadLine());

                if(operacja != 1 && operacja != 2 && operacja != 3 && operacja != 4)
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
                    case 2:
                        {
                            pusteKonto.WyswietliInformacje();

                            break;
                        }
                    case 3:
                        {
                            pusteKonto.WyswietlHistorie();

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Wprowadz monety oddzielone przecinkiem: ");

                            string input = Console.ReadLine();

                            pusteKonto.WplataWiele(input);

                            break;
                        }
                }
            }
        }
    }
}
