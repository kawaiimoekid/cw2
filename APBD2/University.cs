using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace APBD2
{
    [Serializable]
    public class University
    {
        [JsonProperty("createdAt")]
        [XmlAttribute(AttributeName = "createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("author")]
        [XmlAttribute(AttributeName = "author")]
        public string Author { get; set; }

        [JsonProperty("studenci")]
        [XmlElement(ElementName = "studenci")]
        public List<Student> Students { get; set; }

        [JsonProperty("activeStudies")]
        [XmlElement("activeStudies")]
        public ActiveStudies ActiveStudies { get; set; }

        public University()
        {

        }

        public University(List<Student> students)
        {
            CreatedAt = DateTime.Now.ToString("dd.MM.yyyy");
            Author = "Jan Kowalski";

            Students = students;
            ActiveStudies = new ActiveStudies
            {
                Studies = students
                    .GroupBy(x => x.Studies.Name)
                    .Select(x => new ActiveStudy
                    {
                        Name = x.Key,
                        StudentCount = x.Count()
                    })
                    .ToList()
            };
        }
    }
}
