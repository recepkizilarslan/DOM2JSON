using HtmlAgilityPack;
using Mamut.Domain;
using System.Collections.Generic;

namespace Mamut.DomParser
{
    public static class AttributesParser
    {
        public static List<Attribute> Parse(HtmlAttributeCollection attributes)
        {
            List<Attribute> _attributes = new List<Attribute>();

            foreach (var att in attributes)
            {
                _attributes.Add(new Attribute
                {
                    Name = att.Name,
                    Value = att.Value
                });
            }

            return _attributes;

        }
    }
}
