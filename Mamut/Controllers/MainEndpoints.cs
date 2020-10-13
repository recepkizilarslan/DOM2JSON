using System;
using System.Collections.Generic;
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

            List<Page> page = new List<Page>();

            try
            {
                    await _navigatorManager.OpenNavigator();
                
                    string context = await _navigatorManager.Render(request.target);

                    _parserManager.LoadHTML(context);

                    page.Add(new Page
                    {
                        Url = request.target,
                        Elements = _parserManager.Parse()
                    }); ;

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
