using System.Threading.Tasks;

namespace Mamut.Navigator
{
    public interface INavigatorManager
    {
        Task OpenNavigator();
        Task<string> Render(string url);
        Task CloseNavigator();
    }
}
