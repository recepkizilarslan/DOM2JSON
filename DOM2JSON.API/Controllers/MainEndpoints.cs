using System;
using System.Threading.Tasks;
using Mamut.Domain;
using Mamut.DomParser;
using Mamut.Navigator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mamut.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainEndPoints : ControllerBase
    {
        private readonly ILogger<MainEndPoints> _logger;
        private readonly IParserManager _parserManager;
        private readonly INavigatorManager _navigatorManager;

        public MainEndPoints(ILogger<MainEndPoints> logger,
                             IParserManager parserManager,
                             INavigatorManager navigatorManager
                             )
        {
            _parserManager = parserManager;
            _navigatorManager = navigatorManager;
            _logger = logger;
        }

        [HttpGet]
        [Route("convert")]
        public async Task<IActionResult> ConvertContent(Request request)
        {
            Page page = new Page();

            try
            {
                //open navigator
                await _navigatorManager.OpenNavigator();
                
                string rawHTML = await _navigatorManager.Render(request.target);
                
                //load raw html to agality pack context.
                _parserManager.LoadHTML(rawHTML);

                //add a new page
                page.Url = request.target;
                page.Elements = _parserManager.Parse();

                //close navigator
                await _navigatorManager.CloseNavigator();
            }
            catch(Exception e)
            {
                _logger.LogWarning(e.StackTrace);
                return Ok ("Someting went wrong");
            }
            
            return Ok(page);
        }
    }
}
