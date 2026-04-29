using System;
using System.Collections.Generic;
using System.Text;

namespace Ettevõtte_töötajate_haldussüsteem
{
    namespace TootajateHaldus
    {
       public abstract class Tootaja : ITootaja
        {
            public string Nimi { get; set; }
            public string Isikukood { get; set; }
            public string Osakond { get; set; }

            // true = tööl, false = puhkusel
            public bool OnToolojas { get; private set; } = true;

            // Märgib töötaja puhkusele koos algus- ja lõpukuupäevaga
            public DateTime? PuhkuseAlgus { get; private set; }
            public DateTime? PuhkuseLõpp { get; private set; }

            private double _palk;
            public double Palk
            {
                get => _palk;
                set
                {
                    if (value < 0 || value > 100_000)
                        return;

                    _palk = value;
                }
            }

            protected Tootaja(string nimi, string isikukood, string osakond, double palk)
            {
                Nimi = nimi;
                Isikukood = isikukood;
                Osakond = osakond;
                Palk = palk;
            }

            // Kontrollib, kas töötaja on täna tööl
            public bool OnTool()
            {
                if (!OnToolojas)
                    return false;

                // Kui puhkuseperiood on määratud, kontrollitakse tänast kuupäeva
                if (PuhkuseAlgus.HasValue && PuhkuseLõpp.HasValue)
                {
                    DateTime täna = DateTime.Today;
                    if (täna >= PuhkuseAlgus.Value && täna <= PuhkuseLõpp.Value)
                        return false;
                }

                return true;
            }

            // Saadab töötaja puhkusele määratud perioodiks
            public void MineaPuhkusele(DateTime algus, DateTime lõpp)
            {
                if (lõpp < algus)
                    throw new ArgumentException("Puhkuse lõpp ei saa olla enne algust.");

                PuhkuseAlgus = algus;
                PuhkuseLõpp = lõpp;
                OnToolojas = false;
                Console.WriteLine($"  {Nimi} läks puhkusele: {algus:dd.MM.yyyy} – {lõpp:dd.MM.yyyy}");
            }

            // Tagastab töötaja puhkuselt tööle
            public void TuleTagasi()
            {
                OnToolojas = true;
                PuhkuseAlgus = null;
                PuhkuseLõpp = null;
                Console.WriteLine($"  {Nimi} tuli puhkuselt tagasi tööle.");
            }

            // Määrab ülesande ainult siis, kui töötaja on tööl
            public void MaardaUlesanne(string ulesanne)
            {
                if (!OnTool())
                {
                    Console.WriteLine($"  ✗ Ei saa määrata ülesannet — {Nimi} on puhkusel" +
                        (PuhkuseLõpp.HasValue ? $" kuni {PuhkuseLõpp.Value:dd.MM.yyyy}." : "."));
                    return;
                }

                Console.WriteLine($"  ✓ {Nimi} sai ülesande: \"{ulesanne}\"");
            }

            public abstract void TeeTood();
            public abstract void EsitaAruanne();

            public virtual double KalkuleeriPalk() => Palk;

            public override string ToString()
            {
                string staatus = OnTool() ? "tööl" : "puhkusel";
                return $"[{GetType().Name}] {Nimi} | {Osakond} | {staatus} | Palk: {KalkuleeriPalk():C2}";
            }

        }
    }
}
