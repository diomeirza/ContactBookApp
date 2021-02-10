using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactBookApp.Models
{
    public class Contact : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        private string _firstName;
        public string FirstName {
            get
            {
                return _firstName;
            }
            set 
            {
                if (_firstName == value)
                    return;
                _firstName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string LastName { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        [Ignore]
        public string FullName { 
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
