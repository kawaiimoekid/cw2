using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace APBD2
{
    [Serializable]
    public class Student
    {
        [JsonProperty("fname")]
        [XmlElement(ElementName = "fname")]
        public string FirstName { get; set; }

        [JsonProperty("lname")]
        [XmlElement(ElementName = "lname")]
        public string LastName { get; set; }

        [JsonProperty("birthdate")]
        [XmlElement(ElementName = "birthdate")]
        public string BirthDate { get; set; }

        [JsonProperty("email")]
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        [JsonProperty("mothersName")]
        [XmlElement(ElementName = "mothersName")]
        public string MothersName { get; set; }

        [JsonProperty("fathersName")]
        [XmlElement(ElementName = "fathersName")]
        public string FathersName { get; set; }

        [JsonProperty("indexNumber")]
        [XmlAttribute(AttributeName = "indexNumber")]
        public string IndexNumber { get; set; }

        [JsonProperty("studies")]
        [XmlElement(ElementName = "studies")]
        public Studies Studies { get; set; }


        public static Student FromCsv(string[] parts)
        {
            return new Student
            {
                FirstName = parts[0],
                LastName = parts[1],
                IndexNumber = $"s{parts[4]}",
                BirthDate = DateTime.Parse(parts[5]).ToString("dd.MM.yyyy"),
                Email = parts[6],
                MothersName = parts[7],
                FathersName = parts[8],
                Studies = new Studies
                {
                    Name = parts[2],
                    Mode = parts[3]
                }
            };
        }
    }
}
