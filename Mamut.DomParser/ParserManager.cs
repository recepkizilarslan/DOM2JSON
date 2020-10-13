using HtmlAgilityPack;
using Mamut.Domain;
using System.Collections.Generic;

namespace Mamut.DomParser
{
    public class ParserManager:IParserManager
    {
        private HtmlDocument _context = new HtmlDocument();

        public void LoadHTML(string context)
        {
            _context.LoadHtml(context);
        }

        public List<Element> Parse()
        {
            List<Element> elements = new List<Element>();


            foreach (HtmlNode element in _context.DocumentNode.Descendants())
            {
                var attributes = AttributesParser.Parse(element.Attributes);

                elements.Add(new Element
                {
                    Type = element.Name,
                    Attributes = attributes,
                    InnerText = element.InnerText,
                });
            }

            return elements;
        }

    }
}
