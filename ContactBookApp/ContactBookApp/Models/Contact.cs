﻿namespace ContactBookApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public string FullName { 
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
