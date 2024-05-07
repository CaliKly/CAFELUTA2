using System;

namespace cafeneap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GestiuneInventar gestiuneProdus = new GestiuneInventar();
            GestiuneCofetarie gestiuneCofetarie = new GestiuneCofetarie();
            Produs[] produse = new Produs[100]; // Vector pentru stocarea produselor
            Cofetarie[] cofetarii = new Cofetarie[100]; // Vector pentru stocarea informațiilor despre cofetării
            int nrProduse = 0; // Numărul de produse adăugate în vector
            int nrCofetarii = 0; // Numărul de cofetării adăugate în vector

            while (true)
            {
                Console.WriteLine("Meniu:");
                Console.WriteLine("1. Gestionare inventar produs");
                Console.WriteLine("2. Gestionare inventar cofetarie");
                Console.WriteLine("3. Adauga reducere la un produs random");
                Console.WriteLine("4. Adauga reducere la o cofetarie random");
                Console.WriteLine("5. Afisare produse");
                Console.WriteLine("6. Afisare cofetarii");
                Console.WriteLine("7. Cautare produse dupa cantitate exacta");
                Console.WriteLine("8. Iesire din program");
                Console.Write("Alegeti optiunea: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GestionareInventarProdus(gestiuneProdus, produse, ref nrProduse);
                        break;
                    case "2":
                        GestionareInventarCofetarie(gestiuneCofetarie, cofetarii, ref nrCofetarii);
                        break;
                    case "3":
                        AdaugaReducereLaProdusRandom(gestiuneProdus);
                        break;
                    case "4":
                        AdaugaReducereLaCofetarieRandom(gestiuneCofetarie);
                        break;
                    case "5":
                        AfisareProduse(produse, nrProduse);
                        break;
                    case "6":
                        AfisareCofetarii(cofetarii, nrCofetarii);
                        break;
                    case "7":
                        CautareProduseDupaCantitateExacta(produse, nrProduse);
                        break;
                    case "8":
                        Console.WriteLine("Programul s-a terminat.");
                        return;
                    default:
                        Console.WriteLine("Optiune invalida. Va rugam sa alegeti din nou.");
                        break;
                }
            }
        }

        private static void GestionareInventarProdus(GestiuneInventar gestiuneProdus, Produs[] produse, ref int nrProduse)
        {
            Console.WriteLine("Introduceti detalii despre produs:");
            Console.Write("Nume: ");
            string nume = Console.ReadLine();
            Console.Write("Pret: ");
            decimal pret = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Cantitate: ");
            int cantitate = Convert.ToInt32(Console.ReadLine());

            Produs produs = new Produs(nume, pret, cantitate);
            gestiuneProdus.AdaugaProdus(produs);
            produse[nrProduse++] = produs;
        }

        private static void GestionareInventarCofetarie(GestiuneCofetarie gestiuneCofetarie, Cofetarie[] cofetarii, ref int nrCofetarii)
        {
            Console.WriteLine("Introduceti detalii despre cofetarie:");
            Console.Write("Nume: ");
            string nume = Console.ReadLine();
            Console.Write("Pret: ");
            decimal pret = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Cantitate: ");
            int cantitate = Convert.ToInt32(Console.ReadLine());

            Cofetarie cofetarie = new Cofetarie(nume, pret, cantitate);
            gestiuneCofetarie.AdaugaProdus(cofetarie);
            cofetarii[nrCofetarii++] = cofetarie;
        }

        private static void AfisareProduse(Produs[] produse, int nrProduse)
        {
            Console.WriteLine("Produsele din inventar:");
            for (int i = 0; i < nrProduse; i++)
            {
                Console.WriteLine($"Nume: {produse[i].Nume}, Pret: {produse[i].Pret}, Cantitate: {produse[i].Cantitate}");
            }
        }

        private static void AfisareCofetarii(Cofetarie[] cofetarii, int nrCofetarii)
        {
            Console.WriteLine("Cofetariile din inventar:");
            for (int i = 0; i < nrCofetarii; i++)
            {
                Console.WriteLine($"Nume: {cofetarii[i].Nume}, Pret: {cofetarii[i].Pret}, Cantitate: {cofetarii[i].Cantitate}");
            }
        }

        private static void CautareProduseDupaCantitateExacta(Produs[] produse, int nrProduse)
        {
            Console.Write("Introduceti cantitatea dorita: ");
            if (int.TryParse(Console.ReadLine(), out int cantitateCautata))
            {
                Console.WriteLine($"Produsele care au exact cantitatea {cantitateCautata}:");
                bool gasit = false;
                for (int i = 0; i < nrProduse; i++)
                {
                    if (produse[i].Cantitate == cantitateCautata)
                    {
                        Console.WriteLine($"Nume: {produse[i].Nume}, Pret: {produse[i].Pret}, Cantitate: {produse[i].Cantitate}");
                        gasit = true;
                    }
                }
                if (!gasit)
                {
                    Console.WriteLine($"Nu s-au gasit produse cu cantitatea exacta de {cantitateCautata}.");
                }
            }
            else
            {
                Console.WriteLine("Cantitatea introdusa nu este valida.");
            }
        }

        private static void AdaugaReducereLaProdusRandom(GestiuneInventar gestiuneProdus)
        {
            gestiuneProdus.AplicaReducereLaProdusAleatoriu();
        }

        private static void AdaugaReducereLaCofetarieRandom(GestiuneCofetarie gestiuneCofetarie)
        {
            gestiuneCofetarie.AplicaReducereLaProdusAleatoriu();
        }
    }
}
