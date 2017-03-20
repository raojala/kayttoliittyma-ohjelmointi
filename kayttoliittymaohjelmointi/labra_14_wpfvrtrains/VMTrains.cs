using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace labra_14_wpfvrtrains
{
    public class TrainsVM
    {
        public static List<Train> GetTrainsAt(string station)
        {
            try
            {
                // vaihe 1 placebo palauttaa oikean muotoista dataa
                // keksitään muutama juna
                List<Train> trains = new List<Train>();
                if (station == "testi" || station == "")
                {
                    Train tr = new Train();
                    tr.TrainNumber = "666";
                    tr.DepDate = new DateTime(2017, 3, 21);
                    tr.TargetStation = "Highway to hell";
                    trains.Add(tr);
                }
                else
                {
                    // muutetaan jsoni olio kokoelmaksi
                    string tmp = API.GetJsonFromLiikenneVirasto(station);
                    trains = JsonConvert.DeserializeObject<List<Train>>(tmp);
                }
                return trains;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
