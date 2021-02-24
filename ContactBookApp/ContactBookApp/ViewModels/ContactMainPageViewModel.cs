using ContactBookApp.Interfaces;
using ContactBookApp.Models;
using ContactBookApp.Services;
using ContactBookApp.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactBookApp.ViewModels
{
    public class ContactMainPageViewModel : BaseViewModel
    {
        private IPageService _pageService;
        private IContactService _contactService;
        private bool _isDataLoaded;

        public ICommand LoadCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }
        public ICommand AddContactCommand { get; private set; }
        public ICommand ContactSelectedCommand { get; private set; }

        public ObservableCollection<Contact> Contacts { get; private set; }
        public Contact SelectedContact { get; set; }

        public ContactMainPageViewModel(IPageService pageService, IContactService contactService)
        {
            _pageService = pageService ?? new PageService();
            _contactService = contactService ?? new ContactService();
            Contacts = new ObservableCollection<Contact>();

            LoadCommand = new Command(async () => await LoadData());
            AddContactCommand = new Command(async () => await AddContact());
            ContactSelectedCommand = new Command<Contact>(async (x) => await Contact_Selected(x));
            DeleteContactCommand = new Command<Contact>(async (x) => await Contact_Deleted(x));
        }
        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;
            _isDataLoaded = true;

            var contacts = await _contactService.GetContacts();
            //need to insert to collection otherwise the UI doesn't display the data
            foreach (var c in contacts)
                Contacts.Add(c);
            //Contacts = new ObservableCollection<Contact>(contacts);
        }

        private async Task AddContact()
        {
            var page = new ContactDetailPage(new Contact());

            await Subscribe_ContactDetail_Add(page);
        }

        private async Task Contact_Selected(Contact contactSelected)
        {
            if (contactSelected == null)
                return;

            SelectedContact = null;
            var page = new ContactDetailPage(contactSelected);

            await Subscribe_ContactDetail_Add(page);
        }

        private async Task Contact_Deleted(Contact deletedContact)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {deletedContact.FullName}?", "Yes", "No"))
            {
                Contacts.Remove(deletedContact);
                await _contactService.DeleteContact(deletedContact.Id);
            }
        }

        private async Task Subscribe_ContactDetail_Add(ContactDetailPage page)
        {
            page.ContactAdded += async (source, args) =>
            {
                bool isAdd = args.Id == 0;
                if (isAdd)
                {
                    Contacts.Add(args);
                    await _contactService.AddContact(args);
                }
                else
                {
                    var existingContact = Contacts.Where(x => x.Id == args.Id).FirstOrDefault();
                    Contacts[Contacts.IndexOf(existingContact)] = args;
                    await _contactService.UpdateContact(args);
                }
                await _pageService.DisplayAlert("Add Contact",
                                   string.Format("Contact has been {0}", (isAdd) ? "added" : "modified"),
                                   "OK");
                await _pageService.PopAsync();
            };

            await _pageService.PushAsync(page);
        }
    }
}
