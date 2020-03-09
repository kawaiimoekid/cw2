using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace APBD2
{
    [Serializable]
    public class Studies
    {
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; }

        [JsonProperty("mode")]
        [XmlElement("mode")]
        public string Mode { get; set; }
    }
}
