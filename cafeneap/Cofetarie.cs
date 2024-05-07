using System;

namespace cafeneap
{
    public class Cofetarie
    {
        public string Nume { get; set; }
        public decimal Pret { get; set; }
        public int Cantitate { get; set; }

        public Cofetarie(string nume, decimal pret, int cantitate)
        {
            Nume = nume;
            Pret = pret;
            Cantitate = cantitate;
        }
    }
}
