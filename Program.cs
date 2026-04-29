using Ettevõtte_töötajate_haldussüsteem.TootajateHaldus;

namespace Ettevõtte_töötajate_haldussüsteem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("|   ETTEVÕTTE TÖÖTAJATE HALDUSSÜSTEEM          |");
            Console.WriteLine("------------------------------------------------\n");

            List<Tootaja> tootajad = new List<Tootaja>
            {
                new Arendaja            ("Mari Mägi",    "49001012345", "IT",      2800, "C#"),
                new Projektijuht        ("Jüri Kallas",  "38504034567", "IT",      3400, 6),
                new Muugiesindaja       ("Liis Tamm",    "50203056789", "Müük",    1900, 20000, 21500),
                new Raamatupidaja       ("Peeter Saar",  "37812078901", "Finants", 2200, 150),
                new Personalispetsialist("Kati Lumi",    "49307099012", "HR",      2100),
              
            };

            Console.WriteLine(" TeeTood() — iga töötaja teeb oma tööd:\n");
            foreach (Tootaja t in tootajad)
            {
                Console.WriteLine($" {t.Nimi} ({t.GetType().Name}):");
                t.TeeTood();
                Console.WriteLine();
            }

            Console.WriteLine("EsitaAruanne() — kõigi töötajate aruanded:\n");
            foreach (Tootaja t in tootajad)
                t.EsitaAruanne();


            Console.WriteLine("\n KalkuleeriPalk() — palgaarvestus:\n");
            double kogupalk = 0;
            foreach (Tootaja t in tootajad)
            {
                double palk = t.KalkuleeriPalk();
                kogupalk += palk;
                Console.WriteLine($"  {t.Nimi,-22} ({t.GetType().Name,-22}): {palk,10:C2}");
            }
            Console.WriteLine($"  {"─",54}");
            Console.WriteLine($"  {"Kogupalk kuus",-46}: {kogupalk,10:C2}");


            Console.WriteLine("\n Palga valideerimine:\n");
            TestiValideerimist(tootajad[0], -500);
            TestiValideerimist(tootajad[0], 150_000);
            TestiValideerimist(tootajad[0], 3200);


            Console.WriteLine("\n Töötajate kokkuvõte:\n");
            foreach (Tootaja t in tootajad)
                Console.WriteLine($"  {t}");

            Console.WriteLine("\n onTool() — puhkuse kontroll:\n");

    
            tootajad[1].MineaPuhkusele(DateTime.Today, DateTime.Today.AddDays(14));

            tootajad[2].MineaPuhkusele(DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-1));
            tootajad[2].TuleTagasi();

            Console.WriteLine();

            Console.WriteLine("  Ülesannete määramine kõigile töötajatele:\n");
            string[] ulesanded = {
                "Paranda kriitilise vea",
                "Korralda meeskonna koosolek",
                "Helista kliendile",
                "Koosta kuuaruanne",
                "Uuenda töötajate andmed"
            };

            for (int i = 0; i < tootajad.Count; i++)
                tootajad[i].MaardaUlesanne(ulesanded[i]);

            Console.WriteLine("\nProgramm lõpetatud.");
        }

        static void TestiValideerimist(Tootaja tootaja, double uusPalk)
        {
            try
            {
                tootaja.Palk = uusPalk;
                Console.WriteLine($"   {tootaja.Nimi} palk uuendatud: {uusPalk:C2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
                
            
        }
    }
}

