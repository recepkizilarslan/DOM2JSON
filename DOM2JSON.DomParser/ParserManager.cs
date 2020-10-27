using HtmlAgilityPack;
using Mamut.Domain;
using System.Collections.Generic;

namespace Mamut.DomParser
{
    public class ParserManager:IParserManager
    {
        private readonly HtmlDocument _context = new HtmlDocument();

        /// <summary>
        /// This method provides to load to raw html in agalitypack
        /// </summary>
        /// <param name="context"></param>
        public void LoadHTML(string context) => _context.LoadHtml(context);

        /// <summary>
        /// This method provides to parse all elements in raw html
        /// </summary>
        /// <returns></returns>
        public List<Element> Parse()
        {
            List<Element> elements = new List<Element>();

            //read all context
            foreach (HtmlNode element in _context.DocumentNode.Descendants())
            {
                //parse attributes
                var attributes = AttributesParser.Parse(element.Attributes);

                //add to list
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
