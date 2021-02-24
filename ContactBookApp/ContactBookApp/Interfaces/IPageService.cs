using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactBookApp.Interfaces
{
    public interface IPageService
    {
        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
        Task PushAsync(Page page);
        Task PopAsync();
    }
}
