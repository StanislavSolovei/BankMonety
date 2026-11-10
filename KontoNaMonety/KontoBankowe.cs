using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KontoNaMonety
{
    internal class KontoBankowe
    {
        private decimal _saldo;
        private int _iloscWrzuconych = 0;
        private int _iloscZwroconych = 0;
        private string _wlasciel;
        private string _nrKonta;

        List<Operacja> historia = new List<Operacja>();

        decimal[] nominaly = { 5m, 2m, 1m, 0.50m, 0.20m, 0.10m };

        int[] iloscMonet;

        int[] maxMonet = { 2, 5, 10, 20, 50, 100 };

        public decimal Saldo
        {
            get { return _saldo;  }
            set { _saldo = value; }
        }

        public string Wlasciciel
        {
            get { return _wlasciel; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _wlasciel = value;
                } else
                {
                    Console.WriteLine("Błąd: Nazwa właściciela nie może być pusta!");
                }
            }
        }

        public KontoBankowe(string nowyWlasciciel, decimal startoweSaldo)
        {
            _wlasciel = nowyWlasciciel;

            iloscMonet = new int[nominaly.Length];

            if(startoweSaldo < 0)
            {
                Console.WriteLine("Saldo nie może być ujemne!");
            }
            else
            {
                 _saldo = startoweSaldo;
            }

            Random rand = new Random();

            _nrKonta = GeneratorLiczb(10);

            Console.WriteLine($"Utworzono konto dla: {_wlasciel} z saldem: {_saldo} PLN i numerem konta: {_nrKonta}");
        }

        private string GeneratorLiczb(int dlugosc)
        {
            Random rand = new Random();

            string numer = "";

            for(int i = 0; i < dlugosc; i++)
            {
                int num = rand.Next(0, 11);

                numer += num;
            }

            return numer;
        }

        public void Wplata(decimal kwota)
        {
            bool znaleziono = false;

            if (kwota < 0)
            {
                Console.WriteLine("Kwota nie może być ujemna!");
                return;
            }
            
            for (int i = 0; i < nominaly.Length; i++)
            {
                if(kwota == nominaly[i])
                {
                    if (iloscMonet[i] < maxMonet[i]) 
                    {
                        znaleziono = true;
                        _saldo += kwota;
                        _iloscWrzuconych++;
                        iloscMonet[i]++;
                        Console.WriteLine($"Wrzucono monetę o nominale: {kwota} PLN. Aktualne saldo: {_saldo} PLN");
                        historia.Add(new Operacja { Kwota = kwota, Przyjeta = true });
                    } else
                    {
                        _iloscZwroconych++;
                        Console.WriteLine($"Nie można wrzucić więcej monet o tym nominale: {nominaly[i]} PLN");
                        historia.Add(new Operacja { Kwota = kwota, Przyjeta = false });
                        return;
                    }
                }
            }
            if (znaleziono == false)
            {
                _iloscZwroconych++;
                Console.WriteLine($"Nie ma takiej monety!");
                historia.Add(new Operacja { Kwota = kwota, Przyjeta = false });
            }
        }
        public void WplataWiele(string input)
        {
            string[] monety = input.Split(',');

            foreach (string moneta in monety)
            {
                if (decimal.TryParse(moneta.Trim(), out decimal kwota))
                {
                    Wplata(kwota);
                } else
                {
                    _iloscZwroconych++;
                    Console.WriteLine("To nie jest liczba!");
                    return;
                }
            }
        }
        public void WyswietliInformacje()
        {
            Console.WriteLine($"Właścieciel: {_wlasciel}");
            Console.WriteLine($"Stan konta: {_saldo} PLN");
            Console.WriteLine($"Wrzucono monet: {_iloscWrzuconych}");
            Console.WriteLine($"Zwrócono monet: {_iloscZwroconych}");
            for (int i = 0; i < nominaly.Length; i++)
            {
                Console.WriteLine($"Monet o nominale {nominaly[i]} PLN: {iloscMonet[i]}");
            }
        }
        public void WyswietlHistorie()
        {
            if(historia.Count == 0)
            {
                Console.WriteLine("Historia jest pusta!");
                return;
            }
            Console.WriteLine("Historia operacji:");
            foreach(Operacja operacja in historia)
            {
                if(operacja.Przyjeta == true)
                {
                    Console.WriteLine($"{operacja.Kwota} PLN | PRZYJĘTO");
                } else
                {
                    Console.WriteLine($"{operacja.Kwota} PLN | ODRZUCONO");
                }
            }
        }
    }
}
