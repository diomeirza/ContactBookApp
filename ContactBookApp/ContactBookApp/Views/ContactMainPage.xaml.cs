using ContactBookApp.Interfaces;
using ContactBookApp.Models;
using ContactBookApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _contacts = _contactService.GetContacts();

            InitializeComponent();
            listContact.ItemsSource = _contacts;
        }

        private async void AddContact_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ContactDetailPage(new Contact(), _contactService));
        }

        private async void Contact_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var contact = e.SelectedItem as Contact;
            listContact.SelectedItem = null;
            await Navigation.PushAsync(new ContactDetailPage(contact, _contactService));
        }

        private async void Contact_Deleted(object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
                _contacts.Remove(contact);
        }
    }
}