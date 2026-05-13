using Ettevõtte_töötajate_haldussüsteem.TootajateHaldus;

namespace Ettevõtte_töötajate_haldussüsteem
{
    public class Program
    {
        static List<Tootaja> tootajad = new List<Tootaja>();

        static void Main(string[] args)
        {
            // Algandmed
            LisaAlgandmed();

            while (true)
            {
                NaitaMenu();
                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        LisaTootaja();
                        break;
                    case "2":
                        NaitaTootajad();
                        break;
                    case "3":
                        KalkuleeriKogupalk();
                        break;
                    case "4":
                        Console.WriteLine("Väljumine...");
                        return;
                    default:
                        Console.WriteLine("Vale valik!");
                        break;
                }
                Console.WriteLine("\nKlõpsake sisestamiseks Enter...");
                Console.ReadLine();
            }
        }

        static void NaitaMenu()
        {
            Console.Clear();
            Console.WriteLine("=== ETTEVÕTTE TÖÖTAJATE HALDUSSÜSTEEM ===\n");
            Console.WriteLine("1. Lisa uus töötaja");
            Console.WriteLine("2. Näita kõiki töötajaid");
            Console.WriteLine("3. Arvuta kogupalk");
            Console.WriteLine("4. Väljuta");
            Console.WriteLine("\nVali (1-4): ");
        }

        static void LisaTootaja()
        {
            Console.Clear();
            Console.WriteLine("=== UUS TÖÖTAJA ===\n");

            Console.Write("Nimi: ");
            string nimi = Console.ReadLine();

            Console.Write("Isikukood: ");
            string isikukood = Console.ReadLine();

            Console.Write("Osakond: ");
            string osakond = Console.ReadLine();

            Console.Write("Palk: ");
            double palk = double.Parse(Console.ReadLine());

            Console.WriteLine("\nTöötaja roll:");
            Console.WriteLine("1. Arendaja");
            Console.WriteLine("2. Projektijuht");
            Console.WriteLine("3. Müügiesindaja");
            Console.WriteLine("4. Raamatupidaja");
            Console.WriteLine("5. Personalispetsialist");
            Console.Write("\nVali (1-5): ");
            string roll = Console.ReadLine();

            Tootaja uusTootaja = null;

            switch (roll)
            {
                case "1":
                    Console.Write("Programmeerimiskeel: ");
                    string keel = Console.ReadLine();
                    uusTootaja = new Arendaja(nimi, isikukood, osakond, palk, keel);
                    break;
                case "2":
                    Console.Write("Juhitavate inimeste arv: ");
                    int juhitavad = int.Parse(Console.ReadLine());
                    uusTootaja = new Projektijuht(nimi, isikukood, osakond, palk, juhitavad);
                    break;
                case "3":
                    Console.Write("Müügieesmärk: ");
                    double eesmärk = double.Parse(Console.ReadLine());
                    Console.Write("Hetke müük: ");
                    double müük = double.Parse(Console.ReadLine());
                    uusTootaja = new Muugiesindaja(nimi, isikukood, osakond, palk, eesmärk, müük);
                    break;
                case "4":
                    Console.Write("Raamatute arv: ");
                    int raamatud = int.Parse(Console.ReadLine());
                    uusTootaja = new Raamatupidaja(nimi, isikukood, osakond, palk, raamatud);
                    break;
                case "5":
                    uusTootaja = new Personalispetsialist(nimi, isikukood, osakond, palk);
                    break;
                default:
                    Console.WriteLine("Vale valik!");
                    return;
            }

            tootajad.Add(uusTootaja);
            Console.WriteLine("\n✓ Töötaja lisatud!");
        }

        static void NaitaTootajad()
        {
            Console.Clear();
            Console.WriteLine("=== KÕIK TÖÖTAJAD ===\n");

            if (tootajad.Count == 0)
            {
                Console.WriteLine("Töötajaid pole.");
                return;
            }

            foreach (var t in tootajad)
            {
                Console.WriteLine(t);
            }
        }

        static void KalkuleeriKogupalk()
        {
            Console.Clear();
            Console.WriteLine("=== PALGAARVESTUS ===\n");

            double kogupalk = 0;
            foreach (var t in tootajad)
            {
                double palk = t.KalkuleeriPalk();
                kogupalk += palk;
                Console.WriteLine($"{t.Nimi,-25}: {palk,10:C2}");
            }

            Console.WriteLine($"{"─",46}");
            Console.WriteLine($"{"Kogupalk kuus",-25}: {kogupalk,10:C2}");
        }

        static void LisaAlgandmed()
        {
            tootajad.Add(new Arendaja("Mari Mägi", "49001012345", "IT", 2800, "C#"));
            tootajad.Add(new Projektijuht("Jüri Kallas", "38504034567", "IT", 3400, 6));
            tootajad.Add(new Muugiesindaja("Liis Tamm", "50203056789", "Müük", 1900, 20000, 21500));
            tootajad.Add(new Raamatupidaja("Peeter Saar", "37812078901", "Finants", 2200, 150));
            tootajad.Add(new Personalispetsialist("Kati Lumi", "49307099012", "HR", 2100));
        }
    }
}
