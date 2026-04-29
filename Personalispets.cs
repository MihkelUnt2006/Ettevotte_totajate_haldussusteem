using Ettevõtte_töötajate_haldussüsteem.TootajateHaldus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ettevõtte_töötajate_haldussüsteem
{
    public class Personalispetsialist : Tootaja
    {
        public int VarbaturiArv { get; private set; }

        public Personalispetsialist(string nimi, string isikukood, string osakond, double palk): base(nimi, isikukood, osakond, palk)
        {
            VarbaturiArv = 0;
        }

        public void VarbaTootajaid(string positsioon)
        {
            VarbaturiArv++;
            Console.WriteLine($"  {Nimi} värbab töötajat positsioonile: {positsioon} (kokku värvatud: {VarbaturiArv}).");
        }

        public void HaldaAndmeid() =>
            Console.WriteLine($"  {Nimi} uuendab töötajate andmebaasi ja dokumente.");

        public override void TeeTood()
        {
            Console.WriteLine($"  [{Nimi}] personalispetsialisti töö:");
            VarbaTootajaid("Arendaja");
            HaldaAndmeid();
        }

        public override void EsitaAruanne() =>
            Console.WriteLine($"  [{Nimi}] Aruanne: {VarbaturiArv} töötajat värvatud, 2 intervjuud planeeritud.");
    }
}
