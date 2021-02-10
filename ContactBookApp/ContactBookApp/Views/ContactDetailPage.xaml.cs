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
        public event EventHandler<Contact> ContactAdded;

        public ContactDetailPage(Contact contact)
        {
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

            if(String.IsNullOrWhiteSpace(contact.FullName))
            {
                await DisplayAlert("Error Add Contact", "Name cannot be empty", "OK");
                return;
            }

            ContactAdded?.Invoke(this, contact);
            await DisplayAlert("Add Contact", "Contact has been saved", "OK");
            await Navigation.PopAsync();
        }
    }
}