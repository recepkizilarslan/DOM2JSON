using PuppeteerSharp;
using System.Threading.Tasks;

namespace Mamut.Navigator
{
    public class NavigatorManager:INavigatorManager
    {
        private Browser _browser;

        /// <summary>
        /// This method provides to open chromium instance
        /// </summary>
        /// <returns>true/false</returns>
        public async Task OpenNavigator()
        {
            //Download chromium
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            
            //open a headless browser
                _browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true
                });
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
        public async Task CloseNavigator() => await _browser.CloseAsync();
    }
}
