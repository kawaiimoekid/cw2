using System;
using System.Xml.Serialization;

namespace APBD2
{
    [Serializable]
    public class ActiveStudy
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "numberOfStudents")]
        public int StudentCount { get; set; }
    }
}
