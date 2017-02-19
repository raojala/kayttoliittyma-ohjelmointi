using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labra_11_tehtava_3
{
    public class OsaAikainen : Tyontekija
    {

        public OsaAikainen(int SOTU, string etunimi, string sukunimi, DateTime syntymapaiva, string nimike, DateTime aloituspaiva, float tuntipalkka, int tunnit) : base (SOTU, etunimi, sukunimi, syntymapaiva, nimike, aloituspaiva)
        {
            try
            {
                TuntiPalkka = tuntipalkka;
                TehdytTunnit = tunnit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        float tuntipalkka;
        public float TuntiPalkka
        {
            get
            {
                return tuntipalkka;
            }

            set
            {
                tuntipalkka = value;
            }
        }

        int tehdyttunnit;
        public int TehdytTunnit
        {
            get
            {
                return tehdyttunnit;
            }

            set
            {
                tehdyttunnit = value;
            }
        }

        public override float LaskePalkka()
        {
            return TuntiPalkka * TehdytTunnit;
        }
    }
}