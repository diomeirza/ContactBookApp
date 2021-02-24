using ContactBookApp.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactBookApp.Services
{
    public class PageService : IPageService
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
           await MainPage().DisplayAlert(title, message, cancel);
        }
        public async Task<bool> DisplayAlert(string title, string message,string accept, string cancel)
        {
            return await MainPage().DisplayAlert(title, message, accept, cancel);
        }
        public async Task PushAsync(Page page)
        {
            await MainPage().Navigation.PushAsync(page);
        }
        public async Task PopAsync()
        {
            await MainPage().Navigation.PopAsync();
        }
        private Page MainPage()
        {
            return Application.Current.MainPage;
        }
    }
}
