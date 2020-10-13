using Mamut.Domain;
using System.Collections.Generic;

namespace Mamut.DomParser
{
    public interface IParserManager
    {
        void LoadHTML(string context);
        public List<Element> Parse();
    }
}
