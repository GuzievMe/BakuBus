using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#nullable disable                    // nullable vermeyende warninge gore cixan bildirimleri yox edir

namespace WpfMeSelf_7_July7_BingMap
{
    public class Attributes : INotifyPropertyChanged 
    {
        public string BUS_ID { get; set; }
        public string PLATE { get; set; }
        public string DRIVER_NAME { get; set; }
        public string PREV_STOP { get; set; }
        public string CURRENT_STOP { get; set; }
        public string SPEED { get; set; }
        public string BUS_MODEL { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string ROUTE_NAME { get; set; }
        public int LAST_UPDATE_TIME { get; set; }

        public string DISPLAY_ROUTE_CODE { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class BUS
    {
        [JsonPropertyName("@attributes")]
        public Attributes attributes { get; set; }
    }

    public class BakuBus
    {
        public List<BUS> BUS { get; set; }
    }
}
