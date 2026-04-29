using Ettevõtte_töötajate_haldussüsteem.TootajateHaldus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ettevõtte_töötajate_haldussüsteem
{
   public class Projektijuht : Tootaja
    {
        public int MeeskonnaSuurus { get; set; }

        public Projektijuht(string nimi, string isikukood, string osakond,double palk, int meeskonnaSuurus): base(nimi, isikukood, osakond, palk)
        {
            MeeskonnaSuurus = meeskonnaSuurus;
        }

        public void JuhiMeeskonda() =>
            Console.WriteLine($"  {Nimi} juhib {MeeskonnaSuurus}-liikmelise meeskonda.");

        public void JaotaUlesandeid() =>
            Console.WriteLine($"  {Nimi} jagab ülesanded Jira tahvlil laiali.");

        public override void TeeTood()
        {
            Console.WriteLine($"  [{Nimi}] projektijuhi töö:");
            JuhiMeeskonda();
            JaotaUlesandeid();
        }

        public override void EsitaAruanne() =>
            Console.WriteLine($"  [{Nimi}] Aruanne: Sprint lõpetatud, tiim 95% mahutusega.");

        // Projektijuht saab 15% boonust
        public override double KalkuleeriPalk() => Palk * 1.15;
    }
}
