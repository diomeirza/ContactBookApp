using ContactBookApp.Interfaces;
using ContactBookApp.Models;
using ContactBookApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactMainPage : ContentPage
    {
        private IContactService _contactService;
        private ObservableCollection<Contact> _contacts;
        public ContactMainPage()
        {
            _contactService = new ContactServices();

            InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {
            await LoadData();
            base.OnAppearing();
        }

        private async Task LoadData()
        {
            var contacts = await _contactService.GetContacts();
            _contacts = new ObservableCollection<Contact>(contacts);
            listContact.ItemsSource = _contacts;
        }

        private void AddContact_Clicked(object sender, System.EventArgs e)
        {
            var page = new ContactDetailPage(new Contact());

            Subscribe_ContactDetail_Add(page);
        }

        private void Contact_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var contact = e.SelectedItem as Contact;
            listContact.SelectedItem = null;
            
            var page = new ContactDetailPage(contact);

            Subscribe_ContactDetail_Add(page);
        }

        private async void Contact_Deleted(object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
            {
                _contacts.Remove(contact);
                await _contactService.DeleteContact(contact.Id);
            }
        }

        private async void Subscribe_ContactDetail_Add(ContactDetailPage page)
        {
            page.ContactAdded += async (source, args) =>
            {
                var existingContact = _contacts.Where<Contact>(x => x.Id == args.Id).FirstOrDefault();
                bool isAdd = existingContact == null;
                if (isAdd)
                {
                    _contacts.Add(args);
                    await _contactService.AddContact(args);
                }
                else 
                {
                    _contacts[_contacts.IndexOf(existingContact)] = args;
                    await _contactService.UpdateContact(args);
                }
                await DisplayAlert("Add Contact",
                                   string.Format("Contact has been {0}", isAdd ? "added": "modified"), 
                                   "OK");
                await Navigation.PopAsync();
            };

            await Navigation.PushAsync(page);
        }

        private async void Contact_Refresh(object sender, System.EventArgs e)
        {
            await LoadData();
            listContact.EndRefresh();
        }
    }
}