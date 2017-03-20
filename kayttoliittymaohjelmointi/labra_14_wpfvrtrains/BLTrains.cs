using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace labra_14_wpfvrtrains
{

    public class Train
    {
        public string TrainNumber { get; set; }
        [JsonProperty("cancelled")]
        public bool IsCancelled { get; set; }
        [JsonProperty("departureDate")]
        public DateTime DepDate { get; set; }
        public string TargetStation { get; set; }

    }

    public class Station
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Station (string koodi, string ap)
        {
            this.Code = koodi; // asemanapaikan tunniste JY == jyväskylä
            this.Name = ap; // asemapaikan nimi
        }

    }
}
