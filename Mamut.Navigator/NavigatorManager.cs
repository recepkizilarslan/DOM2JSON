using Microsoft.Extensions.Logging;
using PuppeteerSharp;
using System.Threading.Tasks;

namespace Mamut.Navigator
{ 
    public class NavigatorManager:INavigatorManager
    {
        private Browser _browser;
        
        private ILogger<NavigatorManager> _logger;


        /// <summary>
        /// This method provides to open chromium instance
        /// </summary>
        /// <returns>true/false</returns>
        public async Task<bool> OpenNavigator()
        {
            //Download chromium
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            try
            {
                //open a headless browser
                _browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true
                });
                
                return true;
            }
           catch(PuppeteerException e)
            {
                return false;
            }
        }


        /// <summary>
        /// This method provides to render target context
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Raw html</returns>
        public async Task<string> Render(string url)
        {
            string context;

            using (var page = await _browser.NewPageAsync())
            {
                await page.GoToAsync(url);
                context = await page.GetContentAsync();
            }
            return context;
        }


        /// <summary>
        /// This method provides to close chromium instance
        /// </summary>
        /// <returns>true or false</returns>
        public async Task<bool> CloseNavigator()
        {
            try
            {
                await _browser.CloseAsync();

                if (_browser.IsClosed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (PuppeteerException e)
            {
                return false;
            }
        }
    }
}
