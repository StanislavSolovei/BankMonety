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

        private int _nominal5 = 0;
        private int _nominal2 = 0;
        private int _nominal1 = 0;
        private int _nominal050 = 0;
        private int _nominal020 = 0;
        private int _nominal010 = 0;

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
            if (kwota < 0)
            {
                Console.WriteLine("Kwota nie może być ujemna!");
            }
            else
            {
                if(kwota == 5)
                {
                    _ilosc += 1;
                    _nominal5 += 1;
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN. Wrzucono {_ilosc} monet");
                } else if (kwota == 2)
                {
                    _ilosc += 1;
                    _nominal2 += 1;
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN. Wrzucono {_ilosc} monet");
                } else if (kwota == 1)
                {
                    _ilosc += 1;
                    _nominal1 += 1;
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN. Wrzucono {_ilosc} monet");
                } else if (kwota == 0.50m) {
                    _ilosc += 1;
                    _nominal050 += 1;
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN. Wrzucono {_ilosc} monet");
                } else if (kwota == 0.20m)
                {
                    _ilosc += 1;
                    _nominal020 += 1;
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN. Wrzucono {_ilosc} monet");
                } else if (kwota == 0.10m)
                {
                    _ilosc += 1;
                    _nominal010 += 1;
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN. Wrzucono {_ilosc} monet");
                } else
                {
                    Console.WriteLine("Błąd! Można wplacić tylko monety!");
                }
            }
        }
        public void WyswietliInformacje()
        {
            Console.WriteLine($"Właścieciel: {_wlasciel}");
            Console.WriteLine($"Stan konta: {_saldo} PLN");
            Console.WriteLine($"Wrzucono monet: {_ilosc}");
            Console.WriteLine($"Monety 5 PLN: {_nominal5}");
            Console.WriteLine($"Monety 2 PLN: {_nominal2}");
            Console.WriteLine($"Monety 1 PLN: {_nominal1}");
            Console.WriteLine($"Monety 0.50 PLN: {_nominal050}");
            Console.WriteLine($"Monety 0.20 PLN: {_nominal020}");
            Console.WriteLine($"Monety 0.10 PLN: {_nominal010}");
        }
    }
}
