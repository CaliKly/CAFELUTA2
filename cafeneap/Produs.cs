using System;

namespace cafeneap
{
    public class Produs
    {
        public string Nume { get; set; }
        public decimal Pret { get; set; }
        public int Cantitate { get; set; }

        public Produs(string nume, decimal pret, int cantitate)
        {
            Nume = nume;
            Pret = pret;
            Cantitate = cantitate;
        }
    }
}
