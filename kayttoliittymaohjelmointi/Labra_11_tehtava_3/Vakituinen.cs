using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labra_11_tehtava_3
{
    public class Vakituinen : Tyontekija
    {
        public Vakituinen(int SOTU, string etunimi, string sukunimi, DateTime syntymapaiva, string nimike, DateTime aloituspaiva, float kuukausipalkka) : base (SOTU, etunimi, sukunimi, syntymapaiva, nimike, aloituspaiva)
        {
            kkPalkka = kuukausipalkka;
        }

        float kkPalkka;
        public float KuukausiPalkka
        {
            set
            {
                kkPalkka = value;
            }
        }

        public override float LaskePalkka()
        {
            return kkPalkka;
        }
    }
}