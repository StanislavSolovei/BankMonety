using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KontoNaMonety
{
    internal class KontoBankowe
    {
        private decimal _saldo;
        private int _ilosc = 0;
        private string _wlasciel;
        private string _nrKonta;

        decimal[] nominaly = { 5m, 2m, 1m, 0.50m, 0.20m, 0.10m };

        int[] iloscMonet;

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
            bool Znaleziono = false;

            if (kwota < 0)
            {
                Console.WriteLine("Kwota nie może być ujemna!");
            }
            
            for (int i = 0; i < nominaly.Length; i++)
            {
                if(kwota == nominaly[i])
                {
                    Znaleziono = true;

                    if(Znaleziono == true)
                    {
                        _saldo += kwota;
                        _ilosc++;
                        iloscMonet[i]++;
                        Console.WriteLine($"Wrzucono monetę o nominale: {kwota} PLN. Aktualne saldo: {_saldo} PLN");
                    }
                }
            }
            if (Znaleziono == false)
            {
                Console.WriteLine($"Nie ma takiej monety!");
            }
        }
        public void WyswietliInformacje()
        {
            Console.WriteLine($"Właścieciel: {_wlasciel}");
            Console.WriteLine($"Stan konta: {_saldo} PLN");
            Console.WriteLine($"Wrzucono monet: {_ilosc}");
            for (int i = 0; i < nominaly.Length; i++)
            {
                Console.WriteLine($"Monet o nominale {nominaly[i]} PLN: {iloscMonet[i]}");
            }
        }
    }
}
