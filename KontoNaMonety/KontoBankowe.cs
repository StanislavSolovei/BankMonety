using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KontoNaMonety
{
    internal class KontoBankowe
    {
        private decimal _saldo;
        private string _wlasciel;

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
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN.");
                } else if (kwota == 2)
                {
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN.");
                } else if (kwota == 1)
                {
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN.");
                } else if (kwota == 0.50m) {
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN.");
                } else if (kwota == 0.20m)
                {
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN.");
                } else if (kwota == 0.10m)
                {
                    _saldo += kwota;
                    Console.WriteLine($"Wpłacono {kwota} PLN. Aktualny stan konta: {_saldo} PLN.");
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
        }
    }
}
