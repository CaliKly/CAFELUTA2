using System;
using System.Collections.Generic;

namespace cafeneap
{
    public class GestiuneCofetarie
    {
        private List<Cofetarie> inventarCofetarie = new List<Cofetarie>();
        private Random random = new Random();

        public void AdaugaProdus(Cofetarie produs)
        {
            inventarCofetarie.Add(produs);
        }

        public void AfiseazaInventar()
        {
            Console.WriteLine("Inventarul cofetăriei:");
            foreach (Cofetarie produs in inventarCofetarie)
            {
                Console.WriteLine($"Nume: {produs.Nume}, Pret: {produs.Pret}, Cantitate: {produs.Cantitate}");
            }
        }

        public void CautaDupaCantitate(int cantitateCautata)
        {
            bool gasit = false;
            foreach (Cofetarie produs in inventarCofetarie)
            {
                if (produs.Cantitate == cantitateCautata)
                {
                    Console.WriteLine($"Produsul cu cantitatea {cantitateCautata} a fost gasit:");
                    Console.WriteLine($"Nume: {produs.Nume}, Pret: {produs.Pret}, Cantitate: {produs.Cantitate}");
                    gasit = true;
                }
            }

            if (!gasit)
                Console.WriteLine($"Nu a fost gasit niciun produs cu cantitatea {cantitateCautata}.");
        }

        public void AplicaReducereLaProdusAleatoriu()
        {
            if (inventarCofetarie.Count == 0)
            {
                Console.WriteLine("Inventarul este gol. Nu se poate aplica reducerea.");
                return;
            }

            int indexProdus = random.Next(inventarCofetarie.Count);
            Cofetarie produsSelectat = inventarCofetarie[indexProdus];

            decimal pretRedus = produsSelectat.Pret * 0.7m;
            produsSelectat.Pret = pretRedus;

            // Afișăm produsul și prețul redus
            Console.WriteLine($"A fost aplicata o reducere de 30% la produsul aleatoriu:");
            Console.WriteLine($"Nume: {produsSelectat.Nume}");
            Console.WriteLine($"Pretul inițial: {produsSelectat.Pret / 0.7m}"); // Prețul inițial înainte de reducere
            Console.WriteLine($"Pretul cu reducere (30%): {produsSelectat.Pret}");
        }
    }
}
