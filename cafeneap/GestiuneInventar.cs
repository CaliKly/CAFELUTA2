using System;
using System.Collections.Generic;

namespace cafeneap
{
    public class GestiuneInventar
    {
        private List<Produs> inventar = new List<Produs>();
        private Random random = new Random();

        public void AdaugaProdus(Produs produs)
        {
            inventar.Add(produs);
        }

        public void AfiseazaInventar()
        {
            Console.WriteLine("Inventarul cafenelei:");
            foreach (Produs produs in inventar)
            {
                Console.WriteLine($"Nume: {produs.Nume}, Pret: {produs.Pret}, Cantitate: {produs.Cantitate}");
            }
        }

        public void AplicaReducereLaProdusAleatoriu()
        {
            if (inventar.Count == 0)
            {
                Console.WriteLine("Inventarul este gol. Nu se poate aplica reducerea.");
                return;
            }

            int indexProdus = random.Next(inventar.Count);
            Produs produsSelectat = inventar[indexProdus];

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
