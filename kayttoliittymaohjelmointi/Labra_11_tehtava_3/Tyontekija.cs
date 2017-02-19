using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labra_11_tehtava_3
{
    public class Tyontekija : Henkilo
    {

        public Tyontekija (int SOTU, string etunimi, string sukunimi, DateTime syntymapaiva, string nimike, DateTime aloituspaiva) : base (SOTU, etunimi, sukunimi, syntymapaiva)
        {
            Nimike = nimike;
            aloitusPvm = aloituspaiva;
        }

        string nimike;
        public string Nimike
        {
            get
            {
                return nimike;
            }
            set
            {
                nimike = value;
            }
        }

        DateTime aloitusPvm;
        public DateTime AloitusPvm
        {
            get
            {
                return aloitusPvm;
            }
        }

        public float Palkka
        {
            get
            {
                return LaskePalkka();
            }
        }

        public override string ToString()
        {
            return SOTU + " = " + Kokonimi + ", " + Nimike;
        }

        public virtual float LaskePalkka() { return 0; }
    }
}