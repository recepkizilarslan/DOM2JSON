using System.Collections.Generic;

namespace Mamut.Domain
{
    public class Element
    {
        public string Type { get; set; }
        public string InnerText { get; set; }
        public List<Attribute> Attributes { get; set; }

    }
}
