using ContactBookApp.Services;
using ContactBookApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactMainPage : ContentPage
    {
        public ContactMainPageViewModel ViewModel 
        { 
            get
            {
                return BindingContext as ContactMainPageViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

        public ContactMainPage()
        {
            var pageService = new PageService();
            var contactService = new ContactService();
            ViewModel = new ContactMainPageViewModel(pageService,contactService);
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadCommand.Execute(null);
            base.OnAppearing();
        }

        private void Contact_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.ContactSelectedCommand.Execute(e.SelectedItem);
        }

        private void Contact_Refresh(object sender, System.EventArgs e)
        {
            ViewModel.LoadCommand.Execute(null);
            listContact.EndRefresh();
        }
    }
}