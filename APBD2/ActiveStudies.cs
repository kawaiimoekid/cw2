using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace APBD2
{
    [Serializable]
    public class ActiveStudies
    {
        [JsonProperty("studies")]
        [XmlElement(ElementName = "studies")]
        public List<ActiveStudy> Studies { get; set; }
    }
}
