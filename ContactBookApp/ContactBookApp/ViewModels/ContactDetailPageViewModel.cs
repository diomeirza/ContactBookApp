using ContactBookApp.Interfaces;
using ContactBookApp.Models;
using ContactBookApp.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactBookApp.ViewModels
{
    public class ContactDetailPageViewModel : BaseViewModel
    {
        private IPageService _pageService;

        public Contact Contact { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public event EventHandler<Contact> ContactAdded;

        public ContactDetailPageViewModel(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _pageService = new PageService();
            SaveCommand = new Command(async () => await OnSave());

            Contact = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };
        }

        private async Task OnSave()
        {
            if (String.IsNullOrWhiteSpace(Contact.FullName))
            {
                await _pageService.DisplayAlert("Error Add Contact", "Name cannot be empty", "OK");
                return;
            }

            ContactAdded?.Invoke(this, Contact);
        }
    }
}
