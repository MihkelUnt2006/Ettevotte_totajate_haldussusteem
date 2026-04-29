using Ettevõtte_töötajate_haldussüsteem.TootajateHaldus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ettevõtte_töötajate_haldussüsteem
{
    public class Raamatupidaja : Tootaja
    {
        public int ToodeldudArvetArv { get; set; }

        public Raamatupidaja(string nimi, string isikukood, string osakond, double palk, int toodeldudArvetArv): base(nimi, isikukood, osakond, palk)
        {
            ToodeldudArvetArv = toodeldudArvetArv;
        }

        public void TootleArved() =>
            Console.WriteLine($"  {Nimi} töötleb {ToodeldudArvetArv} arvet kuus.");

        public void ArvutaPalgad() =>
            Console.WriteLine($"  {Nimi} arvutab töötajate palgaarvestuse.");

        public override void TeeTood()
        {
            Console.WriteLine($"  [{Nimi}] raamatupidaja töö:");
            TootleArved();
            ArvutaPalgad();
        }

        public override void EsitaAruanne() =>
            Console.WriteLine($"  [{Nimi}] Aruanne: Bilanss suletud, 0 viga, kõik arved töödeldud.");
    }
}
