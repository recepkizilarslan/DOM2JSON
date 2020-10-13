using System.Collections.Generic;

namespace Mamut.Domain
{
    public class Page
    { 
        public string Url { get; set; }
        public List<Element> Elements { get; set; }
    }
}
