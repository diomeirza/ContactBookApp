using ContactBookApp.Interfaces;
using ContactBookApp.Models;
using ContactBookApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        private IContactService _contactService;

        //public event EventHandler<Contact> ContactAdded;

        public ContactDetailPage(Contact contact,IContactService contactServices = null)
        {
            _contactService = contactServices ?? new ContactServices();
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            InitializeComponent();
            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };
        }

        private async void OnSave(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;
            _contactService.AddContact(contact);
            await DisplayAlert("Add Contact", "Contact has been added", "OK");
            await Navigation.PopAsync();
        }
    }
}