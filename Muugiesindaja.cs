using Ettevõtte_töötajate_haldussüsteem.TootajateHaldus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ettevõtte_töötajate_haldussüsteem
{
    public class Muugiesindaja : Tootaja
    {
        public double MuugiEesmark { get; set; }

        private double _tegelikMuuk;
        public double TegelikMuuk
        {
            get => _tegelikMuuk;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Tegelik müük ei saa olla negatiivne.");
                _tegelikMuuk = value;
            }
        }

        public Muugiesindaja(string nimi, string isikukood, string osakond,double palk, double muugiEesmark, double tegelikMuuk): base(nimi, isikukood, osakond, palk)
        {
            MuugiEesmark = muugiEesmark;
            TegelikMuuk = tegelikMuuk;
        }

        public void SuhtleKlientidega() =>
            Console.WriteLine($"  {Nimi} helistab klientidele ja kohtub partneritega.");

        public void TeheMuuk() =>
            Console.WriteLine($"  {Nimi} sõlmib müügilepingu väärtusega {TegelikMuuk:C2}.");

        public override void TeeTood()
        {
            Console.WriteLine($"  [{Nimi}] müügiesindaja töö:");
            SuhtleKlientidega();
            TeheMuuk();
        }

        public override void EsitaAruanne()
        {
            double protsent = MuugiEesmark > 0 ? TegelikMuuk / MuugiEesmark * 100 : 0;
            Console.WriteLine($"  [{Nimi}] Aruanne: Müügieesmärk täidetud {protsent:F1}%.");
        }

   
        public override double KalkuleeriPalk() => Palk + TegelikMuuk * 0.05;
    }
}
