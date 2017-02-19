using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labra_11_tehtava_3
{
    public class Henkilo
    {
        public Henkilo(int SOTU, string etunimi, string sukunimi, DateTime syntymapaiva)
        {
            sotu = SOTU;
            Etunimi = etunimi;
            Sukunimi = sukunimi;
            SyntymaAika = syntymapaiva;
        }

        int sotu;
        public string SOTU
        {
            get
            {
                return sotu.ToString();
            }
        }

        string etunimi;
        public string Etunimi
        {
            get
            {
                return etunimi;
            }

            set
            {
                etunimi = value;
            }
        }

        string sukunimi;
        public string Sukunimi
        {
            get
            {
                return sukunimi;
            }

            set
            {
                sukunimi = value;
            }
        }

        DateTime syntymaaika;
        public DateTime SyntymaAika
        {
            get
            {
                return syntymaaika;
            }

            set
            {
                syntymaaika = value;
            }
        }

        public string Kokonimi
        {
            get
            {
                return Etunimi + " " + Sukunimi;
            }
        }

        public int Ika
        {
            get
            {
                return DateTime.Now.Year - SyntymaAika.Year;
            }
        }
    }
}