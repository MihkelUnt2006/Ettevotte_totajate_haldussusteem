using Ettevõtte_töötajate_haldussüsteem.TootajateHaldus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ettevõtte_töötajate_haldussüsteem
{

    public class Arendaja : Tootaja
    {
        public string Programmeerimiskeel { get; set; }

        public Arendaja(string nimi, string isikukood, string osakond, double palk, string programmeerimiskeel): base(nimi, isikukood, osakond, palk)
        {
            Programmeerimiskeel = programmeerimiskeel;
        }

        public void KirjutaKoodi() =>
            Console.WriteLine($"  {Nimi} kirjutab {Programmeerimiskeel} koodi...");

        public void ParandaVigu() =>
            Console.WriteLine($"  {Nimi} parandab vigu ja teeb code review'd...");

        public override void TeeTood()
        {
            Console.WriteLine($"  [{Nimi}] arendaja töö:");
            KirjutaKoodi();
            ParandaVigu();
        }

        public override void EsitaAruanne() =>
            Console.WriteLine($"  [{Nimi}] Aruanne: Sprint lõpetatud, 3 feature'i valmis, 2 bugfix'i tehtud.");

        public override double KalkuleeriPalk() => Palk * 1.10;
    }
}
