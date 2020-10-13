using System.Threading.Tasks;

namespace Mamut.Navigator
{
    public interface INavigatorManager
    {
        Task<bool> OpenNavigator();
        Task<string> Render(string url);
        Task<bool> CloseNavigator();
    }
}
